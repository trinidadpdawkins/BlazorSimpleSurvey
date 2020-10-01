﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorSimpleSurvey.Models;

namespace BlazorSimpleSurvey.Data
{
    public partial class SimpleSurveyContext : DbContext
    {
        public SimpleSurveyContext()
        {
        }

        public SimpleSurveyContext(DbContextOptions<SimpleSurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswer { get; set; }
        public virtual DbSet<SurveyItem> SurveyItem { get; set; }
        public virtual DbSet<SurveyItemOption> SurveyItemOption { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.HasIndex(e => e.LogType)
                    .HasName("IX_Logs");

                entity.Property(e => e.LogDate).HasColumnType("datetime");

                entity.Property(e => e.LogDetail)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.LogIpaddress)
                    .IsRequired()
                    .HasColumnName("LogIPAddress")
                    .HasMaxLength(500);

                entity.Property(e => e.LogType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LogUser)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.LogUserId)
                    .HasConstraintName("FK_Logs_Users");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.SurveyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Survey)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Survey_Users");
            });

            modelBuilder.Entity<SurveyAnswer>(entity =>
            {
                entity.Property(e => e.AnswerValue)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.SurveyItem)
                    .WithMany(p => p.SurveyAnswer)
                    .HasForeignKey(d => d.SurveyItemId)
                    .HasConstraintName("FK_SurveyAnswer_SurveyItem");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SurveyAnswer)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SurveyAnswer_Users");
            });

            modelBuilder.Entity<SurveyItem>(entity =>
            {
                entity.Property(e => e.ItemLabel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemValue).HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.SurveyNavigation)
                    .WithMany(p => p.SurveyItem)
                    .HasForeignKey(d => d.Survey)
                    .HasConstraintName("FK_SurveyItem_Survey");

                entity.HasOne(d => d.SurveyChoice)
                    .WithMany(p => p.SurveyItem)
                    .HasForeignKey(d => d.SurveyChoiceId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SurveyItem_SurveyItemOption");
            });

            modelBuilder.Entity<SurveyItemOption>(entity =>
            {
                entity.Property(e => e.OptionLabel)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.AuthenticationType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayName).HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.FirstName).HasMaxLength(500);

                entity.Property(e => e.IdentityProvider)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastAuthTime).HasColumnName("LastAuth_time");

                entity.Property(e => e.LastIpaddress)
                    .IsRequired()
                    .HasColumnName("LastIPAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(500);

                entity.Property(e => e.LastidpAccessToken)
                    .HasColumnName("Lastidp_access_token")
                    .HasMaxLength(4000);

                entity.Property(e => e.Objectidentifier)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SigninMethod).HasMaxLength(500);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}