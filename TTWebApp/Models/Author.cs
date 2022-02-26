using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TTWebApp.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int? Age { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Text> Texts { get; set; }

    }
}
