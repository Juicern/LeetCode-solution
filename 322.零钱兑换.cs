using System;
/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 *
 * https://leetcode-cn.com/problems/coin-change/description/
 *
 * algorithms
 * Medium (40.65%)
 * Likes:    726
 * Dislikes: 0
 * Total Accepted:    113.5K
 * Total Submissions: 279.1K
 * Testcase Example:  '[1,2,5]\n11'
 *
 * 给定不同面额的硬币 coins 和一个总金额
 * amount。编写一个函数来计算可以凑成总金额所需的最少的硬币个数。如果没有任何一种硬币组合能组成总金额，返回 -1。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: coins = [1, 2, 5], amount = 11
 * 输出: 3 
 * 解释: 11 = 5 + 5 + 1
 * 
 * 示例 2:
 * 
 * 输入: coins = [2], amount = 3
 * 输出: -1
 * 
 * 
 * 
 * 说明:
 * 你可以认为每种硬币的数量是无限的。
 * 
 */

// @lc code=start
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int max = amount + 1;
        var dp = new int[amount + 1];
        Array.Fill(dp, max);
        dp[0] = 0;
        for(int i = 1;i<= amount;i++) {
            foreach(var coin in coins) {
                if(i >= coin) {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        } 
        return dp[amount] > amount ? -1 : dp[amount];
    }
}
// @lc code=end

