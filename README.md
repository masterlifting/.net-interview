# .NET Interview Algorithms

This project contains a collection of common algorithm implementations and their corresponding unit tests, written in C# and targeting .NET 9.0. It is designed for interview preparation, coding practice, and reference.

## Project Structure

- `Algorithms.cs`: Contains static methods implementing various algorithms, such as:
  - CSV parsing
  - First unique character in a string
  - Longest consecutive sequence
  - Third maximum number
  - String reversal
  - Palindrome check
  - Product and sum difference
  - Matrix sum queries
  - Anagram checks
  - Merging intervals
  - Two sum
  - Grouping anagrams
  - Backspace string compare
- `AlgorithmsTests.cs`: xUnit-based unit tests for all algorithms in `Algorithms.cs`.
- `LiveCoding.csproj`: Project file targeting .NET 9.0, with dependencies for xUnit and test SDKs.

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

## Usage
You can use the algorithms in `Algorithms.cs` as a reference for common coding interview questions or as a base for your own implementations.

## License
This project is for educational and interview preparation purposes.
