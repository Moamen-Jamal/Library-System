namespace Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        NumberOfCopies = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserBook",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        NumberOfBorrowings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserBook", "BookID", "dbo.Book");
            DropForeignKey("dbo.UserBook", "UserID", "dbo.User");
            DropIndex("dbo.UserBook", new[] { "UserID" });
            DropIndex("dbo.UserBook", new[] { "BookID" });
            DropTable("dbo.User");
            DropTable("dbo.UserBook");
            DropTable("dbo.Book");
        }
    }
}
