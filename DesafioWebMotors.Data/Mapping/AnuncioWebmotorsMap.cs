using DesafioWebMotors.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioWebMotors.Data.Mapping
{
    public class AnuncioWebmotorsMap : IEntityTypeConfiguration<AnuncioWebmotorsEntity>
    {
        public void Configure(EntityTypeBuilder<AnuncioWebmotorsEntity> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Marca).HasColumnName("marca").HasColumnType("varchar(45)").IsRequired(true).HasMaxLength(45);
            builder.Property(x => x.Modelo).HasColumnName("modelo").HasColumnType("varchar(45)").IsRequired(true).HasMaxLength(45);
            builder.Property(x => x.Versao).HasColumnName("versao").HasColumnType("varchar(45)").IsRequired(true).HasMaxLength(45);
            builder.Property(x => x.Observacao).HasColumnName("observacao").HasColumnType("text").IsRequired(true).HasMaxLength(45);
            builder.Property(x => x.Ano).HasColumnName("ano").HasColumnType("int").IsRequired(true);
            builder.Property(x => x.Quilometragem).HasColumnName("quilometragem").HasColumnType("int").IsRequired(true);
        }
    }
}
