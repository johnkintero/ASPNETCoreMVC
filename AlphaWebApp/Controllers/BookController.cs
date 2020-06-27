using Microsoft.AspNetCore.Mvc;
using AlphaWebApp.Repository;
using System.Collections.Generic;
using AlphaWebApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlphaWebApp.Controllers 
{
    public class BookController : Controller 
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        //Metodo que retorna un Json con la lista de todos los libros
        // public List<BookModel> GetAllBooks()
        // {
        //     return _bookRepository.GetAllBooks();
        // }

        /// <summary>
        /// Metodo asincronico que retorna el total de libros desde la bd
        /// </summary>
        /// <returns></returns>
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        /// <summary>
        /// Metodo asincronico que retorna la informacion de un libro especifico
        /// las etiquetas de Route sirven para enmascarar en el browser como se hace la consulta
        /// en lugar de mostrar GetBook mostrara Detalle_Libro
        /// </summary>
        /// <param name="id">Identificador del libro</param>
        /// <returns></returns>
       [Route("Detalle-Libro/{id}", Name="DetalleLibroRuta")] 
        public async Task<ViewResult> GetBook(int id)
        {
            //return $"book with id : {id}";
            var data = await _bookRepository.GetBookById(id); 
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }

        public ViewResult AddBook( bool isSuccess = false, int bookId = 0)
        {
            //Pasar la lista para el ddl forma1
            var list = new List<string>() {"Español","Ingles", "Frances","Portugues"};
            ViewBag.ListaLanguge = list;

             //Pasar la lista para el ddl forma 2
            ViewBag.ListaLanguge = new SelectList(new List<string>() {"Español","Ingles", "Frances","Portugues"});

            //Pasar un valor seleccionado en el ddl
            // var model = new BookModel()
            // {
            //     Language = "Ingles"
            // };


            ViewBag.IsSuccess= isSuccess;
            ViewBag.BookId = bookId;
            return View();

            //Pasar datos seleccionados
            //return View(model);
        } 

        /// <summary>
        /// Metodo para agregar un libro nuevo a la bd
        /// </summary>
        /// <param name="bookModel">Objeto libro</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBook(BookModel bookModel)
        {
            int id = _bookRepository.AddBook(bookModel);
            if(id > 0)
            {
                return RedirectToAction(nameof(AddBook), new {isSuccess = true, bookId= id});
            }
            return View();
        }

        /// <summary>
        /// Metodo asincronico para agregar libros a la DB
        /// </summary>
        /// <param name="bookModel">Objeto Libro</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBookasync(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id =  await _bookRepository.AddBookasync(bookModel);
                if(id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new {isSuccess = true, bookId= id});
                }    
            }
            ViewBag.ListaLanguge = new SelectList(new List<string>() {"Español","Ingles", "Frances","Portugues"});
            //con esta linea se pueden enviar errores personalizados a la vista
            ModelState.AddModelError("","Este es mi mensaje desde el modelo");
            return View("AddBook");
        }
    }
}