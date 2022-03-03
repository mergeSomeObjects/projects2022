using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLProject.BusinessLayer
{
    public class Customer
    {
        public string customerID; 

        public string companyName;

        public string contactName;
        
        public string contactTitle;
        
        public string contactPhone;

        public string companyAddress;
        
        public string companyCity;
        
        public string regionCity;
        
        public string postalCode;
        
        public string companyCountry;


        public static List<Customer> customers;

        public Order Order; 

    }
}
