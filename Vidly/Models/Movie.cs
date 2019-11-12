using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [Required]
        public byte NumberInStock { get; set; }
        [Required]
        public byte GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}