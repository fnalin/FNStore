using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.Store.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));
            builder.HasKey(pk => pk.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(80)");
            builder.Property(c => c.PrecoUnitario).IsRequired().HasColumnType("money");
            builder.Property(c => c.CategoriaId).IsRequired();
            
        }
    }
}
