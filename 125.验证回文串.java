/*
 * @lc app=leetcode.cn id=125 lang=java
 *
 * [125] 验证回文串
 *
 * https://leetcode-cn.com/problems/valid-palindrome/description/
 *
 * algorithms
 * Easy (42.07%)
 * Likes:    165
 * Dislikes: 0
 * Total Accepted:    86.3K
 * Total Submissions: 201.6K
 * Testcase Example:  '"A man, a plan, a canal: Panama"'
 *
 * 给定一个字符串，验证它是否是回文串，只考虑字母和数字字符，可以忽略字母的大小写。
 * 
 * 说明：本题中，我们将空字符串定义为有效的回文串。
 * 
 * 示例 1:
 * 
 * 输入: "A man, a plan, a canal: Panama"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: "race a car"
 * 输出: false
 * 
 * 
 */

// @lc code=start
class Solution {
    public char toLow(char ch){
        if('0'<=ch && ch<='9') return ch;
        if('a'<=ch && ch<='z') return ch;
        return (char)(ch - 'A' + 'a');
    }
    public boolean isLetterOrdigit(char ch){
        return ('a'<=ch && ch<='z') || ('A'<=ch && ch<='Z') || ('0'<=ch && ch<='9');
    }
    public boolean isPalindrome(String s) {
        if(s.length()==0) return true;
        char[] ch = s.toCharArray();
        int left = 0;
        int right = s.length()-1;
        while(left<right){
            while(left<right && !isLetterOrdigit(ch[left])) left++;
            while(left<right && !isLetterOrdigit(ch[right])) right--;
            if(toLow(ch[left]) != toLow(ch[right])) return false;
            left++;
            right--;
        }
        return true;
    }
}
// @lc code=end

