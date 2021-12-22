namespace AppDesafio.Application.Dtos
{
    public class AplicarTipoCambioDto
    {
        public decimal Monto { get; set; }
        public decimal MontoConTipoCambio { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal TipoCambio { get; set; }
    }
}
