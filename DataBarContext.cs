using Microsoft.EntityFrameworkCore;

namespace DataBar
{
    class DataBarContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=DataBar;Integrated Security=True;MultipleActiveResultSets=True");
        }
    }
}
