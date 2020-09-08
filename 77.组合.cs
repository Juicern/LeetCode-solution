/*
 * @lc app=leetcode.cn id=77 lang=csharp
 *
 * [77] 组合
 *
 * https://leetcode-cn.com/problems/combinations/description/
 *
 * algorithms
 * Medium (74.58%)
 * Likes:    363
 * Dislikes: 0
 * Total Accepted:    88.6K
 * Total Submissions: 117.3K
 * Testcase Example:  '4\n2'
 *
 * 给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
 * 
 * 示例:
 * 
 * 输入: n = 4, k = 2
 * 输出:
 * [
 * ⁠ [2,4],
 * ⁠ [3,4],
 * ⁠ [2,3],
 * ⁠ [1,2],
 * ⁠ [1,3],
 * ⁠ [1,4],
 * ]
 * 
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var ans = new List<IList<int>>();
        Dfs(n, k, 1, new List<int>(), ans);
        return ans;
    }
    private void Dfs(int n, int k, int cur, List<int> pre, List<IList<int>> ans) {
        if(k == 0) {
            ans.Add(new List<int>(pre));
            return;
        }
        for(int i = cur; i<= n;i++) {
            if(n - i + 1< k) break;
            pre.Add(i);
            Dfs(n, k -1, i + 1, pre, ans);
            pre.Remove(i);
        }
    }
}
// @lc code=end

