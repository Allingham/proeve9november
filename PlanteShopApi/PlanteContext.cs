using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanteShopService;

namespace PlanteShopApi
{
    public class PlanteContext : DbContext
    {
        public PlanteContext(DbContextOptions<PlanteContext> options) : base(options) { }

        public DbSet<Plante> Planter;

        public DbSet<PlanteShopService.Plante> Plante { get; set; }
    }
}
