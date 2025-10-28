# Radix Sort

## Introduction

Radix Sort is a non-comparative integer sorting algorithm that sorts numbers by processing individual digits. It works by sorting the input numbers digit by digit, from the least significant digit to the most significant digit, using a stable sorting algorithm like Counting Sort as a subroutine. Radix Sort is especially efficient for sorting large lists of integers or fixed-length strings, because its time complexity can be better than comparison-based sorting algorithms for these cases.

Use Radix Sort when you have a large collection of non-negative integers needing fast sorting, especially when the numbers have a bounded size or digit length.

## Usage

The following example shows how to use the RadixSort class to sort an integer array:

int[] numbers = { 170, 45, 75, 90, 802, 24, 2, 66 };
RadixSort.Sort(numbers);

// After sorting, numbers = { 2, 24, 45, 66, 75, 90, 170, 802 }

Simply call `RadixSort.Sort()` with the array of non-negative integers you want to sort.

## Detailed Explanation

The implementation works by iterating through each digit of the numbers, starting from the least significant digit (units place) and moving to the most significant digit. For each digit place:

1. Extract the digit from each number using `(number / exp) % 10`, where `exp` is the digit place (1 for units, 10 for tens, etc.).
2. Use a stable counting sort to order the array based on the current digit.

Because counting sort is stable, the relative order of elements with the same digit is maintained across passes, which preserves the previous ordering of more significant digits.

The process repeats until we have processed all digit places of the largest number in the array.

## Complexity Analysis

- **Time Complexity:** O(d * (n + k)), where:
  - `n` is the number of elements,
  - `d` is the number of digits in the maximum number (usually log base 10 of max value),
  - `k` is the range of the digits (0-9, so essentially constant 10).

- **Space Complexity:** O(n + k) due to the auxiliary counting and output arrays used in counting sort.

This makes Radix Sort very efficient for sorting integers with fixed digit sizes and large data sets, often outperforming comparison-based sorts.

---

**Note:** This implementation assumes all integers are non-negative. Handling negative numbers would require additional logic.