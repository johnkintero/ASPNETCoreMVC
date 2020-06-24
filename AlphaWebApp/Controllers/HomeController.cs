using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using AlphaWebApp.Models;

namespace AlphaWebApp.Controllers 
{
    public class HomeController : Controller 
    {
        //Ejemplo ViewData atribute
        [ViewData]
        public string Custom { get; set; }

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
            ViewBag.Titulo = "Acerca de nosotros";
            // xa pasar objetos como ViewBag es anonimo se debe pasar un objeto tipo dynamic
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "John Jairo";
            ViewBag.Data = data;
            //El viewbag tambien sirve para pasar objetos de un modelo espacifico
            ViewBag.Type = new BookModel {Id = 1, Author="Milena Calvachi"};

            //Uso del viewdata
            ViewData["Dato"] = new BookModel {Id=2, Author = "Jose Ivan"};

            return View();
        }

        public ViewResult ContactUs()
        {
            Custom = "Dato desde el controlador";
            return View();
        }
    }
    
}