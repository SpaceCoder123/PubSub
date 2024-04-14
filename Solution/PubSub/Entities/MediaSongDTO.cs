using System.Globalization;
using System.Text.Json.Serialization;

namespace Entities
{
    public class MediaSongDTO
    {
        [JsonIgnore]
        public Guid TransactionId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        private TimeSpan _duration;
        public string Duration
        {
            get { return _duration.ToString(@"hh\:mm\:ss"); }
            set { _duration = TimeSpan.ParseExact(value, @"hh\:mm\:ss", CultureInfo.InvariantCulture); }
        }

        public string GenreType { get; set; }  
        public DateTime ReleaseDate { get; set; }  
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }   
    }

    public class MediaSongEntity : MediaSongDTO
    {
    }
}