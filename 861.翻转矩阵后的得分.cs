/*
 * @lc app=leetcode.cn id=861 lang=csharp
 *
 * [861] 翻转矩阵后的得分
 *
 * https://leetcode-cn.com/problems/score-after-flipping-matrix/description/
 *
 * algorithms
 * Medium (74.09%)
 * Likes:    66
 * Dislikes: 0
 * Total Accepted:    4.7K
 * Total Submissions: 6.4K
 * Testcase Example:  '[[0,0,1,1],[1,0,1,0],[1,1,0,0]]'
 *
 * 有一个二维矩阵 A 其中每个元素的值为 0 或 1 。
 * 
 * 移动是指选择任一行或列，并转换该行或列中的每一个值：将所有 0 都更改为 1，将所有 1 都更改为 0。
 * 
 * 在做出任意次数的移动后，将该矩阵的每一行都按照二进制数来解释，矩阵的得分就是这些数字的总和。
 * 
 * 返回尽可能高的分数。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：[[0,0,1,1],[1,0,1,0],[1,1,0,0]]
 * 输出：39
 * 解释：
 * 转换为 [[1,1,1,1],[1,0,0,1],[1,1,1,1]]
 * 0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 20
 * 1 <= A[0].length <= 20
 * A[i][j] 是 0 或 1
 * 
 * 
 */

// @lc code=start
class Solution{
    public int MatrixScore(int[][] A) {
        int res = A.Length;
        for(int i = 1; i < A[0].Length; i++) {
            int tmp = 0;
            for(int j = 0; j < A.Length; j++) {
                if(A[j][0] == 1) tmp += A[j][i];
                else tmp += 1 - A[j][i];
            }
            res = 2 * res + Math.Max(tmp, A.Length - tmp);
        }
        return res;
    }
}

// @lc code=end

