using System;
/*
 * @lc app=leetcode.cn id=1139 lang=csharp
 *
 * [1139] 最大的以 1 为边界的正方形
 *
 * https://leetcode-cn.com/problems/largest-1-bordered-square/description/
 *
 * algorithms
 * Medium (43.92%)
 * Likes:    19
 * Dislikes: 0
 * Total Accepted:    2.6K
 * Total Submissions: 6K
 * Testcase Example:  '[[1,1,1],[1,0,1],[1,1,1]]'
 *
 * 给你一个由若干 0 和 1 组成的二维网格 grid，请你找出边界全部由 1 组成的最大 正方形 子网格，并返回该子网格中的元素数量。如果不存在，则返回
 * 0。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：grid = [[1,1,1],[1,0,1],[1,1,1]]
 * 输出：9
 * 
 * 
 * 示例 2：
 * 
 * 输入：grid = [[1,1,0,0]]
 * 输出：1
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= grid.length <= 100
 * 1 <= grid[0].length <= 100
 * grid[i][j] 为 0 或 1
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int Largest1BorderedSquare(int[][] grid)
    {
        var dp = new int[grid.Length + 1, grid[0].Length + 1, 2];
        int res = 0;
        for (int i = 1; i <= grid.Length; i++)
        {
            for (int j = 1; j <= grid[0].Length; j++)
            {
                if (grid[i-1][j-1] == 1)
                {
                    dp[i,j,0] = dp[i,j - 1,0] + 1;
                    dp[i,j,1] = dp[i - 1,j,1] + 1;
                    int dis = Math.Min(dp[i,j,0], dp[i,j,1]);
                    while(dp[i,j - dis +1,1] < dis || dp[i - dis +1,j,0] < dis) dis--;
                    res = Math.Max(res, dis);
                }
            }
        }
        return res * res;
    }
}
// @lc code=end

