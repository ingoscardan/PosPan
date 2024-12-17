using System.Diagnostics;
using Services.Extensions;

namespace ServicesTests.Extensions;

[TestFixture]
public class StringExtensionsTests
{
    [TestCase("este es un    string\nque tiene muchos espacios en blanco, y hasta un salto de \t linea", "este-es-un-string-que-tiene-muchos-espacios-en-blanco-y-hasta-un-salto-de-linea")]
    [TestCase("\teste tienen ácento\t", "este-tienen-ácento")]
    [TestCase("\teste es un\t", "este-es-un")]
    [TestCase("\teste es--un\t", "este-es-un")]
    [TestCase("\tunapalabra\t", "unapalabra")]
    public void GetDashedString_ReturnsDashedString(string strToEval, string expectedResult)
    {;
        var result = strToEval.ToDashedString();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ToDashedNotation_ReturnsAStringWithWordsSeparatedByDashesInLowerCase()
    {
        var strToEval = "\teSte es un\t";
        var expectedResult = "este-es-un";
        var result = strToEval.ToDashedNotation();
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}