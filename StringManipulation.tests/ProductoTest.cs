using Moq;

namespace StringManipulation.tests
{
    public class ProductoTest
    {
        [Fact]
        public void GetPrecio_CustomerPremium_ReturnsPrice80Percent()
        {
            Producto produOperation = new Producto
            {
                Precio = 50
            };

            var result = produOperation.GetPrecio(new Cliente { IsPremium = true });

            Assert.Equal(40, result);
        }

        [Fact]
        public void GetPrecio_CustomerPremiumMoq_ReturnsPrice80Percent()
        {
            Producto produOperation = new Producto
            {
                Precio = 50
            };
            var mockingCliente = new Mock<ICliente>();
            mockingCliente.Setup(c => c.IsPremium).Returns(true);

            var result = produOperation.GetPrecio(mockingCliente.Object);

            Assert.Equal(40, result);
        }
    }
}
