# Stack implemented via linked list

## Introduction

This implementation represents a generic stack data structure using a singly linked list. A stack is a Last-In-First-Out (LIFO) data structure where the most recently added element is the first one to be removed. This implementation supports common stack operations such as push, pop, peek, and checking if the stack is empty. Since it uses a linked list internally instead of an array or built-in collections, it dynamically grows and shrinks as items are added or removed, with no fixed size limits.

Use this stack when you need a generic LIFO collection and want to control memory usage explicitly without relying on built-in collection types. It's useful for recursive algorithm simulations, expression evaluation, undo mechanisms, and backtracking scenarios.

## Usage

// Create a stack instance for integers
var stack = new Stack<int>();

// Push items
stack.Push(10);
stack.Push(20);
stack.Push(30);

// Peek at the top item
int top = stack.Peek(); // top == 30

// Pop items
while (!stack.IsEmpty())
{
    Console.WriteLine(stack.Pop());
}

// Trying to Pop or Peek from an empty stack will throw InvalidOperationException

## Detailed Explanation

- The stack is implemented with a private nested class `Node` that holds the data and a reference to the next node.
- The `Stack<T>` class maintains a private `top` reference to the first node in the linked list which represents the top of the stack.
- `Push(T item)`: Creates a new node with the item and links it as the new top.
- `Pop()`: Checks if the stack is empty and throws if so. Otherwise, returns the top item and moves the top pointer down to the next node.
- `Peek()`: Returns the data at the top node without removing it, throwing if empty.
- `IsEmpty()`: Checks if the top is null.

This linked list implementation ensures that all operations are performed in constant time.

## Complexity Analysis

| Operation | Time Complexity | Space Complexity |
|-----------|-----------------|------------------|
| Push      | O(1)            | O(1) additional space for new node |
| Pop       | O(1)            | O(1) (no additional space)         |
| Peek      | O(1)            | O(1)                             |
| IsEmpty   | O(1)            | O(1)                             |

The space complexity for the stack is O(n), with n being the number of elements, since each element requires a node in the linked list.