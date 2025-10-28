# Singly Linked List

## 1. Introduction

A singly linked list is a fundamental linear data structure where each element (node) contains data and a reference (pointer) to the next node in the sequence. Unlike arrays, linked lists allow dynamic memory allocation and efficient insertion or deletion of elements anywhere in the list without the need to shift other elements. This structure is essential for understanding pointer-based data organization and manipulation. Use a singly linked list when you need a dynamic collection with frequent insertions and deletions but do not require backward traversal.

## 2. Usage

Below is an example of how to use the `SinglyLinkedList` class in C#:

SinglyLinkedList list = new SinglyLinkedList();

// Add elements
list.AddFirst(10);         // List: [10]
list.AddLast(20);          // List: [10, 20]
list.InsertAt(1, 15);      // List: [10, 15, 20]

// Search
int pos = list.Search(15); // Returns 1

// Delete
bool removed = list.DeleteByValue(10); // True, List: [15, 20]

// Reverse
list.Reverse();            // List: [20, 15]

// Count
int count = list.Count();  // Returns 2

// Print
string representation = list.ToString(); // "[20, 15]"

## 3. Detailed Explanation

- **Node Class**: Represents the building block of the list, holding an integer data value and a reference to the next node.

- **SinglyLinkedList Class**: Manages the list operations:
  - `AddFirst(int data)`: Inserts a new node at the beginning.
  - `AddLast(int data)`: Appends a new node at the end.
  - `InsertAt(int position, int data)`: Inserts a new node at the given zero-based index. If the position is beyond the end, it appends.
  - `DeleteByValue(int value)`: Removes the first node with the specified value.
  - `Search(int value)`: Returns the zero-based position of the value or -1 if not found.
  - `Reverse()`: Reverses the linked list in place by changing the `Next` pointers.
  - `Count()`: Counts the nodes in the list.
  - `ToString()`: Provides a string representation of the list's contents in order.

The class uses internal iteration over nodes for its operations, ensuring each operation handles edge cases (empty list, single element, out of bounds) robustly.

## 4. Complexity Analysis

| Operation       | Time Complexity | Space Complexity |
|-----------------|-----------------|-----------------|
| AddFirst        | O(1)            | O(1)            |
| AddLast         | O(n)            | O(1)            |
| InsertAt        | O(n)            | O(1)            |
| DeleteByValue   | O(n)            | O(1)            |
| Search          | O(n)            | O(1)            |
| Reverse         | O(n)            | O(1)            |
| Count           | O(n)            | O(1)            |
| ToString        | O(n)            | O(n) (for output) |

- **Time Complexity Explanation:** Operations like adding at the start are constant time because they only manipulate the head pointer. Operations that might require traversal (add at end, insert at position, delete by value, search, reverse) scale linearly with the number of elements.

- **Space Complexity Explanation:** The space used is proportional to the number of nodes stored. No additional significant memory allocation occurs except for temporary pointers or the output string buffer in `ToString()`.

This implementation is suitable for educational purposes and integration into larger C# projects requiring a classic singly linked list structure.