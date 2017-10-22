namespace gymNotebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_Key_exercisesession : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercise", "SessionID", "dbo.TrainingSession");
            DropIndex("dbo.Exercise", new[] { "SessionID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Exercise", "SessionID");
            AddForeignKey("dbo.Exercise", "SessionID", "dbo.TrainingSession", "SessionID", cascadeDelete: true);
        }
    }
}
