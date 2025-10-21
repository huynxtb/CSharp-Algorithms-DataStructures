public static class HeapSort
{
    public static void HeapSort(int[] array)
    {
        int length = array.Length;

        // Build max heap
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            Heapify(array, length, i);
        }

        // Extract elements from heap one by one
        for (int i = length - 1; i >= 0; i--)
        {
            // Move current root (max) to end
            Swap(array, 0, i);

            // call max heapify on the reduced heap
            Heapify(array, i, 0);
        }
    }

    private static void Heapify(int[] array, int heapSize, int rootIndex)
    {
        int largest = rootIndex;  // Initialize largest as root
        int leftChild = 2 * rootIndex + 1; // left = 2*i + 1
        int rightChild = 2 * rootIndex + 2; // right = 2*i + 2

        // If left child is larger than root
        if (leftChild < heapSize && array[leftChild] > array[largest])
        {
            largest = leftChild;
        }

        // If right child is larger than largest so far
        if (rightChild < heapSize && array[rightChild] > array[largest])
        {
            largest = rightChild;
        }

        // If largest is not root
        if (largest != rootIndex)
        {
            Swap(array, rootIndex, largest);

            // Recursively heapify the affected sub-tree
            Heapify(array, heapSize, largest);
        }
    }

    private static void Swap(int[] array, int indexA, int indexB)
    {
        int temp = array[indexA];
        array[indexA] = array[indexB];
        array[indexB] = temp;
    }
}