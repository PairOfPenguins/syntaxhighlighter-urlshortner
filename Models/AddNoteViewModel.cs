namespace pet2.Models
{
    public class AddNoteViewModel
    {
        public string Text { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string Language { get; set; } = "test";
    }
}
