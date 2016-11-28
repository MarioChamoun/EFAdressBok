namespace EFadressBok.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myig : DbMigration
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
                        telefon = c.String(),
                        epost = c.String(),
                        födelsedag = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.contactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.contacts");
        }
    }
}
