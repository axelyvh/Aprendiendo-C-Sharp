using LibreriaAxel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibreriaAxelMSTest
{
    [TestClass]
    public class OperationMSTest
    {

        [TestMethod]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto() {

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

    }
}
