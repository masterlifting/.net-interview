namespace Algorithm;

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

    public static int ThirdMax(int[] nums)
    {
        var results = new int?[] { null, null, null };

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (!results[0].HasValue || num > results[0].Value)
            {
                if (!results[1].HasValue || num > results[1].Value)
                {
                    if (!results[2].HasValue || num > results[2].Value)
                    {
                        results[0] = results[1];
                        results[1] = results[2];
                        results[2] = num;
                    }
                    else if (results[2].Value != num)
                    {
                        results[0] = results[1];
                        results[1] = num;
                    }
                }
                else if (results[1].Value != num)
                {
                    results[0] = num;
                }
            }
        }

        return results[0].HasValue
            ? results[0].Value
            : results[2].HasValue
                ? results[2].Value
                : 0;
    }

    public static char[] ReverseString(char[] s)
    {
        var l = 0;
        var r = s.Length - 1;

        while (l < r)
        {
            (s[r], s[l]) = (s[l], s[r]);
            l++;
            r--;
        }

        Console.WriteLine(s);

        return s;
    }

    public static bool IsPalindrome(string s)
    {
        var l = 0;
        var r = s.Length - 1;

        while (l < r)
        {
            var left = s[l];
            if (char.IsAsciiLetterOrDigit(left))
            {
                var right = s[r];
                if (char.IsAsciiLetterOrDigit(right))
                {
                    if (char.ToLower(left) != char.ToLower(right))
                    {
                        return false;
                    }
                    else
                    {
                        l++;
                        r--;
                    }
                }
                else
                {
                    r--;
                }
            }
            else
            {
                l++;
            }
        }

        return true;
    }

    public static int SubtractProductAndSum(int n)
    {
        var sum = 0;
        var product = 1;

        while (n > 0)
        {
            var lastDigit = n % 10;

            sum += lastDigit;
            product *= lastDigit;

            n /= 10;
        }

        return product - sum;
    }

    public static int SumMatrix(int[][] matrix, int row1, int col1, int row2, int col2)
    {
        var prefixMatrix = new int[matrix.Length][];

        for (var i = 0; i < matrix.Length; i++)
        {
            var cells = new int[matrix[i].Length + 1];
            cells[0] = 0;

            for (var j = 1; j < cells.Length; j++)
            {
                cells[j] = matrix[i][j - 1] + cells[j - 1];
            }

            prefixMatrix[i] = cells;
        }

        var result = 0;

        for (var i = row1; i <= row2; i++)
        {
            result += prefixMatrix[i][col2 + 1] - prefixMatrix[i][col1];
        }

        return result;
    }

    public static bool IsAnagram(string s, string t)
    {
        var dict = new Dictionary<char, uint>(s.Length + t.Length);

        for (var i = 0; i < s.Length; i++)
        {
            if (!dict.TryGetValue(s[i], out uint value))
            {
                dict[s[i]] = 1;
            }
            else
            {
                dict[s[i]] = ++value;
            }
        }

        for (var i = 0; i < t.Length; i++)
        {
            if (!dict.TryGetValue(t[i], out uint value))
            {
                return false;
            }
            else
            {
                dict[t[i]] = --value;
            }
        }

        return dict.All(x => x.Value == 0);
    }

    private class Interval(int start, int end) : IComparable<Interval>
    {
        public int Start => start;
        public int End => end;

        public int CompareTo(Interval? other) => Start - other?.Start ?? 0;
    }

    public static int[][] MergeIntervals(int[][] intervals)
    {
        var orderedIntervals = intervals
            .Select(x => new Interval(x[0], x[1]))
            .Order()
            .ToArray();

        var mergedIntervals = new List<Interval>
        {
          orderedIntervals[0]
        };

        for (var i = 1; i < orderedIntervals.Length; i++)
        {
            var previous = mergedIntervals.Last();
            var current = orderedIntervals[i];

            // overlaping
            if (previous.Start <= current.End && current.Start <= previous.End)
            {
                mergedIntervals.Remove(previous);
                var start = Math.Min(previous.Start, current.Start);
                var end = Math.Max(previous.End, current.End);
                mergedIntervals.Add(new Interval(start, end));
            }
            else
            {
                mergedIntervals.Add(current);
            }
        }

        return mergedIntervals.Select(x => new int[] { x.Start, x.End }).ToArray();
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>(nums.Length);

        for (var i = 0; i < nums.Length; i++)
        {
            var v = target - nums[i];

            if (dict.TryGetValue(v, out int value))
            {
                return [value, i];
            }
            else
            {
                dict.TryAdd(nums[i], i);
            }
        }

        return [];
    }

    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var cache = new Dictionary<string, IList<string>>();

        for (var i = 0; i < strs.Length; i++)
        {
            var str = strs[i];
            var orderedStr = string.Join("", str.Order());

            if (cache.TryGetValue(orderedStr, out var list))
            {
                list.Add(str);
                cache[orderedStr] = list;
            }
            else
            {
                cache[orderedStr] = [str];
            }
        }

        return [.. cache.Values];
    }

    public static bool BackspaceCompare(string s, string t)
    {
        var sStack = new Stack<char>(s.Length);
        var tStack = new Stack<char>(t.Length);

        for (var i = 0; i < s.Length; i++)
        {
            var v = s[i];

            if (v == '#')
            {
                if (sStack.Any())
                {
                    sStack.Pop();
                }
            }
            else
            {
                sStack.Push(v);
            }

        }

        for (var i = 0; i < t.Length; i++)
        {
            var v = t[i];

            if (v == '#')
            {
                if (tStack.Any())
                {
                    tStack.Pop();
                }
            }
            else
            {
                tStack.Push(v);
            }
        }

        return sStack.SequenceEqual(tStack);
    }

    public class ListNode
    {
        public int Val { get; set; }
        public ListNode? Next { get; set; }

        public ListNode(int val = 0, ListNode? next = null)
        {
            Val = val;
            Next = next;
        }
    }

    public static ListNode? MergeTwoSortedLists(ListNode? list1, ListNode? list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        static ListNode? Merge(ListNode? l1, ListNode? l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            ListNode? result;

            if (l1.Val < l2.Val)
            {
                result = new ListNode(l1.Val);
                result.Next = Merge(l1.Next, l2);
            }
            else
            {
                result = new ListNode(l2.Val);
                result.Next = Merge(l2.Next, l1);
            }

            return result;
        }

        return Merge(list1, list2);
    }

    public static void QuickSort<T>(T[] data) where T : IComparable<T>
    {
        if (data.Length < 2)
            return;

        static int Partition(T[] data, int left, int right)
        {
            var pivot = data[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (data[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    (data[i], data[j]) = (data[j], data[i]);
                }
            }

            (data[i + 1], data[right]) = (data[right], data[i + 1]);
            return i + 1;
        }

        static void SortRecursively(T[] data, int left, int right)
        {
            if (left >= right)
                return;

            var pivot = Partition(data, left, right);

            SortRecursively(data, left, pivot - 1);
            SortRecursively(data, pivot + 1, right);
        }

        SortRecursively(data, 0, data.Length - 1);
    }

    public static void MergeSort<T>(T[] data) where T : IComparable<T>
    {
        if (data.Length < 2)
            return;

        // Create a temporary array for merging
        T[] temp = new T[data.Length];
        MergeSortInternal(data, 0, data.Length - 1, temp);
    }

    private static void MergeSortInternal<T>(T[] data, int left, int right, T[] temp) where T : IComparable<T>
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2; // Prevents overflow for large arrays

            MergeSortInternal(data, left, mid, temp);
            MergeSortInternal(data, mid + 1, right, temp);

            Merge(data, left, mid, right, temp);
        }
    }

    private static void Merge<T>(T[] data, int left, int mid, int right, T[] temp) where T : IComparable<T>
    {
        // Copy both halves to temp array
        Array.Copy(data, left, temp, left, right - left + 1);

        int l = left;      // Initial index of first subarray
        int r = mid + 1;   // Initial index of second subarray
        int i = left;      // Initial index of merged array

        while (l <= mid && r <= right)
        {
            if (temp[l].CompareTo(temp[r]) <= 0)
            {
                data[i] = temp[l++];
            }
            else
            {
                data[i] = temp[r++];
            }
            i++;
        }

        while (l <= mid)
        {
            data[i++] = temp[l++];
        }
    }
}
