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
        Customer Customer { get; set; }
        List<Customer> customers { get; set; }

        public static void GetXML()
        {
            XElement node = XElement.Load(@"C:\Users\perse\Documents\sample.xml");
            IEnumerable<XElement> childElements =
                from elements in node.Elements()
                select elements;
           
            List<Customer> customers = new List<Customer>(); 

            foreach (XElement element in childElements.Elements())
            {
                Customer customer = new Customer(); //create customer object 
                customer.Order = new Order();

                var nodes = element.Nodes();

                //if all customer related data grab else

                if(element.Name =="Customer")
                { 
                    customer.customerID= element.Attribute("CustomerID").Value;
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

                    customer.companyName = ((XElement)companyName).Value;
                    customer.contactName = ((XElement)contactName).Value;
                    customer.contactTitle = ((XElement)contactTitle).Value;
                    customer.contactPhone = ((XElement)contactPhone).Value;
                    customer.companyAddress = ((XElement)companyAddress).Value;
                    customer.companyCity = ((XElement)companyCity).Value;
                    customer.regionCity = ((XElement)companyRegion).Value;
                    customer.postalCode =((XElement)postalCode).Value;
                    customer.companyCountry = ((XElement)companyCountry).Value;


                }
                if(element.Name == "Order")
                {
                    var customerID = element.Elements().Where(x => x.Name.LocalName == "CustomerID").FirstOrDefault();
                    customer.Order.customerID = customerID.Value;

                    var employeeID = nodes.Where(el => ((XElement)el).Name.LocalName == "EmployeeID").FirstOrDefault();
                    var orderDate = nodes.Where(el => ((XElement)el).Name.LocalName == "OrderDate").FirstOrDefault();
                    var requiredDate = nodes.Where(el => ((XElement)el).Name.LocalName == "RequiredDate").FirstOrDefault();                   
                    var shippingInfo = nodes.Where(el => ((XElement)el).Name.LocalName == "ShipInfo").FirstOrDefault();

                    var shippingDate = element.Elements().Where(x => x.Name.LocalName == "ShipInfo").Select(x=>x.Attribute("ShippedDate")).FirstOrDefault();              
                    
                    
                    var shippingAddress = ((XElement)shippingInfo).Nodes();
                    var shipVia = shippingAddress.Where(el => ((XElement)el).Name.LocalName == "ShipVia").FirstOrDefault();
                    var freight = shippingAddress.Where(el => ((XElement)el).Name.LocalName == "Freight").FirstOrDefault();

                    customer.Order.employeeID = ((XElement)employeeID).Value;
                    customer.Order.orderDate = ((XElement)orderDate).Value;
                    customer.Order.requiredDate = ((XElement)requiredDate).Value;
                    customer.Order.shipVia = ((XElement)shipVia).Value;
                    customer.Order.freight = ((XElement)freight).Value;
                    customer.Order.shipName = customer.companyName;

                    if(!String.IsNullOrEmpty(Convert.ToString(shippingDate)))
                    {
                        customer.Order.shippedDate = shippingDate.Value;
                    }

                    customer.Order.shipAddress = customers.Where(x=>x.customerID==customer.Order.customerID).Select(x=>x.companyAddress).FirstOrDefault();
                    customer.Order.shipCity = customers.Where(x => x.customerID == customer.Order.customerID).Select(x => x.companyCity).FirstOrDefault(); 
                    customer.Order.shipRegion = customers.Where(x => x.customerID == customer.Order.customerID).Select(x => x.regionCity).FirstOrDefault(); 
                    customer.Order.shipPostalCode = customers.Where(x => x.customerID == customer.Order.customerID).Select(x => x.postalCode).FirstOrDefault();
                    customer.Order.shipCountry = customers.Where(x => x.customerID == customer.Order.customerID).Select(x => x.companyCountry).FirstOrDefault();

                }

                //add customer to list 
                customers.Add(customer);
            }

            //add list to be added to database 
            CustomerEntity.AddCustomers(customers);

        }
    }
}
