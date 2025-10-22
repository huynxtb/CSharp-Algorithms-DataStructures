using System;

public class FenwickTree
{
    private readonly int[] tree;
    private readonly int size;

    public FenwickTree(int[] values)
    {
        if (values == null)
            throw new ArgumentNullException(nameof(values));

        size = values.Length;
        tree = new int[size + 1]; // 1-based indexing

        for (int i = 0; i < size; i++)
        {
            Update(i, values[i]);
        }
    }

    // Increases the value at index 'index' by 'delta'
    // index is 0-based.
    public void Update(int index, int delta)
    {
        if (index < 0 || index >= size)
            throw new ArgumentOutOfRangeException(nameof(index));

        int i = index + 1; // Convert to 1-based indexing
        while (i <= size)
        {
            tree[i] += delta;
            i += i & (-i);
        }
    }

    // Returns the prefix sum from 0 up to index (inclusive)
    // index is 0-based.
    public int Query(int index)
    {
        if (index < 0 || index >= size)
            throw new ArgumentOutOfRangeException(nameof(index));

        int sum = 0;
        int i = index + 1; // Convert to 1-based indexing
        while (i > 0)
        {
            sum += tree[i];
            i -= i & (-i);
        }
        return sum;
    }

    // Returns the sum of elements in the range [left, right]
    // Both left and right are 0-based.
    public int QueryRange(int left, int right)
    {
        if (left < 0 || right >= size || left > right)
            throw new ArgumentOutOfRangeException();

        return Query(right) - (left == 0 ? 0 : Query(left - 1));
    }
}