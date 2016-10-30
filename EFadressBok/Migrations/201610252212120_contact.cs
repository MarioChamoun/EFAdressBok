namespace EFadressBok.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.contacts",
                c => new
                    {
                        contactId = c.Int(nullable: false, identity: true),
                        namn = c.String(),
                        gatuadress = c.String(),
                        postnummer = c.Int(nullable: false),
                        postort = c.String(),
                        telefon = c.Int(nullable: false),
                        födelsedag = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.contactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.contacts");
        }
    }
}
