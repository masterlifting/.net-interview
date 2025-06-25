namespace LiveCoding;

public class AlgorithmsTests
{
    [Theory]
    [InlineData("one,two,three", new string[] { "one", "two", "three" })]
    [InlineData("one,\"two,with,comma\",three", new string[] { "one", "two,with,comma", "three" })]
    [InlineData("\"a,b\"", new string[] { "a,b" })]
    [InlineData("", new string[0])]
    public void ParseCsv(string input, string[] expected)
    {
        var result = Algorithms.ParseCsv(input);
        Assert.Equal(expected, result);
    }
}