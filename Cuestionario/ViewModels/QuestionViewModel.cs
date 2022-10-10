namespace Cuestionario.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;
    using System.Xml.Linq;
    using Cuestionario.Models;

    public class QuestionViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Enunciado")]
        [Required(ErrorMessage = "Por favor introduzca el enunciado.")]
        public string Title { get; set; }
        [Display(Name = "Opciones")]

        public List<Option> Options { get; set; }
    }
}


