using System;

public class FenwickTree
{
    private readonly int[] tree;
    private readonly int size;

    // Constructor to initialize Fenwick Tree with given size
    public FenwickTree(int size)
    {
        if (size < 1)
            throw new ArgumentException("Size should be at least 1.");

        this.size = size;
        tree = new int[size + 1]; // Using 1-based indexing internally
    }

    // Update the Fenwick Tree at zero-based index by adding 'delta'
    public void Update(int index, int delta)
    {
        if (index < 0 || index >= size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds.");

        int i = index + 1; // Convert to 1-based index
        while (i <= size)
        {
            tree[i] += delta;
            i += i & (-i); // Move to next index to update
        }
    }

    // Query the prefix sum from start to zero-based index inclusive
    public int Query(int index)
    {
        if (index < 0 || index >= size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of bounds.");

        int sum = 0;
        int i = index + 1; // Convert to 1-based index
        while (i > 0)
        {
            sum += tree[i];
            i -= i & (-i); // Move to parent index
        }
        return sum;
    }

    // Query the sum over the zero-based range [left, right]
    public int RangeQuery(int left, int right)
    {
        if (left < 0 || right >= size || left > right)
            throw new ArgumentOutOfRangeException("Invalid range specified.");

        return Query(right) - (left == 0 ? 0 : Query(left - 1));
    }
}