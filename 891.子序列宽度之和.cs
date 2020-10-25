using System;
/*
 * @lc app=leetcode.cn id=891 lang=csharp
 *
 * [891] 子序列宽度之和
 *
 * https://leetcode-cn.com/problems/sum-of-subsequence-widths/description/
 *
 * algorithms
 * Hard (30.76%)
 * Likes:    39
 * Dislikes: 0
 * Total Accepted:    1.9K
 * Total Submissions: 6K
 * Testcase Example:  '[2,1,3]'
 *
 * 给定一个整数数组 A ，考虑 A 的所有非空子序列。
 * 
 * 对于任意序列 S ，设 S 的宽度是 S 的最大元素和最小元素的差。
 * 
 * 返回 A 的所有子序列的宽度之和。
 * 
 * 由于答案可能非常大，请返回答案模 10^9+7。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：[2,1,3]
 * 输出：6
 * 解释：
 * 子序列为 [1]，[2]，[3]，[2,1]，[2,3]，[1,3]，[2,1,3] 。
 * 相应的宽度是 0，0，0，1，1，2，2 。
 * 这些宽度之和是 6 。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 20000
 * 1 <= A[i] <= 20000
 * 
 * 
 */

// @lc code=start
public class Solution {
    long MOD = 1_000_000_007;
    public int SumSubseqWidths(int[] A) {
        int n = A.Length;
        Array.Sort(A);
        var two = new long[n + 1];
        two[0] = 1;
        for(int i = 1;i<= n;i++) {
            two[i] = (two[i -1] << 1) % MOD;
        }
        long ans = 0;
        for(int i = 0;i<n;i++ ){
            int left = i;
            int right = n - i - 1;
            ans = (ans + (two[left] - two[right]) * A[i]) % MOD;
        }
        return (int)ans;
    }
}
// @lc code=end

