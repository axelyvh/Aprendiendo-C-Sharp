using LibreriaAxel;
using System;
using Xunit;

namespace LibreriaAxelXUnitTest
{
    public class ClientNUnitTests
    {

        private Client client;

        public ClientNUnitTests()
        {
            client = new Client();
        }

        [Fact]
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
            Assert.Equal("Axel Vasquez", client.NombreCompleto);
            // Si contiene el texto
            Assert.Contains("Axel", client.NombreCompleto);
            //// Si empieza con el texto
            Assert.StartsWith("Axel", client.NombreCompleto);
            //// Si termina con el texto
            Assert.EndsWith("Vasquez", client.NombreCompleto);

        }

        [Fact]
        public void CrearNombrecompleto_NoValues_ReturnsNull()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.Null(client.NombreCompleto);

        }

        [Fact]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            int descuento = client.Descuento;

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.InRange(descuento, 5, 24);

        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            client.CrearNombrecompleto("Axel", "");

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.NotNull(client.NombreCompleto);
            Assert.False(string.IsNullOrEmpty(client.NombreCompleto));

        }

        [Fact]
        public void ClientNombre_InputNombreEnBlanco_ReturnsException()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => client.CrearNombrecompleto("", "Vasquez"));

            // 2. Act

            // 3. Assert
            // Compara resultados
            Assert.Equal("El nombre esta en blanco", exceptionDetalle.Message);
            
            // Se compara el objeto de exception
            Assert.Throws<ArgumentException>(() => client.CrearNombrecompleto("", "Vasquez"));

        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500OrderTotalOrder_ReturnsClienteBasico()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            client.OrderTotal = 150;

            // 2. Act
            var resultado = client.GetClienteDetalle();

            // 3. Assert
            // Compara resultados
            Assert.IsType<ClienteBasico>(resultado);

        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMas500OrderTotalOrder_ReturnsClientePremium()
        {

            // 1. Arrange
            // Inicializar las variables o componentes que ejecutaran el test
            client.OrderTotal = 700;

            // 2. Act
            var resultado = client.GetClienteDetalle();

            // 3. Assert
            // Compara resultados
            Assert.IsType<ClientePremium>(resultado);

        }

    }
}
