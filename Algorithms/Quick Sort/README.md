# Quick Sort

## Introduction
Quick Sort is a widely-used, efficient, comparison-based sorting algorithm that employs a divide-and-conquer strategy to sort elements. It works by selecting a 'pivot' element from the array and partitioning the other elements into two subarrays, according to whether they are less than or greater than the pivot. The subarrays are then sorted recursively. Quick Sort is often faster in practice than other O(n log n) algorithms like Merge Sort or Heap Sort for average and typical cases due to good cache performance and low overhead.

Use Quick Sort when you need a fast in-place sorting algorithm that performs well on average for many types of input data.

## Usage
int[] data = { 10, 7, 8, 9, 1, 5 };
QuickSort.Sort(data);
// After sorting: data = {1, 5, 7, 8, 9, 10}

## Detailed Explanation
The `QuickSort` static class exposes a single public method `Sort` which accepts an array of integers to be sorted in-place in ascending order. Internally, it uses a private recursive method `QuickSortRecursive` to apply the Quick Sort algorithm.

The implementation uses the classic Lomuto partition scheme:
- The last element in the current subarray is chosen as the pivot.
- Elements smaller than or equal to the pivot are moved to the left side.
- Elements greater than the pivot remain to the right.
- After partitioning, the pivot is placed in its correct sorted position.

`QuickSortRecursive` then recursively sorts the left and right partitions around the pivot.

Helper methods:
- `LomutoPartition` performs the partitioning and returns the final pivot index.
- `Swap` exchanges elements in the array to rearrange them around the pivot.

This approach is in-place and does not require additional arrays, leading to efficient memory use.

## Complexity Analysis
**Time Complexity:**
- Average Case: O(n log n)
- Worst Case: O(n²) (When the pivot partitions are highly unbalanced, e.g., already sorted array and pivot chosen as last element)

**Space Complexity:**
- O(log n) due to recursion stack in average cases
- O(n) in worst case due to recursion depth

This implementation emphasizes clarity, adherence to the classic algorithm, and production readiness without additional dependencies.