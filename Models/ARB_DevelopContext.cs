using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using ARBDashboard;
using Microsoft.Extensions.Options;

namespace ARBDashboard.Models
{
    public partial class ARB_DevelopContext : DbContext
    {
        private readonly IOptions<DBSettings> dbSettings;

        public ARB_DevelopContext(DbContextOptions<ARB_DevelopContext> dbContextOptions, IOptions<DBSettings> _dbSettings) : base(dbContextOptions) 
        {
            dbSettings = _dbSettings;
            Database.SetCommandTimeout(150000);
        }


        public virtual DbSet<ActionItem> ActionItems { get; set; }
        public virtual DbSet<ActionItemAttachment> ActionItemAttachments { get; set; }
        public virtual DbSet<ActionItemType> ActionItemTypes { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<DmacceptComment> DmacceptComments { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<ExceptionLogging> ExceptionLoggings { get; set; }
        public virtual DbSet<Gheastandard> Gheastandards { get; set; }
        public virtual DbSet<GheastandardsUsed> GheastandardsUseds { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<PackageAcceptance> PackageAcceptances { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionResponse> QuestionResponses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RequestForm> RequestForms { get; set; }
        public virtual DbSet<ResolutionStrategy> ResolutionStrategies { get; set; }
        public virtual DbSet<ResourceAssignment> ResourceAssignments { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<ReviewerAssignment> ReviewerAssignments { get; set; }
        public virtual DbSet<ReviewerDomainAssignment> ReviewerDomainAssignments { get; set; }
        public virtual DbSet<ReviewStage> ReviewStages { get; set; }
        public virtual DbSet<ReviewType> ReviewTypes { get; set; }
        public virtual DbSet<RiskCategory> RiskCategories { get; set; }
        public virtual DbSet<RiskCategoryAssignment> RiskCategoryAssignments { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (dbSettings==null) {
                string db = "Data Source=172.24.3.69;Initial Catalog=ARB_Develop;User ID=sa;Password=Welcome@321;Connection Timeout=100";
                optionsBuilder.UseSqlServer(db);
            }
            else {
                if (!optionsBuilder.IsConfigured)
                {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                    optionsBuilder.UseSqlServer(dbSettings.Value.ConnectionString);

                } }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionItem>(entity =>
            {
                entity.Property(e => e.ActionItemId).HasColumnName("ActionItemID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.DateClosed).HasColumnType("datetime");

                entity.Property(e => e.DateEntered).HasColumnType("datetime");

                entity.Property(e => e.DateResolved).HasColumnType("datetime");

                entity.Property(e => e.DomainId).HasColumnName("DomainID");

                entity.Property(e => e.DueByDate).HasColumnType("datetime");

                entity.Property(e => e.DueByEvent).HasMaxLength(5);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.ActionItemTypeNavigation)
                    .WithMany(p => p.ActionItems)
                    .HasForeignKey(d => d.ActionItemType)
                    .HasConstraintName("FK_ActionItems_ActionItemTypes");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.ActionItems)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("FK_Domains_DomainID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ActionItems)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionItems_RequestForms");
            });

            modelBuilder.Entity<ActionItemAttachment>(entity =>
            {
                entity.Property(e => e.ActionitemAttachmentId).HasColumnName("ActionitemAttachmentID");

                entity.Property(e => e.ActionItemId).HasColumnName("ActionItemID");

                entity.Property(e => e.AttachmentLocation).IsRequired();

                entity.Property(e => e.AttachmentName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.ActionItem)
                    .WithMany(p => p.ActionItemAttachments)
                    .HasForeignKey(d => d.ActionItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionItemAttachments_ActionItems");
            });

            modelBuilder.Entity<ActionItemType>(entity =>
            {
                entity.Property(e => e.ActionItemTypeId).HasColumnName("ActionItemTypeID");

                entity.Property(e => e.ActionItemType1)
                    .HasColumnName("ActionItemType")
                    .HasMaxLength(50);

                entity.Property(e => e.ParentTypeId).HasColumnName("ParentTypeID");
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.AttachmentName).HasMaxLength(50);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Attachments)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attachments_RequestForms");
            });

            modelBuilder.Entity<DmacceptComment>(entity =>
            {
                entity.HasKey(e => e.DmacceptCommentsId);

                entity.ToTable("DMAcceptComments");

                entity.Property(e => e.DmacceptCommentsId).HasColumnName("DMAcceptCommentsID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.ReviewType)
                    .WithMany(p => p.DmacceptComments)
                    .HasForeignKey(d => d.Acceptance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DMAcceptComments_ReviewType");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.DmacceptComments)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DMAcceptComments_RequestForms");
            });

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.Property(e => e.DomainId).HasColumnName("DomainID");

                entity.Property(e => e.DomainName).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasKey(e => e.EventLogItemId);

                entity.ToTable("EventLog");

                entity.Property(e => e.EventLogItemId).HasColumnName("EventLogItemID");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Domain).HasMaxLength(50);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.EventLogs)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventLog_RequestForms");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.EventType1)
                    .HasColumnName("EventType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExceptionLogging>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("ExceptionLogging");

                entity.Property(e => e.AdditionalInfo).IsUnicode(false);

                entity.Property(e => e.Exception)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionDetails).IsUnicode(false);

                entity.Property(e => e.ExceptionUrl)
                    .HasColumnName("ExceptionURL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.LogType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LoggedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gheastandard>(entity =>
            {
                entity.ToTable("GHEAStandards");

                entity.Property(e => e.GheastandardId).HasColumnName("GHEAStandardID");

                entity.Property(e => e.GheastandardName)
                    .HasColumnName("GHEAStandardName")
                    .HasMaxLength(50);

                entity.Property(e => e.GheastandardType)
                    .HasColumnName("GHEAStandardType")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<GheastandardsUsed>(entity =>
            {
                entity.ToTable("GHEAStandardsUsed");

                entity.Property(e => e.GheastandardsUsedId).HasColumnName("GHEAStandardsUsedId");

                entity.Property(e => e.GheastandardId).HasColumnName("GHEAStandardID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Gheastandard)
                    .WithMany(p => p.GheastandardsUseds)
                    .HasForeignKey(d => d.GheastandardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GHEAStandardsUsed_GHEAStandards");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.GheastandardsUseds)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GHEAStandardsUsed_RequestForms");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.HolidayDate).HasColumnType("datetime");

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackageAcceptance>(entity =>
            {
                entity.HasKey(e => e.AcceptanceId);

                entity.ToTable("PackageAcceptance");

                entity.Property(e => e.AcceptanceId).HasColumnName("AcceptanceID");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.PackageComment).IsUnicode(false);

                entity.Property(e => e.PackageResult).HasMaxLength(50);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.Property(e => e.ProjectTypeId).HasColumnName("ProjectTypeID");

                entity.Property(e => e.ProjectType1)
                    .HasColumnName("ProjectType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Commentoptions).HasMaxLength(10);

                entity.HasOne(d => d.DomainNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Domain)
                    .HasConstraintName("FK_Questions_Domain");
            });

            modelBuilder.Entity<QuestionResponse>(entity =>
            {
                entity.Property(e => e.QuestionResponseId).HasColumnName("QuestionResponseID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.ResponseValue).HasMaxLength(50);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuestionResponses)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_QuestionResponses_Questions");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.QuestionResponses)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionResponses_RequestForms");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RegionName).HasMaxLength(50);

                entity.Property(e => e.RegionToken).HasMaxLength(6);
            });

            modelBuilder.Entity<RequestForm>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.BusinessScope).IsRequired();

                entity.Property(e => e.DateEntered).HasColumnType("datetime");

                entity.Property(e => e.DateOfArb)
                    .HasColumnName("DateOfARB")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateRequested).HasColumnType("datetime");

                entity.Property(e => e.DmreviewDecision)
                    .HasColumnName("DMReviewDecision")
                    .HasMaxLength(50);

                entity.Property(e => e.DmreviewDecisionComment).HasColumnName("DMReviewDecisionComment");

                entity.Property(e => e.DmreviewDecisionDate)
                    .HasColumnName("DMReviewDecisionDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DuebyDate).HasColumnType("datetime");

                entity.Property(e => e.EnteredBy).HasMaxLength(50);

                entity.Property(e => e.EstProjectCostJ0).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EstTotalCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InfrastructurePm)
                    .HasColumnName("InfrastructurePM")
                    .HasMaxLength(50);

                entity.Property(e => e.JeventDate)
                    .HasColumnName("JEventDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NetNewComments).HasMaxLength(200);

                entity.Property(e => e.PackageSubmissionDate).HasColumnType("datetime");

                entity.Property(e => e.Phase).HasMaxLength(10);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(25);

                entity.Property(e => e.ProjectManager).HasMaxLength(50);

                entity.Property(e => e.ProjectName).HasMaxLength(50);

                entity.Property(e => e.ReviewerReviewDecision).HasMaxLength(50);

                entity.Property(e => e.ReviewerReviewDecisionDate).HasColumnType("datetime");

                entity.Property(e => e.SecurityArchitect).HasMaxLength(50);

                entity.Property(e => e.SolutionArchitect).HasMaxLength(50);

                entity.Property(e => e.StandardBasedComments).HasMaxLength(200);

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Region1)
                    .WithMany(p => p.RequestForms)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestForms_Regions");

                entity.HasOne(d => d.ReviewStage)
                    .WithMany(p => p.RequestForms)
                    .HasForeignKey(d => d.Stage)
                    .HasConstraintName("FK_RequestForms_Stage");
            });

            modelBuilder.Entity<ResolutionStrategy>(entity =>
            {
                entity.ToTable("ResolutionStrategy");

                entity.Property(e => e.ResolutionStrategyId).HasColumnName("ResolutionStrategyID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<ResourceAssignment>(entity =>
            {
                entity.Property(e => e.ResourceAssignmentId).HasColumnName("ResourceAssignmentID");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.ResourceEmail).HasMaxLength(50);

                entity.Property(e => e.ResourceName).HasMaxLength(50);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ResourceAssignments)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ResourceAssignments_RequestForms");
            });

            modelBuilder.Entity<Reviewer>(entity =>
            {
                entity.Property(e => e.ReviewerId).HasColumnName("ReviewerID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ReviewerEmail).HasMaxLength(50);

                entity.Property(e => e.ReviewerName).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<ReviewerAssignment>(entity =>
            {
                entity.Property(e => e.DomainId).HasColumnName("DomainID");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.Result).HasMaxLength(50);

                entity.Property(e => e.ReviewerId).HasColumnName("ReviewerID");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.ReviewerAssignments)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewerAssignments_Domain");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.ReviewerAssignments)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewerAssignments_RequestForms");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.ReviewerAssignments)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewerAssignments_Reviewers1");
            });

            modelBuilder.Entity<ReviewerDomainAssignment>(entity =>
            {
                entity.HasKey(e => e.DomainAssignmentId);

                entity.ToTable("ReviewerDomainAssignment");

                entity.Property(e => e.DomainAssignmentId).HasColumnName("DomainAssignmentID");

                entity.Property(e => e.DomainId).HasColumnName("DomainID");

                entity.Property(e => e.ReviewerId).HasColumnName("ReviewerID");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.ReviewerDomainAssignments)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewerDomainAssignment_Domains");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.ReviewerDomainAssignments)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewerDomainAssignment_Reviewers");
            });

            modelBuilder.Entity<ReviewStage>(entity =>
            {
                entity.HasKey(e => e.StageId);

                entity.ToTable("ReviewStage");

                entity.Property(e => e.StageId)
                    .HasColumnName("StageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.RequestStatus).HasMaxLength(50);

                entity.Property(e => e.StageName).HasMaxLength(50);
            });

            modelBuilder.Entity<ReviewType>(entity =>
            {
                entity.ToTable("ReviewType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RiskCategory>(entity =>
            {
                entity.Property(e => e.RiskCategoryId).HasColumnName("RiskCategoryID");

                entity.Property(e => e.RiskCategory1)
                    .HasColumnName("RiskCategory")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RiskCategoryAssignment>(entity =>
            {
                entity.Property(e => e.RiskCategoryAssignmentId).HasColumnName("RiskCategoryAssignmentID");

                entity.Property(e => e.ActionItemId).HasColumnName("ActionItemID");

                entity.Property(e => e.RiskCategoryId).HasColumnName("RiskCategoryID");

                entity.HasOne(d => d.ActionItem)
                    .WithMany(p => p.RiskCategoryAssignments)
                    .HasForeignKey(d => d.ActionItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RiskCategoryAssignments_ActionItems");

                entity.HasOne(d => d.RiskCategory)
                    .WithMany(p => p.RiskCategoryAssignments)
                    .HasForeignKey(d => d.RiskCategoryId)
                    .HasConstraintName("FK_RiskCategoryAssignments_RiskCategories");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.SettingsId);

                entity.Property(e => e.SettingsId).HasColumnName("SettingsID");

                entity.Property(e => e.SettingsKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SettingsValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
