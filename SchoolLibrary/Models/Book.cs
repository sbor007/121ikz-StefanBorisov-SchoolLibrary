using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заглавието е задължително")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Авторът е задължителен")]
        [StringLength(60)]
        public string Author { get; set; }

        [Display(Name = "Година на издаване")]
        [Range(1900, 2100, ErrorMessage = "Въведи година между 1900 и 2100")]
        public int? PublishedYear { get; set; }

        [StringLength(30)]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Display(Name = "Налично ли е?")]
        public bool IsAvailable { get; set; } = true;
    }
}
