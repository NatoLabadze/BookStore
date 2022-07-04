namespace Core.Application.Dtos
{
    public class UpdateBookDto 
    { 
        public int Id { get; set; } 
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int TotalPage { get; set; }
       
    }
}
