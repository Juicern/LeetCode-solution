/*
 * @lc app=leetcode.cn id=309 lang=java
 *
 * [309] 最佳买卖股票时机含冷冻期
 *
 * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
 *
 * algorithms
 * Medium (50.76%)
 * Likes:    286
 * Dislikes: 0
 * Total Accepted:    22K
 * Total Submissions: 41.6K
 * Testcase Example:  '[1,2,3,0,2]'
 *
 * 给定一个整数数组，其中第 i 个元素代表了第 i 天的股票价格 。​
 * 
 * 设计一个算法计算出最大利润。在满足以下约束条件下，你可以尽可能地完成更多的交易（多次买卖一支股票）:
 * 
 * 
 * 你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
 * 卖出股票后，你无法在第二天买入股票 (即冷冻期为 1 天)。
 * 
 * 
 * 示例:
 * 
 * 输入: [1,2,3,0,2]
 * 输出: 3 
 * 解释: 对应的交易状态为: [买入, 卖出, 冷冻期, 买入, 卖出]
 * 
 */

// @lc code=start
class Solution {
    public int maxProfit(int[] prices) {
        int n = prices.length;
        if(n==0) return 0;
        int[][] profits = new int[n][3];    //0->no and not sell 1->have 2->no and sell
        profits[0][0] = 0;
        profits[0][1] = -prices[0];
        profits[0][2] = 0;
        for(int i=1;i<n;i++){
            profits[i][0] = Math.max(profits[i-1][0], profits[i-1][2]);
            profits[i][1] = Math.max(profits[i-1][0] - prices[i], profits[i-1][1]);
            profits[i][2] = profits[i-1][1] + prices[i];
        }
        return Math.max(profits[n-1][0], profits[n-1][2]);
    }
}
// @lc code=end

