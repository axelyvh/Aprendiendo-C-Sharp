namespace LibreriaAxel
{
    public class Producto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public double GetPrecio(Client cliente) {

            if (cliente.IsPremium) {
                return Precio * 0.8;
            }

            return Precio;

        }

        public double GetPrecio(IClient cliente)
        {

            if (cliente.IsPremium)
            {
                return Precio * 0.8;
            }

            return Precio;

        }

    }
}
