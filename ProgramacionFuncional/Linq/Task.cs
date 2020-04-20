using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class Task
    {

        public Task(int Id, string Title, int UserId)
        {
            this.Id = Id;
            this.Title = Title;
            this.UserId = UserId;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public static List<Task> Tasks() {

            return new List<Task> {
                new Task(1, "Terminar examen", 2),
                new Task(2, "Ir por el super", 2),
                new Task(3, "Completar curso de C#", 5),
                new Task(4, "Finalizar presentación del curso", 6),
                new Task(5, "Comprar boletos de avión", 7),
                new Task(6, "Automatizar pago de nomina", 10),
                new Task(7, "Recoger ropa de la tintorería", 10),
                new Task(8, "Formatear computadora", 9),
                new Task(9, "Estudiar para examen de ingles", 9),
                new Task(10,"Limiar casa", 9)
            };

        }

    }
}
