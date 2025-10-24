using System;

public static class CountingSort
{
    /// <summary>
    /// Sorts the given array of non-negative integers using the Counting Sort algorithm.
    /// The original array is not modified; a new sorted array is returned.
    /// </summary>
    /// <param name="input">Array of non-negative integers to be sorted.</param>
    /// <returns>A new array containing all elements from input sorted in ascending order.</returns>
    /// <exception cref="ArgumentNullException">Thrown if input is null.</exception>
    /// <exception cref="ArgumentException">Thrown if input contains negative integers.</exception>
    public static int[] Sort(int[] input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        
        if (input.Length == 0) return new int[0];

        // Find the maximum value in the input array to determine the size of the count array
        int max = input[0];
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] < 0)
                throw new ArgumentException("Input array contains negative integers.", nameof(input));

            if (input[i] > max)
                max = input[i];
        }

        // Initialize count array to store frequency of each value
        int[] count = new int[max + 1];

        // Count the occurrence of each element
        for (int i = 0; i < input.Length; i++)
        {
            count[input[i]]++;
        }

        // Modify count array to store the cumulative count of elements
        for (int i = 1; i <= max; i++)
        {
            count[i] += count[i - 1];
        }

        int[] output = new int[input.Length];

        // Build the output array in a stable manner by iterating input from end to start
        for (int i = input.Length - 1; i >= 0; i--)
        {
            int current = input[i];
            count[current]--;
            output[count[current]] = current;
        }

        return output;
    }
}