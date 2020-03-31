/*
 * @lc app=leetcode.cn id=76 lang=java
 *
 * [76] 最小覆盖子串
 *
 * https://leetcode-cn.com/problems/minimum-window-substring/description/
 *
 * algorithms
 * Hard (35.12%)
 * Likes:    369
 * Dislikes: 0
 * Total Accepted:    27.3K
 * Total Submissions: 76.7K
 * Testcase Example:  '"ADOBECODEBANC"\n"ABC"'
 *
 * 给你一个字符串 S、一个字符串 T，请在字符串 S 里面找出：包含 T 所有字母的最小子串。
 * 
 * 示例：
 * 
 * 输入: S = "ADOBECODEBANC", T = "ABC"
 * 输出: "BANC"
 * 
 * 说明：
 * 
 * 
 * 如果 S 中不存这样的子串，则返回空字符串 ""。
 * 如果 S 中存在这样的子串，我们保证它是唯一的答案。
 * 
 * 
 */

// @lc code=start
class Solution {
    public String minWindow(String s, String t) {
        Map<Character, Integer> pattern = new HashMap();
        Map<Character, Integer> record = new HashMap();
        //初始化pattern
        for(int i = 0; i < t.length(); i++) {
            Character c = t.charAt(i);
            if(!pattern.containsKey(c)) {
                pattern.put(c, 1);
            } else {
                pattern.put(c, pattern.get(c)+1);
            }
        }

        int match = 0;
        int right = 0;
        int left = 0;
        String res = "";
        int minLen = Integer.MAX_VALUE;
        while(right < s.length()) {
            char c = s.charAt(right);
            if(pattern.containsKey(c)) {
                if(!record.containsKey(c)) {
                    record.put(c, 1);
                } else {
                    record.put(c, record.get(c)+1);
                }
                if(record.get(c).compareTo(pattern.get(c)) == 0) {
                    match++;
                }
            }
            right++;

            while(match == pattern.size()) {
                if(right - left < minLen) {
                    minLen = right - left;
                    res = s.substring(left, right);
                }
                char tt = s.charAt(left);
                if(pattern.containsKey(tt)) {
                    record.put(tt, record.get(tt)-1);
                    if(record.get(tt) < pattern.get(tt)) {
                        match--;
                    }
                }
                left++;
            }
        }
        return res;
    }
}
// @lc code=end

