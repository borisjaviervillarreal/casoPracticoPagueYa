using CobranzasApi.Models;

namespace CobranzasApi.Services
{
    public interface IIntencionPagoService
    {
        ApiResponse<bool> RegistrarIntencionPago(IntencionPago intencionPago);
        ApiResponse<List<IntencionPago>> ObtenerIntencionesPagoPorCliente(string cedulaCliente);
        ApiResponse<bool> ActualizarIntencionPago(string cedulaCliente, IntencionPago intencionPagoActualizada);
        ApiResponse<bool> EliminarIntencionesPagoPorCliente(string cedulaCliente);
    }
}
