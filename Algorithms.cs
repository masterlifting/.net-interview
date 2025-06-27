namespace LiveCoding;

public static class Algorithms
{
    public static string[] ParseCsv(string input)
    {
        var results = new LinkedList<string>();
        var span = input.AsSpan();

        while (span.Length > 0)
        {
            var commaIndex = span.IndexOf(',');
            var quotaStartIndex = span.IndexOf('"');

            if (commaIndex == -1 && quotaStartIndex == -1)
            {
                results.AddLast(span.ToString());
                span = [];
            }
            else if (commaIndex > -1 && (commaIndex < quotaStartIndex || quotaStartIndex == -1))
            {
                if (commaIndex > 0)
                {
                    results.AddLast(span[..commaIndex].ToString());
                }

                span = span.Length > (commaIndex + 1)
                    ? span[(commaIndex + 1)..]
                    : [];
            }
            else if (quotaStartIndex > -1 && quotaStartIndex < commaIndex)
            {
                span = span.Length > (quotaStartIndex + 1)
                    ? span[(quotaStartIndex + 1)..]
                    : [];

                var lenghtResult = span.IndexOf('"');

                if (lenghtResult > 0)
                {
                    results.AddLast(span[..lenghtResult].ToString());
                }

                span = span.Length > (lenghtResult + 1)
                    ? span[(lenghtResult + 1)..]
                    : span[lenghtResult..];

                if (span[0] == ',' || span[0] == '"')
                {
                    span = span.Length > 1 ? span[1..] : [];
                }
            }
        }

        return results.ToArray();
    }

    public static int FirstUniqueCharacterInString(string input)
    {
        var storage = new Dictionary<char, (int, int)>();

        for (var i = 0; i < input.Length; i++)
        {
            if (storage.TryGetValue(input[i], out var v))
            {
                storage[input[i]] = (i, ++v.Item2);
            }
            else
            {
                storage[input[i]] = (i, 1);
            }
        }


        var result = -1;

        foreach (var (_, (index, count)) in storage.OrderBy(x => x.Value.Item1))
        {
            if (count == 1)
            {
                result = index;
                break;
            }
        }

        return result;
    }

    public static int LongestConsecutiveSequence(int[] input)
    {
        var result = input.Length == 0 ? 0 : 1;
        var orderedInput = input.Order().ToArray();

        for (int i = 1; i < orderedInput.Length; i++)
        {
            var previous = orderedInput[i - 1];
            var current = orderedInput[i];

            if (previous != current)
            {
                if (previous + 1 == current)
                {
                    result++;
                }
                else
                {
                    break;
                }
            }
        }

        return result;
    }
}
