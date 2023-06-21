using ApiCrudAzureCedex.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudAzureCedex.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) { }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
