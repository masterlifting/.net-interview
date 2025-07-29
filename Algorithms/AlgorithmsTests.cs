using static Algorithm.Algorithms;

namespace Algorithm.Tests;

public class AlgorithmTests
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

    [Theory]
    [InlineData("", "", true)]
    [InlineData("a", "a", true)]
    [InlineData("a", "b", false)]
    [InlineData("abc", "cba", true)]
    [InlineData("rat", "car", false)]
    [InlineData("aa", "bb", false)]
    [InlineData("aa", "aabb", false)]
    [InlineData("aa", "bbbb", false)]
    [InlineData("a", "aa", false)]
    public void IsAnagram(string s, string t, bool expected)
    {
        var result = Algorithms.IsAnagram(s, t);
        Assert.Equal(expected, result);
    }


    [Theory]
    [InlineData("Basic")]
    [InlineData("NonOverlapping")]
    [InlineData("AllOverlapping")]
    [InlineData("UnsortedInput")]
    [InlineData("AdjacentIntervals")]
    public void MergeIntervals(string testCase)
    {
        int[][] intervals;
        int[][] expected;

        switch (testCase)
        {
            case "Basic":
                intervals =
                [
                  [1, 3],
          [2, 6],
          [8, 10],
          [15, 18]
                ];
                expected =
                [
                  [1, 6],
          [8, 10],
          [15, 18]
                ];
                break;
            case "NonOverlapping":
                intervals =
                [
                  [1, 2],
          [3, 4],
          [5, 6]
                ];
                expected =
                [
                  [1, 2],
          [3, 4],
          [5, 6]
                ];
                break;
            case "AllOverlapping":
                intervals =
                [
                  [1, 10],
          [2, 9],
          [3, 8],
          [4, 7]
                ];
                expected =
                [
                  [1, 10]
                ];
                break;
            case "UnsortedInput":
                intervals =
                [
                  [15, 18],
          [2, 6],
          [1, 3],
          [8, 10]
                ];
                expected =
                [
                  [1, 6],
          [8, 10],
          [15, 18]
                ];
                break;
            case "AdjacentIntervals":
                intervals =
                [
                  [1, 3],
          [3, 6],
          [6, 10]
                ];
                expected =
                [
                  [1, 10]
                ];
                break;
            default:
                throw new ArgumentException($"Unknown test case: {testCase}");
        }

        var result = Algorithms.MergeIntervals(intervals);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 9, new int[] { 3, 4 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 10, new int[] { })] // No solution
    public void TwoSum(int[] nums, int target, int[] expected)
    {
        var result = Algorithms.TwoSum(nums, target);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
                new string[] { "eat,tea,ate", "tan,nat", "bat" })]
    [InlineData(new string[] { "listen", "silent", "enlist", "inlets", "google" },
                new string[] { "listen,silent,enlist,inlets", "google" })]
    [InlineData(new string[] { "abc", "bca", "cab", "xyz", "zyx" },
                new string[] { "abc,bca,cab", "xyz,zyx" })]
    [InlineData(new string[] { "a", "b", "c" },
                new string[] { "a", "b", "c" })]
    public void GroupAnagrams(string[] strs, string[] expectedGroups)
    {
        var result = Algorithms.GroupAnagrams(strs);

        // Convert string representation to expected format
        var expected = expectedGroups
            .Select(g => g.Split(',').ToList() as IList<string>)
            .ToList();

        // Check that each expected group is in the result
        Assert.Equal(expected.Count, result.Count);
        foreach (var expectedGroup in expected)
        {
            Assert.Contains(result, resultGroup =>
                expectedGroup.Count == resultGroup.Count &&
                expectedGroup.All(word => resultGroup.Contains(word)));
        }
    }

    [Theory]
    [InlineData("ab#c", "ad#c", true)]
    [InlineData("ab##", "c#d#", true)]
    [InlineData("a##c", "#a#c", true)]
    [InlineData("a#b#c", "c", true)]
    [InlineData("a#b#c", "a#b#c", true)]
    [InlineData("a#b#c", "b#c", true)]
    [InlineData("xywrrmp", "xywrrm#p", false)]
    public void BackspaceCompare(string s, string t, bool expected)
    {
        var result = Algorithms.BackspaceCompare(s, t);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new int[] { 1, 3, 5 }, new int[] { 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
    public void MergeTwoSortedLists(int[] l1, int[] l2, int[] expected)
    {
        static ListNode? ToList(int[] values)
        {
            return values.Length switch
            {
                0 => null,
                1 => new ListNode(values[0]),
                _ => new ListNode(values[0], ToList(values[1..])),
            };
        }

        static int[] FromList(ListNode? node)
        {
            var result = new List<int>();

            while (node != null)
            {
                result.Add(node.Val);
                node = node.Next;
            }

            return [.. result];
        }

        var list1 = ToList(l1);
        var list2 = ToList(l2);

        var result = Algorithms.MergeTwoSortedLists(list1, list2);
        Assert.Equal(expected, FromList(result));
    }

    [Fact]
    public void EmptyArray_BothSorts_HandleCorrectly()
    {
        var array1 = new int[] { };
        var array2 = new int[] { };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Empty(array1);
        Assert.Empty(array2);
    }

    [Fact]
    public void SingleElement_BothSorts_RemainUnchanged()
    {
        var array1 = new int[] { 42 };
        var array2 = new int[] { 42 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { 42 }, array1);
        Assert.Equal(new int[] { 42 }, array2);
    }

    [Fact]
    public void TwoElements_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 2, 1 };
        var array2 = new int[] { 2, 1 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { 1, 2 }, array1);
        Assert.Equal(new int[] { 1, 2 }, array2);
    }

    [Fact]
    public void AlreadySorted_BothSorts_RemainSorted()
    {
        var array1 = new int[] { 1, 2, 3 };
        var array2 = new int[] { 1, 2, 3 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { 1, 2, 3 }, array1);
        Assert.Equal(new int[] { 1, 2, 3 }, array2);
    }

    [Fact]
    public void ReverseSorted_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 3, 2, 1 };
        var array2 = new int[] { 3, 2, 1 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { 1, 2, 3 }, array1);
        Assert.Equal(new int[] { 1, 2, 3 }, array2);
    }

    [Fact]
    public void Duplicates_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 1, 2, 2, 3 };
        var array2 = new int[] { 1, 2, 2, 3 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { 1, 2, 2, 3 }, array1);
        Assert.Equal(new int[] { 1, 2, 2, 3 }, array2);
    }

    [Fact]
    public void NegativeNumbers_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { -3, -2, -1 };
        var array2 = new int[] { -3, -2, -1 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { -3, -2, -1 }, array1);
        Assert.Equal(new int[] { -3, -2, -1 }, array2);
    }

    [Fact]
    public void MixedPositiveNegative_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { -1, 0, 1 };
        var array2 = new int[] { -1, 0, 1 };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new int[] { -1, 0, 1 }, array1);
        Assert.Equal(new int[] { -1, 0, 1 }, array2);
    }

    [Fact]
    public void StringArray_BothSorts_SortAlphabetically()
    {
        var array1 = new string[] { "banana", "apple", "cherry" };
        var array2 = new string[] { "banana", "apple", "cherry" };

        QuickSort(array1);
        MergeSort(array2);

        Assert.Equal(new string[] { "apple", "banana", "cherry" }, array1);
        Assert.Equal(new string[] { "apple", "banana", "cherry" }, array2);
    }
}
