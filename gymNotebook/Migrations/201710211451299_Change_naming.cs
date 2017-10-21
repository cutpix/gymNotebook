namespace gymNotebook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_naming : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Exercises", newName: "Exercise");
            RenameTable(name: "dbo.MuscleParts", newName: "MusclePart");
            RenameTable(name: "dbo.TrainingResults", newName: "TrainingResult");
            RenameTable(name: "dbo.TrainingSessions", newName: "TrainingSession");
            RenameTable(name: "dbo.Trainings", newName: "Training");
            RenameTable(name: "dbo.Progresses", newName: "Progress");
            RenameTable(name: "dbo.UserDatas", newName: "UserData");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserData", newName: "UserDatas");
            RenameTable(name: "dbo.Progress", newName: "Progresses");
            RenameTable(name: "dbo.Training", newName: "Trainings");
            RenameTable(name: "dbo.TrainingSession", newName: "TrainingSessions");
            RenameTable(name: "dbo.TrainingResult", newName: "TrainingResults");
            RenameTable(name: "dbo.MusclePart", newName: "MuscleParts");
            RenameTable(name: "dbo.Exercise", newName: "Exercises");
        }
    }
}
