using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ------------------- Seed Publishers -------------------
            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name", "Address", "Website" },
                values: new object[,]
                {
            { 1, "Publisher A", "Address A", "https://publisherA.com" },
            { 2, "Publisher B", "Address B", "https://publisherB.com" },
            { 3, "Publisher C", "Address C", "https://publisherC.com" }
                });

            // ------------------- Seed Authors -------------------
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName", "Biography", "BirthDay" },
                values: new object[,]
                {
            { 1, "Author One", "Bio 1", new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 2, "Author Two", "Bio 2", new DateTime(1982, 2, 2, 0, 0, 0, DateTimeKind.Utc) },
            { 3, "Author Three", "Bio 3", new DateTime(1984, 3, 3, 0, 0, 0, DateTimeKind.Utc) },
            { 4, "Author Four", "Bio 4", new DateTime(1986, 4, 4, 0, 0, 0, DateTimeKind.Utc) },
            { 5, "Author Five", "Bio 5", new DateTime(1988, 5, 5, 0, 0, 0, DateTimeKind.Utc) }
                });

            // ------------------- Seed Books -------------------
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Title", "PageCount", "PublishedDate", "ISBN", "AuthorId", "PublisherId" },
                values: new object[,]
                {
            { 1, "Book 1", 100, new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), "ISBN001", 1, 1 },
            { 2, "Book 2", 150, new DateTime(2001, 2, 2, 0, 0, 0, DateTimeKind.Utc), "ISBN002", 1, 1 },
            { 3, "Book 3", 200, new DateTime(2002, 3, 3, 0, 0, 0, DateTimeKind.Utc), "ISBN003", 2, 2 },
            { 4, "Book 4", 250, new DateTime(2003, 4, 4, 0, 0, 0, DateTimeKind.Utc), "ISBN004", 2, 2 },
            { 5, "Book 5", 300, new DateTime(2004, 5, 5, 0, 0, 0, DateTimeKind.Utc), "ISBN005", 3, 3 },
            { 6, "Book 6", 120, new DateTime(2005, 6, 6, 0, 0, 0, DateTimeKind.Utc), "ISBN006", 3, 3 },
            { 7, "Book 7", 180, new DateTime(2006, 7, 7, 0, 0, 0, DateTimeKind.Utc), "ISBN007", 4, 1 },
            { 8, "Book 8", 220, new DateTime(2007, 8, 8, 0, 0, 0, DateTimeKind.Utc), "ISBN008", 4, 2 },
            { 9, "Book 9", 140, new DateTime(2008, 9, 9, 0, 0, 0, DateTimeKind.Utc), "ISBN009", 5, 3 },
            { 10, "Book 10", 160, new DateTime(2009, 10, 10, 0, 0, 0, DateTimeKind.Utc), "ISBN010", 5, 1 },
            { 11, "Book 11", 190, new DateTime(2010, 11, 11, 0, 0, 0, DateTimeKind.Utc), "ISBN011", 1, 2 },
            { 12, "Book 12", 210, new DateTime(2011, 12, 12, 0, 0, 0, DateTimeKind.Utc), "ISBN012", 2, 3 }
                });

            // ------------------- Seed Awards -------------------
            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Name", "Description", "CreatedDate" },
                values: new object[,]
                {
            { 1, "Award 1", "Desc 1", new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 2, "Award 2", "Desc 2", new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 3, "Award 3", "Desc 3", new DateTime(2020, 3, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 4, "Award 4", "Desc 4", new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc) }
                });

            // ------------------- Seed AuthorAwardBridge -------------------
            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "Id", "AuthorId", "AwardId", "AwardedDate" },
                values: new object[,]
                {
            { 1, 1, 1, new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 2, 1, 2, new DateTime(2020, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 3, 2, 1, new DateTime(2020, 3, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 4, 2, 3, new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 5, 3, 2, new DateTime(2020, 5, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 6, 3, 3, new DateTime(2020, 6, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 7, 4, 1, new DateTime(2020, 7, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 8, 4, 4, new DateTime(2020, 8, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 9, 5, 2, new DateTime(2020, 9, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 10, 5, 3, new DateTime(2020, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 11, 1, 4, new DateTime(2020, 11, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 12, 2, 4, new DateTime(2020, 12, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 13, 3, 4, new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 14, 4, 2, new DateTime(2021, 2, 1, 0, 0, 0, DateTimeKind.Utc) },
            { 15, 5, 1, new DateTime(2021, 3, 1, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ako želiš rollback, ovde možeš brisati iste podatke
            migrationBuilder.DeleteData(table: "AuthorAwardBridge", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
            migrationBuilder.DeleteData(table: "Awards", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4 });
            migrationBuilder.DeleteData(table: "Books", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            migrationBuilder.DeleteData(table: "Authors", keyColumn: "Id", keyValues: new object[] { 1, 2, 3, 4, 5 });
            migrationBuilder.DeleteData(table: "Publishers", keyColumn: "Id", keyValues: new object[] { 1, 2, 3 });
        }

    }
}
