using System.Collections.Generic;
using AlphaWebApp.Models;
using System.Linq;
using AlphaWebApp.Data;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlphaWebApp.Repository
{
    public class BookRepository
    {
        //Se define la instancia del contexto de la bd
        private readonly TiendaLibrosContext _context = null;

        //constructor
        public BookRepository(TiendaLibrosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega un nuevo libro al contexto y la base de datos
        /// </summary>
        /// <param name="model">Objeto Libro</param>
        /// <returns>Int con el Id del libro nuevo</returns>
        public int AddBook(BookModel model)
        {
            //Crea el nuevo libro con la clase que esta en data
            var newBook = new Libros()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalLines = model.TotalLines.HasValue ? model.TotalLines.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };

            //agrega el libro al contextos
            _context.Libros.Add(newBook);
            //Se actualiza en la BD
            _context.SaveChanges();
            //retorna el ID creado
            return newBook.Id;

        }

        /// <summary>
        /// Crea un nuevo libro con un metodo asincrono
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> AddBookasync(BookModel model)
        {
            //Crea el nuevo libro con la clase que esta en data
            var newBook = new Libros()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                Language = model.Language,
                TotalLines = model.TotalLines.HasValue ? model.TotalLines.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };

            //agrega el libro al contexto
            await _context.Libros.AddAsync(newBook);
            //Se actualiza en la BD
            await _context.SaveChangesAsync();
            //retorna el ID creado
            return newBook.Id;

        }

        /// <summary>
        /// Recupera todos los libros del repositorio
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookModel>> GetAllBooks()
        {   
            // recupera del datasource local incial
            //return DataSource();

            var ListaLibros = new List<BookModel>();
            var libros = await _context.Libros.ToListAsync();
            if (libros?.Any()== true)
            {
                foreach (var libro in libros)
                {
                    ListaLibros.Add(new BookModel {
                        Author = libro.Author,
                        Category = libro.Category,
                        Description = libro.Description,
                        Id = libro.Id,
                        Language = libro.Language,
                        Title = libro.Title,
                        TotalLines = libro.TotalLines
                    });
                }
            }
            return ListaLibros;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            //Recuperando la informcion del repositorio local
            //return DataSource().Where(x => x.Id == id).FirstOrDefault();

            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                var libroDetalle = new BookModel()
                {
                    Author = libro.Author,
                    Category = libro.Category,
                    Description = libro.Description,
                    Id = libro.Id,
                    Language = libro.Language,
                    Title = libro.Title,
                    TotalLines = libro.TotalLines
                };
                return libroDetalle;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return  DataSource().Where(x=> x.Title == title || x.Author==authorName).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="John", Description="Explica el modelo vista controlador", Category="Programacion",Language="Español",TotalLines=300},
                new BookModel(){Id=2, Title="GIT", Author="John", Description="Aprenda a manejar GIT", Category="Programacion",Language="Ingles",TotalLines=100},
                new BookModel(){Id=3, Title="NETCORE", Author="Milena",Description="La nueva microsoft de codigo abierto .NetCore", Category="Programacion",Language="Español",TotalLines=140},
                new BookModel(){Id=4, Title="JAVASCRIPT", Author="Lorena", Description="Secretos de Javascript", Category="Programacion",Language="Ingles",TotalLines=450},
                new BookModel(){Id=5, Title="PYTHON", Author="Tatiana",Description="Aprenda a domar la serpiente", Category="Programacion",Language="Español",TotalLines=300},
                new BookModel(){Id=5, Title="DISEÑO", Author="Tatiana",Description="Aprenda a diseñar su Web", Category="Programacion",Language="Ingles",TotalLines=230},
                new BookModel(){Id=5, Title="MECANICA", Author="Jose",Description="Mecanica para Dummis", Category="Programacion",Language="Español",TotalLines=145},
            };
        }

    }
}