using AppDesafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDesafio.Infrastructure.Data.InMemory
{
    public partial class DesafioDBContext : DbContext
    {
        public DesafioDBContext()
        {
        }

        public DesafioDBContext(DbContextOptions<DesafioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TipoCambio> TipoCambios { get; set; }
    }
}
