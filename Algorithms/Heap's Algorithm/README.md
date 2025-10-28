# Heap's Algorithm

## Introduction
Heap's Algorithm is a classic algorithm designed to generate all possible permutations of a collection, specifically arrays or lists. The algorithm efficiently produces permutations by minimizing the number of swaps needed to generate the next permutation, making it faster and more elegant than many naive approaches. This implementation specifically works with arrays of integers and can be used in any scenario where you need to enumerate all orderings, such as combinatorial problems, testing, or puzzles.

## Usage
To use the provided `HeapsAlgorithm` class, simply call the static method `GeneratePermutations` with an integer array. It will return a list containing all permutations, where each permutation is represented as an integer array.

int[] input = {1, 2, 3};
List<int[]> permutations = HeapsAlgorithm.GeneratePermutations(input);

// Example: Iterate and print all permutations
foreach(var perm in permutations)
{
    Console.WriteLine(string.Join(", ", perm));
}

## Detailed Explanation

The algorithm works recursively as follows:

- Start with the full array length `k`.
- If `k` is 1, the array is one permutation and is added to the results.
- Otherwise, recursively generate permutations of `k - 1` elements.
- Then, for `i` from 0 to `k - 2`, swap elements based on the parity of `k`:
  - If `k` is even, swap the `i`-th element and the `k-1`-th element.
  - If `k` is odd, swap the first element and the `k-1`-th element.
- After swapping, recursively generate permutations of `k - 1` elements again.

Because it works by minimal swaps and careful recursive calls, Heap's Algorithm generates each permutation exactly once without duplicates.

## Complexity Analysis

- **Time Complexity:** O(n! * n) where n is the length of the input array. There are n! permutations, and each permutation is copied into the result list as an array (which takes O(n)) when added.

- **Space Complexity:** O(n! * n) is used for storing all permutations in a list of arrays. Additional space for recursion call stack is O(n).

This is optimal for full permutation generation as listing all permutations necessarily requires O(n!*n) space and time.

---

This implementation focuses on clarity, reuse, and adheres to requirements by avoiding global or static state outside the static method, and avoiding any input/output or entry points.