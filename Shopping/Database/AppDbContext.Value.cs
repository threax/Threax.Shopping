using Microsoft.EntityFrameworkCore;

namespace Shopping.Database
{
    public partial class AppDbContext
    {
        public DbSet<ValueEntity> Values { get; set; }
    }
}
