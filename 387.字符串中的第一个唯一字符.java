import java.util.Map;

/*
 * @lc app=leetcode.cn id=387 lang=java
 *
 * [387] 字符串中的第一个唯一字符
 *
 * https://leetcode-cn.com/problems/first-unique-character-in-a-string/description/
 *
 * algorithms
 * Easy (42.77%)
 * Likes:    204
 * Dislikes: 0
 * Total Accepted:    72.4K
 * Total Submissions: 162.7K
 * Testcase Example:  '"leetcode"'
 *
 * 给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。
 * 
 * 案例:
 * 
 * 
 * s = "leetcode"
 * 返回 0.
 * 
 * s = "loveleetcode",
 * 返回 2.
 * 
 * 
 * 
 * 
 * 注意事项：您可以假定该字符串只包含小写字母。
 * 
 */

// @lc code=start
class Solution {
    public int firstUniqChar(String s) {
        int len = s.length();
        Map<Character, Integer> m = new HashMap<>();
        for(int i=0;i<len;i++) {
            char ch = s.charAt(i);
            if(m.containsKey(ch)) m.replace(ch, m.get(ch)+1);
            else m.put(ch, 1);
        }
        for(int i=0;i<len;i++) {
            char ch = s.charAt(i);
            if(m.get(ch)==1) return i;
        }
        return -1;
    }
}
// @lc code=end

