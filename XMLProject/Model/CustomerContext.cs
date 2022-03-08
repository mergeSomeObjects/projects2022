using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        private Microsoft.EntityFrameworkCore.DbSet<Customer> customer { get; set; }
        private Microsoft.EntityFrameworkCore.DbSet<Order> order { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            var connectionString = ConfigurationManager.ConnectionStrings["projectEntities1"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Order>(
                    eb =>
                    {
                        eb.HasNoKey();               
                    });
        }



        public class Customer
        {
            public string CustomerID { get; set; }

            public string CompanyName { get; set; }

            public string ContactName { get; set; }

            public string ContactTitle { get; set;  }

            public string Phone { get; set; }

            public string StreetAddress { get; set; }

            public string City { get; set; }

            public string Region { get; set;  }

            public int PostalCode { get; set; }

            public string Country { get; set; }

            public List<Customer> customers { get; set; }
        }

        public class Order
        {
            public string customerID;

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
