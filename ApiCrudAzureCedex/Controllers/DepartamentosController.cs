using ApiCrudAzureCedex.Models;
using ApiCrudAzureCedex.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAzureCedex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryHospital repo;

        public DepartamentosController(RepositoryHospital repo)
        {
            this.repo = repo;
        }

        //EL NOMBRE DE LOS METODOS NO IMPORTA
        //SOLO IMPORTAN LAS ANOTACIONES
        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> GetDepartamentos()
        {
            return await this.repo.GetDepartamentosAsync();            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> FindDepartamento(int id)
        {
            return await this.repo.FindDepartamentoAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDepartamento(Departamento departamento)
        {
            await this.repo.Create(departamento.Nombre, departamento.Localidad);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartamento(Departamento departamento)
        {
            await this.repo.Update(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            return Ok(new { mensaje = "Update correcto" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartamento(int id)
        {
            await this.repo.Delete(id);
            return Ok();
        }
    }
}
