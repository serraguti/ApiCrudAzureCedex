using ApiCrudAzureCedex.Data;
using ApiCrudAzureCedex.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudAzureCedex.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos
                .FirstOrDefaultAsync(x => x.IdDepartamento == id);
        }

        private async Task<int> GetMaxIdDepartamentoAsync()
        {
            if (this.context.Departamentos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Departamentos.MaxAsync(x => x.IdDepartamento) + 1;
            }
        }

        public async Task Create(string nombre, string localidad)
        {
            Departamento dept = new Departamento();
            dept.IdDepartamento = await this.GetMaxIdDepartamentoAsync();
            dept.Nombre = nombre;
            dept.Localidad = localidad;
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(int id, string nombre, string localidad)
        {
            Departamento dept = await this.FindDepartamentoAsync(id);
            dept.Nombre = nombre;
            dept.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Departamento dept = await this.FindDepartamentoAsync(id);
            this.context.Departamentos.Remove(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
