using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            //Filtrar elementos

            //List<int> Calificaciones = new List<int> { 10, 10, 5, 7, 7, 10, 8, 9, 10, 9, 9 };

            //Obtener las calificaciones y cantidad total de registros mayores que 8

            //Imperativo

            //Console.WriteLine("Imperativo");//\r
            //Console.WriteLine("------------------------\n");

            //int Contador = 0;
            //foreach (var calificacion in Calificaciones)
            //{
            //    if (calificacion > 8) {
            //        Console.WriteLine(calificacion);
            //        Contador++;
            //    }
            //}

            //Console.WriteLine($"Cantidad Total de registros: {Contador} \n");

            ////Declarativo

            //Console.WriteLine("Declarativo");//\r
            //Console.WriteLine("------------------------\n");

            //var Resultado = Calificaciones.Where(calificacion => calificacion > 8);

            //foreach (var calificacion in Resultado)
            //{
            //    Console.WriteLine(calificacion);
            //}

            //Console.WriteLine($"Cantidad Total de registros: {Resultado.Count()} \n");

            //Fin Filtrar elementos

            /*********************************************************/

            //Modificar Elementos

            //List<int> LstNumero = new List<int> { 1,2,3,4,5,6,7,8,9,10};
            ////Obteniendo el cubo de los números de la lista

            ////Imperativo

            //Console.WriteLine("Imperativo");//\r
            //Console.WriteLine("------------------------\n");

            //foreach (var numero in LstNumero)
            //{
            //    Console.WriteLine(numero * numero);
            //}

            //Console.WriteLine("\n");

            ////Declarativo

            //Console.WriteLine("Declarativo");//\r
            //Console.WriteLine("------------------------\n");

            //var Result = LstNumero.Select(numero => numero * numero);

            //foreach (var numero in Result)
            //{
            //    Console.WriteLine(numero);
            //}

            //Fin Modificar Elementos

            //Reducción de elementos

            //List<int> LstNumero = new List<int> { 1,2,3,4,5,6,7,8,9,10};
            ////Obtener la suma de los elementos

            ////Filter -> Where
            ////Map -> Select
            ////Reduce -> Aggregate

            ////Imperativo

            //int Suma = 0;
            //foreach (var numero in LstNumero)
            //{
            //    Suma += numero;
            //}

            //Console.WriteLine(Suma);

            ////Declarativo

            //int ResultadoSuma = LstNumero.Aggregate((contador, numero) => contador + numero);
            //Console.WriteLine(ResultadoSuma);


            //Fin Reducción de elementos

            //Ordenamiento

            //List<int> Numeros = new List<int> { 2,5,6,7,1,8,9,10,3,4};

            //var ResultadoAsc = Numeros.OrderBy(numero => numero);

            //foreach (var numero in ResultadoAsc)
            //{
            //    Console.WriteLine(numero);
            //}

            //Console.WriteLine("\n");

            //Console.WriteLine("Iteración funcional");

            //Numeros.OrderByDescending(numero => numero)
            //    .ToList()
            //    .ForEach(numero => Console.WriteLine(numero));

            //Fin Ordenamiento

            //Encontrando elementos

            //List<int> numeros = new List<int> {2,5,6,7,1,8,9,10,3,4 };
            ////Encontrar elementos

            //bool ResultadoContains = numeros.Contains(7);
            //Console.WriteLine($"{ResultadoContains}");

            //bool ResultadoAny = numeros.Any(numero => numero == 11);
            //Console.WriteLine(ResultadoAny);

            //int ResultadoFind = numeros.Find(numero => numero == 7);
            //Console.WriteLine(ResultadoFind);

            //int ResultadoSingle = numeros.Single(numero => numero == 10);
            //Console.WriteLine(ResultadoSingle);

            //Fin Encontrando elementos

            //Ordenamiento Parte 2

            var Users = User.Users();
            var Tasks = Task.Tasks();

            /*
             Obtener el nombre de los usuarios mayores de edad cuyo sexo sea Femenino
             Ordenar el resultado de form desc con respecto a su nombre
            */

            //(from user in Users
            //where user.Age > 18 && user.Gender == "female"
            //orderby user.Username descending
            //select user.Username)
            //.ToList()
            //.ForEach(Username => Console.WriteLine(Username));

            //Fin Ordenamiento Parte 2

            //Creando nuevo objeto

            //(from user in Users
            // where user.Age > 18 && user.Gender == "female"
            // orderby user.Username descending
            // select new { 
            //    Nombre = user.Username,
            //    Edad = user.Age
            // })
            //.ToList()
            //.ForEach(user => Console.WriteLine($"Nombre: {user.Nombre} Edad: {user.Edad}"));

            //Fin Creando nuevo objeto

            //Join

            //Obtener las tareas de los usuarios

            //(from user in Users
            // join task in Tasks on user.Id equals task.UserId
            // select new
            // {
            //     Usuario = user.Username,
            //     Tarea = task.Title
            // })
            // .ToList()
            // .ForEach(task => Console.WriteLine($"El usuario {task.Usuario} tiene la tarea de {task.Tarea}"));

            //Fin Join

            //Diference

            //Obtener usuarios que tienen tareas

            //(from user in Users
            // join task in Tasks on user.Id equals task.UserId
            // select user.Username)
            // .Distinct()
            // .ToList()
            // .ForEach(user => Console.WriteLine(user));

            //Fin Diference

            //Group by Parte 1

            //Obtener los username de los usuarios que tengan tareas

            //(from user in Users
            // join task in Tasks on user.Id equals task.UserId
            // group user by user.Username into GroupUser
            // select GroupUser)
            // .ToList()
            // .ForEach(user => Console.WriteLine(user.Key));

            //Fin Group by Parte 1

            //Group by Parte 2

            //Obtener la cantidad de tareas por cada usuario 
            //El resultado debe estar ordenado por la cantidad de tareas desc.

            //(from user in Users
            // join task in Tasks on user.Id equals task.UserId
            // group user by user.Username into GroupUser
            // orderby GroupUser.Count() descending
            // select new { 
            //    Mensaje = $"El usuario {GroupUser.Key} tiene un total de tareas de {GroupUser.Count()}" 
            // })
            // .ToList()
            // .ForEach(user => Console.WriteLine(user.Mensaje));

            //Fin Group by Parte 2

            //Crear variables

            //List<int> LstNumeros = new List<int> { 10,8,7,6,4,5,2,1,10};
            //Dado una lista de números enteros, mostar en consola el cuadrado de cada uno de los elementos
            //si y solo si, dicho cuadrado es mayor a 50

            //(from numero in LstNumeros
            // let cuadrado = numero * numero
            // where cuadrado > 50
            // select cuadrado)
            // .ToList()
            // .ForEach(numero => Console.WriteLine(numero));

            //Fin Crear variables

            //Left join

            //Obtener el username de los usuarios que NO tengan tareas

            //(from user in Users
            // join task in Tasks on user.Id equals task.UserId into Relacion
            // from a in Relacion.DefaultIfEmpty()
            // where a == null
            // select user.Username)
            // .ToList()
            // .ForEach(username => Console.WriteLine(username));

            //Fin Left join

        }
    }
}
