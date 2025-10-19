public static class BinarySearch
{
    /// <summary>
    /// Performs a binary search on a sorted array to find the index of a target value.
    /// </summary>
    /// <param name="sortedArray">An array of integers sorted in ascending order.</param>
    /// <param name="target">The integer value to find in the array.</param>
    /// <returns>
    /// The zero-based index of the target value if found; otherwise, -1.
    /// </returns>
    public static int Search(int[] sortedArray, int target)
    {
        if (sortedArray == null || sortedArray.Length == 0)
        {
            return -1; // Empty or null array edge case
        }

        int left = 0;
        int right = sortedArray.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Prevents potential overflow

            if (sortedArray[mid] == target)
            {
                return mid;
            }
            else if (sortedArray[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1; // Target not found
    }
}