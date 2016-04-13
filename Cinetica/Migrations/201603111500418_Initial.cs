namespace CineticaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cineticas",
                c => new
                    {
                        CineticaId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Name = c.String(),
                        AccX = c.Single(nullable: false),
                        AccY = c.Single(nullable: false),
                        AccZ = c.Single(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CineticaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cineticas");
        }
    }
}
