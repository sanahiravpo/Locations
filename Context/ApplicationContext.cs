using Locations.Models;
using Microsoft.EntityFrameworkCore;

namespace Locations.Context
{
    public class ApplicationContext:DbContext
    {

        public ApplicationContext(DbContextOptions options):base(options )
        { }

      public  DbSet<LocationDetail> Locationdetail { get; set; }
    }
}
