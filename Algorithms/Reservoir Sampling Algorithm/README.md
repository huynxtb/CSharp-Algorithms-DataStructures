# Reservoir Sampling Algorithm

## 1. Introduction

The Reservoir Sampling algorithm is a probabilistic algorithm used to randomly select `k` samples from a data stream of unknown or very large size, ensuring each element in the stream has an equal probability of being chosen. This is particularly useful when the total size of the data stream is unknown or too large to fit in memory. It allows on-the-fly sampling with fixed memory usage.

## 2. Usage

// Create an instance to sample 5 elements from a stream
var sampler = new ReservoirSampler<int>(5);

// Imagine streaming input elements one-by-one
foreach (var element in someLargeDataStream)
{
    sampler.ProcessNext(element);
}

// Retrieve the current sampled elements
var samples = sampler.GetSamples();

// samples contains up to 5 elements, each with equal probability from the entire data stream

## 3. Detailed Explanation

- The class `ReservoirSampler<T>` maintains a fixed-size reservoir (`List<T>` of size `k`).
- As elements stream in, each new element is processed with the `ProcessNext` method.
- For the first `k` elements, it simply adds them to the reservoir.
- For subsequent elements (when count exceeds `k`), the algorithm generates a random integer between `0` and the current element count minus one.
- If this random integer falls within the reservoir's indices (0 to `k-1`), the element at that index is replaced with the new incoming element.
- This ensures every element in the stream has an equal probability (`k` divided by the total number of elements processed so far) of being included in the reservoir.
- The `GetSamples` method provides a readonly snapshot of the current reservoir.

## 4. Complexity Analysis

- **Time Complexity:**
  - Each element in the stream is processed in O(1) time (constant time operations) since random index calculation and potential replacement are O(1).

- **Space Complexity:**
  - The algorithm maintains only `k` elements at any time in memory, so the space complexity is O(k).

This implementation is efficient for large or infinite data streams requiring uniform random sampling with limited memory footprint.