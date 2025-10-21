public static class HeapSort
{
    // Public method to perform heap sort on the input array
    public static void HeapSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return; // Array is null or already sorted

        int n = arr.Length;

        // Build max heap from the array elements
        BuildMaxHeap(arr, n);

        // One by one extract elements from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root (largest) to end
            Swap(arr, 0, i);

            // Heapify the reduced heap
            Heapify(arr, i, 0);
        }
    }

    // Helper method to build a max heap from the array
    private static void BuildMaxHeap(int[] arr, int n)
    {
        // Start from the last non-leaf node and heapify each
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }
    }

    // Heapify a subtree rooted with node i which is an index in arr[]
    // n is the size of the heap
    private static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;          // Initialize largest as root
        int left = 2 * i + 1;     // left = 2*i + 1
        int right = 2 * i + 2;    // right = 2*i + 2

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;

        // If largest is not root
        if (largest != i)
        {
            Swap(arr, i, largest);

            // Recursively heapify the affected subtree
            Heapify(arr, n, largest);
        }
    }

    // Swap elements at index i and j
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
