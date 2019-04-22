using HS.Data.Entitites;
using HS.Data.Entitites.ARO;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Data
{
    public class HsDbContext : DbContext
    {
        public DbSet<OperationRoomAction> OperationRoomActions { get; set; }

        public HsDbContext(string nameOrConnectionString = "hsDb")
            : base(nameOrConnectionString)
        {
            Configure();
        }

        public HsDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new HsDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }

        
    }
}
