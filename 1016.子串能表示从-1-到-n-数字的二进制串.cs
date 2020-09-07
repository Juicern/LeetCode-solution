/*
 * @lc app=leetcode.cn id=1016 lang=csharp
 *
 * [1016] 子串能表示从 1 到 N 数字的二进制串
 */

// @lc code=start
public class Solution {
    public bool QueryString(string S, int N) {
        for(int i=1;i<=N;i++) 
        {
            if(!S.Contains(Convert.ToString(i, 2))) return false;
        }
        return true;
    }
}
// @lc code=end

