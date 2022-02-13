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

            //this needs to be business layer 
            XElement customer = XElement.Load(@"C:\Users\perse\Documents\sample.xml");
            IEnumerable<XElement> childElements =
                from elements in customer.Elements()
                select elements;


            foreach(XElement element in childElements.Elements())
            {
                var result = element.LastNode;
            }
    

        }
    }
}
