using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLProject;
using XMLProject.Model;

namespace XMLProject.Model
{
    class CustomerContext : ObjectContext
    {

        private ObjectSet<customer> _customers;
        private ObjectSet<order> _orders;

        public CustomerContext() : base("name=projectEntities1", "projectEntities1")
        {
            _customers = CreateObjectSet<customer>();
            _orders = CreateObjectSet<order>();
        }

        public ObjectSet<customer> Customers
        {
            get { return _customers; }
        }

        public ObjectSet<order> Orders
        {
            get { return _orders; }
        }



    }


}
