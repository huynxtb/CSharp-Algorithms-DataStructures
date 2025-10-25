using System;
using System.Security.Cryptography;
using System.Text;

public class CountingBloomFilter
{
    private readonly int[] counters;
    private readonly int size;
    private readonly int hashFunctionsCount;

    // For hashing, we use a base hash and derive others from it
    private readonly HashAlgorithm hasher = SHA256.Create();

    /// <summary>
    /// Initializes a new instance of the CountingBloomFilter.
    /// </summary>
    /// <param name="size">The size of the counter array (number of buckets).</param>
    /// <param name="hashFunctionsCount">The number of hash functions to use (minimum 3 recommended).</param>
    public CountingBloomFilter(int size, int hashFunctionsCount)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be positive.");
        if (hashFunctionsCount < 3)
            throw new ArgumentOutOfRangeException(nameof(hashFunctionsCount), "Number of hash functions must be at least 3.");
        this.size = size;
        this.hashFunctionsCount = hashFunctionsCount;
        counters = new int[size];
    }

    /// <summary>
    /// Adds an element to the Counting Bloom Filter.
    /// </summary>
    /// <param name="element">The element (string) to add.</param>
    public void Add(string element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));
        var positions = GetHashPositions(element);
        foreach (var pos in positions)
        {
            // Safely increment counter (no upper bound checking)
            unchecked
            {
                counters[pos]++;
            }
        }
    }

    /// <summary>
    /// Removes an element from the Counting Bloom Filter.
    /// </summary>
    /// <param name="element">The element (string) to remove.</param>
    public void Remove(string element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));
        var positions = GetHashPositions(element);
        foreach (var pos in positions)
        {
            // Decrement only if current count > 0 to avoid negative counts
            if (counters[pos] > 0)
                counters[pos]--;
        }
    }

    /// <summary>
    /// Checks if an element might be contained in the filter.
    /// Returns true if the element might be present, false if definitely not.
    /// </summary>
    /// <param name="element">The element (string) to query.</param>
    /// <returns>Boolean indicating possible presence.</returns>
    public bool Contains(string element)
    {
        if (element == null)
            throw new ArgumentNullException(nameof(element));
        var positions = GetHashPositions(element);
        foreach (var pos in positions)
        {
            if (counters[pos] == 0)
                return false;
        }
        return true;
    }

    // Get positions for each hash function using double hashing technique
    private int[] GetHashPositions(string element)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(element);

        // Compute one base hash for element
        byte[] hash = hasher.ComputeHash(bytes);
        ulong hash1 = BitConverter.ToUInt64(hash, 0);
        ulong hash2 = BitConverter.ToUInt64(hash, 8);

        int[] positions = new int[hashFunctionsCount];

        for (int i = 0; i < hashFunctionsCount; i++)
        {
            ulong combinedHash = (hash1 + (ulong)i * hash2) % (ulong)size;
            positions[i] = (int)combinedHash;
        }
        return positions;
    }
}