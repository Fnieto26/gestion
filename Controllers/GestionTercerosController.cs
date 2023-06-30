using GestionTerceros.Models;
using GestionTerceros.Services.CrearPersonaJuridica;
using GestionTerceros.Services.CrearPersonaNatural;
using GestionTerceros.Services.ExisteTercero;
using Microsoft.AspNetCore.Mvc;


namespace GestionTerceros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionTercerosController : ControllerBase
    {
        private readonly IExisteTerceroService terceroService;
        private readonly ICrearPersonaNaturalService personaNaturalService;
        private readonly ICrearPersonaJuridicaService personaJuridicaService;

        public GestionTercerosController(IExisteTerceroService terceroService, ICrearPersonaNaturalService personaNaturalService, ICrearPersonaJuridicaService personaJuridicaService)
        {
            this.terceroService = terceroService;
            this.personaNaturalService = personaNaturalService;
            this.personaJuridicaService = personaJuridicaService;
        }

        [HttpGet("existeTerceroService")]       

        public GestionTercerosResponseDTO existeTerceroService(GestionTercerosRequestDTO gestionTercerosRequestDTO)                        
        {
            var result = terceroService.ExisteTercero(gestionTercerosRequestDTO);
            return result;
        }

        // POST api/<GestionTercerosController>
        [HttpPost("CrearTerceroCc")]
        public CrearPersonaNaturalResponseDTO CrearPersonaCc([FromBody] CrearPersonaNaturalRequestDTO personaNatural)
        {
            return personaNaturalService.CrearTerceroCc(personaNatural);
        }

        // POST api/<GestionTercerosController>
        [HttpPost("CrearTerceroNit")]
        public CrearPersonaJuridicaResponseDTO CrearPersonaNit([FromBody] CrearPersonaJuridicaRequestDTO personaJuridica)
        {
            return personaJuridicaService.CrearTerceroNit(personaJuridica);
        }

        // PUT api/<GestionTercerosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GestionTercerosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
