using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace XMLProject
{
    public partial class CustomerModel : DbContext
    {
        public CustomerModel()
            : base("name=CustomerModel")
        {
        }

        public virtual DbSet<customer> customers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer>()
                .Property(e => e.CustomerID)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.ContactTitle)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.StreetAddress)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.Country)
                .IsUnicode(false);
        }

        public class Customer
        {
            public string CustomerID { get; set; }

            public string CompanyName { get; set; }

            public string ContactName { get; set; }

            public string ContactTitle { get; set; }

            public string Phone { get; set; }

            public string StreetAddress { get; set; }

            public string City { get; set; }

            public string Region { get; set; }

            public int PostalCode { get; set; }

            public string Country { get; set; }
        }
    }
}
