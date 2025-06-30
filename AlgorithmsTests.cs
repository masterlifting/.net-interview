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

  [Theory]
  [InlineData(new int[] { 3, 2, 1 }, 1)]
  [InlineData(new int[] { 1, 2 }, 2)]
  [InlineData(new int[] { 2, 2, 3, 1 }, 1)]
  [InlineData(new int[] { 1, 2, 2 }, 2)]
  [InlineData(new int[] { 5, 2, 2 }, 5)]
  [InlineData(new int[] { 1, 2, -2, 3 }, 1)]
  public void ThirdMax(int[] input, int expected)
  {
    var result = Algorithms.ThirdMax(input);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' })]
  [InlineData(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new char[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
  public void ReverseString(char[] input, char[] expected)
  {
    Algorithms.ReverseString(input);
    Assert.Equal(expected, input);
  }

  [Theory]
  [InlineData("racecar", true)]
  [InlineData("hello", false)]
  [InlineData("A man, a plan, a canal: Panama", true)]
  [InlineData("No 'x' in Nixon", true)]
  public void IsPalindrome(string input, bool expected)
  {
    var result = Algorithms.IsPalindrome(input);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(234, 15)]
  [InlineData(4421, 21)]
  [InlineData(123456, 699)]
  public void SubtractProductAndSum(int n, int expected)
  {
    var result = Algorithms.SubtractProductAndSum(n);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData(0, 0, 2, 4, 120)]
  public void SumMatrix(int row1, int col1, int row2, int col2, int expected)
  {
    int[][] matrix =
    [
      [1, 2, 3, 4, 5],
      [6, 7, 8, 9, 10],
      [11, 12, 13, 14, 15]
    ];

    var result = Algorithms.SumMatrix(matrix, row1, col1, row2, col2);
    Assert.Equal(expected, result);
  }
}
