using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        
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
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public byte NumberInStock { get; set; }
        [Required]
        public byte GenreId { get; set; }
    }
}