# Counting Inversions Algorithm using Modified Merge Sort

## 1. Introduction
The Counting Inversions algorithm efficiently counts the number of inversions in an array, where an inversion is a pair of indices \((i, j)\) such that \(i < j\) and \(array[i] > array[j]\). This metric indicates how far an array is from being sorted and is useful in computational biology, data analysis, and problems requiring inversion counting.

This implementation uses a modified Merge Sort approach to count inversions while sorting the array, achieving an optimal \(O(n \log n)\) time complexity.

## 2. Usage
// Create an instance of the CountingInversions class
var inversionCounter = new CountingInversions();

// Define the array to analyze
int[] array = { 8, 4, 2, 1 };

// Count the number of inversions
long totalInversions = inversionCounter.CountInversions(array);

Console.WriteLine($"Total inversions: {totalInversions}"); // Output: Total inversions: 6

## 3. Detailed Explanation
The algorithm works by implementing a modified merge sort:

- **Divide:** Recursively split the input array into two halves until individual elements remain.
- **Conquer:** Recursively count inversions in both halves.
- **Combine:** Merge the two sorted halves into one sorted array.

During the merge step:
- Elements from the left and right halves are compared.
- If \(array[i] \leq array[j]\), the left element is moved to the merged array without adding inversions.
- If \(array[i] > array[j]\), it means there are \(mid - i + 1\) inversions, since all remaining elements in the left subarray are greater than \(array[j]\).
- These inversion counts are accumulated as the merge progresses.

This approach efficiently counts all inversions without the naive \(O(n^2)\) pairwise comparison.

## 4. Complexity Analysis
- **Time Complexity:** \(O(n \log n)\) due to the divide-and-conquer strategy of merge sort.
- **Space Complexity:** \(O(n)\) for the auxiliary temporary array used during merging.

This balance between efficient sorting and counting makes this algorithm a standard solution for inversion counting problems.