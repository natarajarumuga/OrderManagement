using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            // CREATE operation
                Customer MyCustomer = new Customer();
            //MyCustomer.Id = 1;
            MyCustomer.first_name = "John";
            MyCustomer.last_name = "Doe";
            MyCustomer.Address1 = "123 Main street";
            MyCustomer.City = "Tampa";
            MyCustomer.state = "FL";
            MyCustomer.ZIP = "33444";

            Order MyOrder1 = new Order();
           // MyOrder1.Id = 1;
            MyOrder1.orderdate = "06-01-2021";
            MyOrder1.orderstatus = "NEW";
            MyOrder1.productid = 1;
            //MyOrder1.Customers.Id = 1;
            MyOrder1.Customers = MyCustomer;

            Order MyOrder2 = new Order();
           // MyOrder2.Id = 2;
            MyOrder2.orderdate = "07-01-2021";
            MyOrder2.orderstatus = "NEW";
            MyOrder2.productid = 1;
            //MyOrder2.Customers.Id = 1;
            MyOrder2.Customers = MyCustomer;


            Product MyProducts = new Product();
            //MyProducts.productid = 1;
            MyProducts.product_description = "product1";

            dbContext.Customers.Add(MyCustomer);
            dbContext.Orders.Add(MyOrder1);
            dbContext.Orders.Add(MyOrder2);
            dbContext.Products.Add(MyProducts);

            dbContext.SaveChanges();

            // READ operation
            Customer CustomerRead1 = dbContext.Customers
                                    .Where(c => c.first_name == "John")
                                    .First();

            /* float CompanyQuoteSum = dbContext.Companies
                                     .Where(c => c.name == "MCOB")
                                     .First()
                                     .Quotes
                                     .Select(q => q.high);

             */


            // UPDATE operation
            // CustomerRead1.iexId = "John";
            // dbContext.Companies.Update(CompanyRead1);
            //dbContext.SaveChanges();
            await dbContext.SaveChangesAsync();

            // DELETE operation
            //dbContext.Companies.Remove(CompanyRead1);
            //await dbContext.SaveChangesAsync();

            return View();
        }

        /*public ViewResult LINQOperations()
        {
            Company CompanyRead1 = dbContext.Companies
                                            .Where(c => c.Id == "MCOB")
                                            .First();

            Company CompanyRead2 = dbContext.Companies
                                            .Include(c => c.Quotes)
                                            .Where(c => c.Id == "MCOB")
                                            .First();

            Quote Quote1 = dbContext.Companies
                                    .Include(c => c.Quotes)
                                    .Where(c => c.Id == "MCOB")
                                    .FirstOrDefault()
                                    .Quotes
                                    .FirstOrDefault();

            return View();
        } */

    }
}