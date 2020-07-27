namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClemencyDegrees",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Describtion = c.String(),
                        Max = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentEnrollSubjects",
                c => new
                    {
                        subjectcode = c.String(nullable: false, maxLength: 128),
                        StudentSeatingNumber = c.Long(nullable: false),
                        ClemencyDegreeID = c.Long(nullable: false),
                        YearID = c.Long(nullable: false),
                        StateStudentEnrollSubject = c.String(),
                        TotalGrade = c.Double(nullable: false),
                        DateTimeENL = c.DateTime(nullable: false),
                        DateTimeCLD = c.DateTime(nullable: false),
                        RateingForGrade = c.String(),
                    })
                .PrimaryKey(t => new { t.subjectcode, t.StudentSeatingNumber })
                .ForeignKey("dbo.ClemencyDegrees", t => t.ClemencyDegreeID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.subjectcode, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentSeatingNumber, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearID, cascadeDelete: true)
                .Index(t => t.subjectcode)
                .Index(t => t.StudentSeatingNumber)
                .Index(t => t.ClemencyDegreeID)
                .Index(t => t.YearID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        SeatingNumber = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Nationality = c.String(),
                        BirthPlace = c.String(),
                        NationalIdNumber = c.String(),
                        SectionID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SeatingNumber)
                .ForeignKey("dbo.sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID);
            
            CreateTable(
                "dbo.EvaluationSubjectStudents",
                c => new
                    {
                        subjectcode = c.String(nullable: false, maxLength: 128),
                        EvaluationID = c.Long(nullable: false),
                        StudentSeatingNumber = c.Long(nullable: false),
                        Abs = c.String(),
                        Note = c.String(),
                        Grade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.subjectcode, t.EvaluationID, t.StudentSeatingNumber })
                .ForeignKey("dbo.Evaluations", t => t.EvaluationID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.subjectcode, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentSeatingNumber, cascadeDelete: true)
                .Index(t => t.subjectcode)
                .Index(t => t.EvaluationID)
                .Index(t => t.StudentSeatingNumber);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Max = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SubjectEvaluations",
                c => new
                    {
                        EvaluationId = c.Long(nullable: false),
                        subjectcode = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.EvaluationId, t.subjectcode })
                .ForeignKey("dbo.Evaluations", t => t.EvaluationId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.subjectcode, cascadeDelete: true)
                .Index(t => t.EvaluationId)
                .Index(t => t.subjectcode);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectCode = c.String(nullable: false, maxLength: 128),
                        SubjectName = c.String(),
                        Description = c.String(),
                        PatchId = c.Long(nullable: false),
                        Semester = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectCode)
                .ForeignKey("dbo.Patches", t => t.PatchId, cascadeDelete: true)
                .Index(t => t.PatchId);
            
            CreateTable(
                "dbo.ControlSubjects",
                c => new
                    {
                        ControlId = c.Long(nullable: false),
                        subjectcode = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ControlId, t.subjectcode })
                .ForeignKey("dbo.Controls", t => t.ControlId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.subjectcode, cascadeDelete: true)
                .Index(t => t.ControlId)
                .Index(t => t.subjectcode);
            
            CreateTable(
                "dbo.Controls",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        ControlName = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        userID = c.Long(nullable: false),
                        user_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Password = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patches",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PatchName = c.String(),
                        PatchNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubjectRates",
                c => new
                    {
                        subjectcode = c.String(nullable: false, maxLength: 128),
                        RateId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.subjectcode, t.RateId })
                .ForeignKey("dbo.Rates", t => t.RateId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.subjectcode, cascadeDelete: true)
                .Index(t => t.subjectcode)
                .Index(t => t.RateId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        description = c.String(),
                        Max = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sections",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StudentYearPatches",
                c => new
                    {
                        YearID = c.Long(nullable: false),
                        StudentSeatingNumber = c.Long(nullable: false),
                        PatchID = c.Long(nullable: false),
                        StateForpatch = c.String(),
                    })
                .PrimaryKey(t => new { t.YearID, t.StudentSeatingNumber, t.PatchID })
                .ForeignKey("dbo.Patches", t => t.PatchID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentSeatingNumber, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearID, cascadeDelete: true)
                .Index(t => t.YearID)
                .Index(t => t.StudentSeatingNumber)
                .Index(t => t.PatchID);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        YearNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.LogFiles",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        Query = c.String(),
                        DataTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.StudentEnrollSubjects", "YearID", "dbo.Years");
            DropForeignKey("dbo.StudentYearPatches", "YearID", "dbo.Years");
            DropForeignKey("dbo.StudentYearPatches", "StudentSeatingNumber", "dbo.Students");
            DropForeignKey("dbo.StudentYearPatches", "PatchID", "dbo.Patches");
            DropForeignKey("dbo.StudentEnrollSubjects", "StudentSeatingNumber", "dbo.Students");
            DropForeignKey("dbo.Students", "SectionID", "dbo.sections");
            DropForeignKey("dbo.EvaluationSubjectStudents", "StudentSeatingNumber", "dbo.Students");
            DropForeignKey("dbo.SubjectRates", "subjectcode", "dbo.Subjects");
            DropForeignKey("dbo.SubjectRates", "RateId", "dbo.Rates");
            DropForeignKey("dbo.SubjectEvaluations", "subjectcode", "dbo.Subjects");
            DropForeignKey("dbo.StudentEnrollSubjects", "subjectcode", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "PatchId", "dbo.Patches");
            DropForeignKey("dbo.EvaluationSubjectStudents", "subjectcode", "dbo.Subjects");
            DropForeignKey("dbo.ControlSubjects", "subjectcode", "dbo.Subjects");
            DropForeignKey("dbo.Controls", "user_ID", "dbo.Users");
            DropForeignKey("dbo.ControlSubjects", "ControlId", "dbo.Controls");
            DropForeignKey("dbo.SubjectEvaluations", "EvaluationId", "dbo.Evaluations");
            DropForeignKey("dbo.EvaluationSubjectStudents", "EvaluationID", "dbo.Evaluations");
            DropForeignKey("dbo.StudentEnrollSubjects", "ClemencyDegreeID", "dbo.ClemencyDegrees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.StudentYearPatches", new[] { "PatchID" });
            DropIndex("dbo.StudentYearPatches", new[] { "StudentSeatingNumber" });
            DropIndex("dbo.StudentYearPatches", new[] { "YearID" });
            DropIndex("dbo.SubjectRates", new[] { "RateId" });
            DropIndex("dbo.SubjectRates", new[] { "subjectcode" });
            DropIndex("dbo.Controls", new[] { "user_ID" });
            DropIndex("dbo.ControlSubjects", new[] { "subjectcode" });
            DropIndex("dbo.ControlSubjects", new[] { "ControlId" });
            DropIndex("dbo.Subjects", new[] { "PatchId" });
            DropIndex("dbo.SubjectEvaluations", new[] { "subjectcode" });
            DropIndex("dbo.SubjectEvaluations", new[] { "EvaluationId" });
            DropIndex("dbo.EvaluationSubjectStudents", new[] { "StudentSeatingNumber" });
            DropIndex("dbo.EvaluationSubjectStudents", new[] { "EvaluationID" });
            DropIndex("dbo.EvaluationSubjectStudents", new[] { "subjectcode" });
            DropIndex("dbo.Students", new[] { "SectionID" });
            DropIndex("dbo.StudentEnrollSubjects", new[] { "YearID" });
            DropIndex("dbo.StudentEnrollSubjects", new[] { "ClemencyDegreeID" });
            DropIndex("dbo.StudentEnrollSubjects", new[] { "StudentSeatingNumber" });
            DropIndex("dbo.StudentEnrollSubjects", new[] { "subjectcode" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LogFiles");
            DropTable("dbo.Years");
            DropTable("dbo.StudentYearPatches");
            DropTable("dbo.sections");
            DropTable("dbo.Rates");
            DropTable("dbo.SubjectRates");
            DropTable("dbo.Patches");
            DropTable("dbo.Users");
            DropTable("dbo.Controls");
            DropTable("dbo.ControlSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.SubjectEvaluations");
            DropTable("dbo.Evaluations");
            DropTable("dbo.EvaluationSubjectStudents");
            DropTable("dbo.Students");
            DropTable("dbo.StudentEnrollSubjects");
            DropTable("dbo.ClemencyDegrees");
        }
    }
}
