using System;
using System.Collections.Generic;

#nullable disable

namespace AppDesafio.Domain.Entities
{
    public partial class TipoCambio : BaseEntity
    {
        public string CodigoIso { get; set; }
        public string Divisa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
    }
}
