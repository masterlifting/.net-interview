namespace AlghorithmStrutures.Tests;

public sealed class TrieTests
{
  [Fact]
  public void Constructor_CreatesEmptyTrie()
  {
    var trie = new Trie();
    // Since we don't have a Count property or Contains method, 
    // we can only test that construction doesn't throw
    Assert.NotNull(trie);
  }

  [Fact]
  public void Add_SingleWord_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("hello");
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_MultipleWords_DoesNotThrow()
  {
    var trie = new Trie();
    var words = new[] { "hello", "world", "test", "trie", "data" };
    
    foreach (var word in words)
    {
      trie.Add(word);
    }
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_NullString_ThrowsArgumentException()
  {
    var trie = new Trie();
    
    var exception = Assert.Throws<ArgumentException>(() => trie.Add(null!));
    Assert.Equal("Word cannot be null or empty. (Parameter 'word')", exception.Message);
  }

  [Fact]
  public void Add_EmptyString_ThrowsArgumentException()
  {
    var trie = new Trie();
    
    var exception = Assert.Throws<ArgumentException>(() => trie.Add(""));
    Assert.Equal("Word cannot be null or empty. (Parameter 'word')", exception.Message);
  }

  [Fact]
  public void Add_SingleCharacter_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("a");
    trie.Add("b");
    trie.Add("c");
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_DuplicateWords_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("hello");
    trie.Add("hello");
    trie.Add("hello");
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_WordsWithCommonPrefixes_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("cat");
    trie.Add("car");
    trie.Add("card");
    trie.Add("care");
    trie.Add("careful");
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_WordsWithNoCommonPrefixes_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("apple");
    trie.Add("banana");
    trie.Add("cherry");
    trie.Add("date");
    trie.Add("elderberry");
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_SpecialCharacters_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("hello!");
    trie.Add("world?");
    trie.Add("test123");
    trie.Add("special@#$");
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_UnicodeCharacters_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("café");
    trie.Add("naïve");
    trie.Add("résumé");
    trie.Add("Москва"); // Moscow in Russian
    trie.Add("東京"); // Tokyo in Japanese
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_VeryLongWord_DoesNotThrow()
  {
    var trie = new Trie();
    var longWord = new string('a', 1000); // 1000 character word
    trie.Add(longWord);
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_MixedCaseWords_DoesNotThrow()
  {
    var trie = new Trie();
    trie.Add("Hello");
    trie.Add("WORLD");
    trie.Add("tEsT");
    trie.Add("CamelCase");
    trie.Add("snake_case");
    // Test passes if no exception is thrown
  }

  [Theory]
  [InlineData("a")]
  [InlineData("ab")]
  [InlineData("abc")]
  [InlineData("test")]
  [InlineData("hello")]
  [InlineData("world")]
  [InlineData("programming")]
  public void Add_VariousWords_DoesNotThrow(string word)
  {
    var trie = new Trie();
    trie.Add(word);
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_WordsThatAreSubstringsOfOthers_DoesNotThrow()
  {
    var trie = new Trie();
    
    // Add words where some are substrings of others
    trie.Add("cat");
    trie.Add("cats");
    trie.Add("caterpillar");
    trie.Add("catastrophe");
    
    trie.Add("dog");
    trie.Add("dogs");
    trie.Add("dogma");
    
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_LargeNumberOfWords_PerformanceTest()
  {
    var trie = new Trie();
    const int wordCount = 10000;
    
    // Add many words to test performance
    for (int i = 0; i < wordCount; i++)
    {
      trie.Add($"word{i}");
    }
    
    // Test passes if no exception is thrown and completes in reasonable time
  }

  [Fact]
  public void Add_AllSingleCharacters_DoesNotThrow()
  {
    var trie = new Trie();
    
    // Add all lowercase letters
    for (char c = 'a'; c <= 'z'; c++)
    {
      trie.Add(c.ToString());
    }
    
    // Add all uppercase letters
    for (char c = 'A'; c <= 'Z'; c++)
    {
      trie.Add(c.ToString());
    }
    
    // Add all digits
    for (char c = '0'; c <= '9'; c++)
    {
      trie.Add(c.ToString());
    }
    
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_CommonEnglishWords_DoesNotThrow()
  {
    var trie = new Trie();
    var commonWords = new[]
    {
      "the", "be", "to", "of", "and", "a", "in", "that", "have",
      "i", "it", "for", "not", "on", "with", "he", "as", "you",
      "do", "at", "this", "but", "his", "by", "from", "they",
      "we", "say", "her", "she", "or", "an", "will", "my",
      "one", "all", "would", "there", "their"
    };
    
    foreach (var word in commonWords)
    {
      trie.Add(word);
    }
    
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_WordsInAlphabeticalOrder_DoesNotThrow()
  {
    var trie = new Trie();
    var words = new[] { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape" };
    
    foreach (var word in words)
    {
      trie.Add(word);
    }
    
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_WordsInReverseAlphabeticalOrder_DoesNotThrow()
  {
    var trie = new Trie();
    var words = new[] { "zebra", "yellow", "xray", "water", "victory", "umbrella", "tiger" };
    
    foreach (var word in words)
    {
      trie.Add(word);
    }
    
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_RandomWords_DoesNotThrow()
  {
    var trie = new Trie();
    var random = new Random(42); // Fixed seed for reproducible tests
    
    for (int i = 0; i < 100; i++)
    {
      var wordLength = random.Next(1, 20);
      var word = new string(Enumerable.Range(0, wordLength)
        .Select(_ => (char)random.Next('a', 'z' + 1))
        .ToArray());
      
      trie.Add(word);
    }
    
    // Test passes if no exception is thrown
  }

  [Fact]
  public void Add_EdgeCaseLengths_DoesNotThrow()
  {
    var trie = new Trie();
    
    // Single character
    trie.Add("x");
    
    // Two characters
    trie.Add("xy");
    
    // Medium length
    trie.Add("medium");
    
    // Longer word
    trie.Add("supercalifragilisticexpialidocious");
    
    // Test passes if no exception is thrown
  }

  // ==== SEARCH METHOD TESTS ====

  [Fact]
  public void Search_NullPrefix_ThrowsArgumentException()
  {
    var trie = new Trie();
    trie.Add("hello");
    
    var exception = Assert.Throws<ArgumentException>(() => trie.Search(null!).ToList());
    Assert.Equal("Prefix cannot be null or empty. (Parameter 'prefix')", exception.Message);
  }

  [Fact]
  public void Search_EmptyPrefix_ThrowsArgumentException()
  {
    var trie = new Trie();
    trie.Add("hello");
    
    var exception = Assert.Throws<ArgumentException>(() => trie.Search("").ToList());
    Assert.Equal("Prefix cannot be null or empty. (Parameter 'prefix')", exception.Message);
  }

  [Fact]
  public void Search_ExactMatch_ReturnsWord()
  {
    var trie = new Trie();
    trie.Add("hello");
    
    var results = trie.Search("hello").ToList();
    
    // This will fail with incomplete implementation
    Assert.Single(results);
    Assert.Contains("hello", results);
  }

  [Fact]
  public void Search_PrefixMatch_ReturnsAllWordsWithPrefix()
  {
    var trie = new Trie();
    trie.Add("cat");
    trie.Add("car");
    trie.Add("card");
    trie.Add("care");
    trie.Add("careful");
    trie.Add("dog"); // Should not be returned
    
    var results = trie.Search("car").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(4, results.Count);
    Assert.Contains("car", results);
    Assert.Contains("card", results);
    Assert.Contains("care", results);
    Assert.Contains("careful", results);
    Assert.DoesNotContain("cat", results);
    Assert.DoesNotContain("dog", results);
  }

  [Fact]
  public void Search_SingleCharacterPrefix_ReturnsAllMatchingWords()
  {
    var trie = new Trie();
    trie.Add("apple");
    trie.Add("apricot");
    trie.Add("ant");
    trie.Add("banana");
    trie.Add("cherry");
    
    var results = trie.Search("a").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(3, results.Count);
    Assert.Contains("apple", results);
    Assert.Contains("apricot", results);
    Assert.Contains("ant", results);
    Assert.DoesNotContain("banana", results);
    Assert.DoesNotContain("cherry", results);
  }

  [Fact]
  public void Search_NoMatches_ReturnsEmptyCollection()
  {
    var trie = new Trie();
    trie.Add("hello");
    trie.Add("world");
    trie.Add("test");
    
    var results = trie.Search("xyz").ToList();
    
    // This might pass or fail depending on implementation
    Assert.Empty(results);
  }

  [Fact]
  public void Search_PrefixNotInTrie_ReturnsEmptyCollection()
  {
    var trie = new Trie();
    trie.Add("programming");
    trie.Add("computer");
    trie.Add("algorithm");
    
    var results = trie.Search("xyz").ToList();
    
    Assert.Empty(results);
  }

  [Fact]
  public void Search_PrefixLongerThanAnyWord_ReturnsEmptyCollection()
  {
    var trie = new Trie();
    trie.Add("cat");
    trie.Add("dog");
    
    var results = trie.Search("superlongprefix").ToList();
    
    Assert.Empty(results);
  }

  [Fact]
  public void Search_EmptyTrie_ReturnsEmptyCollection()
  {
    var trie = new Trie();
    
    var results = trie.Search("any").ToList();
    
    Assert.Empty(results);
  }

  [Fact]
  public void Search_CaseSensitive_ReturnsOnlyExactCaseMatches()
  {
    var trie = new Trie();
    trie.Add("Hello");
    trie.Add("HELLO");
    trie.Add("hello");
    trie.Add("HeLLo");
    
    var results = trie.Search("He").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(2, results.Count);
    Assert.Contains("Hello", results);
    Assert.Contains("HeLLo", results);
    Assert.DoesNotContain("HELLO", results);
    Assert.DoesNotContain("hello", results);
  }

  [Fact]
  public void Search_WordsWithCommonPrefix_ReturnsAllMatches()
  {
    var trie = new Trie();
    trie.Add("test");
    trie.Add("testing");
    trie.Add("tester");
    trie.Add("tests");
    trie.Add("testament");
    
    var results = trie.Search("test").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(5, results.Count);
    Assert.Contains("test", results);
    Assert.Contains("testing", results);
    Assert.Contains("tester", results);
    Assert.Contains("tests", results);
    Assert.Contains("testament", results);
  }

  [Fact]
  public void Search_NestedPrefixes_ReturnsCorrectResults()
  {
    var trie = new Trie();
    trie.Add("a");
    trie.Add("ab");
    trie.Add("abc");
    trie.Add("abcd");
    trie.Add("abcde");
    
    var resultsA = trie.Search("a").OrderBy(x => x).ToList();
    var resultsAb = trie.Search("ab").OrderBy(x => x).ToList();
    var resultsAbc = trie.Search("abc").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(5, resultsA.Count);
    Assert.Equal(4, resultsAb.Count);
    Assert.Equal(3, resultsAbc.Count);
    
    Assert.Contains("a", resultsA);
    Assert.DoesNotContain("a", resultsAb);
    Assert.DoesNotContain("a", resultsAbc);
  }

  [Fact]
  public void Search_SpecialCharacters_HandledCorrectly()
  {
    var trie = new Trie();
    trie.Add("hello!");
    trie.Add("hello?");
    trie.Add("hello@world");
    trie.Add("test123");
    trie.Add("special#chars");
    
    var results = trie.Search("hello").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(3, results.Count);
    Assert.Contains("hello!", results);
    Assert.Contains("hello?", results);
    Assert.Contains("hello@world", results);
  }

  [Fact]
  public void Search_UnicodeCharacters_HandledCorrectly()
  {
    var trie = new Trie();
    trie.Add("café");
    trie.Add("cafeteria");
    trie.Add("naïve");
    trie.Add("résumé");
    
    var results = trie.Search("caf").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(2, results.Count);
    Assert.Contains("café", results);
    Assert.Contains("cafeteria", results);
  }

  [Fact]
  public void Search_LargeDataset_PerformanceTest()
  {
    var trie = new Trie();
    const int wordCount = 1000;
    
    // Add many words with common prefix
    for (int i = 0; i < wordCount; i++)
    {
      trie.Add($"prefix{i}");
    }
    
    // Add some words without the prefix
    trie.Add("different");
    trie.Add("other");
    
    var results = trie.Search("prefix").ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(wordCount, results.Count);
    
    // Verify all results start with "prefix"
    Assert.True(results.All(word => word.StartsWith("prefix")));
  }

  [Theory]
  [InlineData("a", new[] { "apple", "ant", "application" })]
  [InlineData("app", new[] { "apple", "application" })]
  [InlineData("appl", new[] { "apple", "application" })]
  [InlineData("apple", new[] { "apple" })]
  public void Search_VariousPrefixes_ReturnsExpectedResults(string prefix, string[] expectedWords)
  {
    var trie = new Trie();
    var allWords = new[] { "apple", "ant", "application", "banana", "cherry" };
    
    foreach (var word in allWords)
    {
      trie.Add(word);
    }
    
    var results = trie.Search(prefix).OrderBy(x => x).ToList();
    var expected = expectedWords.OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(expected.Count, results.Count);
    for (int i = 0; i < expected.Count; i++)
    {
      Assert.Equal(expected[i], results[i]);
    }
  }

  [Fact]
  public void Search_AfterAddingDuplicates_ReturnsUniqueResults()
  {
    var trie = new Trie();
    trie.Add("test");
    trie.Add("test"); // Duplicate
    trie.Add("testing");
    trie.Add("test"); // Another duplicate
    
    var results = trie.Search("test").ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(2, results.Count);
    Assert.Contains("test", results);
    Assert.Contains("testing", results);
    
    // Ensure no duplicates in results
    Assert.Equal(results.Count, results.Distinct().Count());
  }

  [Fact]
  public void Search_ComplexTreeStructure_ReturnsCorrectResults()
  {
    var trie = new Trie();
    var words = new[]
    {
      "a", "aa", "aaa", "ab", "abc", "abcd", "ac", "acd", "ace",
      "b", "ba", "baa", "bc", "bcd", "bd", "be", "bed", "bee"
    };
    
    foreach (var word in words)
    {
      trie.Add(word);
    }
    
    var resultsA = trie.Search("a").ToList();
    var resultsAb = trie.Search("ab").ToList();
    var resultsB = trie.Search("b").ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(9, resultsA.Count); // All words starting with 'a'
    Assert.Equal(3, resultsAb.Count); // ab, abc, abcd
    Assert.Equal(9, resultsB.Count); // All words starting with 'b'
  }

  [Fact]
  public void Search_SingleCharacterWords_HandledCorrectly()
  {
    var trie = new Trie();
    trie.Add("a");
    trie.Add("b");
    trie.Add("c");
    trie.Add("ab");
    trie.Add("ac");
    
    var resultsA = trie.Search("a").OrderBy(x => x).ToList();
    
    // This will fail with incomplete implementation
    Assert.Equal(3, resultsA.Count);
    Assert.Contains("a", resultsA);
    Assert.Contains("ab", resultsA);
    Assert.Contains("ac", resultsA);
  }

  // ==== CONTAINS METHOD TESTS ====

  [Fact]
  public void Contains_EmptyWord_ReturnsFalse()
  {
    var trie = new Trie();
    trie.Add("hello");
    
    // Empty string should return false since we can't add empty strings
    Assert.False(trie.Contains(""));
  }

  [Fact]
  public void Contains_ExistingWord_ReturnsTrue()
  {
    var trie = new Trie();
    trie.Add("hello");
    
    Assert.True(trie.Contains("hello"));
  }

  [Fact]
  public void Contains_NonExistingWord_ReturnsFalse()
  {
    var trie = new Trie();
    trie.Add("hello");
    
    Assert.False(trie.Contains("world"));
    Assert.False(trie.Contains("hi"));
    Assert.False(trie.Contains("help"));
  }

  [Fact]
  public void Contains_EmptyTrie_ReturnsFalse()
  {
    var trie = new Trie();
    
    Assert.False(trie.Contains("anything"));
    Assert.False(trie.Contains("hello"));
    Assert.False(trie.Contains("a"));
  }

  [Fact]
  public void Contains_SingleCharacterWord_ReturnsCorrectResult()
  {
    var trie = new Trie();
    trie.Add("a");
    trie.Add("b");
    trie.Add("c");
    
    Assert.True(trie.Contains("a"));
    Assert.True(trie.Contains("b"));
    Assert.True(trie.Contains("c"));
    Assert.False(trie.Contains("d"));
    Assert.False(trie.Contains("z"));
  }

  [Fact]
  public void Contains_CaseSensitive_ReturnsCorrectResults()
  {
    var trie = new Trie();
    trie.Add("Hello");
    trie.Add("WORLD");
    trie.Add("test");
    
    Assert.True(trie.Contains("Hello"));
    Assert.True(trie.Contains("WORLD"));
    Assert.True(trie.Contains("test"));
    
    // Different cases should not match
    Assert.False(trie.Contains("hello"));
    Assert.False(trie.Contains("HELLO"));
    Assert.False(trie.Contains("world"));
    Assert.False(trie.Contains("World"));
    Assert.False(trie.Contains("TEST"));
    Assert.False(trie.Contains("Test"));
  }

  [Fact]
  public void Contains_WordsWithCommonPrefixes_ReturnsCorrectResults()
  {
    var trie = new Trie();
    trie.Add("cat");
    trie.Add("car");
    trie.Add("card");
    trie.Add("care");
    trie.Add("careful");
    
    // All added words should be found
    Assert.True(trie.Contains("cat"));
    Assert.True(trie.Contains("car"));
    Assert.True(trie.Contains("card"));
    Assert.True(trie.Contains("care"));
    Assert.True(trie.Contains("careful"));
    
    // Prefixes that are not complete words should not be found
    Assert.False(trie.Contains("ca"));
    Assert.False(trie.Contains("c"));
    
    // Non-existing words should not be found
    Assert.False(trie.Contains("cards"));
    Assert.False(trie.Contains("caring"));
    Assert.False(trie.Contains("careless"));
  }

  [Fact]
  public void Contains_PrefixOfExistingWord_ReturnsFalse()
  {
    var trie = new Trie();
    trie.Add("programming");
    trie.Add("computer");
    
    // Prefixes should not be found unless they were explicitly added
    Assert.False(trie.Contains("prog"));
    Assert.False(trie.Contains("program"));
    Assert.False(trie.Contains("comp"));
    Assert.False(trie.Contains("compu"));
    
    // Full words should be found
    Assert.True(trie.Contains("programming"));
    Assert.True(trie.Contains("computer"));
  }

  [Fact]
  public void Contains_WordLongerThanExistingWord_ReturnsFalse()
  {
    var trie = new Trie();
    trie.Add("test");
    trie.Add("hello");
    
    // Longer words should not be found
    Assert.False(trie.Contains("testing"));
    Assert.False(trie.Contains("tests"));
    Assert.False(trie.Contains("helloworld"));
    Assert.False(trie.Contains("hellos"));
    
    // Original words should be found
    Assert.True(trie.Contains("test"));
    Assert.True(trie.Contains("hello"));
  }

  [Fact]
  public void Contains_NestedWords_ReturnsCorrectResults()
  {
    var trie = new Trie();
    trie.Add("a");
    trie.Add("ab");
    trie.Add("abc");
    trie.Add("abcd");
    trie.Add("abcde");
    
    // All nested words should be found
    Assert.True(trie.Contains("a"));
    Assert.True(trie.Contains("ab"));
    Assert.True(trie.Contains("abc"));
    Assert.True(trie.Contains("abcd"));
    Assert.True(trie.Contains("abcde"));
    
    // Non-existing extensions should not be found
    Assert.False(trie.Contains("abcdef"));
    Assert.False(trie.Contains("abcdefg"));
  }

  [Fact]
  public void Contains_SpecialCharacters_HandledCorrectly()
  {
    var trie = new Trie();
    trie.Add("hello!");
    trie.Add("world?");
    trie.Add("test@123");
    trie.Add("special#chars");
    trie.Add("symbols$%^");
    
    Assert.True(trie.Contains("hello!"));
    Assert.True(trie.Contains("world?"));
    Assert.True(trie.Contains("test@123"));
    Assert.True(trie.Contains("special#chars"));
    Assert.True(trie.Contains("symbols$%^"));
    
    // Without special characters should not match
    Assert.False(trie.Contains("hello"));
    Assert.False(trie.Contains("world"));
    Assert.False(trie.Contains("test"));
    Assert.False(trie.Contains("special"));
    Assert.False(trie.Contains("symbols"));
  }

  [Fact]
  public void Contains_UnicodeCharacters_HandledCorrectly()
  {
    var trie = new Trie();
    trie.Add("café");
    trie.Add("naïve");
    trie.Add("résumé");
    trie.Add("Москва"); // Moscow in Russian
    trie.Add("東京"); // Tokyo in Japanese
    
    Assert.True(trie.Contains("café"));
    Assert.True(trie.Contains("naïve"));
    Assert.True(trie.Contains("résumé"));
    Assert.True(trie.Contains("Москва"));
    Assert.True(trie.Contains("東京"));
    
    // ASCII versions should not match
    Assert.False(trie.Contains("cafe"));
    Assert.False(trie.Contains("naive"));
    Assert.False(trie.Contains("resume"));
  }

  [Fact]
  public void Contains_DuplicateWords_ReturnsTrue()
  {
    var trie = new Trie();
    trie.Add("duplicate");
    trie.Add("duplicate");
    trie.Add("duplicate");
    
    // Should still find the word after multiple additions
    Assert.True(trie.Contains("duplicate"));
  }

  [Fact]
  public void Contains_VeryLongWord_HandledCorrectly()
  {
    var trie = new Trie();
    var longWord = new string('a', 1000);
    trie.Add(longWord);
    
    Assert.True(trie.Contains(longWord));
    
    // Shorter version should not match
    var shorterWord = new string('a', 999);
    Assert.False(trie.Contains(shorterWord));
    
    // Longer version should not match
    var longerWord = new string('a', 1001);
    Assert.False(trie.Contains(longerWord));
  }

  [Theory]
  [InlineData("apple")]
  [InlineData("banana")]
  [InlineData("cherry")]
  [InlineData("date")]
  [InlineData("elderberry")]
  public void Contains_VariousWords_ReturnsTrue(string word)
  {
    var trie = new Trie();
    var allWords = new[] { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape" };
    
    foreach (var w in allWords)
    {
      trie.Add(w);
    }
    
    Assert.True(trie.Contains(word));
  }

  [Theory]
  [InlineData("appl")]
  [InlineData("banan")]
  [InlineData("cherr")]
  [InlineData("dat")]
  [InlineData("elder")]
  public void Contains_PrefixesOfExistingWords_ReturnsFalse(string prefix)
  {
    var trie = new Trie();
    var allWords = new[] { "apple", "banana", "cherry", "date", "elderberry" };
    
    foreach (var word in allWords)
    {
      trie.Add(word);
    }
    
    Assert.False(trie.Contains(prefix));
  }

  [Fact]
  public void Contains_LargeDataset_PerformanceTest()
  {
    var trie = new Trie();
    const int wordCount = 10000;
    
    // Add many words
    for (int i = 0; i < wordCount; i++)
    {
      trie.Add($"word{i}");
    }
    
    // Test finding existing words
    Assert.True(trie.Contains("word0"));
    Assert.True(trie.Contains("word5000"));
    Assert.True(trie.Contains("word9999"));
    
    // Test non-existing words
    Assert.False(trie.Contains("word10000"));
    Assert.False(trie.Contains("notaword"));
    Assert.False(trie.Contains("word"));
  }

  [Fact]
  public void Contains_ComplexTreeStructure_ReturnsCorrectResults()
  {
    var trie = new Trie();
    var words = new[]
    {
      "a", "aa", "aaa", "ab", "abc", "abcd", "ac", "acd", "ace",
      "b", "ba", "baa", "bc", "bcd", "bd", "be", "bed", "bee",
      "cat", "car", "card", "care", "careful", "dog", "dot", "dots"
    };
    
    foreach (var word in words)
    {
      trie.Add(word);
    }
    
    // Test all added words exist
    foreach (var word in words)
    {
      Assert.True(trie.Contains(word), $"Word '{word}' should be found in trie");
    }
    
    // Test some non-existing words
    var nonExistingWords = new[] { "cars", "caring", "dogs", "dotted", "bb", "cc", "xyz" };
    foreach (var word in nonExistingWords)
    {
      Assert.False(trie.Contains(word), $"Word '{word}' should not be found in trie");
    }
  }

  [Fact]
  public void Contains_WordsWithNumbers_HandledCorrectly()
  {
    var trie = new Trie();
    trie.Add("test123");
    trie.Add("abc456");
    trie.Add("user1");
    trie.Add("item2");
    trie.Add("version3.0");
    
    Assert.True(trie.Contains("test123"));
    Assert.True(trie.Contains("abc456"));
    Assert.True(trie.Contains("user1"));
    Assert.True(trie.Contains("item2"));
    Assert.True(trie.Contains("version3.0"));
    
    // Without numbers should not match
    Assert.False(trie.Contains("test"));
    Assert.False(trie.Contains("abc"));
    Assert.False(trie.Contains("user"));
    Assert.False(trie.Contains("item"));
    Assert.False(trie.Contains("version"));
  }

  [Fact]
  public void Contains_MixedLengthWords_ReturnsCorrectResults()
  {
    var trie = new Trie();
    trie.Add("I");
    trie.Add("am");
    trie.Add("testing");
    trie.Add("the");
    trie.Add("implementation");
    trie.Add("of");
    trie.Add("contains");
    
    Assert.True(trie.Contains("I"));
    Assert.True(trie.Contains("am"));
    Assert.True(trie.Contains("testing"));
    Assert.True(trie.Contains("the"));
    Assert.True(trie.Contains("implementation"));
    Assert.True(trie.Contains("of"));
    Assert.True(trie.Contains("contains"));
    
    Assert.False(trie.Contains("a"));
    Assert.False(trie.Contains("test"));
    Assert.False(trie.Contains("implement"));
    Assert.False(trie.Contains("contain"));
  }

  // Note: Since the Trie class only has an Add method, these tests focus on:
  // 1. Ensuring Add doesn't throw exceptions for valid inputs
  // 2. Ensuring Add throws appropriate exceptions for invalid inputs
  // 3. Testing various edge cases and scenarios
  // 
  // To create more comprehensive tests, the Trie class would need additional methods such as:
  // - Contains(string word) - to check if a word exists
  // - StartsWith(string prefix) - to check if any words start with a prefix
  // - GetWordsWithPrefix(string prefix) - to get all words with a prefix
  // - Remove(string word) - to remove a word
  // - Count - property to get number of words
  // - IsEmpty - property to check if trie is empty
  //
  // These additional methods would enable testing:
  // - Word retrieval and search functionality
  // - Prefix matching capabilities
  // - Tree structure validation
  // - Word removal and modification
}
