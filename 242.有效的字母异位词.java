import java.util.*;
/*
 * @lc app=leetcode.cn id=242 lang=java
 *
 * [242] 有效的字母异位词
 *
 * https://leetcode-cn.com/problems/valid-anagram/description/
 *
 * algorithms
 * Easy (57.95%)
 * Likes:    175
 * Dislikes: 0
 * Total Accepted:    89.1K
 * Total Submissions: 150.2K
 * Testcase Example:  '"anagram"\n"nagaram"'
 *
 * 给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。
 * 
 * 示例 1:
 * 
 * 输入: s = "anagram", t = "nagaram"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: s = "rat", t = "car"
 * 输出: false
 * 
 * 说明:
 * 你可以假设字符串只包含小写字母。
 * 
 * 进阶:
 * 如果输入字符串包含 unicode 字符怎么办？你能否调整你的解法来应对这种情况？
 * 
 */

// @lc code=start
class Solution {
    public boolean isAnagram(String s, String t) {
        if(s.length()!=t.length()) return false;
        List<Character> lst1 = new ArrayList<>();
        List<Character> lst2 = new ArrayList<>();
        for(int i=0;i<s.length();i++){
            char ch1 = s.charAt(i);
            char ch2 = t.charAt(i);
            if(ch1!=ch2){
                if(lst2.contains(ch1)) lst2.remove((Character)ch1);
                else lst1.add(ch1);                                                                                                                                                                                                                                       
                if(lst1.contains(ch2)) lst1.remove((Character)ch2);
                else lst2.add(ch2);
            }
        }
        return lst1.size()==0 && lst2.size()==0;
    }
}
// @lc code=end

