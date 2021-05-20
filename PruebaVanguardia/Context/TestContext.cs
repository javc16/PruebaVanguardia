using Microsoft.EntityFrameworkCore;
using PruebaVanguardia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaVanguardia.Context
{
    public class TestContext:DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
       




        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            //optionBuilder.UseSqlServer(@"Server=38.17.54.162,51688;Database=MechanicalWorkShopSystem30042021;User Id=devops;Password=Yf4-Sf");
            optionBuilder.UseSqlServer(@"Server=database-1.cwyafa0gf6ea.us-east-1.rds.amazonaws.com,1433;Database=prueba;User Id=admin;Password=hola1234");

        }
    }
}
