namespace TW.PetSuite.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        FornecedorId = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Telefone1 = c.String(maxLength: 15, unicode: false),
                        Telefone2 = c.String(maxLength: 15, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Guid(nullable: false),
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        PrecoCusto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(),
                        Fornecedor = c.Guid(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Fornecedores", t => t.Fornecedor)
                .Index(t => t.Fornecedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "Fornecedor", "dbo.Fornecedores");
            DropIndex("dbo.Produtos", new[] { "Fornecedor" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Fornecedores");
        }
    }
}
