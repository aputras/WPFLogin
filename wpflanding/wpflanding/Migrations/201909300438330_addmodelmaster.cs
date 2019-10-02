namespace wpflanding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelmaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_T_Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TB_M_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Login_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TB_T_Login", t => t.Login_id, cascadeDelete: true)
                .Index(t => t.Login_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_M_User", "Login_id", "dbo.TB_T_Login");
            DropIndex("dbo.TB_M_User", new[] { "Login_id" });
            DropTable("dbo.TB_M_User");
            DropTable("dbo.TB_T_Login");
        }
    }
}
