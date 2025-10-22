# MaxHeap Data Structure

## Introduction

The **MaxHeap** is a specialized tree-based data structure that satisfies the max-heap property: every parent node is greater than or equal to its children. This property ensures that the largest element is always at the root of the heap. The max heap is commonly used for efficiently implementing priority queues, sorting algorithms such as heap sort, and solving graph problems where quick access to the maximum element is required.

## Usage

// Create a new max heap instance
var maxHeap = new MaxHeap();

// Insert values
maxHeap.Insert(10);
maxHeap.Insert(40);
maxHeap.Insert(30);
maxHeap.Insert(20);

// Peek the maximum element
int maxValue = maxHeap.Peek();  // maxValue == 40

// Extract elements in descending order
while (maxHeap.Count > 0)
{
    int max = maxHeap.ExtractMax();
    Console.WriteLine(max);
}

## Detailed Explanation

Internally, the max heap is represented using a dynamically resizing list (`List<int>`). Each element in the list represents a node in a conceptual binary tree:

- The root element is always at index 0.
- For an element at index `i`:
  - The left child is at index `2 * i + 1`.
  - The right child is at index `2 * i + 2`.
  - The parent is at index `(i - 1) / 2`.

### Insertion (`Insert` method)
When a new value is inserted, it is appended at the end of the list (maintaining a complete tree structure). Then, the `HeapifyUp` process compares the inserted value with its parent repeatedly and swaps them if the new value is greater than the parent, restoring the max-heap property. This operation runs in O(log n) time where n is the number of elements.

### Extraction (`ExtractMax` method)
To remove the maximum element (the root), the root value is saved to return later. The last element is moved to the root, and the last element is removed from the list. Then, `HeapifyDown` is performed: the root swaps with its largest child repeatedly until the max-heap property is restored. This also runs in O(log n) time.

### Peeking (`Peek` method)
Simply returns the root element without removing it, giving O(1) access to the maximum element.

### Count Property
Returns the current number of elements in the heap.

## Complexity Analysis

| Operation     | Time Complexity | Space Complexity |
|---------------|-----------------|------------------|
| Insert        | O(log n)        | O(1)             |
| ExtractMax    | O(log n)        | O(1)             |
| Peek          | O(1)            | O(1)             |
| Memory Usage  | -               | O(n) where n is heap size |

The space complexity is dominated by the internal list storing all heap elements.

This implementation is efficient, clean, and suitable for scenarios demanding priority-based retrieval in logarithmic time without external dependencies.