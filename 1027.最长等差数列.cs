/*
 * @lc app=leetcode.cn id=1027 lang=csharp
 *
 * [1027] 最长等差数列
 */

// @lc code=start
public class Solution {
    public int LongestArithSeqLength(int[] A) {
        int len = A.Length;
        var dp = new int[len, 20001];
        int putPlace = 10000;
        int ans = 0;
        for(int i=0;i<len;i++){
            for(int j=0;j<i;j++)
            {
                int minus = A[i] >= A[j] ? A[i] - A[j] : A[j] - A[i] + putPlace;
                dp[i, minus] = dp[j, minus] + 1;
                ans = Math.Max(ans, dp[i, minus]);
            }
        }
        return ans+1;
    }
}
// @lc code=end

