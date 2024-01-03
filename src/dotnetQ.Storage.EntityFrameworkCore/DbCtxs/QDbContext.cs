using dotnetQ.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Storage.EntityFrameworkCore.DbCtxs
{
    public class QDbContext : DbContext
    {
        public QDbContext(DbContextOptionsBuilder<QDbContext> builder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        #region DbSets
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<PackItem> PackItems { get; set; }
        public DbSet<Worker> Workers { get; set; }
        #endregion
    }
}
