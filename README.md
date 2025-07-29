# .NET Interview - Algorithms and Data Structures

This project contains a comprehensive collection of common algorithm implementations and data structures with their corresponding unit tests, written in C# and targeting .NET 9.0. It is designed for interview preparation, coding practice, and reference.

## Project Structure

### Algorithms (`Algorithms/`)
- `Algorithms.cs`: Contains static methods implementing various algorithms:
  - **String Processing**: CSV parsing, first unique character, string reversal, palindrome check, anagram checks, backspace string compare, group anagrams
  - **Array Operations**: Longest consecutive sequence, third maximum number, two sum, merge intervals
  - **Mathematical**: Product and sum difference, matrix sum queries
  - **Linked Lists**: Merge two sorted lists (with ListNode implementation)
  - **Sorting**: QuickSort and MergeSort generic implementations
- `AlgorithmsTests.cs`: Comprehensive xUnit-based unit tests for all algorithms

### Data Structures (`DataStructures/`)
- **Binary Search Tree** (`BinarySearchTree.cs`): Generic BST implementation with operations:
  - Add, Remove, Contains, GetMin, GetMax
  - Full unit test coverage (`BinarySearchTree.Tests.cs`)
- **Graph** (`Graph.cs`): Generic graph implementation with:
  - Vertex management and bidirectional connections
  - Depth-First Search (DFS) and Breadth-First Search (BFS) traversal algorithms
  - Full unit test coverage (`Graph.Tests.cs`)
- **Singly Linked List** (`SinglyLinkedList.cs`): Generic linked list with:
  - Add, Remove, Contains, Get, Reverse operations
  - Full unit test coverage (`SinglyLinkedList.Tests.cs`)
- **Trie** (`Trie.cs`): Prefix tree implementation for string storage and search:
  - Add, Contains, Search with prefix matching
  - Full unit test coverage (`Trie.Tests.cs`)
- **LRU Cache** (`LRUCache.cs`): Least Recently Used cache implementation with generic key-value support

### Project Configuration
- `AlgorthmsAndDataStructures.csproj`: Project file targeting .NET 9.0 with xUnit dependencies
- `.net-interview.slnx`: Solution file for Visual Studio
- `.gitignore` & `.editorconfig`: Development environment configuration

## Features

### Algorithms Implemented
- **String Algorithms**: Anagram detection, palindrome checking, unique character finding
- **Array Algorithms**: Two sum, merge intervals, consecutive sequences
- **Sorting Algorithms**: QuickSort and MergeSort with generic type support
- **Mathematical Algorithms**: Product/sum calculations, matrix operations
- **Parsing**: CSV parsing with quote handling
- **Linked List Operations**: Merging sorted lists

### Data Structures Implemented
- **Binary Search Tree**: Self-balancing operations with O(log n) average complexity
- **Graph**: Supports both DFS and BFS traversal with cycle detection
- **Singly Linked List**: Efficient insertion and reversal operations
- **Trie**: Efficient prefix-based search operations
- **LRU Cache**: O(1) get/set operations with automatic eviction

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

### Build
```powershell
dotnet build
```

### Run Tests
```powershell
dotnet test
```