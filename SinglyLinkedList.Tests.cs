namespace Algorithm.Tests;

public class SinglyLinkedListTests
{
    [Fact]
    public void Constructor_CreatesEmptyList()
    {
        var list = new SinglyLinkedList<int>();
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Add_SingleElement_IncreasesCount()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        Assert.Equal(1, list.Count);
        Assert.True(list.Contains(1));
    }

    [Fact]
    public void Add_MultipleElements_MaintainsCorrectOrder()
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
    public void Get_ValidIndex_ReturnsCorrectValue()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(5);
        list.Add(10);
        list.Add(15);

        Assert.Equal(15, list.Get(0));
        Assert.Equal(10, list.Get(1));
        Assert.Equal(5, list.Get(2));
    }

    [Fact]
    public void Contains_ExistingElement_ReturnsTrue()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        Assert.True(list.Contains(1));
    }

    [Fact]
    public void Contains_NonExistingElement_ReturnsFalse()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        Assert.False(list.Contains(2));
    }

    [Fact]
    public void Remove_ExistingElement_UpdatesListCorrectly()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.True(list.Remove(2));
        Assert.Equal(2, list.Count);
        Assert.False(list.Contains(2));
    }

    [Fact]
    public void Remove_NonExistingElement_ReturnsFalse()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        Assert.False(list.Remove(2));
    }

    [Fact]
    public void Reverse_MultipleElements_ReversesCorrectly()
    {
        var list = new SinglyLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Reverse();

        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
    }
}

