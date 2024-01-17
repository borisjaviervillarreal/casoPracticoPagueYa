using CobranzasApi.Models;

namespace CobranzasApi.Services
{
    public interface IClienteService
    {
        ApiResponse<bool> AgregarCliente(Cliente cliente);
        ApiResponse<Cliente> ObtenerClientePorCedula(string cedula);
        ApiResponse<bool> ActualizarCliente(string cedula, Cliente clienteActualizado);
        ApiResponse<bool> EliminarCliente(string cedula);
    }
}
