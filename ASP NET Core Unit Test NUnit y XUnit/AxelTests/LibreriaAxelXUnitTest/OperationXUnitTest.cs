using LibreriaAxel;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LibreriaAxelXUnitTest
{
    public class OperationXUnitTest
    {

        [Fact]
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
            Assert.Equal(3, result);

        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        [InlineData(7, false)]
        public void IsValorPar_InputNumeroImpar_ReturnFalse(int NumeroImpar, bool expectedResult)
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Operation operation = new();
            var resultado = operation.IsValorPar(NumeroImpar);

            // 2. Act
            // Ejecucion de la operacion
            Assert.Equal(expectedResult, resultado); 

        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(20)]
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
            Assert.True(result);

        }

        [Theory]
        [InlineData(2.2, 1.2)]
        [InlineData(2.23, 1.24)]
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
            Assert.Equal(3.4, result, 0); // Intervalo 3.3 a 3.5 (El delta resta al numero de referencia)

        }

        [Fact]
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
            Assert.Equal(numerosImparesEsperados, resultados);
            // Si contiene un dato
            Assert.Contains(5, resultados);
            // Si la lista no esta vacia
            Assert.NotEmpty(resultados);
            // Valida la cantidad de elementos
            Assert.Equal(3, resultados.Count);
            // Que no este en la lista
            Assert.DoesNotContain(10, resultados);
            // Valida si esta ordenado
            Assert.Equal(resultados.OrderBy(x => x), resultados);

        }

    }
}
