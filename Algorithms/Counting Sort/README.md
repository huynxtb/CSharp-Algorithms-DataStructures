# Counting Sort

## Introduction

Counting Sort is a non-comparative sorting algorithm particularly efficient for sorting arrays of non-negative integers where the range of possible values (keys) is not significantly larger than the number of elements to be sorted. Instead of comparing elements, it counts the occurrences of each unique value. It then uses these counts to directly compute the sorted position of each element, yielding a stable and efficient sort.

This algorithm is best suited for sorting integers in a known small range, making it extremely fast compared to comparison-based sorts in those scenarios.

## Usage

The `CountingSort` class provides a static method `Sort` that takes an array of non-negative integers and returns a new sorted array without modifying the original input.

Example usage:

int[] unsorted = {4, 2, 2, 8, 3, 3, 1};
int[] sorted = CountingSort.Sort(unsorted);

// 'sorted' now contains: [1, 2, 2, 3, 3, 4, 8]

## Detailed Explanation

- **Input Validation:** The method checks for null input and ensures all integers are non-negative.
- **Find Maximum:** It locates the maximum integer in the input to determine the size of the counting array.
- **Count Frequencies:** Creates a count array where the index represents the integer value and the content at that index represents its frequency.
- **Cumulative Counts:** Modifies the count array to hold cumulative counts, which indicates the final positions of elements in the sorted output.
- **Build Output:** Iterates the input array backward to maintain stability. For each element, it places the element at the position indicated by the count array and decrements the count.
- **Return:** Returns the newly created sorted array, leaving the original array unmodified.

## Complexity Analysis

- **Time Complexity:**
  - Finding the max value: O(n)
  - Counting occurrences: O(n)
  - Computing cumulative counts: O(k) where k is the range of input values
  - Placing elements into output: O(n)
  - Overall: O(n + k)
  
- **Space Complexity:**
  - O(k) for the counting array
  - O(n) for the output array

Here, `n` is the number of elements in the input array, and `k` is the maximum value in the input array plus one.

This makes Counting Sort highly efficient when `k` is not significantly larger than `n`. It is stable, preserves the order of equal elements, and doesn't modify the original array, making it suitable for various applications requiring this property.