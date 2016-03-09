namespace PiggyBankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class goal : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Expenses", name: "Saving_Id", newName: "Goal_Id");
            RenameIndex(table: "dbo.Expenses", name: "IX_Saving_Id", newName: "IX_Goal_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Expenses", name: "IX_Goal_Id", newName: "IX_Saving_Id");
            RenameColumn(table: "dbo.Expenses", name: "Goal_Id", newName: "Saving_Id");
        }
    }
}
