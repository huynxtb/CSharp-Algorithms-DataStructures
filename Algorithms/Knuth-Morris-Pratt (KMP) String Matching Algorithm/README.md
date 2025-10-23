# Knuth-Morris-Pratt (KMP) String Matching Algorithm

## Introduction

The Knuth-Morris-Pratt (KMP) String Matching Algorithm is a classic pattern matching algorithm used to efficiently find all occurrences of a substring (pattern) within a main string (text). It operates in linear time complexity O(n), where "n" is the length of the text, making it much faster than naive substring searches especially for large inputs. KMP avoids redundant comparisons by precomputing a prefix table (also called the longest prefix suffix array), which allows it to skip sections of the text when mismatches occur.

Use the KMP algorithm when you need a reliable and efficient method for substring search, particularly suitable for applications involving large texts such as searching in DNA sequences, text editors, or network security string matching.

## Usage

Example usage of the KmpStringMatcher class:

var matcher = new KmpStringMatcher();
string text = "ababcabcabababd";
string pattern = "ababd";

List<int> matches = matcher.Search(text, pattern);

// matches will contain the starting indices of each occurrence of "ababd" in text
foreach (int index in matches)
{
    System.Console.WriteLine(index);
}

## Detailed Explanation

The implementation has two main parts:

1. **ComputePrefixTable**: This method constructs the prefix table for the pattern. The prefix table holds, for each position in the pattern, the length of the longest prefix that is also a suffix ending at that position. This allows the search to skip ahead when a mismatch occurs without re-examining characters that are already known to match.

2. **Search**: Given a text and a pattern, the search method uses the prefix table to scan the text once. Whenever characters match, it moves forward in the pattern. On mismatch, instead of restarting at the next text character, it uses the prefix table to shift the pattern appropriately and continue. Each time the entire pattern matches, the start index is recorded. The method handles edge cases such as empty input and cases where the pattern is longer than the text.

## Complexity Analysis

- **Time Complexity:**
  - Computing the prefix table takes O(m) time, where m is the length of the pattern.
  - The search operation takes O(n) time, where n is the length of the text.
  - Overall, the algorithm runs in O(n + m) time.

- **Space Complexity:**
  - The prefix table requires O(m) space.
  - The result list may require up to O(n) space in the worst case if there are many matches.

This combination of linear time complexity and efficient space usage makes KMP a preferred algorithm for secure and fast pattern searching within strings.