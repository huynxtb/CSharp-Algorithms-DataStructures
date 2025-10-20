# Fenwick Tree (Binary Indexed Tree)

## 1. Introduction

The Fenwick Tree, also known as the Binary Indexed Tree, is a data structure that provides efficient methods for cumulative frequency tables or prefix sums. It supports updating elements and querying prefix sums in O(log n) time, making it an essential data structure in scenarios where frequent updates and queries of ranges or prefixes are needed, such as in competitive programming, range sum queries, and dynamic frequency counting.

## 2. Usage

Below is a sample usage showing how to create and use the `FenwickTree` class:

// Initialize the Fenwick Tree with size 10
FenwickTree fenwTree = new FenwickTree(10);

// Update index 3 by adding 5
fenwTree.Update(3, 5);

// Update index 7 by adding 2
fenwTree.Update(7, 2);

// Query prefix sum from 0 to 7
int prefixSum = fenwTree.Query(7); // returns cumulative sum up to index 7

// Query the sum in range [3, 7]
int rangeSum = fenwTree.RangeQuery(3, 7);

## 3. Detailed Explanation

- The Fenwick Tree uses a one-based internal array representation to simplify the arithmetic of parent/child tree nodes.
- The constructor initializes the internal tree array with size + 1 to handle 1-based indexing.
- The `Update` method increments the value at a given zero-based index by a specified delta and propagates the update up the tree by adding the least significant bit (LSB) to the current index.
- The `Query` method calculates the prefix sum from the start of the array up to the given zero-based index by traversing backwards using the LSB.
- The `RangeQuery` method returns the sum within a specific range [left, right] by subtracting prefix sums.

## 4. Complexity Analysis

- Time Complexity:
  - Update: O(log n), since it updates all relevant nodes along the path.
  - Query (prefix sum): O(log n), as it traverses the tree upwards.
  - RangeQuery: O(log n), composed of two prefix queries.

- Space Complexity:
  - O(n), where n is the size of the original input array, to store the Fenwick Tree.

This implementation handles zero-based indexing from the user perspective while internally maintaining one-based indexing for efficient computation. It is self-contained and requires no external dependencies.