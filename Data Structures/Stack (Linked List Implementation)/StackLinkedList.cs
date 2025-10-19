using System;

/// <summary>
/// A generic stack implementation using a singly linked list.
/// The stack follows a Last In, First Out (LIFO) principle.
/// </summary>
/// <typeparam name="T">The type of elements stored in the stack.</typeparam>
public class Stack<T>
{
    // Internal node class representing each element in the linked list
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node top; // Reference to the top node of the stack

    /// <summary>
    /// Initializes an empty stack.
    /// </summary>
    public Stack()
    {
        top = null;
    }

    /// <summary>
    /// Adds an item to the top of the stack.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Push(T item)
    {
        Node newNode = new Node(item);
        newNode.Next = top;
        top = newNode;
    }

    /// <summary>
    /// Removes and returns the item at the top of the stack.
    /// Throws InvalidOperationException if the stack is empty.
    /// </summary>
    /// <returns>The item removed from the top of the stack.</returns>
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        T value = top.Value;
        top = top.Next;
        return value;
    }

    /// <summary>
    /// Returns the item at the top of the stack without removing it.
    /// Throws InvalidOperationException if the stack is empty.
    /// </summary>
    /// <returns>The item at the top of the stack.</returns>
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return top.Value;
    }

    /// <summary>
    /// Checks whether the stack is empty.
    /// </summary>
    /// <returns>True if the stack is empty; otherwise, false.</returns>
    public bool IsEmpty()
    {
        return top == null;
    }
}