# Sparse Table for Range Minimum Query (RMQ)

## 1. Introduction

A Sparse Table is a static data structure designed for efficient range queries, specifically for finding minimum (or maximum) values within a segment of an array. Once built, it answers queries in O(1) time with O(n log n) preprocessing time. It is ideal when you have a fixed array that does not change, and you need to perform many range minimum queries (RMQ).

This implementation targets the Range Minimum Query where you want to find the smallest value in a given range `[left, right]` within the array.

## 2. Usage

To use the SparseTable class, initialize it with an integer array. Then call the `Query` method with the range indices to get the minimum value in that range.

Example usage:

int[] array = { 1, 3, 2, 7, 9, 11, 3, 5, 6 };
SparseTable st = new SparseTable(array);

int minInRange = st.Query(2, 5); // Queries the minimum from index 2 to 5
Console.WriteLine(minInRange); // Output will be 2

## 3. Detailed Explanation

### Preprocessing
- The constructor preprocesses the input array to build a 2D table `st` where `st[i, j]` represents the minimum value in the subarray starting at `i` with length `2^j`.
- We first compute the logarithms for all lengths up to the array size to quickly find the largest power of two less than or equal to any interval length.
- Initialization fills the first column of the table with the original array values (intervals of length 1).
- Then, each subsequent column computes minimums for intervals twice as long by combining two smaller intervals from the previous column.

### Querying
- To answer a query for the range `[left, right]`:
  - Compute the length of the range and find the largest power of two interval length `2^p` that fits into this range.
  - The minimum value in the range can be found by taking the minimum of two overlapping intervals each of length `2^p` that cover the entire query segment.

## 4. Complexity Analysis

- Preprocessing Time: O(n log n) — We compute the minimums for intervals of varying lengths.
- Query Time: O(1) — Only two precomputed intervals are compared.
- Space Complexity: O(n log n) — For the precomputed table and logarithm array.

This implementation uses only arrays and primitive data types, adheres to clean code standards, and does not depend on any external libraries or runtime logic.