namespace HireAProToday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Cell = c.String(),
                        Email = c.String(),
                        DateJoined = c.DateTime(nullable: false),
                        Url = c.String(),
                        DuesPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MemberType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberTypes", t => t.MemberType_Id)
                .Index(t => t.MemberType_Id);
            
            CreateTable(
                "dbo.MemberTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "MemberType_Id", "dbo.MemberTypes");
            DropIndex("dbo.Members", new[] { "MemberType_Id" });
            DropTable("dbo.MemberTypes");
            DropTable("dbo.Members");
        }
    }
}
