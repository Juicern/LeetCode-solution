using System;
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
        if(s == null || s.Length == 0) return "";
        int start = 0;
        int end = 0;
        for (int i = 0;i<s.Length;i++) {
            int len1 = ExpendAroundCenter(s, i, i);
            int len2 = ExpendAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);
            if(len> end - start) {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }
        return s.Substring(start, end + 1);
    }
    public int ExpendAroundCenter(string s, int left, int right) {
        while(left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        return right - left  - 1;
    }
}
// @lc code=end

