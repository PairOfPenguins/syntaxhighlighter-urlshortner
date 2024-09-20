namespace pet2.Models.Entities
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Text {  get; set; }
        public DateTime CreationTime { get; set; }
        public string Language {  get; set; }
        public string ShortUrl { get; set; }
    }
}
