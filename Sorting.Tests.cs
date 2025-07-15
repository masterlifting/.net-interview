using Xunit;

namespace AlghorithmStrutures.Tests;

public class SortingTests
{
    // Test 1: Empty array
    [Fact]
    public void EmptyArray_BothSorts_HandleCorrectly()
    {
        var array1 = new int[] { };
        var array2 = new int[] { };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Empty(array1);
        Assert.Empty(array2);
    }
    
    // Test 2: Single element array
    [Fact]
    public void SingleElement_BothSorts_RemainUnchanged()
    {
        var array1 = new int[] { 42 };
        var array2 = new int[] { 42 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 42 }, array1);
        Assert.Equal(new int[] { 42 }, array2);
    }
    
    // Test 3: Two element array (reversed order)
    [Fact]
    public void TwoElements_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 2, 1 };
        var array2 = new int[] { 2, 1 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2 }, array1);
        Assert.Equal(new int[] { 1, 2 }, array2);
    }
    
    // Test 4: Already sorted array
    [Fact]
    public void AlreadySorted_BothSorts_RemainSorted()
    {
        var array1 = new int[] { 1, 2, 3, 4, 5 };
        var array2 = new int[] { 1, 2, 3, 4, 5 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array1);
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array2);
    }
    
    // Test 5: Reversed sorted array
    [Fact]
    public void ReverseSorted_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 5, 4, 3, 2, 1 };
        var array2 = new int[] { 5, 4, 3, 2, 1 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array1);
        Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, array2);
    }
    
    // Test 6: Array with duplicates
    [Fact]
    public void Duplicates_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
        var array2 = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 1, 2, 3, 4, 5, 5, 6, 9 }, array1);
        Assert.Equal(new int[] { 1, 1, 2, 3, 4, 5, 5, 6, 9 }, array2);
    }
    
    // Test 7: All same elements
    [Fact]
    public void AllSameElements_BothSorts_RemainUnchanged()
    {
        var array1 = new int[] { 7, 7, 7, 7, 7 };
        var array2 = new int[] { 7, 7, 7, 7, 7 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 7, 7, 7, 7, 7 }, array1);
        Assert.Equal(new int[] { 7, 7, 7, 7, 7 }, array2);
    }
    
    // Test 8: Negative numbers
    [Fact]
    public void NegativeNumbers_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { -3, -1, -4, -1, -5 };
        var array2 = new int[] { -3, -1, -4, -1, -5 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { -5, -4, -3, -1, -1 }, array1);
        Assert.Equal(new int[] { -5, -4, -3, -1, -1 }, array2);
    }
    
    // Test 9: Mixed positive and negative numbers
    [Fact]
    public void MixedPositiveNegative_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { -3, 1, -4, 1, 5, -9, 2, 6 };
        var array2 = new int[] { -3, 1, -4, 1, 5, -9, 2, 6 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { -9, -4, -3, 1, 1, 2, 5, 6 }, array1);
        Assert.Equal(new int[] { -9, -4, -3, 1, 1, 2, 5, 6 }, array2);
    }
    
    // Test 10: String sorting
    [Fact]
    public void StringArray_BothSorts_SortAlphabetically()
    {
        var array1 = new string[] { "banana", "apple", "cherry", "date" };
        var array2 = new string[] { "banana", "apple", "cherry", "date" };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new string[] { "apple", "banana", "cherry", "date" }, array1);
        Assert.Equal(new string[] { "apple", "banana", "cherry", "date" }, array2);
    }
    
    // Test 11: Character sorting
    [Fact]
    public void CharArray_BothSorts_SortCorrectly()
    {
        var array1 = new char[] { 'z', 'a', 'm', 'b', 'y' };
        var array2 = new char[] { 'z', 'a', 'm', 'b', 'y' };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new char[] { 'a', 'b', 'm', 'y', 'z' }, array1);
        Assert.Equal(new char[] { 'a', 'b', 'm', 'y', 'z' }, array2);
    }
    
    // Test 12: Double sorting
    [Fact]
    public void DoubleArray_BothSorts_SortCorrectly()
    {
        var array1 = new double[] { 3.14, 2.71, 1.41, 0.57, 1.73 };
        var array2 = new double[] { 3.14, 2.71, 1.41, 0.57, 1.73 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new double[] { 0.57, 1.41, 1.73, 2.71, 3.14 }, array1);
        Assert.Equal(new double[] { 0.57, 1.41, 1.73, 2.71, 3.14 }, array2);
    }
    
    // Test 13: Min/Max values
    [Fact]
    public void MinMaxValues_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { int.MaxValue, 0, int.MinValue };
        var array2 = new int[] { int.MaxValue, 0, int.MinValue };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { int.MinValue, 0, int.MaxValue }, array1);
        Assert.Equal(new int[] { int.MinValue, 0, int.MaxValue }, array2);
    }
    
    // Test 14: Random shuffled array
    [Fact]
    public void RandomShuffledArray_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 8, 3, 5, 4, 7, 6, 1, 2 };
        var array2 = new int[] { 8, 3, 5, 4, 7, 6, 1, 2 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, array1);
        Assert.Equal(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, array2);
    }
    
    // Test 15: Repeated pattern
    [Fact]
    public void RepeatedPattern_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };
        var array2 = new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }, array1);
        Assert.Equal(new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3 }, array2);
    }
    
    // Test 17: Array with zeroes
    [Fact]
    public void ArrayWithZeroes_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 0, 0, 5, 0, -1, 0, 3 };
        var array2 = new int[] { 0, 0, 5, 0, -1, 0, 3 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { -1, 0, 0, 0, 0, 3, 5 }, array1);
        Assert.Equal(new int[] { -1, 0, 0, 0, 0, 3, 5 }, array2);
    }
    
    // Test 18: Custom comparable type
    [Fact]
    public void CustomComparableType_BothSorts_SortCorrectly()
    {
        var array1 = new Person[]
        {
            new Person("Charlie", 30),
            new Person("Alice", 25),
            new Person("Bob", 35),
            new Person("Alice", 20)
        };
        
        var array2 = new Person[]
        {
            new Person("Charlie", 30),
            new Person("Alice", 25),
            new Person("Bob", 35),
            new Person("Alice", 20)
        };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        // Check both results match expected order
        Assert.Equal("Alice", array1[0].Name);
        Assert.Equal(20, array1[0].Age);
        Assert.Equal("Alice", array1[1].Name);
        Assert.Equal(25, array1[1].Age);
        Assert.Equal("Bob", array1[2].Name);
        Assert.Equal("Charlie", array1[3].Name);
        
        Assert.Equal("Alice", array2[0].Name);
        Assert.Equal(20, array2[0].Age);
        Assert.Equal("Alice", array2[1].Name);
        Assert.Equal(25, array2[1].Age);
        Assert.Equal("Bob", array2[2].Name);
        Assert.Equal("Charlie", array2[3].Name);
    }
    
    // Test 19: Stability verification
    [Fact]
    public void StableSort_MergeSortMaintainsRelativeOrder()
    {
        var array = new Item[]
        {
            new Item(5, "First"),
            new Item(3, "First"), 
            new Item(3, "Second"),
            new Item(1, "First"),
            new Item(1, "Second")
        };
        
        // MergeSort should be stable
        Sorting.MergeSort(array);
        
        Assert.Equal(1, array[0].Key);
        Assert.Equal("First", array[0].Value);
        Assert.Equal(1, array[1].Key);
        Assert.Equal("Second", array[1].Value);
        Assert.Equal(3, array[2].Key);
        Assert.Equal("First", array[2].Value);
        Assert.Equal(3, array[3].Key);
        Assert.Equal("Second", array[3].Value);
        Assert.Equal(5, array[4].Key);
    }
    
    // Test 20: Performance with large array
    [Fact]
    public void LargeArray_BothSorts_SortCorrectly()
    {
        const int size = 1000;
        var random = new Random(42); // Fixed seed for reproducible results
        
        var array1 = new int[size];
        var array2 = new int[size];
        var expected = new int[size];
        
        // Fill with random data
        for (int i = 0; i < size; i++)
        {
            array1[i] = random.Next(1, 1000);
            array2[i] = array1[i];
            expected[i] = array1[i];
        }
        
        Array.Sort(expected);
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(expected, array1);
        Assert.Equal(expected, array2);
    }
    
    // Helper classes for testing
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
    
    private class Item : IComparable<Item>
    {
        public int Key { get; }
        public string Value { get; }
        
        public Item(int key, string value)
        {
            Key = key;
            Value = value;
        }
        
        public int CompareTo(Item? other)
        {
            if (other == null) return 1;
            return Key.CompareTo(other.Key);
        }
    }
}
