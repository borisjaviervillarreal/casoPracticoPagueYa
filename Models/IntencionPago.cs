namespace CobranzasApi.Models
{
    public class IntencionPago
    {
        public string? CedulaCliente { get; set; }
        public string? CodTipoDeuda { get; set; }
        public decimal MontoIntencionPago { get; set; }
        public string? HorarioDesde { get; set; }
        public string? HorarioHasta { get; set; }
        public string? TelefonoContactabilidad { get; set; }
        public string? FechaIntencion { get; set; }
    }
}
