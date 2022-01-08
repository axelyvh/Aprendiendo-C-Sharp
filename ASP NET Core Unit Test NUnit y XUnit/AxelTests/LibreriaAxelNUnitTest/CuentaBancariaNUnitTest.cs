using LibreriaAxel;
using Moq;
using NUnit.Framework;

namespace LibreriaAxelNUnitTest
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {

        private CuentaBancaria cuenta;

        [SetUp]
        public void SetUp() {
        }

        [Test]
        public void Deposito_InputMonto100_ReturnsTrue()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());

            // 2. Act
            // Ejecucion de la operacion
            var resultado = cuentaBancaria.Deposito(100);

            // 3. Assert
            // Compara resultados
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));

        }

        [Test]
        public void Deposito_InputMonto100Mocking_ReturnsTrue()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            var mocking = new Mock<ILoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);

            // 2. Act
            // Ejecucion de la operacion
            var resultado = cuentaBancaria.Deposito(100);

            // 3. Assert
            // Compara resultados
            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));

        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            var loogerMock = new Mock<ILoggerGeneral>();
            loogerMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            loogerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsAny<int>())).Returns(true);
            // Agregando condicion al metodo
            loogerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(n => n > 0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loogerMock.Object);
            cuentaBancaria.Deposito(balance);

            // 2. Act
            // Ejecucion de la operacion
            var resultado = cuentaBancaria.Retiro(retiro);

            // 3. Assert
            // Compara resultados
            Assert.IsTrue(resultado);

        }

        [Test]
        [TestCase(200, 300)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            var loogerMock = new Mock<ILoggerGeneral>();
            loogerMock.Setup(x => x.LogDatabase(It.IsAny<string>())).Returns(true);
            // Agregando condicion al metodo
            loogerMock.Setup(x => x.LogBalanceDespuesRetiro(It.Is<int>(n => n < 0))).Returns(false);
            // Con rango de montos
            loogerMock.Setup(x => x.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loogerMock.Object);
            cuentaBancaria.Deposito(balance);

            // 2. Act
            // Ejecucion de la operacion
            var resultado = cuentaBancaria.Retiro(retiro);

            // 3. Assert
            // Compara resultados
            Assert.IsFalse(resultado);

        }

    }
}
