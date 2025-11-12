using BookstoreApplication.Domain;

namespace BookstoreApplication.DTOs.Response
{
    public class AuthorDto
    {
        public string FullName { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
