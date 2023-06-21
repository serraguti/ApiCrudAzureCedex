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
    }
}
