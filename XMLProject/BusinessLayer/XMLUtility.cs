using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLProject.Model;

namespace XMLProject.BusinessLayer
{
    public class XMLUtility
    {


        public static void GetXML()
        {
            XElement node = XElement.Load(@"C:\Users\perse\Documents\sample.xml");
            IEnumerable<XElement> childElements =
                from elements in node.Elements()
                select elements;
           
            List<CustomerModel.Customer> customers = new List<CustomerModel.Customer>(); 

            foreach (XElement element in childElements.Elements())
            {
                CustomerModel.Customer customer = new CustomerModel.Customer(); //create customer object 
                

                var nodes = element.Nodes();

                //if all customer related data grab else

                if(element.Name =="Customer")
                { 
                    customer.CustomerID= element.Attribute("CustomerID").Value;
                    var companyName = nodes.Where(el => ((XElement)el).Name.LocalName == "CompanyName").FirstOrDefault();
                    var contactName = nodes.Where(el => ((XElement)el).Name.LocalName == "ContactName").FirstOrDefault();
                    var contactTitle = nodes.Where(el => ((XElement)el).Name.LocalName == "ContactTitle").FirstOrDefault();                            
                    var contactPhone = nodes.Where(el => ((XElement)el).Name.LocalName == "Phone").FirstOrDefault();           
                    var fullAddress = nodes.Where(el => ((XElement)el).Name.LocalName == "FullAddress").FirstOrDefault();   // 2nd nested element              
                    var address = ((XElement)fullAddress).Nodes();
                    var companyAddress = address.Where(el => ((XElement)el).Name.LocalName == "Address").FirstOrDefault();          
                    var companyCity = address.Where(el => ((XElement)el).Name.LocalName == "City").FirstOrDefault();         
                    var companyRegion = address.Where(el => ((XElement)el).Name.LocalName == "Region").FirstOrDefault();
                    var postalCode = address.Where(el => ((XElement)el).Name.LocalName == "PostalCode").FirstOrDefault();
                    var companyCountry = address.Where(el => ((XElement)el).Name.LocalName == "Country").FirstOrDefault();

                    customer.CompanyName = ((XElement)companyName).Value;
                    customer.ContactName = ((XElement)contactName).Value;
                    customer.ContactTitle = ((XElement)contactTitle).Value;
                    customer.Phone = ((XElement)contactPhone).Value;
                    customer.StreetAddress = ((XElement)companyAddress).Value;
                    customer.City = ((XElement)companyCity).Value;
                    customer.Region = ((XElement)companyRegion).Value;   
                    customer.Country = ((XElement)companyCountry).Value;


                }

                //add customer to list 
                customers.Add(customer);
            }

            //add list to be added to database 
            CustomerEntity.AddCustomers(customers);

        }
    }
}
