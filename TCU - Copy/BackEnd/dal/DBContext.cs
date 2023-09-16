using bend.dal.entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace bend.dal
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Options> Options { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<UserContents> UserContents { get; set; }
        public virtual DbSet<UserCourses> UserCourses { get; set; }
        public virtual DbSet<UserResponses> UserResponses { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuración para usar el connection string almacenado en appsettings.json
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("HumanRights"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contents>(entity =>
            {
                entity.ToTable("contents", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasColumnName("contentType")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.TopicId).HasColumnName("topicID");

                /*
                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("fk_contents_topics"); // */
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.ToTable("courses", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Course)
                    .IsRequired()
                    .HasColumnName("course")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnName("descr")
                    .HasColumnType("text");

                entity.Property(e => e.Enabled).HasColumnName("enabled");
            });

            modelBuilder.Entity<Options>(entity =>
            {
                entity.ToTable("options", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentId).HasColumnName("contentID");

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnName("descr")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Valid).HasColumnName("valid");

                /*
                entity.HasOne(d => d.Content)
                    .WithMany(p => p.Options)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("fk_options_contents"); // */
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles", "security");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topics>(entity =>
            {
                entity.ToTable("topics", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasColumnName("topic")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                /*
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("fk_topics_courses"); // */
            });

            modelBuilder.Entity<UserContents>(entity =>
            {
                entity.ToTable("userContents", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.ContentId).HasColumnName("contentID");

                entity.Property(e => e.UserId).HasColumnName("userID");
                
                /*
                entity.HasOne(d => d.Content)
                    .WithMany(p => p.UserContents)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("fk_userContents_contents");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserContents)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userContents_users"); // */
            });

            modelBuilder.Entity<UserCourses>(entity =>
            {
                entity.ToTable("userCourses", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                /*
                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("fk_userCourses_courses");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCourses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userCourses_users"); // */
            });

            modelBuilder.Entity<UserResponses>(entity =>
            {
                entity.ToTable("userResponses", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentId).HasColumnName("contentID");

                entity.Property(e => e.OptionId).HasColumnName("optionID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                /*
                entity.HasOne(d => d.Content)
                    .WithMany(p => p.UserResponses)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("fk_userResponses_contents");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.UserResponses)
                    .HasForeignKey(d => d.OptionId)
                    .HasConstraintName("fk_userResponses_options");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserResponses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userResponses_users"); // */
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.ToTable("userRoles", "security");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("fk_userRoles_roles");
                
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_userRoles_users"); // */
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "security");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
