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

        public BookModel GetBook(int id)
        {
            //return $"book with id : {id}";
            return _bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
    }
}