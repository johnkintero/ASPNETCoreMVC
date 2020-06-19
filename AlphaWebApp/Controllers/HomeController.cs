using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers 
{
    public class HomeController : Controller 
    {
        public ViewResult Index()
        {
            //LLamar la vista pasando un objeto
            //var obj = new {Id=1, name="John"};
            //return View(obj);

            //Llamar vista 
            return View();

            //Llamar vista por nombre de la vista
            //return View("AboutUs");

            //Llamar vista pasando nombre y Objeto
            //var obj = new {Id=1, name="John"};
            //return View("AboutUs",obj);

            //Llamar vista en una carpeta distinta
            //return View("TempView/TempView.cshtml");

        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
    
}