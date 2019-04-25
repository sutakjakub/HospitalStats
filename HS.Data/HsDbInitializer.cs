using FizzWare.NBuilder;
using HS.Data.Entitites.ARO;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;

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
                var gen = new RandomGenerator();
                var faker = new Bogus.Faker();

                var list = Builder<OperationRoomAction>.CreateListOfSize(100).All()
                    .With(p => p.Id = 0)
                    .With(p => p.IsDeleted = false)
                    .With(p => p.Risks_Over65Years = gen.Next(0, 5))
                    .With(p => p.Risks_CombA = gen.Next(0, 5))
                    .With(p => p.Risks_RA = gen.Next(0, 5))
                    .With(p => p.Risks_Risks = gen.Next(0, 5))
                    .With(p => p.Risks_Ups = gen.Next(0, 5))
                    .With(p => p.Perf_Analgo = gen.Boolean())
                    .With(p => p.Perf_Axi = gen.Boolean())
                    .With(p => p.Perf_BilumRourky_Cevni = gen.Boolean())
                    .With(p => p.Perf_BilumRourky_Hyperhydroza = gen.Boolean())
                    .With(p => p.Perf_C23 = gen.Boolean())
                    .With(p => p.Perf_CaLm = gen.Boolean())
                    .With(p => p.Perf_CaOti = gen.Boolean())
                    .With(p => p.Perf_CaRa = gen.Boolean())
                    .With(p => p.Perf_Clea = gen.Boolean())
                    .With(p => p.Perf_Control = gen.Boolean())
                    .With(p => p.Perf_DuringUps = gen.Boolean())
                    .With(p => p.Perf_DuringUps_Over65Years = gen.Boolean())
                    .With(p => p.Perf_Foot = gen.Boolean())
                    .With(p => p.Perf_Inf = gen.Boolean())
                    .With(p => p.Perf_Isch = gen.Boolean())
                    .With(p => p.Perf_Jdch = gen.Boolean())
                    .With(p => p.Perf_MoreThan2Hours = gen.Boolean())
                    .With(p => p.Perf_Over65Years = gen.Boolean())
                    .With(p => p.Perf_Over65Years_Ca = gen.Boolean())
                    .With(p => p.Perf_Over65Years_MoreThan2Hours = gen.Boolean())
                    .With(p => p.Perf_Over65Years_Ra = gen.Boolean())
                    .With(p => p.Perf_PoplitBlock = gen.Boolean())
                    .With(p => p.Perf_Saa = gen.Boolean())
                    .With(p => p.Perf_ScalBlock = gen.Boolean())
                    .With(p => p.Perf_SendToAro = gen.Boolean())
                    .With(p => p.Perf_Tac = gen.Boolean())
                    .With(p => p.Perf_UpTo19Years = gen.Boolean())
                    .With(p => p.Perf_UpTo19Years_MoreThan2Hours = gen.Boolean())
                    .With(p => p.Perf_UpTo19Years_Ra = gen.Boolean())
                    .With(p => p.Compl_Ccf = gen.Boolean())
                    .With(p => p.Compl_FailedMachine = gen.Boolean())
                    .With(p => p.Compl_FailedOti = gen.Boolean())
                    .With(p => p.Compl_FailedRa= gen.Boolean())
                    .With(p => p.Compl_HurtDuringA = gen.Boolean())
                    .With(p => p.Compl_MorsInTabula = gen.Boolean())
                    .With(p => p.Compl_Oti = gen.Boolean())
                    .With(p => p.Compl_UnplanedAro = gen.Boolean())
                    .With(p => p.Compl_UnplanedOti = gen.Boolean())
                    .With(p => p.IssueDate = faker.Date.Between(new DateTime(2019, 4, 1), DateTime.Now.Date))
                    .With(p => p.Modified = DateTime.Now)
                    .With(p => p.Birthday = faker.Date.Between(new DateTime(1920, 1,1), DateTime.Now.Date))
                    .Build();

                ctx.OperationRoomActions.AddRange(list);
                ctx.OperationRoomActions.Add(new OperationRoomAction()
                {
                    Created = DateTime.Now,
                    Description = "JŠ",
                    IsDeleted = false,
                    IssueDate = DateTime.Now.Date.AddDays(-10),
                    Modified = DateTime.Now
                });
                ctx.SaveChanges();
            }
        }
    }
}
