using LibreriaAxel;
using Moq;
using NUnit.Framework;

namespace LibreriaAxelNUnitTest
{
    [TestFixture]
    public class ProductoNUnitTest
    {

        [Test]
        public void GetPrecio_PremiumClient_ReturnsPrecio80()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Producto producto = new Producto
            {
                Precio = 50
            };

            // 2. Act
            // Ejecucion de la operacion
            var resultado = producto.GetPrecio(new Client { IsPremium = true });

            // 3. Assert
            // Compara resultados
            Assert.That(resultado, Is.EqualTo(40));

        }

        [Test]
        public void GetPrecio_PremiumClientMoq_ReturnsPrecio80() {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            Producto producto = new Producto {
                Precio = 50
            };

            var cliente = new Mock<IClient>();
            cliente.Setup(s => s.IsPremium).Returns(true);

            // 2. Act
            // Ejecucion de la operacion
            var resultado = producto.GetPrecio(cliente.Object);

            // 3. Assert
            // Compara resultados
            Assert.That(resultado, Is.EqualTo(40));

        }

    }
}
