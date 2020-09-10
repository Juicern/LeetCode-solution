/*
 * @lc app=leetcode.cn id=867 lang=csharp
 *
 * [867] 转置矩阵
 *
 * https://leetcode-cn.com/problems/transpose-matrix/description/
 *
 * algorithms
 * Easy (68.10%)
 * Likes:    103
 * Dislikes: 0
 * Total Accepted:    24.4K
 * Total Submissions: 36K
 * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
 *
 * 给定一个矩阵 A， 返回 A 的转置矩阵。
 * 
 * 矩阵的转置是指将矩阵的主对角线翻转，交换矩阵的行索引与列索引。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[[1,2,3],[4,5,6],[7,8,9]]
 * 输出：[[1,4,7],[2,5,8],[3,6,9]]
 * 
 * 
 * 示例 2：
 * 
 * 输入：[[1,2,3],[4,5,6]]
 * 输出：[[1,4],[2,5],[3,6]]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 1000
 * 1 <= A[0].length <= 1000
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[][] Transpose(int[][] A) {
        
        // col in A becomes row in transpose
        int[][] transpose = new int[A[0].Length][];
        
        for(int i = 0; i<A[0].Length; i++)
        {
            // row in A becomes col in transpose
            transpose[i] = new int[A.Length];
            for(int j = 0; j<A.Length; j++)
            {
                transpose[i][j] = A[j][i];
            }
        }
        
        return transpose;
    }
}
// @lc code=end

