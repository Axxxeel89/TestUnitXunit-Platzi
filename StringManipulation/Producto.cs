namespace StringManipulation
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }


        public double GetPrecio(Cliente cliente) //-> Va a dependender del tipo de cliente, si es premium va a tener un precio diferente.
        {

            if (cliente.IsPremium)
            {
                return Precio * .8;
            }

            return Precio;
        }



        public double GetPrecio(ICliente cliente) //-> Va a dependender del tipo de cliente, si es premium va a tener un precio diferente.
        {
            if (cliente.IsPremium)
            {
                return Precio * .8;
            }

            return Precio;

        }
    }
}
