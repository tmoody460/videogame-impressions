using System.Collections.Generic;

namespace VideoGameImpressions.Models.Custom
{
    public class VideoGame
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
    }

    public class VideoGameWithNotes
    {
        public VideoGame VideoGame { get; set; }
        public List<Note> Notes { get; set; }
    }
}