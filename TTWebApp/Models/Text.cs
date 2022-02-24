using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TTWebApp.Models
{
    public class Text : ICloneable
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float? Size { get; set; }
        public DateTime DateOfCreation { get; set; }
        public float? Cost { get; set; }
        public int? AuthorId { get; set; }
        public int? NumberOfPurchase { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
