using FluentApi.DataAccess.EFrameworkServer;
using FluentApi.Domain.Abstractions;
using FluentApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace FluentApi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public App()
        {
            using (var context = new MyContext())
            {
                try
                {
                    context.Database.CreateIfNotExists();
                }
                catch (Exception)
                {
                }

            }
            DB = new EFUnitOfWork();
            if (DB.CustomerRepository.GetAllData().Count == 0)
            {
                var c1 = new Customer
                {
                   City="Baku",
                    CompanyName="STEP IT MMC",
                     ContactName="123456789",
                      Country="Azerbaijan"
                };

                var c2 = new Customer
                {
                    City = "Ankara",
                    CompanyName = "Ankara MMC",
                    ContactName = "98765432",
                    Country = "Turkish"
                };
                DB.CustomerRepository.AddData(c1);
                DB.CustomerRepository.AddData(c2);
            }
            if (DB.OrderRepository.GetAllData().Count == 0)
            {
                var o1 = new Order
                {
                    CustomerId = 15,
                    OrderDate = DateTime.Now.AddDays(-3),
                    Imagepath= "https://fdn2.gsmarena.com/vv/bigpic/apple-iphone-13.jpg"
                };
                var o2 = new Order
                {
                    CustomerId = 15,
                    OrderDate = DateTime.Now.AddDays(-5),
                    Imagepath= "https://www.notebookcheck.net/uploads/tx_nbc2/SamsungGalaxyA32.jpg"
                };
                var o3 = new Order
                {
                    CustomerId = 14,
                    OrderDate = DateTime.Now.AddDays(-7),
                   
                };
                var o4 = new Order
                {
                    CustomerId = 14,
                    OrderDate = DateTime.Now.AddDays(-10)
                };
                DB.OrderRepository.AddData(o1);
                DB.OrderRepository.AddData(o2);
                DB.OrderRepository.AddData(o3);
                DB.OrderRepository.AddData(o4);
            }
        }
    }
}
