using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FN.Store.Data.EF
{
    public static class EFExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasData(
                    new Produto(1, "Picanha", 77.80M, 1),
                    new Produto(2, "Iogurte de Morango", 11.90M, 1),
                    new Produto(3, "Detergente líquido", 2.66M, 2),
                    new Produto(4, "Tomate", 3.66M, 1),
                    new Produto(5, "Calça Jeans", 102.99M, 3),
                    new Produto(6, "Sabão em pó", 8.9M, 2),
                    new Produto(7, "Lustra Móvel", 11.8M, 2),
                    new Produto(8, "Ração para o Pet", 50.66M, 4),
                    new Produto(9, "Manteiga", 12.05M, 1),
                    new Produto(10, "Margarina", 5.8M, 1),
                    new Produto(11, "Yakult", 8.7M, 1),
                    new Produto(12, "Sabão Phebo", 3.7M, 5),
                    new Produto(13, "Escova de Dente", 21.66M, 5),
                    new Produto(14, "Pasta de Dente", 5.8M, 5),
                    new Produto(15, "Água Sanitária", 12.5M, 2),
                    new Produto(16, "Desinfetante", 8.99M, 2),
                    new Produto(17, "Shampoo", 10.5M, 2),
                    new Produto(18, "Mouse Microsoft", 100.7M, 6),
                    new Produto(19, "Teclado sem fio", 50.66M, 6),
                    new Produto(20, "Alcool em gel", 2.66M, 5)
                );
        }



    }
}
