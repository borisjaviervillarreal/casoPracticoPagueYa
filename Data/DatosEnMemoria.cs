using CobranzasApi.Models;

namespace CobranzasApi.Data
{
    public static class DatosEnMemoria
    {
        public static List<Cliente> Clientes = new List<Cliente>();
        public static List<IntencionPago> IntencionesPago = new List<IntencionPago>();
        public static List<TipoDeuda> TiposDeuda = new List<TipoDeuda>()
        {
            new TipoDeuda { CodTipoDeuda = "PRESTAMO_NORMAL", Descripcion = "Préstamo Normal" },
            new TipoDeuda { CodTipoDeuda = "PRESTAMO_AUTO", Descripcion = "Préstamo Automóvil" },
            new TipoDeuda { CodTipoDeuda = "PRESTAMO_CASA", Descripcion = "Préstamo Casa" },
            new TipoDeuda { CodTipoDeuda = "TARJETA_CREDITO", Descripcion = "Tarjeta Crédito" },
        };
        public static List<TipoContacto> TiposContacto = new List<TipoContacto>()
        {
            new TipoContacto { CodTipoContacto = "TLF_CEL", Descripcion = "Teléfono Celular" },
            new TipoContacto { CodTipoContacto = "TLF_CASA", Descripcion = "Teléfono Casa" },
            new TipoContacto { CodTipoContacto = "TLF_OFICINA", Descripcion = "Teléfono Oficina" },
        };
    }
}
