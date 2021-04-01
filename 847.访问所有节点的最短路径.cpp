/*
 * @lc app=leetcode.cn id=847 lang=cpp
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
#include <vector>
#include <queue>
using namespace std;
class Solution {
public:
    int shortestPathLength(vector<vector<int>>& graph) {
        if (graph.size() == 0) {
            return 0;
        }
        int n = graph.size();
        int finishState = (1 << n) - 1;
        vector<vector<bool>> visited(n, vector<bool>(1 << n));
        queue<pair<int, int>> q;
        for (int i = 0; i < n; ++i) {
            q.push({i, 1 << i});
        }
        int ans = 0;
        while (q.size() != 0) {
            int size = q.size();
            for (int _ = 0; _  < size; ++_) {
                auto [node, state] = q.front();
                q.pop();
                if (finishState == state) {
                    return ans;
                }
                for (const auto& next : graph[node]) {
                    int nextState = state | (1 << next);
                    if (visited[next][nextState]) {
                        continue;
                    }
                    visited[next][nextState] = true;
                    q.push({next, nextState});
                }
            }
            ++ans;
        }
        return ans;
    }
};
// @lc code=end

