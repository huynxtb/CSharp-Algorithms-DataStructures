# Merge Sort

## Introduction

Merge Sort is a classic, efficient, and stable sorting algorithm that follows the divide-and-conquer paradigm. It recursively divides an array into halves until subarrays contain a single element, then merges those subarrays in a sorted manner to produce a fully sorted array. Merge Sort is especially useful when a guaranteed O(n log n) sorting time is essential regardless of input distribution, and when stability (preserving the relative order of equal elements) is required.

## Usage

int[] data = { 38, 27, 43, 3, 9, 82, 10 };
MergeSort.Sort(data);
// After sorting, 'data' will be: { 3, 9, 10, 27, 38, 43, 82 }

To use the algorithm, simply call `MergeSort.Sort` with your integer array. It sorts the array in place.

## Detailed Explanation

The implementation consists of a public static method `Sort` which:
- Handles edge cases such as `null` arrays or arrays with fewer than 2 elements (already sorted).
- Calls `MergeSortRecursive` to perform the recursive divide and merge steps.

`MergeSortRecursive`:
- Takes the array along with the current `left` and `right` bounds.
- If the current subarray has more than one element, it calculates the middle index.
- Recursively sorts the left and right subarrays.
- Calls `Merge` to combine two sorted halves.

`Merge`:
- Allocates temporary arrays for the left and right halves.
- Copies data from the original array into these temporary arrays.
- Merges these two sorted halves back into the original array by comparing elements and picking the smaller element at each step.
- Handles leftover elements once the other half is exhausted.

This approach ensures a stable sort because elements from the left half are copied before equal elements from the right half.

## Complexity Analysis

- **Time Complexity:**
  - Best, Average, and Worst cases: O(n log n), where n is the number of elements in the array.
    The array is repeatedly divided in half (log n levels), and at each level, merging takes linear time,
    resulting in O(n log n).

- **Space Complexity:**
  - O(n) additional space is used for the temporary arrays during merging.
  - This is a trade-off for the stable and guaranteed efficient sort.

This makes Merge Sort a reliable and predictable sorting algorithm suitable for large datasets and scenarios requiring stable sorting.