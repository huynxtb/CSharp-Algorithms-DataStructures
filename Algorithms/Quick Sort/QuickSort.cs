public static class QuickSort
{
    /// <summary>
    /// Sorts the array of integers in-place using the Quick Sort algorithm.
    /// </summary>
    /// <param name="array">The integer array to be sorted.</param>
    public static void Sort(int[] array)
    {
        if (array == null || array.Length < 2)
            return;

        QuickSortRecursive(array, 0, array.Length - 1);
    }

    // Recursive quicksort implementation
    private static void QuickSortRecursive(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = LomutoPartition(array, low, high);
            QuickSortRecursive(array, low, pivotIndex - 1);
            QuickSortRecursive(array, pivotIndex + 1, high);
        }
    }

    // Lomuto partition scheme
    private static int LomutoPartition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }
        Swap(array, i + 1, high);
        return i + 1;
    }

    // Swap helper method
    private static void Swap(int[] array, int i, int j)
    {
        if (i != j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}