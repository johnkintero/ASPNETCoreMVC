using System.Collections.Generic;
using AlphaWebApp.Models;
using System.Linq;

namespace AlphaWebApp.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return  DataSource().Where(x=> x.Title == title || x.Author==authorName).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="John", Description="Explica el modelo vista controlador"},
                new BookModel(){Id=2, Title="GIT", Author="John", Description="Aprenda a manejar GIT"},
                new BookModel(){Id=3, Title="NETCORE", Author="Milena",Description="La nueva microsoft de codigo abierto .NetCore"},
                new BookModel(){Id=4, Title="JAVASCRIPT", Author="Lorena", Description="Secretos de Javascript"},
                new BookModel(){Id=5, Title="PYTHON", Author="Tatiana",Description="Aprenda a domar la serpiente"},
                new BookModel(){Id=5, Title="DISEÑO", Author="Tatiana",Description="Aprenda a diseñar su Web"},
                new BookModel(){Id=5, Title="MECANICA", Author="Jose",Description="Mecanica para Dummis"},
            };
        }

    }
}