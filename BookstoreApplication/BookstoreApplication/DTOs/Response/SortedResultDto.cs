namespace BookstoreApplication.DTOs.Response
{
    public class SortedResultDto<T>
    {
        public List<T> Items { get; set; }
        public string SortedBy { get; set; }        // npr. "Name" ili "Address"
        public string SortDirection { get; set; }   // "asc" ili "desc"

        public SortedResultDto(List<T> items, string sortedBy, string sortDirection)
        {
            Items = items;
            SortedBy = sortedBy;
            SortDirection = sortDirection?.ToLower() == "desc" ? "desc" : "asc";
        }
    }
}
