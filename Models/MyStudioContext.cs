using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyStudioApp.Models
{
    public partial class MyStudioContext : DbContext
    {
        public MyStudioContext()
        {
        }

        public MyStudioContext(DbContextOptions<MyStudioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Scene> Scenes { get; set; }
        public virtual DbSet<SceneActor> SceneActors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Account");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("Actor");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .HasColumnName("image");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.Actor)
                    .HasForeignKey<Actor>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_Account");
            });

            modelBuilder.Entity<Scene>(entity =>
            {
                entity.ToTable("Scene");

                entity.Property(e => e.DateBegin).HasColumnType("date");

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.Script).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<SceneActor>(entity =>
            {
                entity.ToTable("SceneActor");

                entity.Property(e => e.ActFrom).HasMaxLength(50);

                entity.Property(e => e.ActTo).HasMaxLength(50);

                entity.Property(e => e.ActorUsername).HasMaxLength(50);

                entity.Property(e => e.Character)
                    .HasMaxLength(50)
                    .HasColumnName("character");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.ActorUsernameNavigation)
                    .WithMany(p => p.SceneActors)
                    .HasForeignKey(d => d.ActorUsername)
                    .HasConstraintName("FK_SceneActor_Actor");

                entity.HasOne(d => d.Scene)
                    .WithMany(p => p.SceneActors)
                    .HasForeignKey(d => d.SceneId)
                    .HasConstraintName("FK_SceneActor_Scene");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
