using NUnit.Framework;
using Moq;

namespace SStringCalculatorKata;

[TestFixture]
public class StringCalculatorTest
{
    [Test]
    public void Add_WhenGivenStringOfNumbers_ReturnsANumber() {
        //Arrange
        var sut = new StringCalculator();

        //Act
        var result = sut.Add("32423420");

        //Assert
        Assert.IsInstanceOf<Decimal>(result);
    }

    [Test]
    public void Add_WhenGivenEmptyString_ReturnsAZero() {
        //Arrange
        var sut = new StringCalculator();

        //Act
        var result = sut.Add(String.Empty);

        //Assert
        Assert.AreEqual((Decimal)0, result);
    }

    [Test]
    public void Add_WhenGivenASingleStringNumber_ReturnTheNumber() {
        //Arrange
        var sut = new StringCalculator();

        //Act
        var result = sut.Add("210");

        //Assert
        Assert.AreEqual((Decimal)210, result);
    }

    [Test]
    public void Add_WhenGivenMultipleStringNumbers_ReturnTheSum() {
        //Arrange
        var sut = new StringCalculator();

        //Act
        var result = sut.Add("10, 20, 30, 40, 10, 70");

        //Assert
        Assert.AreEqual((Decimal)180, result);
    }

    [Test]
    public void Subtract_WhenGivenMultipleStringNumbers_ReturnTheSum() {
        //Arrange
        var sut = new StringCalculator();

        //Act
        var result = sut.Subtract(String.Empty);

        //Assert
        Assert.AreEqual((Decimal)0, result);
    }
}
