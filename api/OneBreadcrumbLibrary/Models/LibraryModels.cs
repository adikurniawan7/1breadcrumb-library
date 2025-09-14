using System.Text.Json.Serialization;

namespace OneBreadcrumbLibrary.Models
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("owner")]
        public string Owner { get; set; } = string.Empty;

        [JsonPropertyName("isbn")]
        public string Isbn { get; set; } = string.Empty;

        [JsonPropertyName("publishedDate")]
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        [JsonPropertyName("availability")]
        public bool Availability { get; set; }
    }

    public class BookList
    {
        [JsonPropertyName("books")]
        public List<Book>? Books { get; set; }
    }

    public class GetAllBooksResponse()
    { 
        public bool Status { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class BookResponse()
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public Book? Book { get; set; }
    }

    public class Response()
    { 
        public bool Status { get; set; }
        public string ErrorMessage { get; set; } = string.Empty; 
    }
}
