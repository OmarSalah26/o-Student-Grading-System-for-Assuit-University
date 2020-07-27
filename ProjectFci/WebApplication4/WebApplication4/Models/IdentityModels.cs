using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication4.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            //omar
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ControlDB", throwIfV1Schema: false)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<ClemencyDegree> ClemencyDegree { get; set; }

        public DbSet<Control> Control { get; set; }
        public DbSet<ControlSubject> ControlSubjects { get; set; }
         public DbSet<User> User { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationSubjectStudent> EvaluationSubjectStudents { get; set; }
        public DbSet<LogFile> LogFiles { get; set; }
        public DbSet<Patch> Patchs { get; set; }
    
        public DbSet<Rate> Rates { get; set; }
        public DbSet<section> sections { get; set; }

        public DbSet<StudentEnrollSubject> StudentEnrollSubjects { get; set; }
        public DbSet<StudentYearPatch> StudentYearPatchs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectEvaluation> SubjectEvaluations { get; set; }
        public DbSet<SubjectRate> SubjectRates { get; set; }
       
        public DbSet<Year> Years { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}