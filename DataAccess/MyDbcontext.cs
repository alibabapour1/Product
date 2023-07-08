using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MyDbcontext : DbContext

    {
        public MyDbcontext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
