using System;
using System.Collections.Generic;

/// <summary>
/// Represents a Min-Heap data structure implemented with a zero-based index array.
/// Provides efficient insertion, extraction of the minimum element, and peeking operations.
/// </summary>
public class MinHeap
{
    // Internal list to store heap elements
    private List<int> _elements;

    /// <summary>
    /// Gets the number of elements contained in the heap.
    /// </summary>
    public int Count => _elements.Count;

    /// <summary>
    /// Initializes a new instance of the <see cref="MinHeap"/> class.
    /// </summary>
    public MinHeap()
    {
        _elements = new List<int>();
    }

    /// <summary>
    /// Inserts a new element into the heap.
    /// </summary>
    /// <param name="element">The element to insert.</param>
    public void Insert(int element)
    {
        // Add the new element at the end
        _elements.Add(element);
        // Restore the heap property by heapifying up from the last element
        HeapifyUp(_elements.Count - 1);
    }

    /// <summary>
    /// Removes and returns the minimum element from the heap.
    /// </summary>
    /// <returns>The minimum element.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the heap is empty.</exception>
    public int ExtractMin()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        int min = _elements[0];

        // Move the last element to the root and remove the last
        int lastIndex = _elements.Count - 1;
        _elements[0] = _elements[lastIndex];
        _elements.RemoveAt(lastIndex);

        // Restore the heap property by heapifying down from the root
        HeapifyDown(0);

        return min;
    }

    /// <summary>
    /// Returns the minimum element without removing it.
    /// </summary>
    /// <returns>The minimum element.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the heap is empty.</exception>
    public int Peek()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return _elements[0];
    }

    /// <summary>
    /// Restores the heap property going up from the given index.
    /// </summary>
    /// <param name="index">Index of the element to heapify up.</param>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            // If current element is less than its parent, swap them
            if (_elements[index] < _elements[parentIndex])
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                // Heap property is satisfied
                break;
            }
        }
    }

    /// <summary>
    /// Restores the heap property going down from the given index.
    /// </summary>
    /// <param name="index">Index of the element to heapify down.</param>
    private void HeapifyDown(int index)
    {
        int lastIndex = _elements.Count - 1;

        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallestIndex = index;

            // Check if left child exists and is smaller than current
            if (leftChildIndex <= lastIndex && _elements[leftChildIndex] < _elements[smallestIndex])
            {
                smallestIndex = leftChildIndex;
            }

            // Check if right child exists and is smaller than current smallest
            if (rightChildIndex <= lastIndex && _elements[rightChildIndex] < _elements[smallestIndex])
            {
                smallestIndex = rightChildIndex;
            }

            // If smallest is not the current index, swap and continue
            if (smallestIndex != index)
            {
                Swap(index, smallestIndex);
                index = smallestIndex;
            }
            else
            {
                // Heap property is satisfied
                break;
            }
        }
    }

    /// <summary>
    /// Swaps two elements in the internal list.
    /// </summary>
    /// <param name="firstIndex">The index of the first element.</param>
    /// <param name="secondIndex">The index of the second element.</param>
    private void Swap(int firstIndex, int secondIndex)
    {
        int temp = _elements[firstIndex];
        _elements[firstIndex] = _elements[secondIndex];
        _elements[secondIndex] = temp;
    }
}
