# Circular Queue

## 1. Introduction
A Circular Queue is a specialized data structure that operates as a fixed-size queue with a circular buffering mechanism. It efficiently utilizes space by wrapping around to the beginning of an internal array when the end is reached. Unlike a linear queue, the circular queue prevents wasted space that occurs due to dequeued elements at the front. This structure is particularly useful in scenarios where a fixed buffer size is preferred, such as buffering data streams, handling asynchronous data, or implementing resource pools.

## 2. Usage
Create a queue with a specified capacity, enqueue elements, and dequeue or peek items as needed. Attempting to enqueue when full or dequeue/peek when empty throws an exception.

Example:

var queue = new CircularQueue<int>(5);  // Create a queue with capacity of 5
queue.Enqueue(10);
queue.Enqueue(20);
queue.Enqueue(30);
int front = queue.Peek();    // front == 10
int item = queue.Dequeue(); // item == 10
queue.Enqueue(40);
queue.Enqueue(50);
while (!queue.IsEmpty)
{
    Console.WriteLine(queue.Dequeue());
}

## 3. Details
- Stores elements in a fixed-size generic array.
- Uses _front and _rear indices to track start and end positions.
- Count tracks number of elements currently in the queue.
- Indices wrap around using modulo arithmetic to reuse space.
- Throws exceptions on invalid operations.

## 4. Complexity
- Enqueue, Dequeue, Peek operations run in O(1) time.
- Space complexity is O(n), with n being the queue capacity.

This makes it suitable for performance-critical applications needing fixed-size queues.