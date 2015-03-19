using System.Data.Entity.Migrations;
namespace Fullstack.Core.Migrations
{   
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256, nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256, nullable: false),
                        Email = c.String(maxLength: 256, nullable: false),
                        Password = c.String(maxLength: 124, nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Submitted = c.Boolean(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "User_Id", "dbo.Users");
            DropIndex("dbo.Invoices", new[] { "Company_Id" });
            DropIndex("dbo.Companies", new[] { "User_Id" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Users");
            DropTable("dbo.Companies");
        }
    }
}
