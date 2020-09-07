/*
 * @lc app=leetcode.cn id=221 lang=java
 *
 * [221] 最大正方形
 *
 * https://leetcode-cn.com/problems/maximal-square/description/
 *
 * algorithms
 * Medium (38.62%)
 * Likes:    271
 * Dislikes: 0
 * Total Accepted:    28.6K
 * Total Submissions: 72.7K
 * Testcase Example:  '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]'
 *
 * 在一个由 0 和 1 组成的二维矩阵内，找到只包含 1 的最大正方形，并返回其面积。
 * 
 * 示例:
 * 
 * 输入: 
 * 
 * 1 0 1 0 0
 * 1 0 1 1 1
 * 1 1 1 1 1
 * 1 0 0 1 0
 * 
 * 输出: 4
 * 
 */

// @lc code=start
class Solution {
    public int maximalSquare(char[][] matrix) {
        int row = matrix.length;
        int col = row==0 ? 0 : matrix[0].length;
        int[][] dp = new int[row+1][col+1];
        int maxlen = 0;
        for(int i=1;i<=row;i++){
            for(int j=1;j<=col;j++){
                if(matrix[i-1][j-1]=='1'){
                    dp[i][j] = Integer.min(Integer.min(dp[i-1][j], dp[i-1][j-1]), dp[i][j-1]) + 1;
                    maxlen = Integer.max(dp[i][j], maxlen);
                }
            }
        }
        return maxlen*maxlen;
    }
}
// @lc code=end

