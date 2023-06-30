using GestionTerceros.Models;

namespace GestionTerceros.Services.CrearPersonaJuridica
{
    public interface ICrearPersonaJuridicaService
    {
        CrearPersonaJuridicaResponseDTO CrearTerceroNit(CrearPersonaJuridicaRequestDTO personaJuridica);
    }
}
