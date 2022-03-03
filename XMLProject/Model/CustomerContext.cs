using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLProject;
using XMLProject.Model;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace XMLProject.Model
{
    public class CustomerContext : DbContext 
    {

        private Microsoft.EntityFrameworkCore.DbSet<Customer> _customers { get; set; }
        private Microsoft.EntityFrameworkCore.DbSet<Order> _orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=projectEntities1;Trusted_Connection=True;");
        }


        public class Customer
        {
            public int CustomerID { get; set; }

            public string companyName { get; set; }

            public string contactName { get; set; }

            public string contactTitle { get; set;  }

            public string contactPhone { get; set; }

            public string companyAddress { get; set; }

            public string companyCity { get; set; }

            public string regionCity { get; set;  }

            public int postalCode { get; set; }

            public string companyCountry { get; set; }

            public List<Customer> customers { get; set; }
        }

        public class Order
        {
            public int customerID;

            public int employeeID;

            public string orderDate;

            public string requiredDate;

            public string shippedDate;

            public string shipVia;

            public string freight;

            public string shipName;

            public string shipAddress;

            public string shipCity;

            public string shipRegion;

            public int shipPostalCode;

            public string shipCountry;

            public List<Order> orders { get; set; }
        }

    }
}
