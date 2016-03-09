namespace PiggyBankApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreThings : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Savings", "MaxSaving");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Savings", "MaxSaving", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
