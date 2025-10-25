# Disjoint Set Union (DSU) / Union-Find

## 1. Introduction

The Disjoint Set Union (DSU), also known as Union-Find, is a data structure that efficiently manages a collection of disjoint (non-overlapping) sets. It supports operations to find which set an element belongs to and to unify two distinct sets. DSU is commonly used in algorithms and applications involving connectivity, such as:

- Detecting cycles in undirected graphs.
- Kruskal's algorithm for finding the Minimum Spanning Tree.
- Network connectivity queries.
- Clustering and image processing.

This implementation provides optimized methods using **path compression** and **union by size** to ensure near-constant time complexity on average.

## 2. Usage

Here's a basic usage example illustrating the DSU in action in C#:

// Initialize DSU for 5 elements (0 through 4)
DisjointSetUnion dsu = new DisjointSetUnion(5);

// Union some elements
dsu.Union(0, 1);
dsu.Union(1, 2);
dsu.Union(3, 4);

// Check connectivity
bool connected_0_and_2 = dsu.Connected(0, 2);  // true
bool connected_1_and_4 = dsu.Connected(1, 4);  // false

// Find representative
int parentOf3 = dsu.Find(3); // Will be the root of set containing 3

## 3. Detailed Explanation

- **Initialization:** Each element starts as its own set with itself as the parent and size 1.

- **Find:** Traverses up the `parent` array until it reaches the root of the set (an element whose parent is itself). During this traversal, path compression flattens the structure by attaching all visited nodes directly to the root, speeding up future operations.

- **Union:** Merges two sets by connecting the root of the smaller set to the root of the larger set. This technique (union by size) keeps the trees shallow, ensuring the operations remain efficient.

- **Connected:** Uses the `Find` method for both elements and checks if their root parents are the same.

## 4. Complexity Analysis

- **Time Complexity:**
  - **Find:** Amortized nearly O(1) due to path compression.
  - **Union:** Amortized nearly O(1) because it invokes two Find operations plus a constant amount of work.
  - **Connected:** Also nearly O(1), as it's essentially two Find operations.

- **Space Complexity:** O(n), where n is the number of elements, for storing parent and size arrays.

This makes DSU a very powerful and efficient data structure for handling dynamic connectivity problems.