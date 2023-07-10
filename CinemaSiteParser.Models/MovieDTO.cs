namespace CinemaSiteParser.Models
{
    public class MovieDTO
    {
        public string MovieName { get; set; }

        public string MovieLink { get; set; }

        public List<string> Technologies { get; set; }

        public string AgeRestriction { get; set; }

        public List<string> CurrentTechnologies { get; set; }     
    }
}
