namespace Solutions;

public class SolutionTests
{
    [Theory, InlineData("sample input")]
    public void SplitLongString(string input)
    {
        var delimiter = ' ';
        var result = new List<string>();
        var span = input.AsSpan();

        while (span.Length > 0)
        {
            var index = span.IndexOf(delimiter);
            string value;
            if (index == -1)
            {
                value = span.ToString();
                result.Add(value);
                break;
            }

            value = span[..index].ToString();
            result.Add(value.ToString());

            span = span[(index + 1)..];
        }
        var resultValue = string.Join(delimiter, result);

        Assert.Equal(resultValue, input);
    }

    [Theory]
    [InlineData("aabbcd", 'c')]
    [InlineData("aaabbbcd", 'c')]
    [InlineData("aaaabcd", 'b')]
    [InlineData("abcd", 'a')]
    [InlineData("abbcd", 'a')]
    [InlineData("a", 'a')]
    [InlineData("ab", 'a')]
    public void GetFirstSingleChar(string input, char assertion)
    {
        var result = char.MinValue;
        var count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (count == 0)
            {
                result = input[i];
                count++;
            }
            else
            {
                if (result != input[i])
                {
                    if (count == 1)
                    {
                        break;
                    }
                    else
                    {
                        result = input[i];
                        count = 1;
                    }
                }
                else
                {
                    count++;
                }
            }
        }

        Assert.Equal(result, assertion);
    }

    [Theory]
    [InlineData("abbsccc", "asbbccc")]
    public void FrequencySort(string input, string result)
    {
        var dict = new Dictionary<char, int>();

        foreach (var c in input)
        {
            dict[c] = dict.GetValueOrDefault(c) + 1;
        }

        var sorted = dict.OrderBy(x => x.Value).Select(x => new int[x.Value]).ToList();
    }
}