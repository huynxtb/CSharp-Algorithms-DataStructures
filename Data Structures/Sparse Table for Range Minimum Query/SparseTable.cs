using System;

public class SparseTable
{
    private readonly int[,] st;
    private readonly int[] log;
    private readonly int[] data;
    private readonly int n;

    public SparseTable(int[] input)
    {
        n = input.Length;
        data = input;

        // Precompute logs for use in queries
        log = new int[n + 1];
        log[1] = 0;
        for (int i = 2; i <= n; i++)
            log[i] = log[i / 2] + 1;

        int k = log[n]; // Maximum power of two needed

        st = new int[n, k + 1];

        // Initialize st for the intervals with length 1
        for (int i = 0; i < n; i++)
            st[i, 0] = data[i];

        // Compute values from smaller to bigger intervals
        for (int j = 1; j <= k; j++)
        {
            int length = 1 << j;
            int halfLength = length >> 1;
            for (int i = 0; i + length <= n; i++)
            {
                st[i, j] = Math.Min(st[i, j - 1], st[i + halfLength, j - 1]);
            }
        }
    }

    // Query the minimum in the range [left, right] inclusive
    public int Query(int left, int right)
    {
        if (left < 0 || right >= n || left > right)
            throw new ArgumentOutOfRangeException("Invalid range for Query.");

        int length = right - left + 1;
        int p = log[length];
        int intervalLength = 1 << p;
        return Math.Min(st[left, p], st[right - intervalLength + 1, p]);
    }
}
