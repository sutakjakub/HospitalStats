using HS.Data.Entitites.ARO;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Data
{
    public class HsDbInitializer : SqliteCreateDatabaseIfNotExists<HsDbContext>
    {
        public HsDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder) { }

        protected override void Seed(HsDbContext ctx)
        {
            if (!ctx.OperationRoomActions.Any())
            {
                ctx.OperationRoomActions.Add(new OperationRoomAction()
                {
                    Created = DateTime.Now,
                    Description = "JŠ",
                    IsDeleted = false,
                    IssueDate = DateTime.Now.Date.AddDays(-10),
                    Modified = DateTime.Now,
                    Q1 = true,
                    Q2 = false,
                    Q3 = true,
                    Q4 = true,
                    Q5 = false
                });
                ctx.SaveChanges();
            }
        }
    }
}
