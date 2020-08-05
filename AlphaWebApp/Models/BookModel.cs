using System.ComponentModel.DataAnnotations;
namespace AlphaWebApp.Models
{
    public class BookModel
    {

        //Las anotaciones sirven para la validacion de los datos desde el 
        //lado del servidor, estan se validan en el controller con la validacion de ModalState.IsValid
        public int Id { get; set; }
        [StringLength(100, MinimumLength=5)]
        [Required(ErrorMessage="Ingrese el titulo del libro")]
        public string Title { get; set; }
        [Required(ErrorMessage="Ingrese el nombre del autor")]
        public string Author { get; set; }
        [Required(ErrorMessage="Ingrese una breve descripcion del libro")]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage="Ingrese el idioma del libro")]
        public int IdiomasId { get; set; }

        [Display(Name="Total paginas del libro")]
        [Required(ErrorMessage="Ingrese el total de las lineas")]
        public int? TotalLines { get; set; }

        public string Idioma { get; set; }

       
    }
}