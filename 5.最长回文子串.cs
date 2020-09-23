/*
 * @lc app=leetcode.cn id=5 lang=csharp
 *
 * [5] 最长回文子串
 *
 * https://leetcode-cn.com/problems/longest-palindromic-substring/description/
 *
 * algorithms
 * Medium (31.73%)
 * Likes:    2715
 * Dislikes: 0
 * Total Accepted:    383.7K
 * Total Submissions: 1.2M
 * Testcase Example:  '"babad"'
 *
 * 给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
 * 
 * 示例 1：
 * 
 * 输入: "babad"
 * 输出: "bab"
 * 注意: "aba" 也是一个有效答案。
 * 
 * 
 * 示例 2：
 * 
 * 输入: "cbbd"
 * 输出: "bb"
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        var dp = new bool[n, n];
        string ans = "";
        for(int j = 0;j<n;j++) {
            for(int i = 0;i<=j;i++) {
                if(j - i == 0) dp[i, j] = true;
                else if(j - i == 1) dp[i, j] = s[i] == s[j];
                else {
                    dp[i, j] = s[i] == s[j] && dp[i + 1, j - 1];
                }
                if(dp[i, j] && j - i + 1 > ans.Length) {
                    ans = s.Substring(i, j - i + 1);
                }
            }
        }
        return ans;
    }
}
// @lc code=end

