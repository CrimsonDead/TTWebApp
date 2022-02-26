using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TTWebApp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public float? Size { get; set; }
        public DateTime DateOfCreation { get; set; }
        [Required]
        public int? AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        //public Author Author { get; set; }
        public float? Cost { get; set; }
        public int? NumberOfPurchase { get; set; }

    }
}
