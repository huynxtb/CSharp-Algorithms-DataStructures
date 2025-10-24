# Binary Search Tree (BST)

## 1. Introduction

A Binary Search Tree (BST) is a node-based binary tree data structure where each node contains an integer value, and for every node, values in its left subtree are less than the node's value, and values in its right subtree are greater. This property makes BSTs efficient for dynamic data storage, allowing fast search, insertion, and deletion operations. They are commonly used when you need a sorted data structure that supports quick lookups and ordered traversal.

## 2. Usage

Below is an example showing how to use the provided Binary Search Tree implementation in C#:

// Create a new BST instance
var bst = new BinarySearchTree();

// Insert values
bst.Insert(50);
bst.Insert(30);
bst.Insert(70);
bst.Insert(20);
bst.Insert(40);
bst.Insert(60);
bst.Insert(80);

// Check if a value exists
bool found = bst.Search(60);  // returns true
bool notFound = bst.Search(100);  // returns false

// Delete a value
bst.Delete(30);

// Get the sorted list of elements (Inorder traversal)
IEnumerable<int> sortedValues = bst.InOrderTraversal();

// Output the sorted elements
foreach(var val in sortedValues)
{
    // Do something with val
}

## 3. Detailed Explanation

- **BSTNode Class:** Represents a node holding an integer value and references to its left and right children.

- **BinarySearchTree Class:** Maintains the root node and exposes methods for insertion, searching, deletion, and traversal.

  - **Insert(int value):** Inserts a value into the BST recursively. It navigates the tree to find the appropriate position that respects BST ordering and creates a new node.

  - **Search(int value):** Searches for a value recursively by comparing the target with the current node, moving left or right accordingly.

  - **Delete(int value):** Deletes a node with the specified value by:
    - If the node has no children, simply removes it.
    - If the node has one child, connects its parent directly with this child.
    - If the node has two children, finds the inorder successor (minimum value in the right subtree), replaces the node's value with it, and deletes the successor node.

  - **InOrderTraversal():** Returns all elements in ascending order by visiting left subtree, node, and right subtree recursively.

## 4. Complexity Analysis

- **Insertion:** Average O(log n) time, where n is the number of nodes, because the tree height is balanced in average cases. Worst case O(n), if the tree becomes skewed.

- **Search:** Average O(log n) for balanced trees, worst case O(n) for skewed trees.

- **Deletion:** Average O(log n) due to traversal like search and some fixed additional steps. Worst case O(n) if skewed.

- **InOrder Traversal:** O(n) time to visit all nodes.

- **Space Complexity:** O(n) for storing the nodes, with O(h) auxiliary space for recursion stack, where h is the height of the tree.

This implementation focuses on clarity and correctness, suitable for educational and general usage contexts. For self-balancing variants that guarantee logarithmic height, look into AVL trees or Red-Black trees.