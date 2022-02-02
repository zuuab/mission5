using System;
using System.ComponentModel.DataAnnotations;
namespace mission5.Models
{
    public class AddMovie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage ="Category is a required field")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is a required field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is a required field")]
        public short Year { get; set; }

        [Required(ErrorMessage = "Director is a required field")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Rating is a required field")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
