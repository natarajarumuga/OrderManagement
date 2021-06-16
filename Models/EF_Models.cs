using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models
{
    public class Customer
    {
        //[Key]
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string ZIP { get; set; }
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        //[Key]
        public int Id { get; set; }
        public string orderstatus { get; set; }
        public int productid { get; set; }
        public string orderdate { get; set; }
        public Customer Customers { get; set; }
    }

    public class Product
    {
        [Key]
        public int productid { get; set; }
        public string product_description { get; set; }
    }
    // public class ChartRoot
    //  {
    //  public Quote[] chart { get; set; }
    // }
}