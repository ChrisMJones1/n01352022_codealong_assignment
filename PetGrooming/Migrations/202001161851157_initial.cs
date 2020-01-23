namespace PetGrooming.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetID = c.Int(nullable: false, identity: true),
                        PetName = c.String(),
                        Weight = c.Double(nullable: false),
                        Color = c.String(),
                        Notes = c.String(),
                        SpeciesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.Species", t => t.SpeciesID, cascadeDelete: true)
                .Index(t => t.SpeciesID);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "SpeciesID", "dbo.Species");
            DropIndex("dbo.Pets", new[] { "SpeciesID" });
            DropTable("dbo.Species");
            DropTable("dbo.Pets");
        }
    }
}
