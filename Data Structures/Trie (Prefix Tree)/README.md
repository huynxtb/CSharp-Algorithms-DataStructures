# Trie (Prefix Tree)

## 1. Introduction

A Trie, also known as a prefix tree, is a tree data structure commonly used to store a dynamic set or associative array where the keys are usually strings. The primary advantage of a Trie is that it efficiently supports prefix-based queries such as searching for words or prefixes, making it ideal for applications like autocomplete, spell checking, and prefix searching. Instead of comparing strings entirely, a Trie branches each character, significantly reducing search times with shared prefixes.

## 2. Usage

Here's how you can use the Trie class in C#:

Trie trie = new Trie();
trie.Insert("apple");
bool foundWord = trie.Search("apple");      // returns true
bool foundPrefix = trie.StartsWith("app"); // returns true
bool notFound = trie.Search("app");        // returns false

This example demonstrates inserting a word, searching for the exact word, and checking if any word starts with a given prefix.

## 3. Detailed Explanation

The implementation consists of two main components:

- **TrieNode (internal class):** Each node represents a single character and maintains a fixed-size array of child nodes (size 26 for lowercase English letters a-z). It also stores a boolean flag to mark the end of a valid word.

- **Trie (main class):** Uses a root node to represent the start of the Trie. It provides three methods:

  - **Insert:** Adds a word character by character. For each character, it calculates the index (offset from 'a'). If the corresponding child node doesn't exist, it creates a new TrieNode. After processing all characters, the final node is marked as the end of a word.

  - **Search:** Traverses nodes based on each character in the word. If any character path doesn't exist, returns false. If all characters are found, checks if the last node marks a word's end.

  - **StartsWith:** Similar to Search but only checks for the existence of the prefix path without requiring an end-of-word flag.

This design achieves fast prefix queries by exploiting the common prefixes shared by different words. Using a fixed 26-element array for children allows O(1) access per character.

## 4. Complexity Analysis

- **Insertion:** 
  - Time Complexity: O(m), where m is the length of the word being inserted. Each character insertion is a constant-time operation.
  - Space Complexity: O(m) in the worst case when the word introduces new nodes.

- **Search:** 
  - Time Complexity: O(m), where m is the length of the search word. Traversal requires examining each character.
  - Space Complexity: O(1), no additional space beyond node references.

- **StartsWith:**
  - Time Complexity: O(p), where p is the length of the prefix.
  - Space Complexity: O(1), similar to Search.

This efficient implementation makes the Trie well-suited for tasks involving large dictionaries and prefix-based lookups.