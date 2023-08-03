using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHFinAutoTrack.Domain.Entities;

namespace PHFinAutoTrack.Infra.Data.Mappings
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("VARCHAR(200)");

            builder.Property(x => x.DataLancamento)
                .IsRequired()
                .HasColumnName("data_lancamento")
                .HasColumnType("DATETIME");

            builder.Property(x => x.Imagem)
                .HasColumnName("imagem")
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("valor")
                .HasPrecision(10, 2);

            builder.ToTable("lancamentos");
        }
    }
}
