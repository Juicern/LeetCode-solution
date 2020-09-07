using System;
/*
 * @lc app=leetcode.cn id=343 lang=csharp
 *
 * [343] 整数拆分
 *
 * https://leetcode-cn.com/problems/integer-break/description/
 *
 * algorithms
 * Medium (58.61%)
 * Likes:    350
 * Dislikes: 0
 * Total Accepted:    57.6K
 * Total Submissions: 98.3K
 * Testcase Example:  '2'
 *
 * 给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
 * 
 * 示例 1:
 * 
 * 输入: 2
 * 输出: 1
 * 解释: 2 = 1 + 1, 1 × 1 = 1。
 * 
 * 示例 2:
 * 
 * 输入: 10
 * 输出: 36
 * 解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
 * 
 * 说明: 你可以假设 n 不小于 2 且不大于 58。
 * 
 */

// @lc code=start
public class Solution {
    public int IntegerBreak(int n) {
        if(n == 2 || n ==3) return n - 1; 
        var dp = new int[n + 1];
        dp[1] = 1;
        for(int i = 2;i<=n;i++) {
            dp[i] = i;
            for(int j = 1;j<=i/2;j++) {
                dp[i] = Math.Max(dp[i], dp[j] * dp[i - j]);
            }
        }
        return dp[n];
    }
}
// @lc code=end

