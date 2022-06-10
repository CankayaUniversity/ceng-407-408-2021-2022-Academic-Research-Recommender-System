using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class hypercorrectContext : DbContext
    {
        public hypercorrectContext()
        {
        }

        public hypercorrectContext(DbContextOptions<hypercorrectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area2> Area2s { get; set; }
        public virtual DbSet<Area3> Area3s { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<CosineSimilarity> CosineSimilarities { get; set; }
        public virtual DbSet<CrawlerLastPagenum> CrawlerLastPagenums { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<NewPapersId> NewPapersIds { get; set; }
        public virtual DbSet<Paper> Papers { get; set; }
        public virtual DbSet<Paperrating> Paperratings { get; set; }
        public virtual DbSet<Papers5> Papers5s { get; set; }
        public virtual DbSet<Papers6> Papers6s { get; set; }
        public virtual DbSet<Papers7> Papers7s { get; set; }
        public virtual DbSet<PapersTask> PapersTasks { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Task2> Task2s { get; set; }
        public virtual DbSet<Task3> Task3s { get; set; }
        public virtual DbSet<TestTable> TestTables { get; set; }
        public virtual DbSet<TitAbsVec> TitAbsVecs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=hyperdb;Username=postgres;Password=1998");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_Turkey.1254");

            modelBuilder.Entity<Area2>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("area2_pkey");

                entity.ToTable("area2");

                entity.Property(e => e.AreaId)
                    .HasColumnType("character varying")
                    .HasColumnName("area_id");

                entity.Property(e => e.AreaName)
                    .HasColumnType("character varying")
                    .HasColumnName("area_name");
            });

            modelBuilder.Entity<Area3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("area3");

                entity.Property(e => e.AreaId)
                    .HasColumnType("character varying")
                    .HasColumnName("area_id");

                entity.Property(e => e.AreaName)
                    .HasColumnType("character varying")
                    .HasColumnName("area_name");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEnd).HasColumnType("timestamp with time zone");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CosineSimilarity>(entity =>
            {
                entity.HasKey(e => e.SimilarityNumber)
                    .HasName("cosine_similarity_pkey");

                entity.ToTable("cosine_similarity");

                entity.Property(e => e.SimilarityNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("similarity_number");

                entity.Property(e => e.ComparePaperId)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("compare_paper_id");

                entity.Property(e => e.NewPaperId)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("new_paper_id");

                entity.Property(e => e.Similarity).HasColumnName("similarity");
            });

            modelBuilder.Entity<CrawlerLastPagenum>(entity =>
            {
                entity.HasKey(e => e.LastPageNum)
                    .HasName("crawler_last_pagenum_pkey");

                entity.ToTable("crawler_last_pagenum");

                entity.Property(e => e.LastPageNum)
                    .ValueGeneratedNever()
                    .HasColumnName("last_page_num");
            });

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.HasKey(e => e.Fnumber)
                    .HasName("favourites_pkey");

                entity.ToTable("favourites");

                entity.Property(e => e.Fnumber).HasColumnName("fnumber");

                entity.Property(e => e.Fpaper)
                    .HasMaxLength(256)
                    .HasColumnName("fpaper");

                entity.Property(e => e.Fuser)
                    .HasMaxLength(256)
                    .HasColumnName("fuser");
            });

            modelBuilder.Entity<NewPapersId>(entity =>
            {
                entity.ToTable("new_papers_ids");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Paper>(entity =>
            {
                entity.ToTable("papers");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Abstract)
                    .HasColumnType("character varying")
                    .HasColumnName("abstract");

                entity.Property(e => e.Authors)
                    .HasColumnType("character varying")
                    .HasColumnName("authors");

                entity.Property(e => e.GithubUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("github_url");

                entity.Property(e => e.PdfUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("pdf_url");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("published_date");

                entity.Property(e => e.TaskTypes)
                    .HasColumnType("character varying")
                    .HasColumnName("task_types");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.ViewCounter).HasColumnName("view_counter");

                entity.Property(e => e.VoteCounter).HasColumnName("vote_counter");

                entity.Property(e => e.VoteTotal).HasColumnName("vote_total");
            });

            modelBuilder.Entity<Paperrating>(entity =>
            {
                entity.ToTable("paperrating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Paperid)
                    .HasMaxLength(255)
                    .HasColumnName("paperid");

                entity.Property(e => e.Rating).HasColumnName("rating");
            });

            modelBuilder.Entity<Papers5>(entity =>
            {
                entity.ToTable("papers5");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Abstract)
                    .HasColumnType("character varying")
                    .HasColumnName("abstract");

                entity.Property(e => e.Authors)
                    .HasColumnType("character varying")
                    .HasColumnName("authors");

                entity.Property(e => e.DoneTask).HasColumnName("done_task");

                entity.Property(e => e.DoneTasksStr).HasColumnName("done_tasks_str");

                entity.Property(e => e.GithubUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("github_url");

                entity.Property(e => e.PdfUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("pdf_url");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("published_date");

                entity.Property(e => e.RsponseFourzrofour).HasColumnName("rsponse_fourzrofour");

                entity.Property(e => e.TaskTypes)
                    .HasColumnType("character varying")
                    .HasColumnName("task_types");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.ViewCounter).HasColumnName("view_counter");

                entity.Property(e => e.VoteCounter).HasColumnName("vote_counter");

                entity.Property(e => e.VoteTotal).HasColumnName("vote_total");
            });

            modelBuilder.Entity<Papers6>(entity =>
            {
                entity.ToTable("papers6");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Abstract)
                    .HasColumnType("character varying")
                    .HasColumnName("abstract");

                entity.Property(e => e.Authors)
                    .HasColumnType("character varying")
                    .HasColumnName("authors");

                entity.Property(e => e.DoneTask).HasColumnName("done_task");

                entity.Property(e => e.DoneTasksStr).HasColumnName("done_tasks_str");

                entity.Property(e => e.DoneVec).HasColumnName("done_vec");

                entity.Property(e => e.GithubUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("github_url");

                entity.Property(e => e.PdfUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("pdf_url");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("published_date");

                entity.Property(e => e.RsponseFourzrofour).HasColumnName("rsponse_fourzrofour");

                entity.Property(e => e.TaskTypes)
                    .HasColumnType("character varying")
                    .HasColumnName("task_types");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.ViewCounter)
                    .HasColumnName("view_counter")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VoteCounter)
                    .HasColumnName("vote_counter")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VoteTotal)
                    .HasColumnName("vote_total")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Papers7>(entity =>
            {
                entity.ToTable("papers7");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Abstract)
                    .HasColumnType("character varying")
                    .HasColumnName("abstract");

                entity.Property(e => e.Authors)
                    .HasColumnType("character varying")
                    .HasColumnName("authors");

                entity.Property(e => e.DoneTask).HasColumnName("done_task");

                entity.Property(e => e.DoneTasksStr).HasColumnName("done_tasks_str");

                entity.Property(e => e.DoneVec).HasColumnName("done_vec");

                entity.Property(e => e.GithubUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("github_url");

                entity.Property(e => e.PdfUrl)
                    .HasColumnType("character varying")
                    .HasColumnName("pdf_url");

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("published_date");

                entity.Property(e => e.RsponseFourzrofour).HasColumnName("rsponse_fourzrofour");

                entity.Property(e => e.TaskTypes)
                    .HasColumnType("character varying")
                    .HasColumnName("task_types");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.ViewCounter)
                    .HasColumnName("view_counter")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VoteCounter)
                    .HasColumnName("vote_counter")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.VoteTotal)
                    .HasColumnName("vote_total")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PapersTask>(entity =>
            {
                entity.HasKey(e => e.IdNumber)
                    .HasName("papers_tasks_pkey");

                entity.ToTable("papers_tasks");

                entity.Property(e => e.IdNumber).HasColumnName("id_number");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Task)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("task");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.TaskId)
                    .HasColumnType("character varying")
                    .HasColumnName("task_id");

                entity.Property(e => e.AreaType)
                    .HasColumnType("character varying")
                    .HasColumnName("area_type");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.TaskName)
                    .HasColumnType("character varying")
                    .HasColumnName("task_name");
            });

            modelBuilder.Entity<Task2>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("task2_pkey");

                entity.ToTable("task2");

                entity.Property(e => e.TaskId)
                    .HasColumnType("character varying")
                    .HasColumnName("task_id");

                entity.Property(e => e.AreaType)
                    .HasColumnType("character varying")
                    .HasColumnName("area_type");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.DoneQuantity).HasColumnName("done_quantity");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TaskName)
                    .HasColumnType("character varying")
                    .HasColumnName("task_name");
            });

            modelBuilder.Entity<Task3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("task3");

                entity.Property(e => e.AreaType).HasColumnName("area_type");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.TaskId)
                    .HasColumnType("character varying")
                    .HasColumnName("task_id");

                entity.Property(e => e.TaskName)
                    .HasColumnType("character varying")
                    .HasColumnName("task_name");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasKey(e => e.Titid)
                    .HasName("test_table_pkey");

                entity.ToTable("test_table");

                entity.Property(e => e.Titid).HasColumnName("titid");

                entity.Property(e => e.Titlevev).HasColumnName("titlevev");
            });

            modelBuilder.Entity<TitAbsVec>(entity =>
            {
                entity.ToTable("tit_abs_vec");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.Absvec).HasColumnName("absvec");

                entity.Property(e => e.PreviouslyAdded).HasColumnName("previously_added");

                entity.Property(e => e.Titvec).HasColumnName("titvec");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasDefaultValueSql("nextval('papers_tasks_id_number_seq'::regclass)");

                entity.Property(e => e.MailAddress)
                    .HasColumnType("character varying")
                    .HasColumnName("mailAddress");

                entity.Property(e => e.PaperNumber)
                    .HasColumnName("paperNumber")
                    .HasDefaultValueSql("20");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Preference)
                    .HasColumnName("preference")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.SimilarityRate)
                    .HasColumnName("similarityRate ")
                    .HasDefaultValueSql("0.8");

                entity.Property(e => e.UserName)
                    .HasColumnType("character varying")
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
