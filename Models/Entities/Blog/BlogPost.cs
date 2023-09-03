namespace TechChallengeTwo.Models.Entities.Blog
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}
