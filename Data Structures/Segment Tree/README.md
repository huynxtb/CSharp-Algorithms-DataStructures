# Segment Tree

## Introduction

A Segment Tree is a powerful data structure commonly used for querying and updating intervals or segments of an array efficiently. It provides fast range query capabilities such as finding the sum, minimum, or maximum of elements within a specific segment of an array. This makes it ideal for scenarios with multiple queries and updates on array ranges where simpler approaches like prefix sums might fall short.

## Usage

Below is an example demonstrating how to use the `SegmentTree` class for building a segment tree and performing queries and updates:

int[] array = {1, 3, 5, 7, 9, 11};
SegmentTree segTree = new SegmentTree(array);

// Query sum of range [1, 3] -> 3 + 5 + 7 = 15
int querySum = segTree.Query(1, 3);

// Update element at index 2 to 6 (originally 5)
segTree.Update(2, 6);

// Query again the same range after update: 3 + 6 + 7 = 16
int updatedSum = segTree.Query(1, 3);

## Detailed Explanation

The `SegmentTree` class encapsulates the workings of a segment tree specifically designed for sum queries over integer arrays.

- **Storage:** Internally, a tree array stores sums of segments in a balanced binary tree fashion where each node corresponds to an interval.
- **Build:** Construction happens recursively splitting the array segment in half until leaf nodes represent single elements.
- **Query:** Querying is a recursive process that checks if the current segment is fully inside, outside, or partially overlapping the query range, combining results accordingly.
- **Update:** Updating a single element value propagates changes back up the tree to keep segment sums consistent.

This approach ensures that both queries and updates operate in O(log n) time.

## Complexity Analysis

- **Build:** Takes O(n) time, as each node is visited and computed once.
- **Query:** Performs in O(log n) time because it visits only a logarithmic number of nodes relative to the input size.
- **Update:** Also O(log n) time, since only the nodes along the path from the updated leaf to the root need modification.

- **Space Complexity:** O(n) for the data storage plus O(4*n) for the segment tree array, resulting in O(n) overall space.

This implementation ensures efficient range sum queries and point updates, suitable for integration into larger systems requiring interval operations.