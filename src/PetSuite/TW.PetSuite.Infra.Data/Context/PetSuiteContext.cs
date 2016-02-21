using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TW.PetSuite.Domain.Entities.Fornecedores;
using TW.PetSuite.Domain.Entities.Produtos;
using TW.PetSuite.Infra.Data.EntityConfig;

namespace TW.PetSuite.Infra.Data.Context
{
    public partial class PetSuiteContext : BaseDbContext
    {
        public PetSuiteContext()
            : base("name=PetSuiteContext")
        {
            //para performance no EF.
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<PetSuiteContext>(null); // default CreateDatabaseIfNotExists, no ambiente de produção deixar null, pois o defaul causará erro em caso de mudança no model.
            //http://www.dotnetfunda.com/forums/show/19393/unit-test-error-the-model-backing-the-3939-context-has-changed-since-t
            //http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx
        }

        public IDbSet<Fornecedores> Fornecedores { get; set; }
        public IDbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(50));

            //modelBuilder.Properties<decimal>()
            //    .Configure(p => p.HasColumnType("money"));

            //model configuration
            modelBuilder.Configurations.Add(new ProdutosConfiguration());
            modelBuilder.Configurations.Add(new FornecedoresConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
