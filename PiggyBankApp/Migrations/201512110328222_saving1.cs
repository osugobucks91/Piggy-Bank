namespace PiggyBankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saving1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Owner_Id = c.String(maxLength: 128),
                        Saving_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.Savings", t => t.Saving_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Saving_Id);
            
            CreateTable(
                "dbo.Savings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        ItemValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxSaving = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Savings", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Expenses", "Saving_Id", "dbo.Savings");
            DropForeignKey("dbo.Expenses", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Savings", new[] { "Owner_Id" });
            DropIndex("dbo.Expenses", new[] { "Saving_Id" });
            DropIndex("dbo.Expenses", new[] { "Owner_Id" });
            DropTable("dbo.Savings");
            DropTable("dbo.Expenses");
        }
    }
}
