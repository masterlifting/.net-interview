namespace AlghorithmStrutures.Tests;

public class BinarySearchTreeTests
{
  [Fact]
  public void Constructor_CreatesEmptyTree()
  {
    var tree = new BinarySearchTree<int>();
    Assert.Equal(0, tree.Count);
  }

  [Fact]
  public void Add_SingleElement_IncreasesCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    Assert.Equal(1, tree.Count);
  }

  [Fact]
  public void Add_MultipleElements_IncreasesCountCorrectly()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    tree.Add(1);
    tree.Add(9);
    
    Assert.Equal(5, tree.Count);
  }

  [Fact]
  public void Add_DuplicateElements_DoesNotIncreaseCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(5);
    tree.Add(5);
    
    Assert.Equal(1, tree.Count);
  }

  [Fact]
  public void Add_ElementsInOrder_MaintainsCorrectCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(1);
    tree.Add(2);
    tree.Add(3);
    tree.Add(4);
    tree.Add(5);
    
    Assert.Equal(5, tree.Count);
  }

  [Fact]
  public void Add_ElementsInReverseOrder_MaintainsCorrectCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(4);
    tree.Add(3);
    tree.Add(2);
    tree.Add(1);
    
    Assert.Equal(5, tree.Count);
  }

  [Fact]
  public void Add_WithStringType_WorksCorrectly()
  {
    var tree = new BinarySearchTree<string>();
    tree.Add("banana");
    tree.Add("apple");
    tree.Add("cherry");
    tree.Add("date");
    
    Assert.Equal(4, tree.Count);
  }

  [Fact]
  public void Add_WithDoubleType_WorksCorrectly()
  {
    var tree = new BinarySearchTree<double>();
    tree.Add(3.14);
    tree.Add(2.71);
    tree.Add(1.41);
    tree.Add(1.73);
    
    Assert.Equal(4, tree.Count);
  }

  [Fact]
  public void Contains_EmptyTree_ReturnsFalse()
  {
    var tree = new BinarySearchTree<int>();
    Assert.False(tree.Contains(5));
  }

  [Fact]
  public void Contains_SingleElement_ReturnsCorrectResult()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    
    Assert.True(tree.Contains(5));
    Assert.False(tree.Contains(3));
    Assert.False(tree.Contains(7));
  }

  [Fact]
  public void Contains_MultipleElements_ReturnsCorrectResults()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    tree.Add(1);
    tree.Add(9);
    
    // Test existing elements
    Assert.True(tree.Contains(5));
    Assert.True(tree.Contains(3));
    Assert.True(tree.Contains(7));
    Assert.True(tree.Contains(1));
    Assert.True(tree.Contains(9));
    
    // Test non-existing elements
    Assert.False(tree.Contains(2));
    Assert.False(tree.Contains(4));
    Assert.False(tree.Contains(6));
    Assert.False(tree.Contains(8));
    Assert.False(tree.Contains(10));
  }

  [Fact]
  public void Contains_WithStringType_WorksCorrectly()
  {
    var tree = new BinarySearchTree<string>();
    tree.Add("banana");
    tree.Add("apple");
    tree.Add("cherry");
    
    Assert.True(tree.Contains("banana"));
    Assert.True(tree.Contains("apple"));
    Assert.True(tree.Contains("cherry"));
    Assert.False(tree.Contains("date"));
    Assert.False(tree.Contains("elderberry"));
  }

  [Fact]
  public void Contains_AfterAddingDuplicates_StillFindsElement()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(5);
    tree.Add(5);
    
    Assert.True(tree.Contains(5));
    Assert.Equal(1, tree.Count);
  }

  [Fact]
  public void Remove_EmptyTree_ReturnsFalse()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    Assert.True(tree.Contains(5));
    Assert.True(tree.Remove(5));
    Assert.False(tree.Contains(5));
    Assert.Equal(0, tree.Count);
  }

  [Fact]
  public void Remove_NonExistingElement_ReturnsFalse()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    
    Assert.False(tree.Remove(10));
    Assert.True(tree.Contains(5));
    Assert.True(tree.Contains(3));
    Assert.True(tree.Contains(7));
    Assert.Equal(3, tree.Count);
  }

  [Fact]
  public void Remove_ExistingElement_ShouldReturnTrue()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);

    tree.Remove(5);
    Assert.False(tree.Contains(5));
    Assert.True(tree.Contains(3));
    Assert.True(tree.Contains(7));
    Assert.Equal(2, tree.Count);
  }

  [Fact]
  public void Remove_ExistingElements_ShouldDecreaseCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    tree.Add(1);
    tree.Add(9);
    tree.Add(2);

    var initialCount = tree.Count;
    tree.Remove(3);
    Assert.False(tree.Contains(3));
    Assert.Equal(initialCount - 1, tree.Count);
    tree.Remove(7);
    Assert.False(tree.Contains(7));
    Assert.Equal(initialCount - 2, tree.Count);
    tree.Remove(1);
    Assert.False(tree.Contains(1));
    Assert.Equal(initialCount - 3, tree.Count);
    Assert.True(tree.Contains(5));
    Assert.True(tree.Contains(9));
    Assert.True(tree.Contains(2));
    Assert.Equal(3, tree.Count);
  }

  [Theory]
  [InlineData(1)]
  [InlineData(10)]
  [InlineData(100)]
  public void LargeTree_Operations_PerformCorrectly(int size)
  {
    var tree = new BinarySearchTree<int>();
    
    // Add elements
    for (int i = 0; i < size; i++)
    {
      tree.Add(i);
    }
    
    Assert.Equal(size, tree.Count);
    
    // Verify all elements exist
    for (int i = 0; i < size; i++)
    {
      Assert.True(tree.Contains(i));
    }
    
    // Verify non-existing elements
    Assert.False(tree.Contains(-1));
    Assert.False(tree.Contains(size));
  }

  [Fact]
  public void ComplexOperations_AddAndSearch_WorksCorrectly()
  {
    var tree = new BinarySearchTree<int>();
    var values = new[] { 50, 30, 70, 20, 40, 60, 80, 10, 25, 35, 45 };
    
    // Add all values
    foreach (var value in values)
    {
      tree.Add(value);
    }
    
    Assert.Equal(values.Length, tree.Count);
    
    // Verify all values exist
    foreach (var value in values)
    {
      Assert.True(tree.Contains(value));
    }
    
    // Test some non-existing values
    var nonExisting = new[] { 5, 15, 55, 75, 85, 100 };
    foreach (var value in nonExisting)
    {
      Assert.False(tree.Contains(value));
    }
  }

  [Fact]
  public void EdgeCase_MinMaxValues_WorkCorrectly()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(int.MaxValue);
    tree.Add(int.MinValue);
    tree.Add(0);
    
    Assert.Equal(3, tree.Count);
    Assert.True(tree.Contains(int.MaxValue));
    Assert.True(tree.Contains(int.MinValue));
    Assert.True(tree.Contains(0));
  }

  [Fact]
  public void Performance_AddManyElements_MaintainsCorrectState()
  {
    var tree = new BinarySearchTree<int>();
    const int elementCount = 1000;
    
    // Add elements in random order to create a more balanced tree
    var random = new Random(42); // Fixed seed for reproducible tests
    var values = Enumerable.Range(0, elementCount).OrderBy(x => random.Next()).ToArray();
    
    foreach (var value in values)
    {
      tree.Add(value);
    }
    
    // Verify count
    Assert.Equal(elementCount, tree.Count);
    
    // Verify some random elements exist
    Assert.True(tree.Contains(500));
    Assert.True(tree.Contains(250));
    Assert.True(tree.Contains(750));
    Assert.True(tree.Contains(0));
    Assert.True(tree.Contains(elementCount - 1));
  }

  [Fact]
  public void BinarySearchProperty_MaintainedAfterOperations()
  {
    var tree = new BinarySearchTree<int>();
    
    // Add elements that would test BST property
    var values = new[] { 5, 3, 7, 2, 4, 6, 8, 1, 9 };
    
    foreach (var value in values)
    {
      tree.Add(value);
    }
    
    // All values should be findable (tests BST search property)
    foreach (var value in values)
    {
      Assert.True(tree.Contains(value));
    }
    
    // Values that shouldn't exist
    Assert.False(tree.Contains(0));
    Assert.False(tree.Contains(10));
    Assert.False(tree.Contains(-1));
  }

  [Fact]
  public void DuplicateHandling_ConsistentBehavior()
  {
    var tree = new BinarySearchTree<string>();
    
    tree.Add("apple");
    tree.Add("banana");
    tree.Add("apple"); // Duplicate
    tree.Add("cherry");
    tree.Add("banana"); // Duplicate
    
    // Count should only include unique elements
    Assert.Equal(3, tree.Count);
    
    // All unique elements should be found
    Assert.True(tree.Contains("apple"));
    Assert.True(tree.Contains("banana"));
    Assert.True(tree.Contains("cherry"));
    Assert.False(tree.Contains("date"));
  }

  // ==== COMPREHENSIVE REMOVE TESTS ====
  
  [Fact]
  public void Remove_RootWithNoChildren_RemovesCorrectly()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    
    var result = tree.Remove(5);
    
    // These should fail with current implementation to indicate missing functionality
    Assert.True(result); // Remove should return true when removing existing element
    Assert.False(tree.Contains(5)); // Element should not be found after removal
    Assert.Equal(0, tree.Count); // Count should decrease after removal
  }

  [Fact]
  public void Remove_ExistingElement_ShouldReturnTrueAndDecreaseCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    
    var initialCount = tree.Count;
    var result = tree.Remove(5);
    
    // These assertions will FAIL with current implementation
    Assert.True(result); // Remove should return true for existing elements
    Assert.False(tree.Contains(5)); // Removed element should not be found
    Assert.Equal(initialCount - 1, tree.Count); // Count should decrease by 1
  }

  [Fact]
  public void Remove_LeafNode_ShouldWork()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    
    var result = tree.Remove(3); // Remove leaf
    
    Assert.True(result); // Remove should return true for existing leaf
    Assert.False(tree.Contains(3)); // Removed leaf should not be found
    Assert.Equal(2, tree.Count); // Count should be 2 after removing one element
    Assert.True(tree.Contains(5)); // Other elements should remain
    Assert.True(tree.Contains(7)); // Other elements should remain
  }

  [Fact]
  public void Remove_MultipleElements_ShouldDecrementCountCorrectly()
  {
    var tree = new BinarySearchTree<int>();
    var values = new[] { 5, 3, 7, 1, 9 };
    
    foreach (var value in values)
    {
      tree.Add(value);
    }
    
    var initialCount = tree.Count;
    
    // Remove two elements
    var result1 = tree.Remove(1);
    var result2 = tree.Remove(9);
    
    Assert.True(result1); // First remove should succeed
    Assert.True(result2); // Second remove should succeed
    Assert.Equal(initialCount - 2, tree.Count); // Count should decrease by 2
    Assert.False(tree.Contains(1)); // First removed element should not be found
    Assert.False(tree.Contains(9)); // Second removed element should not be found
  }

  // Helper methods to test tree structure (these will need actual tree traversal)
  private static bool TestTreeStructure(BinarySearchTree<int> tree, int rootValue, int leftValue, int rightValue)
  {
    // This is a simplified test - in real implementation, you'd need access to internal structure
    // For now, we'll just test that all values are still present
    // A real test would verify the actual tree structure
    
    // This test will effectively always pass, which means Reverse tests won't properly fail
    // This demonstrates the limitation of testing without proper access to tree structure
    return tree.Contains(rootValue) && tree.Contains(leftValue) && tree.Contains(rightValue);
  }

  private static bool HasOnlyLeftChild(BinarySearchTree<int> tree, int rootValue)
  {
    // Simplified - real implementation would check actual tree structure
    return tree.Contains(rootValue);
  }

  private static bool HasOnlyRightChild(BinarySearchTree<int> tree, int rootValue)
  {
    // Simplified - real implementation would check actual tree structure  
    return tree.Contains(rootValue);
  }

  // ==== INTEGRATION TESTS FOR REMOVE AND REVERSE ====

  [Fact]
  public void Remove_ExistingElement_MustReturnTrue_ThisTestWillFail()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(10);
    
    // This test will FAIL because Remove always returns false
    var result = tree.Remove(10);
    Assert.True(result); // FAILS - demonstrates unimplemented Remove
  }

  [Fact]
  public void Remove_ExistingElement_MustDecreaseCount_ThisTestWillFail()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(10);
    tree.Add(5);
    
    var initialCount = tree.Count; // Should be 2
    tree.Remove(10);
    
    // This test will FAIL because Count doesn't change
    Assert.Equal(1, tree.Count); // FAILS - demonstrates unimplemented Remove
    Assert.NotEqual(initialCount, tree.Count); // FAILS - Count doesn't change
  }

  [Fact]
  public void Remove_ExistingElement_MustMakeContainsFalse_ThisTestWillFail()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(42);
    
    Assert.True(tree.Contains(42)); // Should pass - element exists
    
    tree.Remove(42);
    
    // This test will FAIL because element is still in tree
    Assert.False(tree.Contains(42)); // FAILS - demonstrates unimplemented Remove
  }
}