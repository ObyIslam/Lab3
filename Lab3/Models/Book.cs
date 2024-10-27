using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime publication { get; set; }
        public int authorID { get; set; }
        public decimal publisherID { get; set; }
        public string coverpage { get; set; }
    }
}
