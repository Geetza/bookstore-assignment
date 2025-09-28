using System.Security.Cryptography.X509Certificates;
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

            // ------------------- Seed Publishers -------------------
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Publisher A", Address = "Address A", Website = "https://publisherA.com" },
                new Publisher { Id = 2, Name = "Publisher B", Address = "Address B", Website = "https://publisherB.com" },
                new Publisher { Id = 3, Name = "Publisher C", Address = "Address C", Website = "https://publisherC.com" }
            );

            // ------------------- Seed Authors -------------------
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "Author One", Biography = "Bio 1", DateOfBirth = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 2, FullName = "Author Two", Biography = "Bio 2", DateOfBirth = new DateTime(1982, 2, 2, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 3, FullName = "Author Three", Biography = "Bio 3", DateOfBirth = new DateTime(1984, 3, 3, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 4, FullName = "Author Four", Biography = "Bio 4", DateOfBirth = new DateTime(1986, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
                new Author { Id = 5, FullName = "Author Five", Biography = "Bio 5", DateOfBirth = new DateTime(1988, 5, 5, 0, 0, 0, DateTimeKind.Utc) }
            );

            // ------------------- Seed Books -------------------
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book 1", PageCount = 100, PublishedDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN001", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Book 2", PageCount = 150, PublishedDate = new DateTime(2001, 2, 2, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN002", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 3, Title = "Book 3", PageCount = 200, PublishedDate = new DateTime(2002, 3, 3, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN003", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 4, Title = "Book 4", PageCount = 250, PublishedDate = new DateTime(2003, 4, 4, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN004", AuthorId = 2, PublisherId = 2 },
                new Book { Id = 5, Title = "Book 5", PageCount = 300, PublishedDate = new DateTime(2004, 5, 5, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN005", AuthorId = 3, PublisherId = 3 },
                new Book { Id = 6, Title = "Book 6", PageCount = 120, PublishedDate = new DateTime(2005, 6, 6, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN006", AuthorId = 3, PublisherId = 3 },
                new Book { Id = 7, Title = "Book 7", PageCount = 180, PublishedDate = new DateTime(2006, 7, 7, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN007", AuthorId = 4, PublisherId = 1 },
                new Book { Id = 8, Title = "Book 8", PageCount = 220, PublishedDate = new DateTime(2007, 8, 8, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN008", AuthorId = 4, PublisherId = 2 },
                new Book { Id = 9, Title = "Book 9", PageCount = 140, PublishedDate = new DateTime(2008, 9, 9, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN009", AuthorId = 5, PublisherId = 3 },
                new Book { Id = 10, Title = "Book 10", PageCount = 160, PublishedDate = new DateTime(2009, 10, 10, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN010", AuthorId = 5, PublisherId = 1 },
                new Book { Id = 11, Title = "Book 11", PageCount = 190, PublishedDate = new DateTime(2010, 11, 11, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN011", AuthorId = 1, PublisherId = 2 },
                new Book { Id = 12, Title = "Book 12", PageCount = 210, PublishedDate = new DateTime(2011, 12, 12, 0, 0, 0, DateTimeKind.Utc), ISBN = "ISBN012", AuthorId = 2, PublisherId = 3 }
            );

            // ------------------- Seed Awards -------------------
            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Award 1", Description = "Desc 1", CreatedDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Award { Id = 2, Name = "Award 2", Description = "Desc 2", CreatedDate = new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Award { Id = 3, Name = "Award 3", Description = "Desc 3", CreatedDate = new DateTime(2020, 3, 1, 0, 0, 0, DateTimeKind.Utc) },
                new Award { Id = 4, Name = "Award 4", Description = "Desc 4", CreatedDate = new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

            // ------------------- Seed AuthorAwardBridge -------------------
            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { Id = 1, AuthorId = 1, AwardId = 1, AwardedDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 2, AuthorId = 1, AwardId = 2, AwardedDate = new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 3, AuthorId = 2, AwardId = 1, AwardedDate = new DateTime(2020, 3, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 4, AuthorId = 2, AwardId = 3, AwardedDate = new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 5, AuthorId = 3, AwardId = 2, AwardedDate = new DateTime(2020, 5, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 6, AuthorId = 3, AwardId = 3, AwardedDate = new DateTime(2020, 6, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 7, AuthorId = 4, AwardId = 1, AwardedDate = new DateTime(2020, 7, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 8, AuthorId = 4, AwardId = 4, AwardedDate = new DateTime(2020, 8, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 9, AuthorId = 5, AwardId = 2, AwardedDate = new DateTime(2020, 9, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 10, AuthorId = 5, AwardId = 3, AwardedDate = new DateTime(2020, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 11, AuthorId = 1, AwardId = 4, AwardedDate = new DateTime(2020, 11, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 12, AuthorId = 2, AwardId = 4, AwardedDate = new DateTime(2020, 12, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 13, AuthorId = 3, AwardId = 4, AwardedDate = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 14, AuthorId = 4, AwardId = 2, AwardedDate = new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
                new AuthorAward { Id = 15, AuthorId = 5, AwardId = 1, AwardedDate = new DateTime(2021, 3, 1, 0, 0, 0, DateTimeKind.Utc) }
            );

        }

    }
}
