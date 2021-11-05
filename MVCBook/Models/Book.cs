using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBook.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Column(TypeName ="varchar")]
        [MaxLength(50)]
        [Required(ErrorMessage ="The Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Author must be a string with a maximun length of 50")]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Author { get; set; }

        [Range(100,10000)]
        [Required(ErrorMessage = "The field PagesNumber must be between 100 and 10000")]
        public int PagesNumber { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Publisher { get; set; }

        [RegularExpression(@"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$")]
        [Required(ErrorMessage = "Ingrese un formato de fecha válido, Por ejemplo: 2017 - 06 - 16")]
        public string PublicationDate { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string Content { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "PriceConfirm and Price do not match")]
[System.ComponentModel.DataAnnotations.Compare("Price")]
        [Column(TypeName = "money")]
        public decimal PriceConfirm { get; set; }
    }
}