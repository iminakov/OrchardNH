OrchardNH
=========

This is example project how to use NHibernate features in Orchard.CMS module directly. Solution includes the following projects:

1. NHStore.Domain - simple library with domain model and fluent NHibernate mapping
2. NHStore.DB.DataBuilder - console application for creation DB Scheme based on NHStore.Domain library and adding new test data records.
3. NHStoreUI - Orchard CMS module project, which using NHStore.Domain

How to execute this example:

1. Download Orchard CMS 1.8 install package from Offical web site: https://orchard.codeplex.com/downloads/get/865709
2. Deploy Orchard CMS instance on local environment with DataBase instance name "OrchardNH" (You can use another db name, but you should modify NHStore.DB.DataBuilder project code in this case)
3. Copy "NHStore" solution to "..\Modules" folder of Orchard web site instance.
4. Execute NHStore.DB.DataBuilder project to create DB scheme and test data
5. Enable NHStore module in Orchard Admin panel.
6. Execute http://localhost/NHStore url to verify project.
