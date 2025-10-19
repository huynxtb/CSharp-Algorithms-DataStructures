# Doubly Linked List

## Introduction

A Doubly Linked List is a fundamental data structure consisting of nodes where each node contains a value and two pointers: one pointing to the next node and one pointing to the previous node. This design allows traversal of the list in both forward and backward directions efficiently. It is useful when you need quick insertion and deletion of elements from any position in the list and require bidirectional traversal. Common use cases include navigation systems, undo/redo functionality, and complex data manipulation scenarios.

## Usage

var list = new DoublyLinkedList<int>();

// Adding elements
list.AddFirst(10);
list.AddLast(20);
list.AddFirst(5);

// Check count
Console.WriteLine(list.Count); // Output: 3

// Check if contains
bool contains20 = list.Contains(20); // true

// Enumerate forward
foreach(var item in list.EnumerateForward())
{
    Console.WriteLine(item); // 5, 10, 20
}

// Enumerate backward
foreach(var item in list.EnumerateBackward())
{
    Console.WriteLine(item); // 20, 10, 5
}

// Remove an element
bool removed = list.Remove(10); // true

// Clear the list
list.Clear();
Console.WriteLine(list.Count); // 0

## Detailed Explanation

- The `DoublyLinkedList<T>` class is generic, supporting any data type.
- It contains a private nested class `Node` which holds the data and references to the next and previous nodes.
- The list tracks the `head` (first node), `tail` (last node), and `count` (number of elements).
- `AddFirst(T value)`: Creates a new node and inserts it at the beginning. Updates head and tail references as needed.
- `AddLast(T value)`: Creates a new node and inserts it at the end. Updates tail and head references as needed.
- `Remove(T value)`: Searches from head to tail, removes the first node matching the value, and fixes the links between neighboring nodes accordingly.
- `Contains(T value)`: Checks from head to tail if a node contains the specified value.
- `Clear()`: Traverses and dereferences each node to help with garbage collection, and resets the list.
- `Count`: Returns the number of elements currently in the list.
- `EnumerateForward()`: Returns an enumerable to iterate from head to tail using `yield return`.
- `EnumerateBackward()`: Returns an enumerable to iterate from tail to head using `yield return`.

All operations handle edge cases such as empty lists and single element lists.

## Complexity Analysis

- **AddFirst(T value):**
  - Time Complexity: O(1)
  - Space Complexity: O(1)

- **AddLast(T value):**
  - Time Complexity: O(1)
  - Space Complexity: O(1)

- **Remove(T value):**
  - Time Complexity: O(n)
  - Space Complexity: O(1)

- **Contains(T value):**
  - Time Complexity: O(n)
  - Space Complexity: O(1)

- **Clear():**
  - Time Complexity: O(n)
  - Space Complexity: O(1)

- **EnumerateForward() / EnumerateBackward():**
  - Time Complexity: O(n)
  - Space Complexity: O(1)