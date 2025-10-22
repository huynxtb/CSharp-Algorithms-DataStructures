using System;
using System.Collections.Generic;

public class MaxHeap
{
    private List<int> heap;

    public MaxHeap()
    {
        heap = new List<int>();
    }

    public int Count => heap.Count;

    public void Insert(int value)
    {
        heap.Add(value);
        HeapifyUp(heap.Count - 1);
    }

    public int ExtractMax()
    {
        if (Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        int max = heap[0];

        // Move last element to root and remove last
        heap[0] = heap[Count - 1];
        heap.RemoveAt(Count - 1);

        HeapifyDown(0);

        return max;
    }

    public int Peek()
    {
        if (Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        return heap[0];
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (heap[index] <= heap[parentIndex])
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int lastIndex = heap.Count - 1;

        while (true)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild <= lastIndex && heap[leftChild] > heap[largest])
                largest = leftChild;

            if (rightChild <= lastIndex && heap[rightChild] > heap[largest])
                largest = rightChild;

            if (largest == index)
                break;

            Swap(index, largest);
            index = largest;
        }
    }

    private void Swap(int i, int j)
    {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}
