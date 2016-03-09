namespace PiggyBankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Debts", "CompanyName", c => c.String());
            AddColumn("dbo.Incomes", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incomes", "CompanyName");
            DropColumn("dbo.Debts", "CompanyName");
        }
    }
}
