using System;

/// <summary>
/// Count-Min Sketch probabilistic data structure for approximate frequency counting.
/// </summary>
/// <typeparam name="T">Type of items to be counted. Must provide GetHashCode.
/// </typeparam>
public class CountMinSketch<T>
{
    private readonly int width;
    private readonly int depth;
    private readonly int[][] table;
    private readonly HashFunction[] hashFunctions;

    // A delegate type for hash functions
    private delegate int HashFunction(T item);

    /// <summary>
    /// Initializes a new instance of the CountMinSketch class with specified width and depth.
    /// </summary>
    /// <param name="width">Number of counters in each row.</param>
    /// <param name="depth">Number of hash functions / rows.</param>
    public CountMinSketch(int width, int depth)
    {
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Width must be positive.");
        if (depth <= 0) throw new ArgumentOutOfRangeException(nameof(depth), "Depth must be positive.");

        this.width = width;
        this.depth = depth;

        table = new int[depth][];
        for (int i = 0; i < depth; i++)
        {
            table[i] = new int[width];
        }

        hashFunctions = new HashFunction[depth];

        // Initialize simple hash functions with different seeds
        Random rnd = new Random(0); // fixed seed for reproducibility
        for (int i = 0; i < depth; i++)
        {
            int seed = rnd.Next();
            hashFunctions[i] = CreateHashFunction(seed);
        }
    }

    /// <summary>
    /// Adds the item to the sketch with the specified count.
    /// </summary>
    /// <param name="item">Item to add.</param>
    /// <param name="count">Number of occurrences to add; default 1.</param>
    public void Add(T item, int count = 1)
    {
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");
        if (count == 0) return;

        for (int i = 0; i < depth; i++)
        {
            int hash = hashFunctions[i](item);
            int index = Mod(hash, width);
            unchecked
            {
                table[i][index] += count;
            }
        }
    }

    /// <summary>
    /// Returns the estimated frequency count of the specified item.
    /// </summary>
    /// <param name="item">Item to query.</param>
    /// <returns>Approximate count of the item.</returns>
    public int EstimateCount(T item)
    {
        int min = int.MaxValue;
        for (int i = 0; i < depth; i++)
        {
            int hash = hashFunctions[i](item);
            int index = Mod(hash, width);
            int count = table[i][index];
            if (count < min)
                min = count;
        }
        return min;
    }

    // Creates a simple hash function using a seed to simulate independent hash functions.
    // Uses the item.GetHashCode combined with a linear congruential method.
    private HashFunction CreateHashFunction(int seed)
    {
        return item =>
        {
            int h = item == null ? 0 : item.GetHashCode();
            unchecked
            {
                // mix the hashcode with the seed
                int hash = h ^ seed;
                // simple linear congruential step
                hash = (hash * 0x27d4eb2d) + 0x165667b1;
                // ensure positive integer
                return hash & 0x7FFFFFFF;
            }
        };
    }

    // Computes modulus safely for potentially negative numbers
    private static int Mod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + m : r;
    }
}