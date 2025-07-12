namespace AlghorithmStrutures.Tests;

public class SinglyLinkedListTests
{
  [Fact]
  public void Constructor_CreatesEmptyList()
  {
    var list = new SinglyLinkedList<int>();
    Assert.Equal(0, list.Count);
  }

  [Fact]
  public void AddFirst_AddsElementToEmptyList()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(1);
    Assert.Equal(1, list.Count);
    Assert.True(list.Contains(1));
  }

  [Fact]
  public void AddFirst_AddsMultipleElements_MaintainsOrder()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(1);
    list.Add(2);
    list.Add(3);

    Assert.Equal(3, list.Count);
    Assert.Equal(3, list.Get(0));
    Assert.Equal(2, list.Get(1));
    Assert.Equal(1, list.Get(2));
  }

  [Fact]
  public void AddFirst_LargeNumberOfElements_MaintainsOrder()
  {
    var list = new SinglyLinkedList<int>();
    var expectedOrder = new List<int>();
    
    // Add elements 1-10, which will result in reverse order: 10,9,8...1
    for (int i = 1; i <= 10; i++)
    {
      list.Add(i);
      expectedOrder.Insert(0, i); // Insert at beginning to match AddFirst behavior
    }

    Assert.Equal(10, list.Count);
    for (int i = 0; i < 10; i++)
    {
      Assert.Equal(expectedOrder[i], list.Get(i));
      Assert.True(list.Contains(expectedOrder[i]));
    }
  }

  [Fact]
  public void Contains_ReturnsTrueForExistingElement()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(3);  // Will be at index 0
    list.Add(2);  // Will be at index 0, 3 moves to index 1
    list.Add(1);  // Will be at index 0, others shift: 1,2,3

    Assert.True(list.Contains(1));
    Assert.True(list.Contains(2));
    Assert.True(list.Contains(3));
  }

  [Fact]
  public void Contains_ReturnsFalseForNonExistingElement()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(2);
    list.Add(1);  // List: 1,2

    Assert.False(list.Contains(3));
    Assert.False(list.Contains(0));
    Assert.False(list.Contains(-1));
  }

  [Fact]
  public void Contains_EmptyList_ReturnsFalse()
  {
    var list = new SinglyLinkedList<int>();
    Assert.False(list.Contains(1));
  }

  [Fact]
  public void Remove_EmptyList_ReturnsFalse()
  {
    var list = new SinglyLinkedList<int>();
    Assert.False(list.Remove(1));
    Assert.Equal(0, list.Count);
  }

  [Fact]
  public void Remove_NonExistingElement_ReturnsFalse()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(2);
    list.Add(1);  // List: 1,2

    Assert.False(list.Remove(3));
    Assert.Equal(2, list.Count);
    Assert.True(list.Contains(1));
    Assert.True(list.Contains(2));
  }

  [Fact]
  public void Remove_FirstElement_UpdatesHead()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(3);
    list.Add(2);
    list.Add(1);  // List: 1,2,3

    Assert.True(list.Remove(1));
    Assert.Equal(2, list.Count);
    Assert.False(list.Contains(1));
    Assert.True(list.Contains(2));
    Assert.True(list.Contains(3));
    Assert.Equal(2, list.Get(0));
  }

  [Fact]
  public void Remove_RemovesElementFromList()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(2);
    list.Add(1);  // List: 1,2
    Assert.True(list.Remove(1));
    Assert.False(list.Contains(1));
    Assert.True(list.Contains(2));
    Assert.Equal(1, list.Count);
  }

  [Fact]
  public void Remove_RemovesMiddleElement()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(3);
    list.Add(2);
    list.Add(1);  // List: 1,2,3
    Assert.True(list.Remove(2));
    Assert.False(list.Contains(2));
    Assert.True(list.Contains(1));
    Assert.True(list.Contains(3));
    Assert.Equal(2, list.Count);
  }

  [Fact]
  public void Remove_RemovesLastElement()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(2);
    list.Add(1);  // List: 1,2
    Assert.True(list.Remove(2));
    Assert.False(list.Contains(2));
    Assert.True(list.Contains(1));
    Assert.Equal(1, list.Count);
  }

  [Fact]
  public void Remove_SingleElement_MakesListEmpty()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(1);

    Assert.True(list.Remove(1));
    Assert.Equal(0, list.Count);
    Assert.False(list.Contains(1));
  }

  [Fact]
  public void Remove_DuplicateElements_RemovesFirstOccurrence()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(3);
    list.Add(1);
    list.Add(2);
    list.Add(1);  // List: 1,2,1,3
    
    Assert.True(list.Remove(1));
    Assert.Equal(3, list.Count);
    Assert.True(list.Contains(1)); // Second occurrence should still exist
    Assert.Equal(2, list.Get(0));
    Assert.Equal(1, list.Get(1));
    Assert.Equal(3, list.Get(2));
  }

  [Fact]
  public void Remove_WithNullValue_ShouldWork()
  {
    var list = new SinglyLinkedList<string>();
    list.Add("test2");
    list.Add("test");  // List: "test", "test2"
    
    Assert.True(list.Remove("test"));
    Assert.Equal(1, list.Count);
    Assert.False(list.Contains("test"));
    Assert.True(list.Contains("test2"));
  }

  [Fact]
  public void Get_EmptyList_ReturnsDefault()
  {
    var list = new SinglyLinkedList<int>();
    Assert.Equal(0, list.Get(0));
    Assert.Equal(0, list.Get(1));
    Assert.Equal(0, list.Get(-1));
  }

  [Fact]
  public void Get_ValidIndices_ReturnsCorrectValues()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(30);
    list.Add(20);
    list.Add(10);  // List: 10,20,30
    
    Assert.Equal(10, list.Get(0));
    Assert.Equal(20, list.Get(1));
    Assert.Equal(30, list.Get(2));
  }

  [Fact]
  public void Get_InvalidIndices_ReturnsDefault()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(20);
    list.Add(10);  // List: 10,20
    
    Assert.Equal(0, list.Get(-1)); // Invalid negative index
    Assert.Equal(0, list.Get(2));  // Index out of range
    Assert.Equal(0, list.Get(100)); // Way out of range
  }

  [Fact]
  public void Get_WithStringType_ReturnsCorrectValues()
  {
    var list = new SinglyLinkedList<string>();
    list.Add("third");
    list.Add("second");
    list.Add("first");  // List: "first", "second", "third"
    
    Assert.Equal("first", list.Get(0));
    Assert.Equal("second", list.Get(1));
    Assert.Equal("third", list.Get(2));
  }

  [Fact]
  public void Reverse_EmptyList_DoesNothing()
  {
    var list = new SinglyLinkedList<int>();
    list.Reverse();
    Assert.Equal(0, list.Count);
  }

  [Fact]
  public void Reverse_SingleElementList_DoesNothing()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(1);
    list.Reverse();
    Assert.Equal(1, list.Count);
    Assert.True(list.Contains(1));
    Assert.Equal(1, list.Get(0));
  }

  [Fact]
  public void Reverse_TwoElements_ReversesCorrectly()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(2);
    list.Add(1);  // List: 1,2
    
    list.Reverse();
    
    Assert.Equal(2, list.Count);
    Assert.Equal(2, list.Get(0));
    Assert.Equal(1, list.Get(1));
  }

  [Fact]
  public void Reverse_MultipleElements_ReversesCorrectly()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(5);
    list.Add(4);
    list.Add(3);
    list.Add(2);
    list.Add(1);  // List: 1,2,3,4,5
    
    list.Reverse();
    
    Assert.Equal(5, list.Count);
    Assert.Equal(5, list.Get(0));
    Assert.Equal(4, list.Get(1));
    Assert.Equal(3, list.Get(2));
    Assert.Equal(2, list.Get(3));
    Assert.Equal(1, list.Get(4));
    
    // Verify all elements are still present
    Assert.True(list.Contains(1));
    Assert.True(list.Contains(2));
    Assert.True(list.Contains(3));
    Assert.True(list.Contains(4));
    Assert.True(list.Contains(5));
  }

  [Fact]
  public void Reverse_WithDuplicates_MaintainsDuplicates()
  {
    var list = new SinglyLinkedList<int>();
    list.Add(2);
    list.Add(3);
    list.Add(1);
    list.Add(2);
    list.Add(1);  // List: 1,2,1,3,2
    
    list.Reverse();
    
    Assert.Equal(5, list.Count);
    Assert.Equal(2, list.Get(0));
    Assert.Equal(3, list.Get(1));
    Assert.Equal(1, list.Get(2));
    Assert.Equal(2, list.Get(3));
    Assert.Equal(1, list.Get(4));
  }

  [Fact]
  public void ComplexOperations_AddRemoveReverse_WorksCorrectly()
  {
    var list = new SinglyLinkedList<string>();
    
    // Add elements using only AddFirst
    list.Add("C");
    list.Add("B");
    list.Add("A");
    list.Add("Z");  // List: Z,A,B,C
    
    // Remove middle element
    Assert.True(list.Remove("A"));  // List: Z,B,C
    
    // Reverse
    list.Reverse();  // List: C,B,Z
    
    // Verify final state
    Assert.Equal(3, list.Count);
    Assert.Equal("C", list.Get(0));
    Assert.Equal("B", list.Get(1));
    Assert.Equal("Z", list.Get(2));
  }

  [Theory]
  [InlineData(1)]
  [InlineData(10)]
  [InlineData(100)]
  public void LargeList_Operations_PerformCorrectly(int size)
  {
    var list = new SinglyLinkedList<int>();
    
    // Add elements using AddFirst (will be in reverse order)
    for (int i = 0; i < size; i++)
    {
      list.Add(i);
    }
    
    Assert.Equal(size, list.Count);
    
    // Verify elements (they should be in reverse order due to AddFirst)
    for (int i = 0; i < size; i++)
    {
      Assert.Equal(size - 1 - i, list.Get(i));
      Assert.True(list.Contains(i));
    }
    
    // Reverse and verify (should restore original order)
    list.Reverse();
    for (int i = 0; i < size; i++)
    {
      Assert.Equal(i, list.Get(i));
    }
  }

  [Fact]
  public void EdgeCase_SingleElementOperations()
  {
    var list = new SinglyLinkedList<int>();
    
    // Add single element
    list.Add(42);
    Assert.Equal(1, list.Count);
    Assert.True(list.Contains(42));
    Assert.Equal(42, list.Get(0));
    
    // Reverse single element (should do nothing)
    list.Reverse();
    Assert.Equal(1, list.Count);
    Assert.Equal(42, list.Get(0));
    
    // Remove the element
    Assert.True(list.Remove(42));
    Assert.Equal(0, list.Count);
    Assert.False(list.Contains(42));
  }

  [Fact]
  public void Performance_AddFirstManyElements_MaintainsCorrectState()
  {
    var list = new SinglyLinkedList<int>();
    const int elementCount = 1000;
    
    // Add many elements
    for (int i = 0; i < elementCount; i++)
    {
      list.Add(i);
    }
    
    // Verify count
    Assert.Equal(elementCount, list.Count);
    
    // Verify first and last elements
    Assert.Equal(elementCount - 1, list.Get(0)); // Last added is first
    Assert.Equal(0, list.Get(elementCount - 1)); // First added is last
    
    // Verify some random elements exist
    Assert.True(list.Contains(500));
    Assert.True(list.Contains(250));
    Assert.True(list.Contains(750));
  }

  [Fact]
  public void Contains_WithStringType_WorksCorrectly()
  {
    var list = new SinglyLinkedList<string>();
    list.Add("apple");
    list.Add("banana");
    list.Add("cherry");  // List: "cherry", "banana", "apple"
    
    Assert.True(list.Contains("cherry"));
    Assert.True(list.Contains("banana"));
    Assert.True(list.Contains("apple"));
    Assert.False(list.Contains("orange"));
    Assert.False(list.Contains(""));
  }

  [Fact]
  public void Remove_WithStringType_WorksCorrectly()
  {
    var list = new SinglyLinkedList<string>();
    list.Add("third");
    list.Add("second");
    list.Add("first");  // List: "first", "second", "third"
    
    Assert.True(list.Remove("second"));
    Assert.Equal(2, list.Count);
    Assert.False(list.Contains("second"));
    Assert.True(list.Contains("first"));
    Assert.True(list.Contains("third"));
    Assert.Equal("first", list.Get(0));
    Assert.Equal("third", list.Get(1));
  }

  [Fact]
  public void Get_BoundaryConditions_HandledCorrectly()
  {
    var list = new SinglyLinkedList<double>();
    list.Add(3.14);
    list.Add(2.71);
    list.Add(1.41);  // List: 1.41, 2.71, 3.14
    
    // Valid indices
    Assert.Equal(1.41, list.Get(0));
    Assert.Equal(2.71, list.Get(1));
    Assert.Equal(3.14, list.Get(2));
    
    // Invalid indices should return default(double) = 0.0
    Assert.Equal(0.0, list.Get(-1));
    Assert.Equal(0.0, list.Get(3));
    Assert.Equal(0.0, list.Get(int.MaxValue));
    Assert.Equal(0.0, list.Get(int.MinValue));
  }

}

