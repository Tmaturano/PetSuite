using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using TW.PetSuite.Domain.Entities.Fornecedores;
using System.ComponentModel.DataAnnotations.Schema;

namespace TW.PetSuite.Infra.Data.EntityConfig
{
    public class FornecedoresConfiguration : EntityTypeConfiguration<Fornecedores>
    {
        public FornecedoresConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.FornecedorId);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Telefone1)
                .HasMaxLength(15);

            this.Property(t => t.Telefone2)
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Codigo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Fornecedores");
            this.Property(t => t.FornecedorId).HasColumnName("FornecedorId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Telefone1).HasColumnName("Telefone1");
            this.Property(t => t.Telefone2).HasColumnName("Telefone2");
            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Email).HasColumnName("Email");
        }
       
    }
}
