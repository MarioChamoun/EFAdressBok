namespace EFadressBok.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class telefon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.contacts", "telefon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.contacts", "telefon", c => c.Int(nullable: false));
        }
    }
}
