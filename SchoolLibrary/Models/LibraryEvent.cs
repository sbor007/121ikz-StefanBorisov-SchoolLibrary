using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Models
{
    public class LibraryEvent
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Име на събитието")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Локация")]
        public string Location { get; set; }
    }
}
