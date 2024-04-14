namespace Entities
{
    public class MediaSongDTO
    {
        public Guid TransactionId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public TimeOnly Duration { get; set; }  
        public string GenreType { get; set; }  
        public DateTime ReleaseDate { get; set; }  
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }   
    }

    public class MediaSongEntity : MediaSongDTO
    {
    }
}
