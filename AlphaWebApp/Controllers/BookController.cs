using Microsoft.AspNetCore.Mvc;
using AlphaWebApp.Repository;
using System.Collections.Generic;
using AlphaWebApp.Models;
using System.Threading.Tasks;

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

        //Metodo que retorna la vista de los libros
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

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
            ViewBag.IsSuccess= isSuccess;
            ViewBag.BookId = bookId;
            return View();
        } 

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

        [HttpPost]
        public async Task<IActionResult> AddBookasync(BookModel bookModel)
        {
            int id =  await _bookRepository.AddBookasync(bookModel);
            if(id > 0)
            {
                return RedirectToAction(nameof(AddBook), new {isSuccess = true, bookId= id});
            }
            return View();
        }
    }
}