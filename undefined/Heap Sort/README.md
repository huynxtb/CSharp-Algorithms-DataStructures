# Heap Sort

## 1. Introduction
Heap Sort is a comparison-based sorting algorithm that uses the binary heap data structure to sort elements efficiently. It is known for its consistent performance, with a time complexity of *O(n log n)* in the best, average, and worst cases. Heap Sort is an in-place sorting technique, which means it requires only a constant amount of additional memory.

Heap Sort is especially useful when stability is not a requirement (it is not a stable sort) and when a guaranteed worst-case runtime performance is needed. It is widely used in systems where memory overhead needs to be limited compared to algorithms like Merge Sort.

## 2. Usage
The provided implementation is a static class `HeapSort` with a single public static method `HeapSort` which modifies the input integer array in place.

int[] numbers = { 12, 11, 13, 5, 6, 7 };

HeapSort.HeapSort(numbers);

// numbers is now sorted: [5, 6, 7, 11, 12, 13]

## 3. Detailed Explanation
- **Heap Construction (BuildMaxHeap):**
  Initially, the array is reorganized into a max heap, a complete binary tree where every parent node is greater than or equal to its children. This is done by heapifying nodes from the last non-leaf up to the root.

- **Heapify:**
  Given an element's index, `Heapify` ensures the subtree rooted at that index follows the max heap property by comparing the element with its children and swapping with the largest child if necessary. This operation is recursive, ensuring the heap property's propagation downward.

- **Sorting Process:**
  Once the max heap is built, the largest element is at the root of the heap (the beginning of the array). The root is repeatedly swapped with the last element of the heap and then the heap size is reduced by one. After each swap, the heap property is restored by heapifying the root again.

- **In-place Sorting:**
  The algorithm sorts the array without using extra space for another array; the input array itself is transformed incrementally into the sorted arrangement.

## 4. Complexity Analysis
- **Time Complexity:**
  - Building the max heap takes *O(n)* time.
  - Each of the *n* elements is then "heapified" with *O(log n)* complexity.
  - Overall: *O(n log n)* for all cases (worst, average, best).

- **Space Complexity:**
  - Heap Sort is an in-place algorithm, so it uses *O(1)* extra space.

This makes Heap Sort efficient and predictable for sorting large datasets when memory usage is a consideration and worst-case scenario performance matters.

---
Type: Algorithms