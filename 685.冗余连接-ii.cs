/*
 * @lc app=leetcode.cn id=685 lang=csharp
 *
 * [685] 冗余连接 II
 *
 * https://leetcode-cn.com/problems/redundant-connection-ii/description/
 *
 * algorithms
 * Hard (35.34%)
 * Likes:    76
 * Dislikes: 0
 * Total Accepted:    3.7K
 * Total Submissions: 10.5K
 * Testcase Example:  '[[1,2],[1,3],[2,3]]'
 *
 * 在本问题中，有根树指满足以下条件的有向图。该树只有一个根节点，所有其他节点都是该根节点的后继。每一个节点只有一个父节点，除了根节点没有父节点。
 * 
 * 输入一个有向图，该图由一个有着N个节点 (节点值不重复1, 2, ..., N)
 * 的树及一条附加的边构成。附加的边的两个顶点包含在1到N中间，这条附加的边不属于树中已存在的边。
 * 
 * 结果图是一个以边组成的二维数组。 每一个边 的元素是一对 [u, v]，用以表示有向图中连接顶点 u 和顶点 v 的边，其中 u 是 v
 * 的一个父节点。
 * 
 * 返回一条能删除的边，使得剩下的图是有N个节点的有根树。若有多个答案，返回最后出现在给定二维数组的答案。
 * 
 * 示例 1:
 * 
 * 输入: [[1,2], [1,3], [2,3]]
 * 输出: [2,3]
 * 解释: 给定的有向图如下:
 * ⁠ 1
 * ⁠/ \
 * v   v
 * 2-->3
 * 
 * 
 * 示例 2:
 * 
 * 输入: [[1,2], [2,3], [3,4], [4,1], [1,5]]
 * 输出: [4,1]
 * 解释: 给定的有向图如下:
 * 5 <- 1 -> 2
 * ⁠    ^    |
 * ⁠    |    v
 * ⁠    4 <- 3
 * 
 * 
 * 注意:
 * 
 * 
 * 二维数组大小的在3到1000范围内。
 * 二维数组中的每个整数在1到N之间，其中 N 是二维数组的大小。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int[] FindRedundantDirectedConnection(int[][] edges)
    {
        int numNodes = edges.Length;
        int edgeRemoved = -1;
        int edgeMakesCycle = -1;

        var parent = new int[numNodes + 1];

        for (int i = 0; i < numNodes; i++)
        {
            int parentId = edges[i][0];
            int childId = edges[i][1];

            if (parent[childId] != 0)
            {
                /* Assume we removed the second edge. */
                edgeRemoved = i;
                break;
            }
            else
                parent[childId] = parentId;
        }

        var unionFind = new UnionFind(numNodes);
        for (int i = 0; i < numNodes; i++)
        {
            if (i == edgeRemoved)
            {
                continue;
            }

            int u = edges[i][0];
            int v = edges[i][1];

            if (!unionFind.Union(u, v))
            {
                edgeMakesCycle = i;
                break;
            }
        }

        /* Handle with the cyclic problem only. */
        if (edgeRemoved == -1)
        {
            return edges[edgeMakesCycle];
        }

        /* Handle with the cyclic problem when we remove the wrong edge. */
        if (edgeMakesCycle != -1)
        {
            int v = edges[edgeRemoved][1];
            int u = parent[v];
            return new int[] { u, v };
        }

        /* CHandle with the cyclic problem when we remove the right edge. */
        return edges[edgeRemoved];
    }

    /// <summary>
    /// code review March 29, 2019
    /// </summary>
    internal class UnionFind
    {
        private int[] parent;
        private int[] rank;

        public UnionFind(int n)
        {
            parent = new int[n + 1];
            rank = new int[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        private int find(int x)
        {
            if (parent[x] == x)
                return x;
            return parent[x] = find(parent[x]);
        }

        public bool Union(int x, int y)
        {
            int rootX = find(x);
            int rootY = find(y);

            if (rootX == rootY)
                return false;
            if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
                rank[rootY] += rank[rootX];
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX] += rank[rootY];
            }

            return true;
        }
    }
}
// @lc code=end

