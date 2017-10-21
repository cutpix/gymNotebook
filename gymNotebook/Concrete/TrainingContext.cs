using gymNotebook.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace gymNotebook.Concrete
{
    public class TrainingContext : IdentityDbContext<ApplicationUser>
    {
        public TrainingContext() : base("TrainingContext")
        {

        }

        static TrainingContext()
        {
            Database.SetInitializer<TrainingContext>(new TrainingInitializer());
        }

        public static TrainingContext Create()
        {
            return new TrainingContext();
        }

        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingSession> TrainingSessions { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<TrainingResult> TrainingResults { get; set; }
        public virtual DbSet<MusclePart> MuscleParts { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }
        public virtual DbSet<Progress> Progress { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}