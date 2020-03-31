import java.util.*;
/*
 * @lc app=leetcode.cn id=205 lang=java
 *
 * [205] 同构字符串
 *
 * https://leetcode-cn.com/problems/isomorphic-strings/description/
 *
 * algorithms
 * Easy (46.92%)
 * Likes:    172
 * Dislikes: 0
 * Total Accepted:    31.8K
 * Total Submissions: 67.2K
 * Testcase Example:  '"egg"\n"add"'
 *
 * 给定两个字符串 s 和 t，判断它们是否是同构的。
 * 
 * 如果 s 中的字符可以被替换得到 t ，那么这两个字符串是同构的。
 * 
 * 所有出现的字符都必须用另一个字符替换，同时保留字符的顺序。两个字符不能映射到同一个字符上，但字符可以映射自己本身。
 * 
 * 示例 1:
 * 
 * 输入: s = "egg", t = "add"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: s = "foo", t = "bar"
 * 输出: false
 * 
 * 示例 3:
 * 
 * 输入: s = "paper", t = "title"
 * 输出: true
 * 
 * 说明:
 * 你可以假设 s 和 t 具有相同的长度。
 * 
 */

// @lc code=start
class Solution {
    public boolean isIsomorphic(String s, String t) {
        int n = s.length();
        Map<Character, Character> m1 = new HashMap<>();
        Map<Character, Character> m2 = new HashMap<>();
        for(int i=0;i<n;i++){
            char s_ch = s.charAt(i);
            char t_ch = t.charAt(i);
            if(m1.containsKey(s_ch)){
                if(m1.get(s_ch)!=t_ch) return false;
                continue;
            }
            else if(m2.containsKey(t_ch)){
                if(m2.get(t_ch)!=s_ch) return false;
                continue;
            }
            else{
                m1.put(s_ch, t_ch);
                m2.put(t_ch, s_ch);
            } 
        }
        return true;
    }
}
// @lc code=end

