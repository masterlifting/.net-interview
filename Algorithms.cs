namespace LiveCoding;

public static class Algorithms
{
    public static string[] ParseCsv(string input)
    {
        var results = new LinkedList<string>();

        var span = input.AsSpan();

        while (span.Length > 0)
        {
            var startIndex = span.IndexOf("\"", StringComparison.Ordinal);

            if (startIndex == -1)
            {
                startIndex = span.IndexOf(",", StringComparison.Ordinal);

                if (startIndex == -1)
                {
                    results.AddLast(span.ToString());
                    span = [];
                }
                else
                {
                    results.AddLast(span[..startIndex].ToString());
                    span = span[(startIndex + 1)..];
                }
            }
            else
            {
                var endIndex = span[(startIndex + 1)..].IndexOf("\"", StringComparison.Ordinal);

                if (endIndex == -1)
                {
                    results.Clear();
                    break;
                }
                else
                {
                    var result = span[..startIndex];
                    result = result[^1] == ',' ? result[..^1] : result;
                    result = result[0] == ',' ? result[1..] : result;

                    results.AddLast(result.ToString());
                    results.AddLast(span[startIndex..endIndex].ToString());

                    span = span[(endIndex + 1)..];
                }
            }
        }

        return results.ToArray();
    }
}