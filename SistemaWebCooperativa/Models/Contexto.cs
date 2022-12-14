using Microsoft.EntityFrameworkCore;
using SistemaWebCooperativa.Models;

namespace SistemaWebCooperativa.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Cooperado> Cooperado { get; set; }
        public DbSet<Insumo> Insumo { get; set; }
        public DbSet<Producao> Producao { get; set; }
        public DbSet<Propriedade> Propriedade { get; set; }
        public DbSet<SistemaWebCooperativa.Models.Transacao> Transacao { get; set; }


    }
}
