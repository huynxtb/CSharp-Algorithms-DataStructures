using System.Collections.Generic;

public static class HeapsAlgorithm
{
    /// <summary>
    /// Generates all permutations of the given integer array using Heap's Algorithm.
    /// </summary>
    /// <param name="array">The input array of integers to permute.</param>
    /// <returns>A list of integer arrays representing all permutations of the input array.</returns>
    public static List<int[]> GeneratePermutations(int[] array)
    {
        var result = new List<int[]>();
        int n = array.Length;

        // Copy the original array to avoid modifying the input
        int[] arrCopy = new int[n];
        array.CopyTo(arrCopy, 0);

        Generate(n, arrCopy, result);
        return result;
    }

    // Recursive method implementing Heap's Algorithm
    private static void Generate(int k, int[] array, List<int[]> result)
    {
        if (k == 1)
        {
            // Add a copy of the current permutation
            int[] perm = new int[array.Length];
            array.CopyTo(perm, 0);
            result.Add(perm);
        }
        else
        {
            Generate(k - 1, array, result);

            for (int i = 0; i < k - 1; i++)
            {
                if (k % 2 == 0)
                {
                    // If k is even, swap i-th and last element
                    Swap(ref array[i], ref array[k - 1]);
                }
                else
                {
                    // If k is odd, swap first and last element
                    Swap(ref array[0], ref array[k - 1]);
                }
                Generate(k - 1, array, result);
            }
        }
    }

    // Helper method to swap two elements
    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
