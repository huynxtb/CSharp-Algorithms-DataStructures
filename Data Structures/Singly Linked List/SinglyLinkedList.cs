using System;
using System.Text;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

public class SinglyLinkedList
{
    private Node head;

    public SinglyLinkedList()
    {
        head = null;
    }

    // Add a node at the beginning of the list
    public void AddFirst(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
    }

    // Add a node at the end of the list
    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Insert a node at a specified zero-based position
    // If position is greater than the list count, insert at end
    // Throws ArgumentOutOfRangeException if position is negative
    public void InsertAt(int position, int data)
    {
        if (position < 0)
            throw new ArgumentOutOfRangeException(nameof(position), "Position cannot be negative.");

        if (position == 0)
        {
            AddFirst(data);
            return;
        }

        Node newNode = new Node(data);
        Node current = head;
        int index = 0;

        while (current != null && index < position - 1)
        {
            current = current.Next;
            index++;
        }

        if (current == null)
        {
            // Position is beyond current list - add at end
            AddLast(data);
            return;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }

    // Delete the first node that contains the specified value
    // Returns true if a node was deleted, false otherwise
    public bool DeleteByValue(int value)
    {
        if (head == null)
            return false;

        if (head.Data == value)
        {
            head = head.Next;
            return true;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data != value)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            return false; // Value not found
        }

        current.Next = current.Next.Next;
        return true;
    }

    // Search for a value and return its zero-based position; return -1 if not found
    public int Search(int value)
    {
        Node current = head;
        int index = 0;

        while (current != null)
        {
            if (current.Data == value)
                return index;

            current = current.Next;
            index++;
        }

        return -1;
    }

    // Reverse the linked list in-place
    public void Reverse()
    {
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        head = prev;
    }

    // Return the count of nodes in the list
    public int Count()
    {
        int count = 0;
        Node current = head;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    // Convert the linked list to a string representation showing all elements in order
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        Node current = head;

        sb.Append("[");
        while (current != null)
        {
            sb.Append(current.Data);
            if (current.Next != null)
                sb.Append(", ");
            current = current.Next;
        }
        sb.Append("]");

        return sb.ToString();
    }
}