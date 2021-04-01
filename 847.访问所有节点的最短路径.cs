/*
 * @lc app=leetcode.cn id=847 lang=csharp
 *
 * [847] 访问所有节点的最短路径
 *
 * https://leetcode-cn.com/problems/shortest-path-visiting-all-nodes/description/
 *
 * algorithms
 * Hard (55.16%)
 * Likes:    122
 * Dislikes: 0
 * Total Accepted:    3.9K
 * Total Submissions: 7.1K
 * Testcase Example:  '[[1,2,3],[0],[0],[0]]'
 *
 * 给出 graph 为有 N 个节点（编号为 0, 1, 2, ..., N-1）的无向连通图。 
 * 
 * graph.length = N，且只有节点 i 和 j 连通时，j != i 在列表 graph[i] 中恰好出现一次。
 * 
 * 返回能够访问所有节点的最短路径的长度。你可以在任一节点开始和停止，也可以多次重访节点，并且可以重用边。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[[1,2,3],[0],[0],[0]]
 * 输出：4
 * 解释：一个可能的路径为 [1,0,2,0,3]
 * 
 * 示例 2：
 * 
 * 输入：[[1],[0,2,4],[1,3,4],[2],[1,2]]
 * 输出：4
 * 解释：一个可能的路径为 [0,1,4,2,3]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= graph.length <= 12
 * 0 <= graph[i].length < graph.length
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length;
        if (graph == null || graph.Length == 0){
            return 0;
        }
        var visited = new bool[n, 1 << n];
        int finishState = (1 << n) - 1;
        var queue = new Queue<(int, int)>();
        for (int i = 0; i < n; ++i) {
            queue.Enqueue((i, 1 << i));
        }
        int ans = 0;
        while (queue.Any()) {
            for (int i = queue.Count; i > 0; --i) {
                var (node, state) = queue.Dequeue();
                if (finishState == state) {
                    return ans;
                }
                foreach (var next in graph[node]) {
                    var nextState = state | (1 << next);
                    if (visited[next, nextState]) {
                        continue;
                    }
                    visited[next, nextState] = true;
                    queue.Enqueue((next, nextState));
                }
            }
            ++ans;
        }
        return ans;
    }
}
// @lc code=end

