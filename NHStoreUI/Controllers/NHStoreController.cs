using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHStoreUI.Services;
using NHStoreUI.ViewModel;
using Orchard.Themes;

namespace NHStoreUI.Controllers
{
    [Themed]
    public class NHStoreController : Controller
    {
        private readonly INHStoreService _nhStoreService = null;

        public NHStoreController(INHStoreService nhStoreService)
        {
            _nhStoreService = nhStoreService;
        }

        public ActionResult Index()
        {
            var orders = _nhStoreService.GetOrders();

            return View(new NHStoreViewModel()
                {
                    Orders = orders.Select(x => new OrderViewModel()
                        {
                            OrderCreationDate = x.CreationDate,
                            OrderStatus = x.Status.ToString(),
                            OrderNumber = x.OrderNumber,
                            ShipToCustomerAddress = x.Customer.Address,
                            ShipToCustomerBirthDay = x.Customer.BirthDay,
                            ShipToCustomerFirstName = x.Customer.FirstName,
                            ShipToCustomerLastName = x.Customer.LastName,
                                OrderDetails = x.OrderDetails.Select(od => new OrderDetailViewModel()
                                    {
                                        OrderLine = od.OrderLine,
                                        Quantity = od.Quantity,
                                        Rate = od.Rate,
                                        ProductName = od.Product.Name,
                                        ProductDescription = od.Product.Description
                                    })
                        }).ToList()
                });
        }
    }
}