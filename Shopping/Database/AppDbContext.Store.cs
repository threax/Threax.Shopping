using Microsoft.EntityFrameworkCore;

namespace Shopping.Database
{
    public partial class AppDbContext
    {
        public DbSet<StoreEntity> Stores { get; set; }
    }
}
