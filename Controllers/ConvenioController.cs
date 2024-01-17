using CobranzasApi.Models;
using CobranzasApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CobranzasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvenioController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IIntencionPagoService _intencionPagoService;

        public ConvenioController(IClienteService clienteService, IIntencionPagoService intencionPagoService)
        {
            _clienteService = clienteService;
            _intencionPagoService = intencionPagoService;
        }

        [HttpPost("registrarConvenioCliente")]
        public IActionResult RegistrarConvenioPago(RegistroConvenioPago registro)
        {
            var respuestaCliente = _clienteService.AgregarCliente(registro.Cliente);
            if(!respuestaCliente.Success)
            {
                return BadRequest(respuestaCliente);
            }

            registro.IntencionPago.CedulaCliente = registro.Cliente.Cedula;

            var respuestaIntencion = _intencionPagoService.RegistrarIntencionPago(registro.IntencionPago);

            if(!respuestaIntencion.Success)
            {
                return BadRequest(respuestaIntencion);
            }

            return Ok(respuestaIntencion);
        }

        [HttpGet("consultarConvenioCliente/{cedula}")]
        public IActionResult ConsultaConvenioCliente(string cedula)
        {
            var cliente = _clienteService.ObtenerClientePorCedula(cedula);
            if (!cliente.Success)
            {
                return BadRequest(cliente);
            }

            var intencionesPago = _intencionPagoService.ObtenerIntencionesPagoPorCliente(cedula);

            if(!intencionesPago.Success)
            {
                return BadRequest(intencionesPago);
            }

            return Ok(intencionesPago);
        }

        [HttpPut("actualizarConvenioCliente/{cedula}")]
        public IActionResult ActualizarConvenioCliente(string cedula, RegistroConvenioPago registroActualizado)
        {
            var clienteExistente = _clienteService.ObtenerClientePorCedula(cedula);
            if (!clienteExistente.Success)
            {
                return BadRequest(clienteExistente.ErrorMessage);
            }

            var actualizarCliente =  _clienteService.ActualizarCliente(cedula, registroActualizado.Cliente);
            if(!actualizarCliente.Success)
            {
                return BadRequest(actualizarCliente.ErrorMessage);
            }

            var actualizarIntencionPago = _intencionPagoService.ActualizarIntencionPago(cedula, registroActualizado.IntencionPago);

            if(!actualizarIntencionPago.Success)
            {
                return BadRequest(actualizarCliente);
            }

            return Ok(actualizarCliente);
        }

        [HttpDelete("eliminarConvenioCliente/{cedula}")]
        public IActionResult EliminarConvenioCliente(string cedula)
        {
            var respuesta = _intencionPagoService.EliminarIntencionesPagoPorCliente(cedula);

            if (respuesta.Success)
            {
                return Ok(respuesta);
                
            }

            return BadRequest(respuesta.ErrorMessage);

        }
    }
}
