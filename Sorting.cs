namespace Algorithm;

public static class Sorting
{
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