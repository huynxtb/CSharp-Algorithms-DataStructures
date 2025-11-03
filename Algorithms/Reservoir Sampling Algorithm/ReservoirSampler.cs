using System;
using System.Collections.Generic;

/// <summary>
/// Implements reservoir sampling algorithm to randomly sample k elements from a data stream of unknown or very large size.
/// </summary>
/// <typeparam name="T">The type of elements in the stream.</typeparam>
public class ReservoirSampler<T>
{
    private readonly int _k;                   // Size of the reservoir
    private readonly List<T> _reservoir;      // The reservoir holding sampled elements
    private int _count;                       // Number of elements processed so far
    private readonly Random _random;          // Random number generator

    /// <summary>
    /// Initializes a new instance of the <see cref="ReservoirSampler{T}"/> class with reservoir size k.
    /// </summary>
    /// <param name="k">The fixed size of the reservoir.</param>
    public ReservoirSampler(int k)
    {
        if (k <= 0)
            throw new ArgumentException("Reservoir size k must be positive.", nameof(k));

        _k = k;
        _reservoir = new List<T>(k);
        _count = 0;
        _random = new Random();
    }

    /// <summary>
    /// Processes the next element from the data stream, updating the reservoir with correct probability.
    /// </summary>
    /// <param name="element">The next element from the data stream.</param>
    public void ProcessNext(T element)
    {
        _count++;

        if (_count <= _k)
        {
            // Initially fill the reservoir array
            _reservoir.Add(element);
        }
        else
        {
            // Randomly decide whether to include the new element
            // Generate a random index from 0 to _count - 1
            int randIndex = _random.Next(_count);
            if (randIndex < _k)
            {
                // Replace element at randIndex with the new element
                _reservoir[randIndex] = element;
            }
        }
    }

    /// <summary>
    /// Returns the current reservoir sample as a read-only list.
    /// </summary>
    /// <returns>A list containing the sampled elements so far.</returns>
    public IReadOnlyList<T> GetSamples()
    {
        return _reservoir.AsReadOnly();
    }
}