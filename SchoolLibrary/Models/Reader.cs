using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Models
{
    public class Reader
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; }

        [EmailAddress]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Клас/Група")]
        public string ClassName { get; set; }
    }
}
