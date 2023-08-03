using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PHFinAutoTrack.Domain.Entities;

namespace PHFinAutoTrack.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(200)");

            // 1 : N => Categoria : Lancamentos

            builder.HasMany(c => c.Lancamentos)
                .WithOne(l => l.Categoria)
                .HasForeignKey(l => l.CategoriaId);

            builder.ToTable("categorias");
        }
    }
}
