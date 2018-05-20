namespace VanHackAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyModels",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            AddColumn("dbo.AspNetUsers", "CompanyModel_CompanyId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "CompanyModel_CompanyId");
            AddForeignKey("dbo.AspNetUsers", "CompanyModel_CompanyId", "dbo.CompanyModels", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyModel_CompanyId", "dbo.CompanyModels");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyModel_CompanyId" });
            DropColumn("dbo.AspNetUsers", "CompanyModel_CompanyId");
            DropTable("dbo.CompanyModels");
        }
    }
}
