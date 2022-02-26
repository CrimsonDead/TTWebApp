using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TTWebApp.Models
{
    public class Text
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float? Size { get; set; }
        public DateTime DateOfCreation { get; set; }
        public float? Cost { get; set; }
        [Required]
        public int? AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        //public Author Author { get; set; }
        public int? NumberOfPurchase { get; set; }

    }
}
