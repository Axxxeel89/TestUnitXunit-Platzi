using Moq;

namespace StringManipulation.tests
{
    //[TestFixture]
    public class CuentaBancariaTest
    {
        [Fact]
        public void Deposito_InputMonto100_ReturnsTrue() 
        {
            //Arrenge
            var mockLogger = new Mock<ILoggerGeneral>();
            var cuentaBancaria = new CuentaBancaria(mockLogger.Object);

            //Act
            var resultado = cuentaBancaria.Deposito(100);

            //Assert
            Assert.True(resultado);
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        //[InlineData(50, 100)]
        public void Retiro_Retiro100CponBalance200_ReturnTrue(int balance, int retiro)
        {
            //Arrenge
            var mockingLogger = new Mock<ILoggerGeneral>();
            mockingLogger.Setup(d => d.LogDatabase(It.IsAny<string>())).Returns(true);
            mockingLogger.Setup(d => d.LogBalanceDespuesRetiro(It.Is<int>(x => x>0))).Returns(true); //Condicionamos a que el balance sea mayor a 0

            CuentaBancaria cuentaBancaria = new CuentaBancaria(mockingLogger.Object);
            cuentaBancaria.Deposito(balance);

            //if(cuentaBancaria.GetBalance() < retiro) //Validamos que el retiro no vaya hacer mayor al balance
            //{
            //    mockingLogger.Setup(d => d.LogBalanceDespuesRetiro(It.IsAny<int>())).Returns(false);
            //}

            //Act
            var result = cuentaBancaria.Retiro(retiro);

            //Assert
            Assert.True(result); 
        }

        [Theory]
        [InlineData(200, 300)]
        public void Retiro_Retiro300CponBalance200_ReturnFalse(int balance, int retiro)
        {
            //Arrenge
            var mockingLogger = new Mock<ILoggerGeneral>();
            //mockingLogger.Setup(d => d.LogBalanceDespuesRetiro(It.Is<int>(x => x < 0))).Returns(false); //Condicionamos a que el balance sea mayor a 0
            mockingLogger.Setup(d => d.LogBalanceDespuesRetiro(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(mockingLogger.Object);
            cuentaBancaria.Deposito(balance);

            //Act
            var result = cuentaBancaria.Retiro(retiro);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CuentaBancariaLoggerGeneral_logMocking_ReturnTrue()
        {
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textoPrueba = "hola santi";

            //Indicamos que el parametro que va a entrar es un string y va a retornar un string pero en minuscula.
            loggerGeneralMock.Setup(m =>m.MessageConReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            //Act
            var result = loggerGeneralMock.Object.MessageConReturnString("hoLA SAnti");

            Assert.Equal(textoPrueba, result);
        }
    }
}
