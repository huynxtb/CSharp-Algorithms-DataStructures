# Heap Sort

## Introduction
Heap Sort is a comparison-based sorting algorithm that leverages a binary heap data structure to sort elements. It sorts an array in-place with a time complexity of O(n log n), making it efficient and reliable for many practical applications. Heap Sort is particularly useful when you need a consistent O(n log n) performance and want to avoid the worst-case scenarios of algorithms like Quick Sort.

## Usage
You can use the HeapSort class to sort an integer array directly. Below is an example of how to use the static `HeapSort` method:

int[] data = { 5, 3, 8, 4, 2, 7, 1, 10 };
HeapSort.HeapSort(data);
// After sorting, data will be: {1, 2, 3, 4, 5, 7, 8, 10}

## Detailed Explanation
The Heap Sort algorithm works in two main phases:

1. **Building a Max Heap:**
   - The input array is transformed into a max-heap, a binary tree where the parent node is always greater than or equal to its children.
   - This is done by starting from the last non-leaf node going up to the root, applying the "heapify" process to ensure each subtree satisfies the max-heap property.

2. **Sorting the Array:**
   - Repeatedly, the root of the heap (the largest element) is swapped with the last element of the heap.
   - The heap size is reduced by one, and the new root is heapified to maintain the max-heap property.
   - These steps continue until the heap size is reduced to one, resulting in a sorted array.

The helper method `Heapify` ensures that a subtree rooted at a given index satisfies the max-heap property. It compares the root with its children and performs swaps and recursive heapifications if necessary.

The `Swap` method is a simple utility that exchanges two elements in the array.

## Complexity Analysis
- **Time Complexity:**
  - Building the max heap takes O(n) time.
  - Each extraction takes O(log n) time, and there are n extractions.
  - Overall time complexity: O(n log n).

- **Space Complexity:**
  - In-place sorting algorithm; requires O(1) additional space.

Heap Sort provides a good balance of efficiency and space usage, with the added advantage of being an in-place, non-recursive sorting algorithm (if implemented iteratively).