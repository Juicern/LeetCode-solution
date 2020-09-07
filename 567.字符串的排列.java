/*
 * @lc app=leetcode.cn id=567 lang=java
 *
 * [567] 字符串的排列
 *
 * https://leetcode-cn.com/problems/permutation-in-string/description/
 *
 * algorithms
 * Medium (35.03%)
 * Likes:    117
 * Dislikes: 0
 * Total Accepted:    22.7K
 * Total Submissions: 64.9K
 * Testcase Example:  '"ab"\n"eidbaooo"'
 *
 * 给定两个字符串 s1 和 s2，写一个函数来判断 s2 是否包含 s1 的排列。
 * 
 * 换句话说，第一个字符串的排列之一是第二个字符串的子串。
 * 
 * 示例1:
 * 
 * 
 * 输入: s1 = "ab" s2 = "eidbaooo"
 * 输出: True
 * 解释: s2 包含 s1 的排列之一 ("ba").
 * 
 * 
 * 
 * 
 * 示例2:
 * 
 * 
 * 输入: s1= "ab" s2 = "eidboaoo"
 * 输出: False
 * 
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * 输入的字符串只包含小写字母
 * 两个字符串的长度都在 [1, 10,000] 之间
 * 
 * 
 */

// @lc code=start
class Solution {
    public boolean checkInclusion(String s1, String s2) {
        if(s1.length() > s2.length()) return false;
        int[] str1 = new int[26];
        int[] str2 = new int[26];
        for(int i=0;i<s1.length();i++) {
            str1[s1.charAt(i)-'a']++;
            str2[s2.charAt(i)-'a']++;
        }
        for(int i=0;i<s2.length()-s1.length();i++) {
            if(matched(str1, str2)) return true;
            str2[s2.charAt(i)-'a']--;
            str2[s2.charAt(i+s1.length())-'a']++;
        }
        return matched(str1, str2);
    }
    public boolean matched(int[] str1, int[] str2) {
        for(int i=0;i<str2.length;i++) {
            if(str1[i] != str2[i]) return false;
        }
        return true;
    }
}
// @lc code=end

