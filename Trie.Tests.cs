namespace AlghorithmStrutures.Tests;

public sealed class TrieTests
{
  [Fact]
  public void Constructor_CreatesEmptyTrie()
  {
    var trie = new Trie();
    Assert.NotNull(trie);
  }

  [Fact]
  public void Contains_NewTrie_ReturnsFalse()
  {
    var trie = new Trie();
    Assert.False(trie.Contains("test"));
  }

  [Fact]
  public void Contains_AddedWord_ReturnsTrue()
  {
    var trie = new Trie();
    trie.Add("hello");
    Assert.True(trie.Contains("hello"));
  }

  [Fact]
  public void Contains_NonAddedWord_ReturnsFalse()
  {
    var trie = new Trie();
    trie.Add("hello");
    Assert.False(trie.Contains("world"));
  }

  [Fact]
  public void Add_MultipleWords_AllWordsCanBeFound()
  {
    var trie = new Trie();
    var words = new[] { "hello", "world", "test", "trie", "data" };
    
    foreach (var word in words)
    {
      trie.Add(word);
    }
    
    foreach (var word in words)
    {
      Assert.True(trie.Contains(word));
    }
  }

  [Fact]
  public void Search_ExistingPrefix_ReturnsAllMatchingWords()
  {
    var trie = new Trie();
    trie.Add("hello");
    trie.Add("hell");
    trie.Add("heaven");
    trie.Add("heavy");

    var results = trie.Search("he").ToList();

    Assert.Equal(4, results.Count);
    Assert.Contains("hello", results);
    Assert.Contains("hell", results);
    Assert.Contains("heaven", results);
    Assert.Contains("heavy", results);
  }

  [Fact]
  public void Search_NonExistingPrefix_ReturnsEmptyCollection()
  {
    var trie = new Trie();
    trie.Add("hello");
    trie.Add("world");

    var results = trie.Search("no").ToList();

    Assert.Empty(results);
  }

  [Fact]
  public void Search_ExactWordAsPrefix_IncludesThatWordInResults()
  {
    var trie = new Trie();
    trie.Add("test");

    var results = trie.Search("test").ToList();

    Assert.Single(results);
    Assert.Contains("test", results);
  }

  [Fact]
  public void Add_DuplicateWords_WorksCorrectly()
  {
    var trie = new Trie();
    trie.Add("test");
    trie.Add("test");

    Assert.True(trie.Contains("test"));
  }
}
