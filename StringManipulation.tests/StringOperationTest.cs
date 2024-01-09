using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace StringManipulation.tests
{
    public class StringOperationTest
    {
        //La descripción del porque se va a saltar debe ser clara, ademas debe un ticket en el backlog para indicar cuando se solucionara
        [Fact(Skip = "Esta prueba no es valida en este momento, TICKET-001")]
        public void ConcatenateStrings()
        {
            //Arrenge
            var strOperation = new StringOperations();
            
            //Act
            var resultado = strOperation.ConcatenateStrings("Hello", "Platzi");

            //Assert
            Assert.NotNull(resultado);  //Validamos que no sea null
            Assert.NotEmpty(resultado);  //Validamos que no este vacio
            Assert.Equal("Hello Platzi", resultado);
            
        }

        [Fact]
        public void IsPalindrome_True() 
        {
            //Arrenge
            var strOperation = new StringOperations();

            //Act
            var result = strOperation.IsPalindrome("somos");

            //Assert
            Assert.NotNull(result);
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            //Arrenge
            var strOperation = new StringOperations();

            //Act
            var result = strOperation.IsPalindrome("Hello");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void QuantityInWords_ContainsWords()
        {
            //Arrenge
            var strOperation = new StringOperations();

            //Act
            var result = strOperation.QuantintyInWords("dog", 8);

            //Assert
            Assert.StartsWith("ocho", result); //->Valida que el string empiece con unos caracteres
            Assert.Contains("dog", result); //Que busque si contiene la palabra dog en el string
            
        }

        [Fact]
        public void GetStringLength_Exception()
        {
            //Arrenge
            var strOperation = new StringOperations();

            //Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperation.GetStringLength(null));
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        [InlineData("VII", 7)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {

            var strOperation = new StringOperations();

            var result = strOperation.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);

        }

        [Fact]
        public void CountOccurrences_Count()
        {
            //Arrenge
            var mockLogger = new Mock<ILogger<StringOperations>>(); // Utilizamos un mock del logger para aislar la prueba de la funcionalidad del logger,
            var strOperation = new StringOperations(mockLogger.Object); // centrándonos exclusivamente en evaluar la lógica de negocio de CountOccurrences.

            //Act
            var result = strOperation.CountOccurrences("Hola santi, te amo", 'a');

            //Assert
            Assert.Equal(3, result); 
        }

        [Fact]  
        public void ReadFile()
        {
            //Arrenge
            var strOperation = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            //Debemos programar el funcionamiento ya que esta dependencia si tiene un funcionamiento en la logica del negocio
            //mockFileReader.Setup(p => p.ReadString("file.txt")).Returns("Reading file"); //-Puede ser que le agreguemos el nombre concreto
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file"); //Simularia que puede ser cualquier nombre que le pasemos de tipo string

            //Act
            //var result = strOperation.ReadFile(mockFileReader.Object, "file.txt"); //Puede ser file.txt
            var result = strOperation.ReadFile(mockFileReader.Object, "file2.txt");  //Puede ser file2.txt

            //Assert
            Assert.Equal("Reading file", result); 

        }

        [Theory]
        [InlineData(1, 10)]
        public void GetListNumberImpar_ImparNumbers(int min, int max)
        {
            //Arrenge
            var strOperation = new StringOperations();
            List<int> expectedList = new List<int> { 1, 3, 5, 7 , 9 };

            //Act 
            var result = strOperation.GetListNumberImpar(min, max);

            //Assert
            Assert.Equal(expectedList, result);

        }

    }
}                                   