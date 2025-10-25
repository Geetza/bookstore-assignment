using BookstoreApplication.Domain;
using Microsoft.VisualBasic;

namespace BookstoreApplication.DTOs.Response
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }

        public string? AuthorFullName { get; set; }
        public string? PublisherName { get; set; }
        public int YearsAfterPublished { get; set; }
    }
}
