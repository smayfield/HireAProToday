namespace HireAProToday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDirectoryCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectoryCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DirectoryCategoryMembers",
                c => new
                    {
                        DirectoryCategory_Id = c.Int(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DirectoryCategory_Id, t.Member_Id })
                .ForeignKey("dbo.DirectoryCategories", t => t.DirectoryCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.DirectoryCategory_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectoryCategoryMembers", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.DirectoryCategoryMembers", "DirectoryCategory_Id", "dbo.DirectoryCategories");
            DropIndex("dbo.DirectoryCategoryMembers", new[] { "Member_Id" });
            DropIndex("dbo.DirectoryCategoryMembers", new[] { "DirectoryCategory_Id" });
            DropTable("dbo.DirectoryCategoryMembers");
            DropTable("dbo.DirectoryCategories");
        }
    }
}
