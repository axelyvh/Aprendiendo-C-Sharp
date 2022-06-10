using LibreriaAxel;
using NUnit.Framework;
using System.Collections.Generic;

namespace LibreriaAxelNUnitTest
{
    [TestFixture]
    public class OperationNUnitTest
    {

        [Test]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Operation operation = new();
            int Num1 = 1;
            int Num2 = 2;

            // 2. Act
            // Ejecucion de la operacion
            int result = operation.SumarNumeros(Num1, Num2);

            // 3. Assert
            // Compara resultados
            Assert.AreEqual(3, result);

        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsValorPar_InputNumeroImpar_ReturnFalse(int NumeroImpar)
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Operation operation = new();

            // 2. Act
            // Ejecucion de la operacion
            return operation.IsValorPar(NumeroImpar);

        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(20)]
        public void IsValorPar_InputNumeroPar_ReturnTrue(int NumeroPar)
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Operation operation = new();

            // 2. Act
            // Ejecucion de la operacion
            bool result = operation.IsValorPar(NumeroPar);

            // 3. Assert
            // Compara resultados
            Assert.IsTrue(result);
            // Otra forma
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        [TestCase(2.2, 1.2)]
        [TestCase(2.23, 1.24)]
        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double Num1, double Num2)
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Operation operation = new();

            // 2. Act
            // Ejecucion de la operacion
            double result = operation.SumarDecimal(Num1, Num2);

            // 3. Assert
            // Compara resultados
            Assert.AreEqual(3.4, result, 0.1); // Intervalo 3.3 a 3.5 (El delta resta al numero de referencia)

        }

        [Test]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalor_ReturnsListaImpares()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Operation operation = new();
            List<int> numerosImparesEsperados = new() { 5, 7, 9 };

            // 2. Act
            // Ejecucion de la operacion
            List<int> resultados = operation.GetListaNumerosImpares(5, 10);

            // 3. Assert
            // Compara resultados
            Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));
            // Otra forma
            Assert.AreEqual(numerosImparesEsperados, resultados);
            // Si contiene un dato
            Assert.That(resultados, Does.Contain(5));
            // Si la lista no esta vacia
            Assert.That(resultados, Is.Not.Empty);
            // Valida la cantidad de elementos
            Assert.That(resultados.Count, Is.EqualTo(3));
            // Que no este en la lista
            Assert.That(resultados, Has.No.Member(10));
            // Valida si esta ordenado
            Assert.That(resultados, Is.Ordered.Ascending);
            // Que no exista duplicado
            Assert.That(resultados, Is.Unique);

        }

    }
}
