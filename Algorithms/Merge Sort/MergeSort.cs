public class MergeSort
{
    public static void Sort(int[] array)
    {
        if (array == null || array.Length < 2)
        {
            return; // Already sorted or null
        }
        MergeSortRecursive(array, 0, array.Length - 1);
    }

    private static void MergeSortRecursive(int[] array, int left, int right)
    {
        if (left >= right) return;

        int middle = left + (right - left) / 2;
        MergeSortRecursive(array, left, middle);
        MergeSortRecursive(array, middle + 1, right);
        Merge(array, left, middle, right);
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        for (int i = 0; i < leftSize; i++)
            leftArray[i] = array[left + i];

        for (int j = 0; j < rightSize; j++)
            rightArray[j] = array[middle + 1 + j];

        int leftIndex = 0, rightIndex = 0;
        int mergedIndex = left;

        while (leftIndex < leftSize && rightIndex < rightSize)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                array[mergedIndex++] = leftArray[leftIndex++];
            }
            else
            {
                array[mergedIndex++] = rightArray[rightIndex++];
            }
        }

        while (leftIndex < leftSize)
        {
            array[mergedIndex++] = leftArray[leftIndex++];
        }

        while (rightIndex < rightSize)
        {
            array[mergedIndex++] = rightArray[rightIndex++];
        }
    }
}