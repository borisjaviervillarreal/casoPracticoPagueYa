using CobranzasApi.Models;

namespace CobranzasApi.Services
{
    public interface IDatosParametricasService
    {
        List<TipoDeuda> ObtenerTiposDeuda();
        List<TipoContacto> ObtenerTiposContacto();
    }
}
