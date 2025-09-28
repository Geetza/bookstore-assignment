﻿using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Author)
                .WithMany(a => a.AuthorAwards)
                .HasForeignKey(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<AuthorAward>()
                .HasOne(aa => aa.Award)
                .WithMany(a => a.AuthorAwards)
                .HasForeignKey(aa => aa.AwardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorAward>()
                .ToTable("AuthorAwardBridge");

            modelBuilder.Entity<Author>()
                .Property(a => a.DateOfBirth)
                .HasColumnName("BirthDay");

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany()
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }

    }
}
