using System.Collections.Generic;
using System.Linq;
using AlphaWebApp.Data;
using AlphaWebApp.Models;

namespace AlphaWebApp.Repository
{
    public class LanguageRepository 
    {
        public readonly TiendaLibrosContext _context = null;

        public LanguageRepository(TiendaLibrosContext context)
        {
            _context = context;
        }
        
        public List<LanguageModel> GetAllLanguage()
        {
            var ListaLenguajes = new List<LanguageModel>();
            var Lenguages = _context.Idiomas.ToList();
            if (Lenguages?.Any()==true)
            {
                foreach (var lenguage in Lenguages)
                {
                    ListaLenguajes.Add (new LanguageModel()
                    {
                        Id =  lenguage.Id,
                        Text = lenguage.Text
                    });
                    
                }
                
            }
            return ListaLenguajes;
        }

    }
}