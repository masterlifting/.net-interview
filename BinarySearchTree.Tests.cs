namespace Algorithm.Tests;

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
  public void Contains_ExistingElement_ReturnsTrue()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    
    Assert.True(tree.Contains(5));
  }

  [Fact]
  public void Contains_NonExistingElement_ReturnsFalse()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    
    Assert.False(tree.Contains(10));
  }

  [Fact]
  public void GetMin_ReturnsSmallestElement()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    
    Assert.Equal(3, tree.GetMin());
  }

  [Fact]
  public void GetMax_ReturnsLargestElement()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    
    Assert.Equal(7, tree.GetMax());
  }

  [Fact]
  public void Remove_ExistingElement_ReturnsTrueAndDecreasesCount()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    tree.Add(3);
    tree.Add(7);
    
    Assert.True(tree.Remove(3));
    Assert.Equal(2, tree.Count);
  }

  [Fact]
  public void Remove_NonExistingValue_ReturnsFalse()
  {
    var tree = new BinarySearchTree<int>();
    tree.Add(5);
    
    Assert.False(tree.Remove(10));
  }
}