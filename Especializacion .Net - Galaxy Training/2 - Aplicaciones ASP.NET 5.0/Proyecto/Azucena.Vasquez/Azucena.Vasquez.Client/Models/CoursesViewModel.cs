using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Azucena.Vasquez.Client.Models
{
    public class CoursesViewModel
    {
        public CoursesViewModel()
        {
            Scores = new List<ScoresViewModel>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public bool? State { get; set; }

        public List<ScoresViewModel> Scores { get; set; }
    }
}
