using System.Collections.Generic;

public class BSTNode
{
    public int Value { get; set; }
    public BSTNode Left { get; set; }
    public BSTNode Right { get; set; }

    public BSTNode(int value)
    {
        this.Value = value;
        this.Left = null;
        this.Right = null;
    }
}

public class BinarySearchTree
{
    private BSTNode root;

    public BinarySearchTree()
    {
        root = null;
    }

    // Insert a new value into the BST
    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    private BSTNode InsertRec(BSTNode node, int value)
    {
        if (node == null)
        {
            return new BSTNode(value);
        }

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRec(node.Right, value);
        // If value equals node.Value, do not insert duplicates.

        return node;
    }

    // Search for a value in the BST
    public bool Search(int value)
    {
        return SearchRec(root, value);
    }

    private bool SearchRec(BSTNode node, int value)
    {
        if (node == null)
            return false;
        if (value == node.Value)
            return true;
        else if (value < node.Value)
            return SearchRec(node.Left, value);
        else
            return SearchRec(node.Right, value);
    }

    // Delete a value from the BST
    public void Delete(int value)
    {
        root = DeleteRec(root, value);
    }

    private BSTNode DeleteRec(BSTNode node, int value)
    {
        if (node == null)
            return null;

        if (value < node.Value)
            node.Left = DeleteRec(node.Left, value);
        else if (value > node.Value)
            node.Right = DeleteRec(node.Right, value);
        else
        {
            // Node with only one child or no child
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            node.Value = MinValue(node.Right);

            // Delete the inorder successor
            node.Right = DeleteRec(node.Right, node.Value);
        }

        return node;
    }

    private int MinValue(BSTNode node)
    {
        int minv = node.Value;
        while (node.Left != null)
        {
            minv = node.Left.Value;
            node = node.Left;
        }
        return minv;
    }

    // InOrder Traversal: returns elements in sorted order
    public IEnumerable<int> InOrderTraversal()
    {
        var list = new List<int>();
        InOrderRec(root, list);
        return list;
    }

    private void InOrderRec(BSTNode node, List<int> list)
    {
        if (node != null)
        {
            InOrderRec(node.Left, list);
            list.Add(node.Value);
            InOrderRec(node.Right, list);
        }
    }
}