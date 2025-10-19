# Stack (Linked List Implementation)

## 1. Introduction
The Stack is a fundamental abstract data structure that follows the Last In, First Out (LIFO) principle. This means the last element added to the stack is the first one to be removed. Stacks are commonly used in scenarios such as undo mechanisms, expression evaluation, backtracking algorithms, and managing function calls.

This implementation uses a singly linked list as its internal storage, making it dynamic in size and efficient for stack operations without any need for resizing or pre-allocating storage.

## 2. Usage
// Create a stack instance for integers
var stack = new Stack<int>();

// Push elements onto the stack
stack.Push(10);
stack.Push(20);
stack.Push(30);

// Peek at the top element without removing it
int topItem = stack.Peek();  // topItem = 30

// Pop elements from the stack
int poppedItem = stack.Pop();  // poppedItem = 30

// Check if the stack is empty
bool empty = stack.IsEmpty();  // false

// Pop remaining elements
stack.Pop(); // Pops 20
stack.Pop(); // Pops 10

// Now stack is empty
bool isEmptyNow = stack.IsEmpty();  // true

// Attempt to pop or peek on empty stack will throw InvalidOperationException
try
{
    stack.Pop();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);  // Outputs "Stack is empty."
}

## 3. Detailed Explanation
- The Stack is implemented as a generic class to support any type `T`.
- Internally, it uses a private nested class `Node` that holds individual elements and references to the next node.
- The `top` reference points to the node representing the top of the stack.
- **Push:** Creates a new node with the given value and links it as the new top.
- **Pop:** Returns the value from the top node, then reassigns the top reference to the next node in the list. Throws if empty.
- **Peek:** Returns the value of the top node without removing it. Throws if empty.
- **IsEmpty:** Checks if the top reference is null to determine if the stack is empty.

This design allows all primary operations to execute in constant time without requiring additional memory allocation besides that for new nodes during pushes.

## 4. Complexity Analysis
- **Push:** O(1) Time, O(1) Space (for new node allocation)
- **Pop:** O(1) Time, O(1) Space
- **Peek:** O(1) Time, O(1) Space
- **IsEmpty:** O(1) Time, O(1) Space

The space complexity grows linearly with the number of elements added due to the linked list nodes, but no resizing or copying operations are needed.