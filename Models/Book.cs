using System.ComponentModel.DataAnnotations;

namespace BooksRazorPages.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }
    }
}
