namespace AlghorithmStrutures;

public static class Sorting
{
  public static void QuickSort<T>(T[] data) where T : IComparable<T>
  {
    if (data == null)
      throw new ArgumentNullException(nameof(data));
      
    if (data.Length < 2)
      return;

    static int Partition(T[] data, int left, int right)
    {
      var pivot = data[right];
      right--;

      while (left <= right)
      {
        while (left < data.Length && data[left].CompareTo(pivot) < 0)
          left++;

        while (right >= 0 && data[right].CompareTo(pivot) > 0)
          right--;

        if (left <= right)
        {
          (data[left], data[right]) = (data[right], data[left]);
          left++;
          right--;
        }
      }

      (data[left], data[right + 1]) = (data[right + 1], data[left]);
      return left;
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
}