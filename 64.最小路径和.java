/*
 * @lc app=leetcode.cn id=64 lang=java
 *
 * [64] 最小路径和
 *
 * https://leetcode-cn.com/problems/minimum-path-sum/description/
 *
 * algorithms
 * Medium (64.12%)
 * Likes:    401
 * Dislikes: 0
 * Total Accepted:    65.3K
 * Total Submissions: 100.8K
 * Testcase Example:  '[[1,3,1],[1,5,1],[4,2,1]]'
 *
 * 给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
 * 
 * 说明：每次只能向下或者向右移动一步。
 * 
 * 示例:
 * 
 * 输入:
 * [
 * [1,3,1],
 * ⁠ [1,5,1],
 * ⁠ [4,2,1]
 * ]
 * 输出: 7
 * 解释: 因为路径 1→3→1→1→1 的总和最小。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int minPathSum(int[][] grid) {
        int row = grid.length;
        int col = grid[0].length;
        int[][] dp = new int[row][col];
        dp[0][0] = grid[0][0];
        for(int i=1;i<row;i++) dp[i][0] = dp[i-1][0] + grid[i][0];
        for(int j=1;j<col;j++) dp[0][j] = dp[0][j-1] + grid[0][j];
        for(int i=1;i<row;i++){
            for(int j=1;j<col;j++){
                dp[i][j] = grid[i][j] + Integer.min(dp[i-1][j], dp[i][j-1]);
            }
        }
        return dp[row-1][col-1]; 
    }
}
// @lc code=end

