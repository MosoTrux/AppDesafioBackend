using System;

namespace AppDesafio.Application.Dtos
{
    public class AgregarTipoCambioDto
    {
        public string CodigoIso { get; set; }
        public string Divisa { get; set; }
        //public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
    }
}
