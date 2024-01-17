using CobranzasApi.Data;
using CobranzasApi.Models;

namespace CobranzasApi.Services
{
    public class IntencionPagoService : IIntencionPagoService
    {
        private readonly IClienteService _clienteService;

        public IntencionPagoService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public ApiResponse<bool> RegistrarIntencionPago(IntencionPago intencionPago)
        {
            var cliente = _clienteService.ObtenerClientePorCedula(intencionPago.CedulaCliente);
            if (cliente != null)
            {
                DatosEnMemoria.IntencionesPago.Add(intencionPago);

                return new ApiResponse<bool>(true, true);
            }
            else
            {
                return ApiResponse<bool>.CreateError("No se encontro el cliente.");
            }
        }

        public ApiResponse<List<IntencionPago>> ObtenerIntencionesPagoPorCliente(string cedulaCliente)
        {
            var intenciones = DatosEnMemoria.IntencionesPago
                .Where(ip => ip.CedulaCliente == cedulaCliente)
                .ToList();

            if (intenciones.Count == 0)
            {
                return ApiResponse<List<IntencionPago>>.CreateError("No se encontraron intenciones de pago para el cliente.");
            }

            return new ApiResponse<List<IntencionPago>>(intenciones);
        }

        public ApiResponse<bool> ActualizarIntencionPago(string cedulaCliente, IntencionPago intencionPagoActualizada)
        {
            var intencion = DatosEnMemoria.IntencionesPago
                .FirstOrDefault(ip => ip.CedulaCliente == cedulaCliente);
            if (intencion != null)
            {
                intencion.MontoIntencionPago = intencionPagoActualizada.MontoIntencionPago;
                intencion.HorarioDesde = intencionPagoActualizada.HorarioDesde;
                intencion.HorarioHasta = intencionPagoActualizada.HorarioHasta;
                intencion.TelefonoContactabilidad = intencionPagoActualizada.TelefonoContactabilidad;
                intencion.FechaIntencion = intencionPagoActualizada.FechaIntencion;

                return new ApiResponse<bool>(true, true);

            }
            else
            {
                return ApiResponse<bool>.CreateError("No se encontraron intenciones de pago para el cliente.");
            }
            
        }

        public ApiResponse<bool> EliminarIntencionesPagoPorCliente(string cedulaCliente)
        {
            var intenciones = DatosEnMemoria.IntencionesPago
                .Where(ip => ip.CedulaCliente == cedulaCliente)
                .ToList();

            if(!intenciones.Any())
            {
                return ApiResponse<bool>.CreateError("No se encontraron intenciones de pago para el cliente.");
            }

            foreach (var intencion in intenciones)
            {
                DatosEnMemoria.IntencionesPago.Remove(intencion);
            }

            return new ApiResponse<bool>(true, true);
        }


    }
}
