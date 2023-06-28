using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BackEnd.dal.entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackEnd.dal
{
    public partial class HumanRightsContext : DbContext
    {
        public HumanRightsContext()
        {
        }

        public HumanRightsContext(DbContextOptions<HumanRightsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContentOptions> ContentOptions { get; set; }
        public virtual DbSet<Contents> Contents { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<CoursesByPerson> CoursesByPerson { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesAssignedToUsers> RolesAssignedToUsers { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=hre;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentOptions>(entity =>
            {
                entity.ToTable("contentOptions", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContentId).HasColumnName("contentID");

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasColumnName("descr")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Valid).HasColumnName("valid");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.ContentOptions)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contentOptions_contents");
            });

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

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_contents_topics");
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

            modelBuilder.Entity<CoursesByPerson>(entity =>
            {
                entity.ToTable("coursesByPerson", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approved).HasColumnName("approved");

                entity.Property(e => e.Completed).HasColumnName("completed");

                entity.Property(e => e.CourseId).HasColumnName("courseID");

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CoursesByPerson)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_coursesByPerson_courses");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CoursesByPerson)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_coursesByPerson_persons");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.ToTable("persons", "lms");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Persons)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_persons_users");
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

            modelBuilder.Entity<RolesAssignedToUsers>(entity =>
            {
                entity.ToTable("rolesAssignedToUsers", "security");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesAssignedToUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_rolesAssignedToUsers_roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RolesAssignedToUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_rolesAssignedToUsers_users");
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

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_topics_courses");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users", "security");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_users_persons");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
