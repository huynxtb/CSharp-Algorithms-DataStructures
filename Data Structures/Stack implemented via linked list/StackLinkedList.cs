using System;

public class Stack<T>
{
    private class Node
    {
        public T Data;
        public Node Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node top;

    public Stack()
    {
        top = null;
    }

    // Adds an item to the top of the stack
    public void Push(T item)
    {
        Node newNode = new Node(item);
        newNode.Next = top;
        top = newNode;
    }

    // Removes and returns the item from the top of the stack
    // Throws InvalidOperationException if stack is empty
    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        T value = top.Data;
        top = top.Next;
        return value;
    }

    // Returns the item from the top of the stack without removing it
    // Throws InvalidOperationException if stack is empty
    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return top.Data;
    }

    // Returns true if the stack is empty, false otherwise
    public bool IsEmpty()
    {
        return top == null;
    }
}