namespace FlixHub.DTO.MovieDTO
{
    public class MovieUpdateDTO
    {

        public string Name { get; set; }
       
        public string Description { get; set; }
        
        public DateTime ReleaseDate { get; set; }
       
        public int TotalTicketsAvailable { get; set; }
        
        public string Genre { get; set; }
    }
}
