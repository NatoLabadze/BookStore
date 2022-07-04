namespace Core.Application.Dtos
{
    public class AddBookDto 
    {
        public string Title { get; set; }
        public int TotalPage { get; set; }
        public int AuthorId { get; set; }
    }
}
