using CobranzasApi.Data;
using CobranzasApi.Models;

namespace CobranzasApi.Services
{
    public class DatosParametricasService : IDatosParametricasService
    {
        public List<TipoDeuda> ObtenerTiposDeuda()
        {
            return DatosEnMemoria.TiposDeuda;
        }

        public List<TipoContacto> ObtenerTiposContacto()
        {
            return DatosEnMemoria.TiposContacto;
        }
    }
}
