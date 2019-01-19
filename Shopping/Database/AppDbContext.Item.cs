using Microsoft.EntityFrameworkCore;

namespace Shopping.Database
{
    public partial class AppDbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
    }
}
