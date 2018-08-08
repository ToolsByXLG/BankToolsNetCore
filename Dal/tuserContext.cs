using Microsoft.EntityFrameworkCore;
using Model.Cmb;

namespace Dal
{
    public class ToolDbContext : DbContext
    {

        public ToolDbContext(DbContextOptions<ToolDbContext> options)
            : base(options)
        {
        }
        public  DbSet<tuser> tuser { get; set; }
    }

    
}
