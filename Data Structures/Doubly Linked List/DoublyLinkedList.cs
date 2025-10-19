using System;
using System.Collections.Generic;

public class DoublyLinkedList<T>
{
    private class Node
    {
        public T Data;
        public Node Next;
        public Node Prev;

        public Node(T data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public int Count {
        get { return count; }
    }

    public void AddFirst(T value)
    {
        Node newNode = new Node(value);
        if (head == null) 
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        count++;
    }

    public void AddLast(T value)
    {
        Node newNode = new Node(value);
        if (tail == null) 
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        count++;
    }

    public bool Remove(T value)
    {
        Node current = head;
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;

        while (current != null)
        {
            if (comparer.Equals(current.Data, value))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    tail = current.Prev;
                }

                count--;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public bool Contains(T value)
    {
        Node current = head;
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        while (current != null)
        {
            if (comparer.Equals(current.Data, value))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Clear()
    {
        Node current = head;
        while(current != null)
        {
            Node next = current.Next;
            current.Prev = null;
            current.Next = null;
            current = next;
        }
        head = null;
        tail = null;
        count = 0;
    }

    public IEnumerable<T> EnumerateForward()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    public IEnumerable<T> EnumerateBackward()
    {
        Node current = tail;
        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }
}