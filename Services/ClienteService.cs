using CobranzasApi.Data;
using CobranzasApi.Models;

namespace CobranzasApi.Services
{
    public class ClienteService : IClienteService
    {
        public ApiResponse<bool> AgregarCliente(Cliente cliente)
        {
            var clienteExistente = DatosEnMemoria.Clientes.FirstOrDefault(c => c.Cedula == cliente.Cedula);
            if (clienteExistente == null)
            {
                DatosEnMemoria.Clientes.Add(cliente);

                return new ApiResponse<bool>(true, true);
            }


            return ApiResponse<bool>.CreateError("Cliente ya existe no se puede agregar.");
        }

        public ApiResponse<Cliente> ObtenerClientePorCedula(string cedula)
        {
            var clienteExistente = DatosEnMemoria.Clientes.FirstOrDefault(c => c.Cedula == cedula);

            if (clienteExistente != null)
            {
                return new ApiResponse<Cliente>(clienteExistente);

            }

            return ApiResponse<Cliente>.CreateError("No se encontro el cliente.");
            
        }

        public ApiResponse<bool> ActualizarCliente(string cedula, Cliente clienteActualizado)
        {
            var cliente = DatosEnMemoria.Clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente != null)
            {
                cliente.Nombres = clienteActualizado.Nombres;
                cliente.Apellidos = clienteActualizado.Apellidos;
                cliente.DireccionCasa = clienteActualizado.DireccionCasa;
                cliente.DireccionTrabajo = clienteActualizado.DireccionTrabajo;
                cliente.EmailPersonal = clienteActualizado.EmailPersonal;
                cliente.EmailTrabajo = clienteActualizado.EmailTrabajo;
                cliente.TelefonoCelular = clienteActualizado.TelefonoCelular;
                cliente.TelefonoCasa = clienteActualizado.TelefonoCasa;
                cliente.TelefonoOficina = clienteActualizado.TelefonoOficina;

                return new ApiResponse<bool>(true, true);
            }
            else
            {
                return ApiResponse<bool>.CreateError("No se encontro el cliente.");
            }
        }

        public ApiResponse<bool> EliminarCliente(string cedula)
        {
            var cliente = DatosEnMemoria.Clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente != null)
            {
                DatosEnMemoria.Clientes.Remove(cliente);

                return new ApiResponse<bool>(true, true);
            }
            else
            {
                return ApiResponse<bool>.CreateError("No se encontro el cliente.");
            }
            
        }

    }
}
