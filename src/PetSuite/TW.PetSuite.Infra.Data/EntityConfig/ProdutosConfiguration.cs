using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TW.PetSuite.Domain.Entities.Produtos;
using System.ComponentModel.DataAnnotations.Schema;

namespace TW.PetSuite.Infra.Data.EntityConfig
{
    public class ProdutosConfiguration : EntityTypeConfiguration<Produtos>
    {
        public ProdutosConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.ProdutoId);

            // Properties
            this.Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Produtos");
            this.Property(t => t.ProdutoId).HasColumnName("ProdutoId");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.PrecoCusto).HasColumnName("PrecoCusto");
            this.Property(t => t.PrecoVenda).HasColumnName("PrecoVenda");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");

            // Relationships
            this.HasOptional(t => t.Fornecedores)
                .WithMany(t => t.Produtos)
                .HasForeignKey(d => d.FornecedorId);

            //Criar um novo Migration, porque alterei o campo Fornecedor para FornecedorId
        }
    }
}
