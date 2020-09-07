/*
 * @lc app=leetcode.cn id=576 lang=csharp
 *
 * [576] 出界的路径数
 *
 * https://leetcode-cn.com/problems/out-of-boundary-paths/description/
 *
 * algorithms
 * Medium (36.73%)
 * Likes:    68
 * Dislikes: 0
 * Total Accepted:    4.6K
 * Total Submissions: 12.6K
 * Testcase Example:  '2\n2\n2\n0\n0'
 *
 * 给定一个 m × n 的网格和一个球。球的起始坐标为 (i,j)
 * ，你可以将球移到相邻的单元格内，或者往上、下、左、右四个方向上移动使球穿过网格边界。但是，你最多可以移动 N
 * 次。找出可以将球移出边界的路径数量。答案可能非常大，返回 结果 mod 10^9 + 7 的值。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入: m = 2, n = 2, N = 2, i = 0, j = 0
 * 输出: 6
 * 解释:
 * 
 * 
 * 
 * 示例 2：
 * 
 * 输入: m = 1, n = 3, N = 3, i = 0, j = 1
 * 输出: 12
 * 解释:
 * 
 * 
 * 
 * 
 * 
 * 说明:
 * 
 * 
 * 球一旦出界，就不能再被移动回网格内。
 * 网格的长度和高度在 [1,50] 的范围内。
 * N 在 [0,50] 的范围内。
 * 
 */

// @lc code=start
public class Solution {
    public  int MOD = 1000000007;
    int?[,,] dp;
    public int FindPaths(int m, int n, int N, int i, int j) {
        dp = new int?[m, n, N + 1];
        return Dfs(m, n, N, i, j); 
    }
    public int Dfs(int m, int n, int N, int i, int j) {
        if(N < 0) return 0;
        if(i < 0 || i >= m || j < 0 || j>= n) return 1;
        if(dp[i, j, N].HasValue) return dp[i, j, N].Value;
        dp[i, j, N] = (((Dfs(m , n, N - 1, i -1, j) + Dfs(m , n, N - 1, i +1, j)) % MOD + Dfs(m , n, N - 1, i, j - 1)) % MOD + Dfs(m , n, N - 1, i, j + 1)) % MOD;
        return dp[i, j, N].Value;
    }
}
// @lc code=end

