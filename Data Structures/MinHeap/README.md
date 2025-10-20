# MinHeap Data Structure

## 1. Introduction

A Min-Heap is a specialized tree-based data structure where the key at the root is the minimum among all keys present. This property is recursively true for all nodes, ensuring the minimum element is always easily accessible at the root. Min-Heaps are widely used in priority queues, efficient sorting algorithms like HeapSort, and various graph algorithms.

This implementation uses a zero-based index array (List<int>) to represent the heap internally, making it efficient in both time and space.

## 2. Usage

Create a new MinHeap instance:

MinHeap heap = new MinHeap();

Insert elements into the heap:

heap.Insert(10);
heap.Insert(5);
heap.Insert(20);
heap.Insert(3);

Peek at the minimum element:

int minValue = heap.Peek();  // 3

Extract the minimum element:

int extractedMin = heap.ExtractMin(); // 3

Check the count:

int count = heap.Count; // 3

Extract remaining elements:

while (heap.Count > 0)
{
    Console.WriteLine(heap.ExtractMin());
}

Note: Calling ExtractMin on an empty heap will throw an InvalidOperationException.

## 3. Detailed Explanation

- **Internal Storage:** The heap elements are stored in a List<int> where parent-child relationships are determined by indices:
  - Parent of index i is (i - 1) / 2
  - Left child of index i is 2 * i + 1
  - Right child of index i is 2 * i + 2

- **Insert(int element):**
  Adds the element at the end and then calls HeapifyUp from the last index to maintain the min-heap property.

- **ExtractMin():**
  Throws if empty. Returns root element, replaces it with last element, removes last, and calls HeapifyDown to restore property.

- **Peek():**
  Returns root element without removing it, throws if empty.

- **HeapifyUp(int index):**
  Moves the element at index up until heap property holds.

- **HeapifyDown(int index):**
  Moves the element at index down until heap property holds.

- **Swap(int firstIndex, int secondIndex):**
  Exchanges two elements in the internal list.

## 4. Complexity Analysis

- **Insertion:** O(log n) time, O(1) extra space.
- **ExtractMin:** O(log n) time, O(1) extra space.
- **Peek:** O(1) time.
- **Count:** O(1) time.

This implementation efficiently maintains the min-heap property with optimal complexity for standard heap operations.