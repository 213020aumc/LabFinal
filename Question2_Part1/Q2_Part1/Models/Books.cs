using System;
using System.Collections.Generic;

namespace Q2_Part1.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? BookAuthor { get; set; }
        public int? Isbn { get; set; }
        public string? PublicationYear { get; set; }
    }
}
