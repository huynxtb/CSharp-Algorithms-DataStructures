using System;

public class CountingInversions
{
    /// <summary>
    /// Counts the number of inversions in the input array using a modified merge sort algorithm.
    /// An inversion is a pair (i, j) such that i < j and array[i] > array[j].
    /// </summary>
    /// <param name="array">Integer array to count inversions in.</param>
    /// <returns>Total number of inversions as a long integer.</returns>
    public long CountInversions(int[] array)
    {
        if (array == null || array.Length < 2)
            return 0;

        int[] temp = new int[array.Length];
        return MergeSortAndCount(array, temp, 0, array.Length - 1);
    }

    private long MergeSortAndCount(int[] array, int[] temp, int left, int right)
    {
        long inversionCount = 0;
        if (left < right)
        {
            int mid = left + (right - left) / 2;
            inversionCount += MergeSortAndCount(array, temp, left, mid);
            inversionCount += MergeSortAndCount(array, temp, mid + 1, right);
            inversionCount += MergeAndCount(array, temp, left, mid, right);
        }
        return inversionCount;
    }

    private long MergeAndCount(int[] array, int[] temp, int left, int mid, int right)
    {
        int i = left;    // Starting index for left subarray
        int j = mid + 1; // Starting index for right subarray
        int k = left;    // Starting index for temporary merged array
        long inversions = 0;

        while (i <= mid && j <= right)
        {
            if (array[i] <= array[j])
            {
                temp[k++] = array[i++];
            }
            else
            {
                // Since array[i] > array[j], all elements from i to mid are inversions with array[j]
                inversions += (mid - i + 1);
                temp[k++] = array[j++];
            }
        }

        // Copy remaining elements of left subarray if any
        while (i <= mid)
            temp[k++] = array[i++];

        // Copy remaining elements of right subarray if any
        while (j <= right)
            temp[k++] = array[j++];

        // Copy merged elements back to original array
        for (int idx = left; idx <= right; idx++)
            array[idx] = temp[idx];

        return inversions;
    }
}
