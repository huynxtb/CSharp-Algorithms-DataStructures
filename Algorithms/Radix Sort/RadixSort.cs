using System;

/// <summary>
/// Provides an implementation of Radix Sort algorithm for sorting arrays of non-negative integers.
/// </summary>
public static class RadixSort
{
    /// <summary>
    /// Sorts the input array of non-negative integers in ascending order using Radix Sort.
    /// </summary>
    /// <param name="array">The array of non-negative integers to sort.</param>
    public static void Sort(int[] array)
    {
        if (array == null || array.Length < 2)
            return;

        int max = GetMax(array);

        // Perform counting sort for every digit, starting from least significant digit (exponent = 1)
        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSortByDigit(array, exp);
        }
    }

    // Get maximum value in array
    private static int GetMax(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
                max = array[i];
        }
        return max;
    }

    // Stable counting sort for sorting array according to the digit represented by exp
    private static void CountingSortByDigit(int[] array, int exp)
    {
        int n = array.Length;
        int[] output = new int[n];
        int[] count = new int[10]; // Since digits are 0 to 9

        // Count occurrences of digits at exp place
        for (int i = 0; i < n; i++)
        {
            int digit = (array[i] / exp) % 10;
            count[digit]++;
        }

        // Change count[i] so that count[i] contains the actual position of this digit in output[]
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array from right to left to maintain stable sort
        for (int i = n - 1; i >= 0; i--)
        {
            int digit = (array[i] / exp) % 10;
            output[count[digit] - 1] = array[i];
            count[digit]--;
        }

        // Copy sorted elements back into the original array
        for (int i = 0; i < n; i++)
        {
            array[i] = output[i];
        }
    }
}
