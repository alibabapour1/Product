using Domain;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class MyDbcontext : DbContext

    {
        public MyDbcontext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        //public DbSet<Users> Users { get; set; }

    }
}
