using GestionTerceros.Models;

namespace GestionTerceros.Services.CrearPersonaNatural
{
    public interface ICrearPersonaNaturalService
    {
        CrearPersonaNaturalResponseDTO CrearTerceroCc(CrearPersonaNaturalRequestDTO personaNatural);
    }
}
