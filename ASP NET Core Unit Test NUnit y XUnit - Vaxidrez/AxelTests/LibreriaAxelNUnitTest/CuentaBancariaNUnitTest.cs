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

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMocking_ReturnTrue() {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textPrueba = "hola mundo";

            loggerGeneralMock.Setup(x => x.MessageConReturnStr(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            var resultado = loggerGeneralMock.Object.MessageConReturnStr("holA Mundo");

            Assert.That(resultado, Is.EqualTo(textPrueba));

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingOutPut_ReturnTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textPrueba = "Hola";

            loggerGeneralMock.Setup(x => x.MessageConOutParametroReturnBoolean(It.IsAny<string>(), out textPrueba))
                             .Returns(true);

            string parametroOut = "";
            var resultado = loggerGeneralMock.Object.MessageConOutParametroReturnBoolean("Axel", out parametroOut);

            Assert.IsTrue(resultado);

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingObjetoRef_ReturnTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            Client client = new();
            Client clientNoUsado = new();

            loggerGeneralMock.Setup(x => x.MessageConObjetoReferenciaReturnBoolean(ref client))
                             .Returns(true);

            var resultado_true = loggerGeneralMock.Object.MessageConObjetoReferenciaReturnBoolean(ref client);
            Assert.IsTrue(resultado_true);

            var resultado_false = loggerGeneralMock.Object.MessageConObjetoReferenciaReturnBoolean(ref clientNoUsado);
            Assert.IsFalse(resultado_false);

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipo_ReturnsTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            loggerGeneralMock.SetupAllProperties();
            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);

            loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.That(loggerGeneralMock.Object.TipoLogger, Is.EqualTo("warning"));
            Assert.That(loggerGeneralMock.Object.PrioridadLogger, Is.EqualTo(100));

        }

        [Test]
        public void CuentaBancariaLoggerGeneral_LogMockingPropiedadPrioridadTipoCallBacks_ReturnsTrue()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();

            loggerGeneralMock.SetupAllProperties();
            loggerGeneralMock.Setup(x => x.TipoLogger).Returns("warning");
            loggerGeneralMock.Setup(x => x.PrioridadLogger).Returns(10);

            loggerGeneralMock.Object.PrioridadLogger = 100;

            Assert.That(loggerGeneralMock.Object.TipoLogger, Is.EqualTo("warning"));
            Assert.That(loggerGeneralMock.Object.PrioridadLogger, Is.EqualTo(100));

            string textoTemporal = "axel";
            loggerGeneralMock.Setup(x => x.LogDatabase(It.IsAny<string>()))
                             .Returns(true)
                             .Callback((string parametro) => textoTemporal += parametro);

            loggerGeneralMock.Object.LogDatabase("vasquez");

            Assert.That(textoTemporal, Is.EqualTo("axelvasquez"));

        }

        [Test]
        public void CuentaBancariaLogger_VerifyEjemplo()
        {

            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerGeneralMock.Object);
            cuentaBancaria.Deposito(100);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));

            // Verifica cuantas veces el mock esta llamando al metodo message
            loggerGeneralMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(3));

            // Si alguna vez se ejecuto
            loggerGeneralMock.Verify(x => x.Message("Visita axel.com"), Times.AtLeastOnce);

            // Cuantas veces se ha seteado
            loggerGeneralMock.VerifySet(x => x.PrioridadLogger = 100, Times.Once);

            // Cuantas veces se ha ejecutado
            loggerGeneralMock.VerifyGet(x => x.PrioridadLogger, Times.Once);

        }

    }
}
