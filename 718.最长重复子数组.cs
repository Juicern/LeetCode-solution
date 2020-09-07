using System;
/*
 * @lc app=leetcode.cn id=718 lang=csharp
 *
 * [718] 最长重复子数组
 *
 * https://leetcode-cn.com/problems/maximum-length-of-repeated-subarray/description/
 *
 * algorithms
 * Medium (49.78%)
 * Likes:    155
 * Dislikes: 0
 * Total Accepted:    11.5K
 * Total Submissions: 23.1K
 * Testcase Example:  '[1,2,3,2,1]\n[3,2,1,4,7]'
 *
 * 给两个整数数组 A 和 B ，返回两个数组中公共的、长度最长的子数组的长度。
 * 
 * 示例 1:
 * 
 * 
 * 输入:
 * A: [1,2,3,2,1]
 * B: [3,2,1,4,7]
 * 输出: 3
 * 解释: 
 * 长度最长的公共子数组是 [3, 2, 1]。
 * 
 * 
 * 说明:
 * 
 * 
 * 1 <= len(A), len(B) <= 1000
 * 0 <= A[i], B[i] < 100
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int FindLength(int[] A, int[] B)
    {
        int ans = 0;
        int[,] dp = new int[A.Length+1, B.Length+1];
        for (int i = 1; i <= A.Length; i++)
        {
            for (int j = 1; j <= B.Length; j++)
            {
                if (A[i-1] == B[j-1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                    ans = Math.Max(ans, dp[i, j]);
                }
            }
        }
        return ans;
    }
}
// @lc code=end

