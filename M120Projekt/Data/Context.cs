using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Context : DbContext
    {
        public Context() : base("name=M120Connectionstring")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.Context, M120Projekt.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Task"); // So that there won't be attached an "s" on the table
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            // so that on every DateTime Attribute on the DB is converted to datetime2
        }
        public DbSet<Task> Task { get; set; }
    }
}
