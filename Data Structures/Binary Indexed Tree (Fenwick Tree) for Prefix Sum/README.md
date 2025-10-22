# Binary Indexed Tree (Fenwick Tree) for Prefix Sum

## 1. Introduction

The Binary Indexed Tree, also known as Fenwick Tree, is a data structure that provides efficient methods for calculating prefix sums and updating elements in an array. It supports the operations of updating an element and querying prefix sums both in O(log n) time, which is much faster than the naive O(n) methods for large datasets.

Fenwick Trees are particularly useful in scenarios involving frequent updates and prefix sum queries, such as in frequency counting, cumulative frequency tables, and certain range query problems in competitive programming and real-time data analysis.

## 2. Usage

Here's how you can use the `FenwickTree` class in C#:

int[] values = {2, 1, 5, 3, 4};
FenwickTree fenw = new FenwickTree(values);

// Query prefix sums
int prefixSum0to2 = fenw.Query(2);       // Sum of elements from index 0 to 2
int rangeSum1to3 = fenw.QueryRange(1, 3); // Sum of elements from index 1 to 3

// Update element at index 3 (0-based) by adding 2
fenw.Update(3, 2);

// Query again after update
int updatedRangeSum1to3 = fenw.QueryRange(1, 3);

## 3. Detailed Explanation

- **Internal Structure:** The Fenwick Tree maintains an internal array `tree` which is 1-based indexed. This means the user-facing indices are adjusted internally by +1.

- **Building the Tree:** Upon construction, the Fenwick Tree is built by calling `Update` with each initial value, which cumulatively sets up the internal structure.

- **Updating Values (`Update` method):** When a value at index `i` is updated by a delta, the Fenwick Tree updates multiple positions in the `tree` array. Using the property `i += i & (-i)`, it moves to the next responsible node that covers the range including `i`.

- **Querying Prefix Sum (`Query` method):** To retrieve the sum from the start up to index `i`, the Fenwick Tree walks down the tree array, summing values at nodes covering appropriate ranges. This relies on `i -= i & (-i)` to move upwards in the tree.

- **Range Query (`QueryRange` method):** The sum within a range `[left, right]` is computed by subtracting the prefix sum ending before `left` from the prefix sum ending at `right`.

## 4. Complexity Analysis

- **Space Complexity:** O(n), where n is the number of elements. The internal Fenwick tree array stores n+1 elements.

- **Time Complexity:**
  - **Update:** O(log n) — updates affect a logarithmic number of elements in the tree array.
  - **Query (Prefix sum):** O(log n) — sums are computed by traversing up to the root in logarithmic steps.
  - **Range Query:** O(log n) — computed using two prefix sums.

This implementation is clean, efficient, and suitable for embedding in projects requiring fast prefix sum queries with dynamic updates.