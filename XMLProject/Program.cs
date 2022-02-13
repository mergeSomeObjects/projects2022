using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XMLProject.Model;

namespace XMLProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement customer = XElement.Load(@"C:\Users\perse\Documents\sample.xml");
            IEnumerable<XElement> childElements =
                from elements in customer.Elements()
                select elements;


            foreach(XElement element in childElements.Elements())
            {
                var nodes = element.Nodes();//Get all nodes under 'File'
                var company = nodes.Where(el => ((XElement)el).Name.LocalName == "CompanyName")
                .FirstOrDefault();
                string companyName = ((XElement)company).Value;
                var contact = nodes.Where(el => ((XElement)el).Name.LocalName == "ContactName")
               .FirstOrDefault();
                string contactName = ((XElement)contact).Value;
                var title = nodes.Where(el => ((XElement)el).Name.LocalName == "ContactTitle")
                .FirstOrDefault();
                string contactTitle = ((XElement)title).Value;

                var phone = nodes.Where(el => ((XElement)el).Name.LocalName == "Phone")
                .FirstOrDefault();
                string contactPhone = ((XElement)phone).Value;

                var fullAddress = nodes.Where(el => ((XElement)el).Name.LocalName == "FullAddress")
                .FirstOrDefault();
                var address = ((XElement)fullAddress).Nodes();




            }


        }
    }
}
