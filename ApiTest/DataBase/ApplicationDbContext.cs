using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public  DbSet<CustomerModel> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=IT-BABUL; Database=myDb; Trusted_Connection=true;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
