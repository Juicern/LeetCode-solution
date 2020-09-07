/*
 * @lc app=leetcode.cn id=357 lang=csharp
 *
 * [357] 计算各个位数不同的数字个数
 *
 * https://leetcode-cn.com/problems/count-numbers-with-unique-digits/description/
 *
 * algorithms
 * Medium (50.81%)
 * Likes:    62
 * Dislikes: 0
 * Total Accepted:    9.8K
 * Total Submissions: 19.3K
 * Testcase Example:  '2'
 *
 * 给定一个非负整数 n，计算各位数字都不同的数字 x 的个数，其中 0 ≤ x < 10^n 。
 * 
 * 示例:
 * 
 * 输入: 2
 * 输出: 91 
 * 解释: 答案应为除去 11,22,33,44,55,66,77,88,99 外，在 [0,100) 区间内的所有数字。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int CountNumbersWithUniqueDigits(int n)
    {
        if (n == 0) return 1;
        if (n == 1) return 10;
        var dp = new int[n + 1];
        dp[1] = 10;
        dp[2] = 81;
        int sum = dp[1] + dp[2];
        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 1] * (11 - i);
            sum += dp[i];
        }
        return sum;
    }
}
// @lc code=end

