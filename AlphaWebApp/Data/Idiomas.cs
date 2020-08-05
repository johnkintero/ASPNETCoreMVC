using System.Collections.Generic;

namespace AlphaWebApp.Data
{
    public class Idiomas
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public ICollection<Libros> Libros { get; set; }
    }
}