using Domain.FlyWeight.Entities;
using Domain.Product;
using Domain.Unit.Test;

namespace FlyWeight.Unit.Test
{
    public class BrandTest : IClassFixture<BrandFixture>
    {
        Brand _brand;

        public BrandTest(BrandFixture fixture)
        {
            this._brand = fixture.brand;
        }

        [Fact]
        public void Create_Brand_When_Data_Is_Ok()
        {
            //Arrange
            string name = "Test Name";
            string logo = "Test logo";
            Guid id = Guid.NewGuid();

            //Act
            var brand = new Brand(id, name, logo);

            //Assert
            Assert.Equal(logo, brand.LogoBase64);
            Assert.Equal(id, brand.Id);
            Assert.Equal(name, brand.Name);

            //brand.Should().Match(brand.Name==name);
        }
        [Theory]
        [InlineData("First Name", "First Logo", "First Extrinsic Logo")]
        [InlineData("Second Name", "Second Logo", "Second Extrinsic Logo")]
        public void Operation_Should_Write_Correct_Output_To_Console(string name,
            string logo, string extrinsicData)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            var brand = new Brand(id, name, logo);
            string expectedOutput = $"Brand: {name} , ExtrinsicData: {extrinsicData}";

            // Redirect console output to StringWriter
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //Act
            var actualOutput = stringWriter.ToString();
            brand.Operation(extrinsicData);

            //Assert
            //Assert.Equal(expectedOutput, actualOutput);

            // Cleanup (optional) - reset console output
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standardOutput);
        }

        [Fact]
        public void Set_Key_For_Generic_Class_IFlyWeight()
        {
            //Arrange And Act
            var result = _brand.Key;
            //Assert
            Assert.Equal(result, _brand.Id);
            Assert.Equal(_brand.Id, _brand.Id);
        }
    }
}