using Xunit;

namespace AlghorithmStrutures.Tests;

public class SortingTests
{
  // ==== QUICKSORT TESTS ====

  [Fact]
  public void QuickSort_EmptyArray_HandlesCorrectly()
  {
    var data = new int[] { };
    
    Sorting.QuickSort(data);
    
    Assert.Empty(data);
  }

  [Fact]
  public void QuickSort_SingleElement_RemainsUnchanged()
  {
    var data = new int[] { 42 };
    var expected = new int[] { 42 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_TwoElements_SortsCorrectly()
  {
    var data = new int[] { 2, 1 };
    var expected = new int[] { 1, 2 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_TwoElementsAlreadySorted_RemainsCorrect()
  {
    var data = new int[] { 1, 2 };
    var expected = new int[] { 1, 2 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_SmallArray_SortsCorrectly()
  {
    var data = new int[] { 3, 1, 4, 1, 5 };
    var expected = new int[] { 1, 1, 3, 4, 5 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_ReverseSortedArray_SortsCorrectly()
  {
    var data = new int[] { 5, 4, 3, 2, 1 };
    var expected = new int[] { 1, 2, 3, 4, 5 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_AlreadySortedArray_RemainsCorrect()
  {
    var data = new int[] { 1, 2, 3, 4, 5 };
    var expected = new int[] { 1, 2, 3, 4, 5 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_ArrayWithDuplicates_SortsCorrectly()
  {
    var data = new int[] { 3, 1, 3, 2, 1, 2, 3 };
    var expected = new int[] { 1, 1, 2, 2, 3, 3, 3 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_AllSameElements_RemainsUnchanged()
  {
    var data = new int[] { 5, 5, 5, 5, 5 };
    var expected = new int[] { 5, 5, 5, 5, 5 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_LargerArray_SortsCorrectly()
  {
    var data = new int[] { 64, 34, 25, 12, 22, 11, 90, 88, 76, 50, 42 };
    var expected = new int[] { 11, 12, 22, 25, 34, 42, 50, 64, 76, 88, 90 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_NegativeNumbers_SortsCorrectly()
  {
    var data = new int[] { -3, 1, -4, 1, 5, -9, 2, 6 };
    var expected = new int[] { -9, -4, -3, 1, 1, 2, 5, 6 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_MixedPositiveNegativeZero_SortsCorrectly()
  {
    var data = new int[] { 0, -5, 3, 0, -2, 8, -1 };
    var expected = new int[] { -5, -2, -1, 0, 0, 3, 8 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_StringArray_SortsAlphabetically()
  {
    var data = new string[] { "banana", "apple", "cherry", "date" };
    var expected = new string[] { "apple", "banana", "cherry", "date" };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_StringArrayWithDuplicates_SortsCorrectly()
  {
    var data = new string[] { "cat", "bat", "cat", "ant", "bat" };
    var expected = new string[] { "ant", "bat", "bat", "cat", "cat" };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_CharArray_SortsCorrectly()
  {
    var data = new char[] { 'z', 'a', 'm', 'b', 'y' };
    var expected = new char[] { 'a', 'b', 'm', 'y', 'z' };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_DoubleArray_SortsCorrectly()
  {
    var data = new double[] { 3.14, 2.71, 1.41, 0.57, 1.73 };
    var expected = new double[] { 0.57, 1.41, 1.73, 2.71, 3.14 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_LargeArray_PerformanceTest()
  {
    const int size = 10000;
    var data = new int[size];
    var random = new Random(42); // Fixed seed for reproducible results
    
    // Fill with random data
    for (int i = 0; i < size; i++)
    {
      data[i] = random.Next(1, 1000);
    }
    
    // Create expected result by using Array.Sort
    var expected = new int[size];
    Array.Copy(data, expected, size);
    Array.Sort(expected);
    
    // Test our QuickSort
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_ArrayWithMinMaxValues_SortsCorrectly()
  {
    var data = new int[] { int.MaxValue, 0, int.MinValue, 1, -1 };
    var expected = new int[] { int.MinValue, -1, 0, 1, int.MaxValue };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_RandomizedArray_ProducesStableSortedResult()
  {
    var data = new int[] { 8, 3, 5, 4, 7, 6, 1, 2 };
    var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
    
    // Verify it's properly sorted
    for (int i = 1; i < data.Length; i++)
    {
      Assert.True(data[i] >= data[i - 1], $"Array not properly sorted at index {i}");
    }
  }

  [Theory]
  [InlineData(new int[] { 1 })]
  [InlineData(new int[] { 1, 2 })]
  [InlineData(new int[] { 2, 1 })]
  [InlineData(new int[] { 1, 2, 3 })]
  [InlineData(new int[] { 3, 2, 1 })]
  [InlineData(new int[] { 2, 1, 3 })]
  public void QuickSort_VariousSmallArrays_SortsCorrectly(int[] input)
  {
    var expected = new int[input.Length];
    Array.Copy(input, expected, input.Length);
    Array.Sort(expected);
    
    Sorting.QuickSort(input);
    
    Assert.Equal(expected, input);
  }

  [Fact]
  public void QuickSort_ArrayWithRepeatedPattern_SortsCorrectly()
  {
    var data = new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };
    var expected = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
    
    Sorting.QuickSort(data);
    
    Assert.Equal(expected, data);
  }

  [Fact]
  public void QuickSort_NullArray_ThrowsArgumentNullException()
  {
    int[]? data = null;
    
    Assert.Throws<ArgumentNullException>(() => Sorting.QuickSort(data!));
  }

  [Fact]
  public void QuickSort_PreservesOriginalArrayLength()
  {
    var data = new int[] { 5, 2, 8, 1, 9 };
    var originalLength = data.Length;
    
    Sorting.QuickSort(data);
    
    Assert.Equal(originalLength, data.Length);
  }

  [Fact]
  public void QuickSort_SortsInPlace()
  {
    var data = new int[] { 3, 1, 4, 1, 5 };
    var originalArray = data; // Reference to the same array
    
    Sorting.QuickSort(data);
    
    // Should modify the original array, not create a new one
    Assert.Same(originalArray, data);
    Assert.Equal(new int[] { 1, 1, 3, 4, 5 }, data);
  }

  [Fact]
  public void QuickSort_VeryLargeArray_HandlesCorrectly()
  {
    const int size = 100000;
    var data = new int[size];
    
    // Create worst-case scenario: reverse sorted array
    for (int i = 0; i < size; i++)
    {
      data[i] = size - i;
    }
    
    Sorting.QuickSort(data);
    
    // Verify it's sorted
    for (int i = 1; i < data.Length; i++)
    {
      Assert.True(data[i] >= data[i - 1], "Array should be sorted in ascending order");
    }
    
    Assert.Equal(1, data[0]);
    Assert.Equal(size, data[size - 1]);
  }

  [Fact]
  public void QuickSort_CustomComparableType_SortsCorrectly()
  {
    var data = new Person[] 
    {
      new Person("Charlie", 30),
      new Person("Alice", 25),
      new Person("Bob", 35),
      new Person("Alice", 20)
    };
    
    Sorting.QuickSort(data);
    
    Assert.Equal("Alice", data[0].Name);
    Assert.Equal(20, data[0].Age);
    Assert.Equal("Alice", data[1].Name);
    Assert.Equal(25, data[1].Age);
    Assert.Equal("Bob", data[2].Name);
    Assert.Equal("Charlie", data[3].Name);
  }

  // Helper class for testing custom IComparable types
  private class Person : IComparable<Person>
  {
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
      Name = name;
      Age = age;
    }

    public int CompareTo(Person? other)
    {
      if (other == null) return 1;
      
      var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
      if (nameComparison != 0) return nameComparison;
      
      return Age.CompareTo(other.Age);
    }
  }
}