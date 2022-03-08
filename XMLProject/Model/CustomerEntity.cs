using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLProject.BusinessLayer;

namespace XMLProject.Model
{
    public static class CustomerEntity
    {

        public static void AddCustomers(List<Customer> customers)
        {
            using (var context = new CustomerContext())
            {           
                context.Database.BeginTransaction();

                Model.CustomerContext.Customer c = new CustomerContext.Customer();
                c.customers = new List<CustomerContext.Customer>();

                Model.CustomerContext.Order o = new CustomerContext.Order();
                o.orders = new List<CustomerContext.Order>();
       
                foreach (var item in customers)
                {
                    var customer = new CustomerContext.Customer
                    {
                        CustomerID = item.customerID,
                        CompanyName = item.companyName,
                        ContactName = item.contactName,
                        ContactTitle = item.contactTitle,
                        Phone = item.contactPhone,                       
                        StreetAddress = item.companyAddress,
                        City = item.companyCity,
                        Region = item.regionCity                     
                    };

                    // c.customers.Add(customer);
                    if(!String.IsNullOrEmpty(customer.CustomerID))
                    {
                        context.Add(customer);
                    }
                    
                   // var order = new CustomerContext.Order
                   // {
                   //     employeeID = Convert.ToInt32(item.Order.employeeID),
                   //     customerID = item.Order.customerID
                   //};

                    //   o.orders.Add(order);
                  //  context.Add(order);
                };

                context.SaveChanges();               
            }
        }
    }
}

