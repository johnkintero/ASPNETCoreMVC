using Microsoft.AspNetCore.Mvc;
using AlphaWebApp.Repository;
using System.Collections.Generic;
using AlphaWebApp.Models;

namespace AlphaWebApp.Controllers 
{
    public class BookController : Controller 
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        //Metodo que retorna un Json con la lista de todos los libros
        // public List<BookModel> GetAllBooks()
        // {
        //     return _bookRepository.GetAllBooks();
        // }

        //Metodo que retorna la vista de los libros
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

       [Route("Detalle-Libro/{id}", Name="DetalleLibroRuta")] 
        public ViewResult GetBook(int id)
        {
            //return $"book with id : {id}";
            var data = _bookRepository.GetBookById(id); 
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }

        public ViewResult AddBook()
        {
            return View();
        } 

        [HttpPost]
        public ViewResult AddBook(BookModel bookModel)
        {
            return View();
        }
    }
}