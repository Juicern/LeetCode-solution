/*
 * @lc app=leetcode.cn id=59 lang=java
 *
 * [59] 螺旋矩阵 II
 *
 * https://leetcode-cn.com/problems/spiral-matrix-ii/description/
 *
 * algorithms
 * Medium (76.26%)
 * Likes:    154
 * Dislikes: 0
 * Total Accepted:    27.8K
 * Total Submissions: 36.2K
 * Testcase Example:  '3'
 *
 * 给定一个正整数 n，生成一个包含 1 到 n^2 所有元素，且元素按顺时针顺序螺旋排列的正方形矩阵。
 * 
 * 示例:
 * 
 * 输入: 3
 * 输出:
 * [
 * ⁠[ 1, 2, 3 ],
 * ⁠[ 8, 9, 4 ],
 * ⁠[ 7, 6, 5 ]
 * ]
 * 
 */

// @lc code=start
class Solution {
    public int[][] generateMatrix(int n) {
        int[][] ans = new int[n][n];
        int count = 1;
        for(int i=0;i<n/2;i++){
            //right
            for(int j=i;j<n-1-i;j++) ans[i][j] = count++;
            //down
            for(int j=i;j<n-1-i;j++) ans[j][n-1-i] = count++;
            //left
            for(int j=i;j<n-1-i;j++) ans[n-1-i][n-1-j] = count++;
            //up
            for(int j=i;j<n-1-i;j++) ans[n-1-j][i] = count++;
        }
        if(n%2==1) ans[n/2][n/2] = count;
        return ans;
    }
}
// @lc code=end

