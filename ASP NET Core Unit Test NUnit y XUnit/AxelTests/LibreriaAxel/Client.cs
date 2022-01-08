using System;

namespace LibreriaAxel
{

    public interface IClient {

        string NombreCompleto { get; set; }
        int Descuento { get; set; }
        int OrderTotal { get; set; }
        bool IsPremium { get; set; }
        string CrearNombrecompleto(string nombre, string apellido);
        TipoCliente GetClienteDetalle();
    }

    public class Client : IClient
    {

        public string NombreCompleto { get; set; }
        public int Descuento { get; set; }
        public int OrderTotal { get; set; }
        public bool IsPremium { get; set; }

        public Client()
        {
            IsPremium = false;
            Descuento = 10;
        }

        public string CrearNombrecompleto(string nombre, string apellido) {

            if (string.IsNullOrEmpty(nombre)) {
                throw new ArgumentException("El nombre esta en blanco");
            }

            Descuento = 30;
            NombreCompleto = $"{nombre} {apellido}";
            return NombreCompleto;

        }

        public TipoCliente GetClienteDetalle()
        {

            if (OrderTotal < 500) {
                return new ClienteBasico();
            }

            return new ClientePremium();

        }

    }

    public class TipoCliente { }
    public class ClienteBasico : TipoCliente { }
    public class ClientePremium : TipoCliente { }

}
