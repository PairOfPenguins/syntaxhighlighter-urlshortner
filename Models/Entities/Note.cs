﻿namespace pet2.Models.Entities
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Text {  get; set; }
        public DateTime CreationdDate { get; set; }
        public string Language {  get; set; }
    }
}
