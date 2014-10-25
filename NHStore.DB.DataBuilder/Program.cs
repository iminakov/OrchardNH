using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHStoreDomain.Domain;
using NHStoreDomain.Enums;
using NHStoreDomain.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Order = NHStoreDomain.Domain.Order;

namespace NHStore.DB.DataBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=OrchardNH;User ID=sa;Password=sa;";

            var configuration = Fluently.Configure()
            .Database(MsSqlConfiguration
            .MsSql2008
            .ConnectionString(connString))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
            .BuildConfiguration();

            new SchemaExport(configuration).Execute(true, true, false);

            var factory = configuration.BuildSessionFactory();

            using (var session = factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                CreateProductsList(session);
                tx.Commit();
            }

            using (var session = factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                CreateCustomersList(session);
                tx.Commit();
            }

            using (var session = factory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                CreateOrder(session.QueryOver<Customer>().Where(x => x.LastName == "Murray").List<Customer>().FirstOrDefault(),
                    session.QueryOver<Product>().Where(x => x.Name == "Hyperlite Wakeboard").List<Product>(), session);

                CreateOrder(session.QueryOver<Customer>().Where(x => x.LastName == "Watson").List<Customer>().FirstOrDefault(),
                    session.QueryOver<Product>().WhereRestrictionOn(x => x.Name).IsLike("%Wakeboard%").List<Product>(), session);

                CreateOrder(session.QueryOver<Customer>().Where(x => x.FirstName == "Rusty").List<Customer>().FirstOrDefault(),
                    session.QueryOver<Product>().WhereRestrictionOn(x => x.Name).IsLike("%Slingshot%").List<Product>(), session);

                CreateOrder(session.QueryOver<Customer>().Where(x => x.FirstName == "Adam").List<Customer>().FirstOrDefault(),
                    session.QueryOver<Product>().Where(x => x.Name == "Timekiller").List<Product>(), session);


                tx.Commit();
            }
        }

        private static int OrderNumber = 1;
        private static Random RateRandom = new Random(100000);

        private static void CreateOrder(Customer customer, IList<Product> products, ISession session)
        {
            var order =
                new Order
                    {
                        CreationDate = DateTime.Now,
                        Status = OrderStatus.Created,
                        OrderNumber = (OrderNumber++).ToString().PadLeft(4,'0'),
                        Customer = customer,
                        OrderDetails = new List<OrderDetail>()
                    };

            for (int i = 0; i < products.Count; i++)
            {
                var orderDetail = new OrderDetail
                {
                    OrderLine = i+1,
                    Quantity = 1,
                    Rate = RateRandom.Next(20, 2200),
                    Product = products[i],
                    Order = order
                };

                order.OrderDetails.Add(orderDetail);
            }

            

            session.Save(order);
        }

        private static List<Product> CreateProductsList(ISession session)
        {
            var products = new List<Product>()
                {

                    new Product()
                        {
                            Name = "Slingshot Wakeboard",
                            Description = "140"
                        },
                    new Product()
                        {
                            Name = "Hyperlite Wakeboard",
                            Description = "141"
                        },
                    new Product()
                        {
                            Name = "Timekiller",
                            Description = "Movie"
                        },
                    new Product()
                        {
                            Name = "Slingshot Wakeboard Pro",
                            Description = "141"
                        },
                };

            foreach (var product in products)
            {
                session.Save(product);
            }

            return products;
        }

        private static void CreateCustomersList(ISession session)
        {
            var customers = new List<Customer>()
                {

                    new Customer()
                        {
                            FirstName = "Adam",
                            LastName = "Sendler",
                            BirthDay = new DateTime(1962,1,5),
                            Address = "DC, Street" + DateTime.Now.Second
                        },
                    new Customer()
                        {
                            FirstName = "Shaun",
                            LastName = "Murray",
                            BirthDay = new DateTime(1978,10,10),
                            Address = "NY, Street" + DateTime.Now.Second
                        },
                    new Customer()
                        {
                            FirstName = "Shaun",
                            LastName = "Watson",
                            BirthDay = new DateTime(1980,4,11),
                            Address = "VA, Street" + DateTime.Now.Second
                        },
                    new Customer()
                        {
                            FirstName = "Rusty",
                            LastName = "Malinovski",
                            BirthDay = new DateTime(1960,1,1),
                            Address = "MD, Street" + DateTime.Now.Second
                        },
                };


            foreach (var customer in customers)
            {
                session.Save(customer);
            }
        }
    }
}
