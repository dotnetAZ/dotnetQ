using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs.Abstract
{
    public class QAbstractDbContext : DbContext
    {
        #region Ctors
        public QAbstractDbContext(DbContextOptions<QAbstractDbContext> options) : base(options)
        {

        }

        public QAbstractDbContext(DbContextOptions options) : base(options)
        {

        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Q");
            //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        #region DbSets
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<PackItem> PackItems { get; set; }
        #endregion
    }
}
