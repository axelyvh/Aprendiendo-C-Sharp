using LibreriaAxel;
using NUnit.Framework;
using System;

namespace LibreriaAxelNUnitTest
{
    public class ClientNUnitTests
    {

        private Client client;

        [SetUp]
        public void Setup() {
            client = new Client();
        }

        [Test]
        public void CrearNombrecompleto_InputNombreApellido_ReturnsNombreCompleto()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test

            // 2. Act
            // Ejecucion de la operacion
            client.CrearNombrecompleto("Axel", "Vasquez");

            // 3. Assert
            // Compara resultados
            // Permite mostrar el log de todos los asserts
            Assert.Multiple(() =>
            {
                Assert.That(client.NombreCompleto, Is.EqualTo("Axel Vasquez"));
                Assert.AreEqual(client.NombreCompleto, "Axel Vasquez");
                // Si contiene el texto
                Assert.That(client.NombreCompleto, Does.Contain("Axel"));
                //// Para textos siempre verificar las mayusculas
                Assert.That(client.NombreCompleto, Does.Contain("Axel").IgnoreCase);
                //// Si empieza con el texto
                Assert.That(client.NombreCompleto, Does.StartWith("Axel"));
                //// Si termina con el texto
                Assert.That(client.NombreCompleto, Does.EndWith("Vasquez"));
            });

        }

        [Test]
        public void CrearNombrecompleto_NoValues_ReturnsNull()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.IsNull(client.NombreCompleto);

        }

        [Test]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            int descuento = client.Descuento;

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.That(descuento, Is.InRange(5, 24));

        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            client.CrearNombrecompleto("Axel", "");

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.IsNotNull(client.NombreCompleto);
            Assert.IsFalse(string.IsNullOrEmpty(client.NombreCompleto));

        }

        [Test]
        public void ClientNombre_InputNombreEnBlanco_ReturnsException()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => client.CrearNombrecompleto("", "Vasquez"));

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.AreEqual("El nombre esta en blanco", exceptionDetalle.Message);
            // Otra forma
            Assert.That(() => client.CrearNombrecompleto("", ""), Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco"));

            // Se compara el objeto de exception
            Assert.Throws<ArgumentException>(() => client.CrearNombrecompleto("", "Vasquez"));
            Assert.That(() => client.CrearNombrecompleto("", "Vasquez"), Throws.ArgumentException);

        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMenos500OrderTotalOrder_ReturnsClienteBasico()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            client.OrderTotal = 150;

            // 2. Act
            var resultado = client.GetClienteDetalle();

            // 3. Assert
            // Compara resultados
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());

        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMas500OrderTotalOrder_ReturnsClientePremium()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            client.OrderTotal = 700;

            // 2. Act
            var resultado = client.GetClienteDetalle();

            // 3. Assert
            // Compara resultados
            Assert.That(resultado, Is.TypeOf<ClientePremium>());

        }

    }
}
