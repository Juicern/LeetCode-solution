/*
 * @lc app=leetcode.cn id=910 lang=csharp
 *
 * [910] 最小差值 II
 */

// @lc code=start
public class Solution {
    public int SmallestRangeII(int[] A, int K) {
        Array.Sort(A);
        int ans = A[A.Length - 1] - A[0];
        for(int i=0;i<A.Length - 1;i++) {
            int high = Math.Max(A[A.Length -1] - K, A[i] + K);
            int low = Math.Min(A[0] + K, A[i + 1] - K);
            ans = Math.Min(ans, high - low);
        }
        return ans;
    }
}
// @lc code=end

