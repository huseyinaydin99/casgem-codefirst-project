namespace Casgem_CodeFirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_relation_guide_socialmedia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "GuideID", c => c.Int(nullable: false));
            CreateIndex("dbo.SocialMedias", "GuideID");
            AddForeignKey("dbo.SocialMedias", "GuideID", "dbo.Guides", "GuideID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMedias", "GuideID", "dbo.Guides");
            DropIndex("dbo.SocialMedias", new[] { "GuideID" });
            DropColumn("dbo.SocialMedias", "GuideID");
        }
    }
}
