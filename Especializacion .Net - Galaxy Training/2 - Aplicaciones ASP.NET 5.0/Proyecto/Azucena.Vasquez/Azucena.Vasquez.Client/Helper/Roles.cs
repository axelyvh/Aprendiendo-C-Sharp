namespace Azucena.Vasquez.Client.Helper
{
    public class Roles
    {
        public const string Administrator = "Administrator";
        public const string Profesor = "Profesor";
        public const string Alumno = "Alumno";
        public const string AdministratorOrProfesor = Administrator + "," + Profesor;
        public const string AdministratorOrAlumno = Administrator + "," + Alumno;
        public const string AdministratorOrProfesorOrAlumno = Administrator + "," + Profesor + "," + Alumno;
    }
}
