using DesafioWebMotors.Data.Mapping;
using DesafioWebMotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioWebMotors.Data.Context
{
    public class DesafioWebmotorsContext : DbContext
    {
        public DbSet<AnuncioWebmotorsEntity> AnunciosWebmotors { get; set; }

        public DesafioWebmotorsContext(DbContextOptions<DesafioWebmotorsContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AnuncioWebmotorsEntity>(new AnuncioWebmotorsMap().Configure);
        }
    }
}
