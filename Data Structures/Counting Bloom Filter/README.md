# Counting Bloom Filter

## Introduction

A *Counting Bloom Filter* is a probabilistic, space-efficient data structure designed to test whether an element is part of a set, similar to a standard Bloom Filter. Unlike classical Bloom Filters, which only support additions and membership checks, Counting Bloom Filters allow removal of elements as well. They maintain counts for each position in the filter's internal array rather than just bits, enabling decrementing counters during removals.

Use a Counting Bloom Filter when you need approximate set membership queries with support for dynamic additions and removals. It is especially useful in network systems, databases, and caching scenarios where memory efficiency and fast membership queries are critical, but exact membership tracking is unnecessary.


## Usage

var filter = new CountingBloomFilter(size: 1000, hashFunctionsCount: 4);

filter.Add("apple");
filter.Add("banana");

bool mightHaveApple = filter.Contains("apple");  // true
bool mightHaveCherry = filter.Contains("cherry");  // probably false

filter.Remove("apple");

bool mightHaveAppleAfterRemoval = filter.Contains("apple");  // false (likely)


## Detailed Explanation

- **Initialization:** The filter is initialized with a specified `size` (length of internal counter array) and number of `hashFunctionsCount` (at least 3). The counters array holds integer counts representing how many times each position is "occupied" by inserted elements.

- **Hashing:** To generate multiple positions for an element, the implementation uses a double hashing technique with the SHA256 hash function. We compute two 64-bit hash values (`hash1` and `hash2`) from the element string. Then the `i`th hash is calculated as `(hash1 + i * hash2) % size`. This avoids the need for separate hash functions and ensures good distribution.

- **Add:** When adding an element, all positions derived from its hashes get their counters incremented by one.

- **Remove:** When removing, counters at the element's hashed positions are decremented but never below zero, thus "undoing" a prior addition.

- **Contains:** To test membership, the filter checks that all counters at hashed positions are greater than zero. If any position is zero, the element is definitely not present. If all are positive, the element might be present (with false positives possible).

- **Limitations:** The filter can over-count if the same element is added multiple times without corresponding removals. Decrementing counters for un-inserted elements can cause inaccuracies but does not produce false negatives.


## Complexity Analysis

| Operation | Time Complexity | Space Complexity |
|-----------|-----------------|------------------|
| Add       | O(k) where k is the number of hash functions | O(m) where m is the size of the counter array |
| Remove    | O(k)            |                   |
| Contains  | O(k)            |                   |

- Here, the complexity is dominated by computing hash positions and updating or checking counters.
- The space complexity depends primarily on the chosen size of the counter array.

This implementation achieves a balance between space efficiency and the capability to both add and remove elements approximately.
