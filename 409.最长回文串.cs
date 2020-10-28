using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=409 lang=csharp
 *
 * [409] 最长回文串
 *
 * https://leetcode-cn.com/problems/longest-palindrome/description/
 *
 * algorithms
 * Easy (55.22%)
 * Likes:    240
 * Dislikes: 0
 * Total Accepted:    62.7K
 * Total Submissions: 113.6K
 * Testcase Example:  '"abccccdd"'
 *
 * 给定一个包含大写字母和小写字母的字符串，找到通过这些字母构造成的最长的回文串。
 * 
 * 在构造过程中，请注意区分大小写。比如 "Aa" 不能当做一个回文字符串。
 * 
 * 注意:
 * 假设字符串的长度不会超过 1010。
 * 
 * 示例 1: 
 * 
 * 
 * 输入:
 * "abccccdd"
 * 
 * 输出:
 * 7
 * 
 * 解释:
 * 我们可以构造的最长的回文串是"dccaccd", 它的长度是 7。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int LongestPalindrome(string s) {
        int ans = 0;
        int max_odd = 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach(var letter in s) {
            if(!dict.ContainsKey(letter)) dict.Add(letter, 0);
            dict[letter]++;
        }
        bool flag = false;
        foreach(var value in dict.Values) {
            if(value % 2 == 1) flag = true;
            ans += value / 2 * 2;
        }
        if(flag) ans += 1;
        return ans;
    }

}
// @lc code=end
