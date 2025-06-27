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

  [Theory]
  [InlineData("leetcode", 0)]
  [InlineData("loveleetcode", 2)]
  [InlineData("aabb", -1)]
  [InlineData("a", 0)]
  [InlineData("zxyz", 1)]
  public void FirstUniqueCharacterInString(string input, int expected)
  {
    var result = Algorithms.FirstUniqueCharacterInString(input);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(new int[] { 100, 4, 200, 1, 3, 2 }, 4)]
  [InlineData(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
  [InlineData(new int[] { 1, 2, 0, 1 }, 3)]
  [InlineData(new int[0], 0)]

  public void LongestConsecutiveSequence(int[] input, int expected)
  {
    var result = Algorithms.LongestConsecutiveSequence(input);
    Assert.Equal(expected, result);
  }
}
