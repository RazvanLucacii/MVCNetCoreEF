using Microsoft.EntityFrameworkCore;
using MVCNetCoreEF.Models;

namespace MVCNetCoreEF.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options):base(options) 
        { }

        public DbSet<Hospital> Hospitales { get; set; }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
