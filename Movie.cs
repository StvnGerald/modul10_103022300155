using System.Reflection;

namespace Modul10
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director {  get; set; }
        public List<string> Stars {  get; set; }
        public string Description { get; set; }

        public Movie(string title, string director, List<string> stars, string Description)
        {
            this.Title = title;
            this.Director = director;
            this.Stars = stars;
            this.Description = Description;
        }
    }
}
