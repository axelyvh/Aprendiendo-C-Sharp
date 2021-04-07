using System.ComponentModel.DataAnnotations;

namespace Azucena.Vasquez.Client.Models
{
    public class ScoresViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Alumno es requerido")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Curso es requerido")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Nota es requerido")]
        [Range(0, 20, ErrorMessage = "La nota minima es 0 y la maxima es 20")]
        public int Score { get; set; }

        public virtual CoursesViewModel Course { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
