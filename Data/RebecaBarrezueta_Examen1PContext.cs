using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebecaBarrezueta_Examen1P.Models;

namespace RebecaBarrezueta_Examen1P.Data
{
    public class RebecaBarrezueta_Examen1PContext : DbContext
    {
        public RebecaBarrezueta_Examen1PContext (DbContextOptions<RebecaBarrezueta_Examen1PContext> options)
            : base(options)
        {
        }

        public DbSet<RebecaBarrezueta_Examen1P.Models.ZapatosRB> ZapatosRB { get; set; } = default!;
        public DbSet<RebecaBarrezueta_Examen1P.Models.PromocionRB> PromocionRB { get; set; } = default!;
    }
}
