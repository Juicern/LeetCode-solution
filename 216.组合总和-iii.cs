/*
 * @lc app=leetcode.cn id=216 lang=csharp
 *
 * [216] 组合总和 III
 *
 * https://leetcode-cn.com/problems/combination-sum-iii/description/
 *
 * algorithms
 * Medium (71.66%)
 * Likes:    178
 * Dislikes: 0
 * Total Accepted:    41.1K
 * Total Submissions: 56K
 * Testcase Example:  '3\n7'
 *
 * 找出所有相加之和为 n 的 k 个数的组合。组合中只允许含有 1 - 9 的正整数，并且每种组合中不存在重复的数字。
 * 
 * 说明：
 * 
 * 
 * 所有数字都是正整数。
 * 解集不能包含重复的组合。 
 * 
 * 
 * 示例 1:
 * 
 * 输入: k = 3, n = 7
 * 输出: [[1,2,4]]
 * 
 * 
 * 示例 2:
 * 
 * 输入: k = 3, n = 9
 * 输出: [[1,2,6], [1,3,5], [2,3,4]]
 * 
 * 
 */

// @lc code=start
public class Solution {
    bool[] visited;
    List<IList<int>> ans = new List<IList<int>>();
    public IList<IList<int>> CombinationSum3(int k, int n) {
        visited = new bool[10];
        Dfs(k, n, 1, new List<int>(), 0);
        return ans;
    }
    private void Dfs(int k, int n, int start, List<int> pre, int sum) {
        if(k == 0) {
            if(sum == n) {
                ans.Add(new List<int>(pre));
            }
            return;
        }
        if(sum >= n) return;
        for(int i = start;i<=9;i++) {
            if(visited[i]) continue;
            visited[i] = true;
            pre.Add(i);
            Dfs(k - 1, n, i + 1, pre, sum + i);
            visited[i] = false;
            pre.Remove(i);
        }
    }
}
// @lc code=end

