using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TTWebApp.Models
{
    public class Author : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int? Age { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Text> Texts { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
