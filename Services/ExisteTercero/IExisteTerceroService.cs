using GestionTerceros.Models;

namespace GestionTerceros.Services.ExisteTercero
{
    public interface IExisteTerceroService
    {
        GestionTercerosResponseDTO ExisteTercero (GestionTercerosRequestDTO gestionTercerosRequestDTO);
    }
}
