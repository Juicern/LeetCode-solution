/*
 * @lc app=leetcode.cn id=1081 lang=java
 *
 * [1081] 不同字符的最小子序列
 *
 * https://leetcode-cn.com/problems/smallest-subsequence-of-distinct-characters/description/
 *
 * algorithms
 * Medium (50.56%)
 * Likes:    50
 * Dislikes: 0
 * Total Accepted:    4.6K
 * Total Submissions: 8.9K
 * Testcase Example:  '"cdadabcc"'
 *
 * 返回字符串 text 中按字典序排列最小的子序列，该子序列包含 text 中所有不同字符一次。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入："cdadabcc"
 * 输出："adbc"
 * 
 * 
 * 示例 2：
 * 
 * 输入："abcd"
 * 输出："abcd"
 * 
 * 
 * 示例 3：
 * 
 * 输入："ecbacba"
 * 输出："eacb"
 * 
 * 
 * 示例 4：
 * 
 * 输入："leetcode"
 * 输出："letcod"
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= text.length <= 1000
 * text 由小写英文字母组成
 * 
 * 
 * 
 * 
 * 注意：本题目与 316 https://leetcode-cn.com/problems/remove-duplicate-letters/ 相同
 * 
 */

// @lc code=start
class Solution {
    public String smallestSubsequence(String s) {
        var set = new HashSet<Character>();
        var counts = new int[26];
        var ans = new Stack<Character>();
        for (var letter : s.toCharArray()) {
            counts[letter - 'a']++;
        }
        for (var letter : s.toCharArray()) {
            if (!set.contains(letter)) {
                while (!ans.isEmpty() && ans.peek() > letter && counts[ans.peek() - 'a'] > 0) {
                    set.remove(ans.pop());
                }
                ans.add(letter);
                set.add(letter);
            }
            counts[letter - 'a']--;
        }
        var res = new StringBuffer();
        for (var letter : ans) {
            res.append((letter));
        }
        return res.toString();
    }
}
// @lc code=end
