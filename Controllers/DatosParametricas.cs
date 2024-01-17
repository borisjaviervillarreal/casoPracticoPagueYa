using CobranzasApi.Data;
using CobranzasApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CobranzasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosParametricas : ControllerBase
    {
        private readonly IDatosParametricasService _datosParametricasService;

        public DatosParametricas(IDatosParametricasService datosParametricasService)
        {
            _datosParametricasService = datosParametricasService;
        }

        [HttpGet("tiposDeuda")]
        public IActionResult ObtenerTiposDeuda()
        {
            var tiposDeuda = _datosParametricasService.ObtenerTiposDeuda();
            return Ok(tiposDeuda);
        }

        [HttpGet("tiposContacto")]
        public IActionResult ObtenerTiposContacto()
        {
            var tiposContacto = _datosParametricasService.ObtenerTiposContacto();
            return Ok(tiposContacto);
        }


    }
}
