import java.util.*;

/*
 * @lc app=leetcode.cn id=32 lang=java
 *
 * [32] 最长有效括号
 *
 * https://leetcode-cn.com/problems/longest-valid-parentheses/description/
 *
 * algorithms
 * Hard (29.26%)
 * Likes:    531
 * Dislikes: 0
 * Total Accepted:    41.7K
 * Total Submissions: 140.2K
 * Testcase Example:  '"(()"'
 *
 * 给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。
 * 
 * 示例 1:
 * 
 * 输入: "(()"
 * 输出: 2
 * 解释: 最长有效括号子串为 "()"
 * 
 * 
 * 示例 2:
 * 
 * 输入: ")()())"
 * 输出: 4
 * 解释: 最长有效括号子串为 "()()"
 * 
 * 
 */

// @lc code=start
class Solution {
    public int longestValidParentheses(String s) {
        int left = 0, right = 0;
        int max = 0;
        char[] ch = s.toCharArray();
        for(int i=0;i<s.length();i++){
            if(ch[i]=='(') left++;
            else right++;
            if(right>left) left = right = 0;
            if(right==left) max = Integer.max(max, left+right);
        }
        left = 0;
        right = 0;
        for(int i=0;i<s.length();i++){
            if(ch[s.length()-1-i]==')') right++;
            else left++;
            if(left>right) left = right = 0;
            if(right==left) max = Integer.max(max, right+left);
        }
        return max;
    }
}
// @lc code=end

