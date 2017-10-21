namespace gymNotebook.Migrations
{
    using gymNotebook.Concrete;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<gymNotebook.Concrete.TrainingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "gymNotebook.Concrete.TrainingContext";
        }

        protected override void Seed(gymNotebook.Concrete.TrainingContext context)
        {
            TrainingInitializer.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
