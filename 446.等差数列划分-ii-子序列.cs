/*
 * @lc app=leetcode.cn id=446 lang=csharp
 *
 * [446] 等差数列划分 II - 子序列
 *
 * https://leetcode-cn.com/problems/arithmetic-slices-ii-subsequence/description/
 *
 * algorithms
 * Hard (34.68%)
 * Likes:    72
 * Dislikes: 0
 * Total Accepted:    2.3K
 * Total Submissions: 6.5K
 * Testcase Example:  '[2,4,6,8,10]'
 *
 * 如果一个数列至少有三个元素，并且任意两个相邻元素之差相同，则称该数列为等差数列。
 * 
 * 例如，以下数列为等差数列:
 * 
 * 1, 3, 5, 7, 9
 * 7, 7, 7, 7
 * 3, -1, -5, -9
 * 
 * 以下数列不是等差数列。
 * 
 * 1, 1, 2, 5, 7
 * 
 * 
 * 
 * 数组 A 包含 N 个数，且索引从 0 开始。该数组子序列将划分为整数序列 (P0, P1, ..., Pk)，P 与 Q 是整数且满足 0 ≤ P0
 * < P1 < ... < Pk < N。
 * 
 * 
 * 
 * 如果序列 A[P0]，A[P1]，...，A[Pk-1]，A[Pk] 是等差的，那么数组 A 的子序列 (P0，P1，…，PK)
 * 称为等差序列。值得注意的是，这意味着 k ≥ 2。
 * 
 * 函数要返回数组 A 中所有等差子序列的个数。
 * 
 * 输入包含 N 个整数。每个整数都在 -2^31 和 2^31-1 之间，另外 0 ≤ N ≤ 1000。保证输出小于 2^31-1。
 * 
 * 
 * 
 * 示例：
 * 
 * 
 * 
 * 输入：[2, 4, 6, 8, 10]
 * 
 * 输出：7
 * 
 * 解释：
 * 所有的等差子序列为：
 * [2,4,6]
 * [4,6,8]
 * [6,8,10]
 * [2,4,6,8]
 * [4,6,8,10]
 * [2,4,6,8,10]
 * [2,6,10]
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        int counts = 0;
        if (A.Length == 0)
        {
            return counts;    
        }
        Dictionary<int, int>[] dp = new Dictionary<int, int>[A.Length];
        dp[0] = new Dictionary<int, int>();
        for(int i = 1; i < A.Length; i++)
        {
            dp[i] = new Dictionary<int, int>();
            for(int j = i-1; j >= 0; j--)
            {
                long diff = (long)A[i] - (long)A[j];
                if (diff <= Int32.MinValue || diff > Int32.MaxValue) continue;
                int df = (int)diff;
                if (!dp[i].ContainsKey(df))
                {
                    dp[i][df] = 0; 
                }
                dp[i][df]++;
                if (dp[j].ContainsKey(df))
                {
                   var jsDiffCounts = dp[j][df];
                   dp[i][df] += jsDiffCounts;
                   counts += dp[j][df];
                }
            }
        }
        return counts;
    }
}
// @lc code=end

