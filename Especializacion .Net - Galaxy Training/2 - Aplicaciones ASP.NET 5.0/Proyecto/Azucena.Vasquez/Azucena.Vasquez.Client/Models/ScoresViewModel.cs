namespace Azucena.Vasquez.Client.Models
{
    public class ScoresViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public int Score { get; set; }

        public virtual CoursesViewModel Course { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
