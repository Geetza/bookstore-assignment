namespace BookstoreApplication.Domain
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<AuthorAward> AuthorAwards { get; set; } = new List<AuthorAward>();
    }
}
