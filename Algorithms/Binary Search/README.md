# Binary Search

## Introduction
Binary Search is a fundamental searching algorithm used to efficiently find the position of a target value within a sorted array. It significantly reduces the time complexity compared to linear search by repeatedly dividing the search interval in half until the target is found or the search interval is empty.

## Usage
Here is an example of how to use the `BinarySearch` class and its `Search` method:

int[] sortedNumbers = { 1, 3, 5, 7, 9, 11, 13 };
int target = 7;
int index = BinarySearch.Search(sortedNumbers, target);

if (index != -1)
{
    Console.WriteLine($"Target {target} found at index: {index}");
}
else
{
    Console.WriteLine($"Target {target} not found in the array.");
}

## Explanation
The `Search` method implements the binary search algorithm:

1. Checks if the input array is null or empty and returns `-1` if so.
2. Initializes two pointers, `left` and `right`, representing the search boundaries.
3. Iteratively calculates the middle index and compares the middle element with the target.
   - If equal, returns the index.
   - If middle element is less, adjusts `left` to search the right half.
   - Otherwise, adjusts `right` to search the left half.
4. Returns `-1` if the target is not found.

## Complexity
- Time Complexity: O(log n)
- Space Complexity: O(1)
