namespace LiveCoding;

public static class Algorithms
{
    private static string[] Split(ref ReadOnlySpan<char> span, string delimiter)
    {
        var results = new LinkedList<string>();

        while (span.Length > 0)
        {
            var index = span.IndexOf(delimiter, StringComparison.Ordinal);

            ReadOnlySpan<char> result;

            if (index == -1)
            {
                result = span;
                span = [];
            }
            else
            {
                result = span[..index];
                span = span[(index + 1)..];
            }

            results.AddLast(result.ToString());
        }

        return results.ToArray();
    }
    public static string[] ParseCsv(string input)
    {
        var span = input.AsSpan();
        var results = Split(ref span, "\"");

        if (results.Length == 0)
        {
            results = Split(ref span, ",");
        }
        else
        {
            for (var i = 0; i < results.Length; i++)
            {
                var result = results[i];
                result = result[^1] == ',' ? result[..^1] : result;
                result = result[0] == ',' ? result[1..] : result;
                results[i] = result;
            }
        }

        return results;
    }
}