using System;
/*
 * @lc app=leetcode.cn id=1000 lang=csharp
 *
 * [1000] 合并石头的最低成本
 *
 * https://leetcode-cn.com/problems/minimum-cost-to-merge-stones/description/
 *
 * algorithms
 * Hard (35.98%)
 * Likes:    100
 * Dislikes: 0
 * Total Accepted:    2K
 * Total Submissions: 5.6K
 * Testcase Example:  '[3,2,4,1]\n2'
 *
 * 有 N 堆石头排成一排，第 i 堆中有 stones[i] 块石头。
 * 
 * 每次移动（move）需要将连续的 K 堆石头合并为一堆，而这个移动的成本为这 K 堆石头的总数。
 * 
 * 找出把所有石头合并成一堆的最低成本。如果不可能，返回 -1 。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：stones = [3,2,4,1], K = 2
 * 输出：20
 * 解释：
 * 从 [3, 2, 4, 1] 开始。
 * 合并 [3, 2]，成本为 5，剩下 [5, 4, 1]。
 * 合并 [4, 1]，成本为 5，剩下 [5, 5]。
 * 合并 [5, 5]，成本为 10，剩下 [10]。
 * 总成本 20，这是可能的最小值。
 * 
 * 
 * 示例 2：
 * 
 * 输入：stones = [3,2,4,1], K = 3
 * 输出：-1
 * 解释：任何合并操作后，都会剩下 2 堆，我们无法再进行合并。所以这项任务是不可能完成的。.
 * 
 * 
 * 示例 3：
 * 
 * 输入：stones = [3,5,1,2,6], K = 3
 * 输出：25
 * 解释：
 * 从 [3, 5, 1, 2, 6] 开始。
 * 合并 [5, 1, 2]，成本为 8，剩下 [3, 8, 6]。
 * 合并 [3, 8, 6]，成本为 17，剩下 [17]。
 * 总成本 25，这是可能的最小值。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= stones.length <= 30
 * 2 <= K <= 30
 * 1 <= stones[i] <= 100
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int MergeStones(int[] stones, int K) {
        int n = stones.Length;
        if((n - 1) % (K - 1) != 0) return -1;
        var dp = new int[n + 1, n + 1];
        var sum = new int[n + 1];
        for(int i = 1;i<=n;i++) sum[i] = sum[i - 1] + stones[i - 1];
        for(int len = 2;len <= n;len++) {
            for(int i = 1;i + len - 1<= n;i++) {
                int j = i + len - 1;
                dp[i, j] = int.MaxValue;
                for(int p = i;p<j;p+= K  -1) {
                    dp[i,j] = Math.Min(dp[i, j], dp[i, p] + dp[p + 1, j]);
                }
                if((j - i) % (K - 1) == 0) dp[i, j] += sum[j] - sum[i - 1]; 
            }
        }
        return dp[1, n];
    }
}
/* public class Solution {
    private int MAX = 99999999;
    public int MergeStones(int[] stones, int K) {
        int n = stones.Length;
        if ((n - 1) % (K - 1) != 0) return -1;
        var dp = new int[n + 1, n + 1, K  + 1];
        var sum = new int[n + 1];
        for(int i = 1;i<=n;i++) sum[i] = sum[i - 1] + stones[i - 1];
        for(int i = 1;i<=n;i++) {
            for(int j = i;j<=n;j++){
                for(int m = 2;m<=K;m++){
                    dp[i, j, m] = MAX;
                }
            }
            dp[i, i, 1] = 0;
        }
        for(int len = 2;len <= n; len ++){
            for(int i = ;i + len - 1 <= n;i++){
                int j = i + len - 1;
                for(int m = 2;m <= K;m++){
                    for(int p = i;p<j;p+=K - 1) 
                    {
                        dp[i, j, m] = Math.Min(dp[i, j , m], dp[i, p, 1] + dp[p + 1, j, m - 1]);
                    }
                }
                dp[i, j, 1] = dp[i, j, K] + sum[j] - sum[i - 1];
            }
        }
        return dp[1,n, 1];
    }
} */
// @lc code=end

