using System;

namespace Lambda
{
    class Program
    {

        public delegate float DelegateOperacion(float val1, float val2);

        public static float Depositar(float MontoActual, float Cantidad)
        {
            return MontoActual + Cantidad;
        }

        public static float Retirar(float MontoActual, float Cantidad)
        {
            if (Cantidad > MontoActual)
            {
                Console.WriteLine("No es posible realizar el retiro");
                return 0.0f;
            }
            return MontoActual - Cantidad;
        }

        public static float EjecutarOperacion(DelegateOperacion operacion, float MontoActual, float Cantidad)
        {

            float Result = operacion(MontoActual, Cantidad);
            Console.WriteLine("La operación se ha ejecutado");
            Console.WriteLine($"El resultado es: {Result}");
            return Result;

        }

        static void Main(string[] args)
        {

            //Expresiones lambda

            //Lambda = Función anonima
            //(Parametros) => El cuerpo de la función

            //Func<double, bool> NumeroPar = numero => numero % 2 == 0;

            //Console.WriteLine("¿El numero es par?");//\r
            //Console.WriteLine("------------------------\n");

            //Console.WriteLine("Ingrese un número:");
            //double Numero = Convert.ToDouble(Console.ReadLine());

            //if (NumeroPar(Numero)) {
            //    Console.WriteLine("El numero es par");
            //} else {
            //    Console.WriteLine("El numero es impar");
            //}

            //Console.ReadKey();

            //Fin Expresiones lambda

            /*************************************************************************************/

            //Expresiones lambda múltiples parámetros

            //Func<double, double, double> Suma = (Numero1, Numero2) => Numero1 + Numero2;

            //Console.WriteLine("Sumar");
            //Console.WriteLine("------------------------\n");

            //Console.WriteLine("Ingrese el primer número:");
            //double Num1 = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Ingrese el segundo número:");
            //double Num2 = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine($"La suma de los numeros es: {Suma(Num1, Num2)}");
            //Console.ReadKey();

            //Fin Expresiones lambda múltiples parámetros

            /*************************************************************************************/

            //Expresiones lambda múltiples sentencias

            //Func<string, bool> ValidarCorreo = correo =>
            //{
            //    if (correo.EndsWith("gmail.com", StringComparison.CurrentCulture) == false) {
            //        Console.WriteLine("> El corre es invalido");
            //        return false;
            //    }
            //    Console.WriteLine("> El corre es valido");
            //    return true;
            //};

            //Console.WriteLine("Validar Correo");
            //Console.WriteLine("------------------------\n");

            //Console.WriteLine("Ingrese su correo:");
            //string correo = Convert.ToString(Console.ReadLine());
            //ValidarCorreo(correo);

            //Console.ReadKey();

            //Fin Expresiones lambda múltiples sentencias

            /*************************************************************************************/

            //Expresiones lambda funciones sin retorno

            //Action<string, string> Mensaje = (Titulo, Nombre) =>
            //{
            //    Console.WriteLine($"{Titulo} {Nombre}");
            //};

            //Console.WriteLine("Mensaje");
            //Console.WriteLine("------------------------\n");

            //Console.WriteLine("Ingrese el titulo:");
            //string Titulo = Convert.ToString(Console.ReadLine());

            //Console.WriteLine("Ingrese el nombre:");
            //string Nombre = Convert.ToString(Console.ReadLine());

            //Mensaje(Titulo, Nombre);

            //Console.ReadKey();

            //Fin Expresiones lambda funciones sin retorno

            /*************************************************************************************/

            //Delegados

            //DelegateOperacion DepositarTarjeta = Depositar;
            //DelegateOperacion RetirarTarjeta = Retirar;

            //EjecutarOperacion(DepositarTarjeta, 100, 20);
            //EjecutarOperacion(RetirarTarjeta, 100, 20);

            ////Delegado Con Lambda
            //DelegateOperacion DepositarConComision = (MontoActual, Cantidad) => 
            //Cantidad > 100 ? MontoActual + Cantidad + (Cantidad * 0.02f) : MontoActual + Cantidad;

            //EjecutarOperacion(DepositarConComision, 100, 101);

            //Console.ReadKey();

            //Fin Delegados

            /*************************************************************************************/

        }

    }
}
