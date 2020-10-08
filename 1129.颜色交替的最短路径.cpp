/*
 * @lc app=leetcode.cn id=1129 lang=cpp
 *
 * [1129] 颜色交替的最短路径
 *
 * https://leetcode-cn.com/problems/shortest-path-with-alternating-colors/description/
 *
 * algorithms
 * Medium (35.34%)
 * Likes:    51
 * Dislikes: 0
 * Total Accepted:    4.3K
 * Total Submissions: 12K
 * Testcase Example:  '3\n[[0,1],[1,2]]\n[]'
 *
 * 在一个有向图中，节点分别标记为 0, 1, ..., n-1。这个图中的每条边不是红色就是蓝色，且存在自环或平行边。
 * 
 * red_edges 中的每一个 [i, j] 对表示从节点 i 到节点 j 的红色有向边。类似地，blue_edges 中的每一个 [i, j]
 * 对表示从节点 i 到节点 j 的蓝色有向边。
 * 
 * 返回长度为 n 的数组 answer，其中 answer[X] 是从节点 0 到节点 X
 * 的红色边和蓝色边交替出现的最短路径的长度。如果不存在这样的路径，那么 answer[x] = -1。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：n = 3, red_edges = [[0,1],[1,2]], blue_edges = []
 * 输出：[0,1,-1]
 * 
 * 
 * 示例 2：
 * 
 * 输入：n = 3, red_edges = [[0,1]], blue_edges = [[2,1]]
 * 输出：[0,1,-1]
 * 
 * 
 * 示例 3：
 * 
 * 输入：n = 3, red_edges = [[1,0]], blue_edges = [[2,1]]
 * 输出：[0,-1,-1]
 * 
 * 
 * 示例 4：
 * 
 * 输入：n = 3, red_edges = [[0,1]], blue_edges = [[1,2]]
 * 输出：[0,1,2]
 * 
 * 
 * 示例 5：
 * 
 * 输入：n = 3, red_edges = [[0,1],[0,2]], blue_edges = [[1,0]]
 * 输出：[0,1,1]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= n <= 100
 * red_edges.length <= 400
 * blue_edges.length <= 400
 * red_edges[i].length == blue_edges[i].length == 2
 * 0 <= red_edges[i][j], blue_edges[i][j] < n
 * 
 * 
 */

// @lc code=start
class Solution
{
public:
    const int INF = 1e8;
    void dfs(vector<vector<vector<int>>> &g, int col, int i, vector<vector<int>> &res)
    {
        for (auto j : g[col][i])
        {
            if (res[i][col] + 1 < res[j][!col])
            {
                res[j][!col] = res[i][col] + 1;
                dfs(g, !col, j, res);
            }
        }
    }
    vector<int> shortestAlternatingPaths(int n, vector<vector<int>> &red_edges, vector<vector<int>> &blue_edges)
    {
        vector<vector<int>> rg(n);
        vector<vector<int>> bg(n);
        for (auto &e : red_edges)
            rg[e[0]].push_back(e[1]);
        for (auto &e : blue_edges)
            bg[e[0]].push_back(e[1]);
        vector<vector<vector<int>>> g{rg, bg};
        vector<vector<int>> res(n, {INF, INF});
        res[0] = {0, 0};
        dfs(g, 0, 0, res);
        dfs(g, 1, 0, res);
        vector<int> out(n);
        for (int i = 0; i < n; ++i)
        {
            out[i] = min(res[i][0], res[i][1]);
            if (out[i] == INF)
                out[i] = -1;
        }
        return out;
    }
};

// @lc code=end
