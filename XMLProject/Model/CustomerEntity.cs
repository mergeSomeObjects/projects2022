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
            using (var context = new projectEntities1())
            {

               
               
                context.SaveChanges();
            }



        }

    }
}
