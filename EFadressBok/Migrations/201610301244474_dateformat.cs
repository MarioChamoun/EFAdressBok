namespace EFadressBok.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateformat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.contacts", "födelsedag", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.contacts", "födelsedag", c => c.DateTime(nullable: false));
        }
    }
}
