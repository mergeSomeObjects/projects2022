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

        private Microsoft.EntityFrameworkCore.DbSet<customer> _customers { get; set; }
        private Microsoft.EntityFrameworkCore.DbSet<order> _orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }




    }


}
