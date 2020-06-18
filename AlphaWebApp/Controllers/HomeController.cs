using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers 
{
    public class HomeController : Controller 
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }
    }
    
}