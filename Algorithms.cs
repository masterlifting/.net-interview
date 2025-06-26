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
}
