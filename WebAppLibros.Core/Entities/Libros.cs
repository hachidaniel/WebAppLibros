using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppLibros.Core.Entities
{
    public class Libros
    {
        public Libros() {
           
        }
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Description { get; set; }
        public  string Title { get; set; }
        public string Url { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
    }
}
