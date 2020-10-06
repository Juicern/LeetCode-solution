using System.Collections.Generic;
using System;
/*
 * @lc app=leetcode.cn id=834 lang=csharp
 *
 * [834] 树中距离之和
 *
 * https://leetcode-cn.com/problems/sum-of-distances-in-tree/description/
 *
 * algorithms
 * Hard (34.31%)
 * Likes:    182
 * Dislikes: 0
 * Total Accepted:    7.3K
 * Total Submissions: 14.6K
 * Testcase Example:  '6\n[[0,1],[0,2],[2,3],[2,4],[2,5]]'
 *
 * 给定一个无向、连通的树。树中有 N 个标记为 0...N-1 的节点以及 N-1 条边 。
 * 
 * 第 i 条边连接节点 edges[i][0] 和 edges[i][1] 。
 * 
 * 返回一个表示节点 i 与其他所有节点距离之和的列表 ans。
 * 
 * 示例 1:
 * 
 * 
 * 输入: N = 6, edges = [[0,1],[0,2],[2,3],[2,4],[2,5]]
 * 输出: [8,12,6,10,10,10]
 * 解释: 
 * 如下为给定的树的示意图：
 * ⁠ 0
 * ⁠/ \
 * 1   2
 * ⁠  /|\
 * ⁠ 3 4 5
 * 
 * 我们可以计算出 dist(0,1) + dist(0,2) + dist(0,3) + dist(0,4) + dist(0,5) 
 * 也就是 1 + 1 + 2 + 2 + 2 = 8。 因此，answer[0] = 8，以此类推。
 * 
 * 
 * 说明: 1 <= N <= 10000
 * 
 */

// @lc code=start
public class Solution
{
    private List<List<int>> graph = new List<List<int>>();
    int[] distSum;
    int[] nodeNum;
    public int[] SumOfDistancesInTree(int N, int[][] edges)
    {
        for (int i = 0; i < N; i++)
        {
            graph.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            int src = edge[0];
            int dst = edge[1];
            graph[src].Add(dst);
            graph[dst].Add(src);
        }
        distSum = new int[N];
        nodeNum = new int[N];
        Array.Fill(nodeNum, 1);
        PostOrder(0, -1);
        PreOrder(0, -1);
        return distSum;
    }
    private void PostOrder(int root, int parent)
    {
        List<int> neighbors = graph[root];
        foreach (var neighbor in neighbors)
        {
            if (neighbor == parent) continue;
            PostOrder(neighbor, root);
            nodeNum[root] += nodeNum[neighbor];
            distSum[root] += distSum[neighbor] + nodeNum[neighbor];
        }
    }
    private void PreOrder(int root, int parent)
    {
        List<int> neighbors = graph[root];
        foreach (var neighbor in neighbors)
        {
            if (neighbor == parent) continue;
            distSum[neighbor] = distSum[root] - nodeNum[neighbor] + graph.Count - nodeNum[neighbor];
            PreOrder(neighbor, root);
        }
    }

}
// @lc code=end

