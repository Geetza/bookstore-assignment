using System.Text.Json.Serialization;

namespace BookstoreApplication.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishedDate { get; set; }
        public required string ISBN { get; set; }

        public int AuthorId { get; set; }

        [JsonIgnore]
        public Author? Author { get; set; }

        public int PublisherId { get; set; }

        [JsonIgnore]
        public Publisher? Publisher { get; set; }
    }
}
