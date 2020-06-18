using Microsoft.AspNetCore.Mvc;

namespace WebAlpha.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "AllBooks";
        }
    }
}