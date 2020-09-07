using System;
using System.Security.Cryptography;
/*
 * @lc app=leetcode.cn id=924 lang=csharp
 *
 * [924] 尽量减少恶意软件的传播
 *
 * https://leetcode-cn.com/problems/minimize-malware-spread/description/
 *
 * algorithms
 * Hard (38.68%)
 * Likes:    30
 * Dislikes: 0
 * Total Accepted:    2.2K
 * Total Submissions: 6K
 * Testcase Example:  '[[1,1,0],[1,1,0],[0,0,1]]\n[0,1]'
 *
 * 在节点网络中，只有当 graph[i][j] = 1 时，每个节点 i 能够直接连接到另一个节点 j。
 * 
 * 一些节点 initial
 * 最初被恶意软件感染。只要两个节点直接连接，且其中至少一个节点受到恶意软件的感染，那么两个节点都将被恶意软件感染。这种恶意软件的传播将继续，直到没有更多的节点可以被这种方式感染。
 * 
 * 假设 M(initial) 是在恶意软件停止传播之后，整个网络中感染恶意软件的最终节点数。
 * 
 * 我们可以从初始列表中删除一个节点。如果移除这一节点将最小化 M(initial)， 则返回该节点。如果有多个节点满足条件，就返回索引最小的节点。
 * 
 * 请注意，如果某个节点已从受感染节点的列表 initial 中删除，它以后可能仍然因恶意软件传播而受到感染。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：graph = [[1,1,0],[1,1,0],[0,0,1]], initial = [0,1]
 * 输出：0
 * 
 * 
 * 示例 2：
 * 
 * 输入：graph = [[1,0,0],[0,1,0],[0,0,1]], initial = [0,2]
 * 输出：0
 * 
 * 
 * 示例 3：
 * 
 * 输入：graph = [[1,1,1],[1,1,1],[1,1,1]], initial = [1,2]
 * 输出：1
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 < graph.length = graph[0].length <= 300
 * 0 <= graph[i][j] == graph[j][i] <= 1
 * graph[i][i] == 1
 * 1 <= initial.length < graph.length
 * 0 <= initial[i] < graph.length
 * 
 * 
 */

// @lc code=start
public class Solution
{
    class DisJointSet
    {
        private int[] parents;
        private int[] sizes;
        public DisJointSet(int n)
        {
            parents = new int[n];
            sizes = new int[n];
            for (int i = 0; i < n; i++)
            {
                parents[i] = i;
                sizes[i] = 1;
            }
        }
        public int Find(int index)
        {
            if (parents[index] != index)
            {
                parents[index] = Find(parents[index]);
            }
            return parents[index];
        }

        public void Union(int i, int j)
        {
            int pi = Find(i);
            int pj = Find(j);
            if (pi != pj)
            {
                parents[pi] = pj;
                sizes[pj] += sizes[pi];
            }
        }
        public int Size(int index)
        {
            return sizes[Find(index)];
        }
    }
    public int MinMalwareSpread(int[][] graph, int[] initial)
    {
        var ds = new DisJointSet(graph.Length);
        for (int i = 0; i < graph.Length; i++)
        {
            for (int j = i + 1; j < graph.Length; j++)
            {
                if (graph[i][j] == 1) ds.Union(i, j);
            }
        }
        var Count = new int[graph.Length];
        foreach(var node in initial)
        {
            Count[ds.Find(node)]++;
        }
        int ans = -1, ansSize = -1;
        foreach (var node in initial)
        {
            int root = ds.Find(node);
            if(Count[root]==1)
            {
                int curSize = ds.Size(root);
                if (curSize > ansSize || (curSize == ansSize && node < ans))
                {
                    ans = node;
                    ansSize = curSize;
                }
            }
        }
        if(ans==-1)
        {
            ans = Int16.MaxValue;
            foreach(var node in initial)
            {
                ans = Math.Min(ans, node);
            }
        }
        return ans;
    }
}
// @lc code=end

