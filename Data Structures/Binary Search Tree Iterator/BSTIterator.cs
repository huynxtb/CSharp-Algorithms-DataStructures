using System.Collections.Generic;

// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class BSTIterator
{
    private Stack<TreeNode> stack;

    // Constructor: initialize the iterator with the root of the BST
    public BSTIterator(TreeNode root)
    {
        stack = new Stack<TreeNode>();
        PushLeftBranch(root);
    }

    // Returns true if there is a next smallest number
    public bool HasNext()
    {
        return stack.Count > 0;
    }

    // Returns the next smallest number
    public int Next()
    {
        if (!HasNext())
            throw new System.InvalidOperationException("No next element available.");

        TreeNode node = stack.Pop();
        int result = node.val;
        if (node.right != null)
        {
            PushLeftBranch(node.right);
        }
        return result;
    }

    // Helper method to push all left children of a subtree onto the stack
    private void PushLeftBranch(TreeNode node)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.left;
        }
    }
}
