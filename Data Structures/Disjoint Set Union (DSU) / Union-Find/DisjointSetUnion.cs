public class DisjointSetUnion
{
    private int[] parent;
    private int[] size;

    // Initializes the DSU with each element being its own parent (self-rooted)
    // and size of each set being 1.
    public DisjointSetUnion(int size)
    {
        parent = new int[size];
        this.size = new int[size];
        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
            this.size[i] = 1;
        }
    }

    // Find the root parent of an element with path compression.
    public int Find(int element)
    {
        if (parent[element] != element)
        {
            parent[element] = Find(parent[element]);
        }
        return parent[element];
    }

    // Union two sets by size to keep tree height minimal.
    public void Union(int element1, int element2)
    {
        int root1 = Find(element1);
        int root2 = Find(element2);

        if (root1 != root2)
        {
            // Attach smaller tree under larger tree root
            if (size[root1] < size[root2])
            {
                parent[root1] = root2;
                size[root2] += size[root1];
            }
            else
            {
                parent[root2] = root1;
                size[root1] += size[root2];
            }
        }
    }

    // Check if two elements belong to the same set
    public bool Connected(int element1, int element2)
    {
        return Find(element1) == Find(element2);
    }
}