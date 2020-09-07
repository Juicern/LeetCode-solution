/*
 * @lc app=leetcode.cn id=629 lang=csharp
 *
 * [629] K个逆序对数组
 *
 * https://leetcode-cn.com/problems/k-inverse-pairs-array/description/
 *
 * algorithms
 * Hard (37.83%)
 * Likes:    57
 * Dislikes: 0
 * Total Accepted:    1.6K
 * Total Submissions: 4.3K
 * Testcase Example:  '3\n0'
 *
 * 给出两个整数 n 和 k，找出所有包含从 1 到 n 的数字，且恰好拥有 k 个逆序对的不同的数组的个数。
 * 
 * 逆序对的定义如下：对于数组的第i个和第 j个元素，如果满i < j且 a[i] > a[j]，则其为一个逆序对；否则不是。
 * 
 * 由于答案可能很大，只需要返回 答案 mod 10^9 + 7 的值。
 * 
 * 示例 1:
 * 
 * 
 * 输入: n = 3, k = 0
 * 输出: 1
 * 解释: 
 * 只有数组 [1,2,3] 包含了从1到3的整数并且正好拥有 0 个逆序对。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: n = 3, k = 1
 * 输出: 2
 * 解释: 
 * 数组 [1,3,2] 和 [2,1,3] 都有 1 个逆序对。
 * 
 * 
 * 说明:
 * 
 * 
 * n 的范围是 [1, 1000] 并且 k 的范围是 [0, 1000]。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private static int MOD = 1_000_000_007;
    public int KInversePairs(int n, int k)
    {
        var dp = new int[n + 1, k + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j <= k && j <= i * (i - 1) / 2; j++)
            {
                if (i == 1 && j == 0)
                {
                    dp[i, j] = 1;
                    break;
                }
                else if (j == 0)
                {
                    dp[i, j] = 1;
                }
                else
                {
                    int val = (dp[i - 1, j] + MOD - ((j - i) >= 0 ? dp[i - 1, j - i] : 0)) % MOD;
                    dp[i, j] = (dp[i, j - 1] + val) % MOD;
                }
            }
        }
        return dp[n, k];
    }
}
// @lc code=end

