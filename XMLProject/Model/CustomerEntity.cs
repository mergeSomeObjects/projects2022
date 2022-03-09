using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLProject.BusinessLayer;

namespace XMLProject.Model
{
    public static class CustomerEntity
    {
        public static void AddCustomers(List<CustomerModel.Customer> customers)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CustomerModel"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (var cus = new CustomerModel())
                {
                    foreach (var item in customers)
                    {
                        var customer = new customer()
                        {
                            CustomerID = item.CustomerID,
                            CompanyName = item.CompanyName,
                            ContactName = item.ContactName,
                            ContactTitle = item.ContactTitle,
                            Phone = item.Phone,
                            StreetAddress = item.StreetAddress,
                            City = item.City,
                            Region = item.Region
                        };
                        if (!String.IsNullOrEmpty(customer.CustomerID))
                        {
                            cus.customers.Add(customer);
                        }
                    }

                    cus.SaveChanges();
                }          
            }
        }
    }
}


