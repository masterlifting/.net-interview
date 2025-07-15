namespace AlghorithmStrutures;

public static class Sorting
{
  public static void QuickSort<T>(T[] data) where T : IComparable<T>
  {
    if (data.Length < 2)
      return;

    static int Partition(T[] data, int left, int right)
    {
      var pivot = data[right];
      right--;

      while (left <= right)
      {
        while (left <= right && data[left].CompareTo(pivot) < 0)
          left++;

        while (left <= right && data[right].CompareTo(pivot) > 0)
          right--;

        if (left < right)
          (data[left], data[right]) = (data[right], data[left]);

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

  public static void MergeSort<T>(ref T[] data) where T : IComparable<T>
  {
    if (data.Length < 2)
      return;

    void Merge(ref T[] data, int left, int mid, int right)
    {
      var leftArray = data[left..mid];
      var rightArray = data[(mid + 1)..right];

      int l = 0, r = 0, writeIndex = left;

      while (l < leftArray.Length && r < rightArray.Length)
      {
        if (leftArray[l].CompareTo(rightArray[r]) <= 0)
        {
          data[writeIndex] = leftArray[l];
          l++;
        }
        else
        {
          data[writeIndex] = rightArray[r];
          r++;
        }
        writeIndex++;
      }

      if (l < leftArray.Length)
      {
        while (l < leftArray.Length)
        {
          data[writeIndex] = leftArray[l];
          l++;
          writeIndex++;
        }
      }
      else if (r < rightArray.Length)
      {
        while (r < rightArray.Length)
        {
          data[writeIndex] = rightArray[r];
          r++;
          writeIndex++;
        }
      }
    }

    void SortRecursively(ref T[] data, int left, int right)
    {
      if (left >= right)
        return;

      var mid = (left + right) / 2;

      SortRecursively(ref data, left, mid);
      SortRecursively(ref data, mid + 1, right);

      Merge(ref data, left, mid, right);
    }

    SortRecursively(ref data, 0, data.Length - 1);
  }
}