namespace PiggyBankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newStuff : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Expenses", name: "Owner_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Expenses", name: "IX_Owner_Id", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Expenses", name: "IX_ApplicationUser_Id", newName: "IX_Owner_Id");
            RenameColumn(table: "dbo.Expenses", name: "ApplicationUser_Id", newName: "Owner_Id");
        }
    }
}
