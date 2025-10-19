using System;

public class CircularQueue<T>
{
    private readonly T[] _items;
    private int _front;
    private int _rear;
    private int _count;

    public CircularQueue(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        }

        _items = new T[capacity];
        _front = 0;
        _rear = -1;
        _count = 0;
    }

    public void Enqueue(T item)
    {
        if (IsFull)
            throw new InvalidOperationException("Queue is full.");

        _rear = (_rear + 1) % _items.Length;
        _items[_rear] = item;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty.");

        T item = _items[_front];
        _items[_front] = default!; // Clear the reference
        _front = (_front + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Queue is empty.");

        return _items[_front];
    }

    public bool IsEmpty
    {
        get { return _count == 0; }
    }

    public bool IsFull
    {
        get { return _count == _items.Length; }
    }

    public int Count
    {
        get { return _count; }
    }
}