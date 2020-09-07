using System;
/*
 * @lc app=leetcode.cn id=516 lang=csharp
 *
 * [516] 最长回文子序列
 *
 * https://leetcode-cn.com/problems/longest-palindromic-subsequence/description/
 *
 * algorithms
 * Medium (56.46%)
 * Likes:    269
 * Dislikes: 0
 * Total Accepted:    25.2K
 * Total Submissions: 44.5K
 * Testcase Example:  '"bbbab"'
 *
 * 给定一个字符串 s ，找到其中最长的回文子序列，并返回该序列的长度。可以假设 s 的最大长度为 1000 。
 * 
 * 
 * 
 * 示例 1:
 * 输入:
 * 
 * "bbbab"
 * 
 * 
 * 输出:
 * 
 * 4
 * 
 * 
 * 一个可能的最长回文子序列为 "bbbb"。
 * 
 * 示例 2:
 * 输入:
 * 
 * "cbbd"
 * 
 * 
 * 输出:
 * 
 * 2
 * 
 * 
 * 一个可能的最长回文子序列为 "bb"。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= s.length <= 1000
 * s 只包含小写英文字母
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;
        var dp = new int[n, n];
        for(int i = n - 1;i>=0;i--) {
            dp[i, i] = 1;
            for(int j = i  +1;j<n;j++) {
                if(s[i] == s[j]) {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else {
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i +1 , j]);
                }
            }
        }
        return dp[0, n - 1];
    }
   
}
// @lc code=end

