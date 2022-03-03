using System;
using System.Collections.Generic;
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
                Model.CustomerContext.Customer c = new CustomerContext.Customer();
                c.customers = new List<CustomerContext.Customer>();

                Model.CustomerContext.Order o = new CustomerContext.Order();
                o.orders = new List<CustomerContext.Order>();


                foreach (var item in customers)
                {
                    var customer = new CustomerContext.Customer
                    {
                        CustomerID = Convert.ToInt32(item.customerID),
                        companyName = item.companyName,
                        companyAddress = item.companyAddress,
                        companyCity = item.companyCity,
                        companyCountry = item.companyCountry,
                        contactName = item.contactName,
                        contactPhone = item.contactPhone,
                        contactTitle = item.contactTitle,
                        postalCode = Convert.ToInt32(item.postalCode),
                        regionCity = item.regionCity
                      

                    };

                    c.customers.Add(customer);

                    //
                    var order = new CustomerContext.Order
                    {


                    };

                    o.orders.Add(order);
                };


                // o.orders.Add()




            }
        }
    }
}

