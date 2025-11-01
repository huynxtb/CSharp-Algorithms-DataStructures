# Binary Search Tree (BST) Iterator

## 1. Introduction
The Binary Search Tree Iterator (BSTIterator) is a data structure that enables efficient in-order traversal (ascending order) of a Binary Search Tree (BST). Instead of using recursion or generating the entire sorted list upfront, this iterator provides an on-demand, controlled traversal that allows clients to retrieve the next smallest element one by one. This is particularly useful in scenarios where partial iteration is enough, or memory efficiency is critical.

## 2. Usage
// Assume TreeNode and BSTIterator classes are defined as per the implementation

// Construct BST manually
TreeNode root = new TreeNode(7,
                    new TreeNode(3),
                    new TreeNode(15,
                        new TreeNode(9),
                        new TreeNode(20)));

// Create BST iterator
BSTIterator iterator = new BSTIterator(root);

while (iterator.HasNext())
{
    int nextVal = iterator.Next();
    System.Console.WriteLine(nextVal);
}

This will output the BST elements in ascending order: 3, 7, 9, 15, 20

## 3. Detailed Explanation
- TreeNode class: Represents nodes of the BST, each storing an integer value and references to left and right children.
- BSTIterator class:
  - Maintains an internal stack to simulate the in-order traversal iteratively.
  - On initialization (BSTIterator(TreeNode root)), it pushes all the left nodes from the root down to the leftmost node onto the stack. This prepares the iterator to return the smallest element first.
  - HasNext() checks if there are remaining nodes to process by checking if the stack is not empty.
  - Next() pops the top node from the stack (which is the next smallest element), and if that node has a right child, it pushes all the left descendants of that right subtree onto the stack. This ensures that the next call to Next() continues the in-order traversal correctly.

This approach uses a controlled iterative traversal with a stack and avoids recursive function calls or pre-computing the entire in-order list. It offers amortized O(1) time per Next() call and efficient memory usage proportional to the tree height.

## 4. Complexity Analysis
- Time Complexity:
  - Initialization takes O(h) time, where h is the height of the tree, due to pushing the leftmost path.
  - Each Next() operation works in amortized O(1) time because each node is pushed and popped exactly once.
  - HasNext() operates in O(1) time.

- Space Complexity:
  - The stack holds at most O(h) elements at any time, where h is the height of the BST.
  - Hence, the space usage depends on the depth of the tree, not the total number of nodes.

This iterator is well-suited for applications that require efficient, incremental access to BST elements in sorted order without the overhead of full traversal storage or recursion.