using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vidly.Models
{
    public class VidlyDb : DbContext
    {
   public DbSet<Customers> Customers { get; set; }
   public DbSet<Movie> Movies { get; set; }
    }
}