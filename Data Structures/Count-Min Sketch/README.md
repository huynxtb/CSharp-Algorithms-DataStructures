# Count-Min Sketch

## Introduction
The Count-Min Sketch is a probabilistic data structure used for frequency estimation of events within data streams. It provides an approximate count of the number of occurrences of elements using sub-linear space and is particularly useful when dealing with large-scale streaming data where exact counting is memory-prohibitive. Common applications include network traffic monitoring, natural language processing, and large-scale analytics.

## Usage
Create a Count-Min Sketch with width 1000 and depth 5
var cms = new CountMinSketch<string>(1000, 5);

Add items
cms.Add("apple", 1);
cms.Add("banana", 2);

Query estimated counts
int appleCount = cms.EstimateCount("apple");
int bananaCount = cms.EstimateCount("banana");

## Detailed Explanation
The `CountMinSketch<T>` class implements the sketch as a 2D array (depth rows and width columns) where each row is associated with a different hash function. When an item is added, it is hashed by each hash function and the count at the corresponding cell is incremented by a specified count.

The `EstimateCount` method returns the minimum count among all hashed positions, which provides an upper-bound estimate of the true frequency. This approach reduces the error probability caused by hash collisions.

The implementation uses a simple custom hash function generator based on the item's `GetHashCode()` combined with a seed and a linear congruential step to simulate multiple pairwise independent hash functions. The seeds are fixed with a known seed to allow consistent behavior.

## Complexity Analysis
- Add Operation:  Time complexity is O(depth), since the item is hashed `depth` times and counter increments are performed.
- EstimateCount Operation: Time complexity is also O(depth), as it queries each row to find the minimum count.
- Space Complexity: O(width * depth), the size of the 2D counter array.

This trade-off allows frequency estimation with much less memory than exact counting, at the cost of some probabilistic error.

---

This single-file implementation is self-contained and uses only standard .NET libraries, making it easy to integrate into larger projects without dependencies.