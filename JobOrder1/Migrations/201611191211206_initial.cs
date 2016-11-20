namespace JobOrder1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(nullable: false),
                        SessionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentTopic = c.Int(nullable: false),
                        CurrentSession = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "SessionId", "dbo.Sessions");
            DropIndex("dbo.Histories", new[] { "SessionId" });
            DropTable("dbo.Statuses");
            DropTable("dbo.Histories");
        }
    }
}
