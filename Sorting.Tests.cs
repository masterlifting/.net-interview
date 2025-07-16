namespace Algorithm.Tests;

public class SortingTests
{
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

    [Fact]
    public void AlreadySorted_BothSorts_RemainSorted()
    {
        var array1 = new int[] { 1, 2, 3 };
        var array2 = new int[] { 1, 2, 3 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2, 3 }, array1);
        Assert.Equal(new int[] { 1, 2, 3 }, array2);
    }

    [Fact]
    public void ReverseSorted_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 3, 2, 1 };
        var array2 = new int[] { 3, 2, 1 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2, 3 }, array1);
        Assert.Equal(new int[] { 1, 2, 3 }, array2);
    }

    [Fact]
    public void Duplicates_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { 1, 2, 2, 3 };
        var array2 = new int[] { 1, 2, 2, 3 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { 1, 2, 2, 3 }, array1);
        Assert.Equal(new int[] { 1, 2, 2, 3 }, array2);
    }

    [Fact]
    public void NegativeNumbers_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { -3, -2, -1 };
        var array2 = new int[] { -3, -2, -1 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { -3, -2, -1 }, array1);
        Assert.Equal(new int[] { -3, -2, -1 }, array2);
    }

    [Fact]
    public void MixedPositiveNegative_BothSorts_SortCorrectly()
    {
        var array1 = new int[] { -1, 0, 1 };
        var array2 = new int[] { -1, 0, 1 };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new int[] { -1, 0, 1 }, array1);
        Assert.Equal(new int[] { -1, 0, 1 }, array2);
    }

    [Fact]
    public void StringArray_BothSorts_SortAlphabetically()
    {
        var array1 = new string[] { "banana", "apple", "cherry" };
        var array2 = new string[] { "banana", "apple", "cherry" };
        
        Sorting.QuickSort(array1);
        Sorting.MergeSort(array2);
        
        Assert.Equal(new string[] { "apple", "banana", "cherry" }, array1);
        Assert.Equal(new string[] { "apple", "banana", "cherry" }, array2);
    }
}
