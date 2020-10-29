/*
 * @lc app=leetcode.cn id=500 lang=csharp
 *
 * [500] 键盘行
 *
 * https://leetcode-cn.com/problems/keyboard-row/description/
 *
 * algorithms
 * Easy (69.44%)
 * Likes:    112
 * Dislikes: 0
 * Total Accepted:    21.3K
 * Total Submissions: 30.7K
 * Testcase Example:  '["Hello","Alaska","Dad","Peace"]'
 *
 * 给定一个单词列表，只返回可以使用在键盘同一行的字母打印出来的单词。键盘如下图所示。
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例：
 * 
 * 输入: ["Hello", "Alaska", "Dad", "Peace"]
 * 输出: ["Alaska", "Dad"]
 * 
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * 你可以重复使用键盘上同一字符。
 * 你可以假设输入的字符串将只包含字母。
 * 
 */

// @lc code=start
public class Solution {
    public string[] FindWords(string[] words) {
        var rows = new [] { "qwertyuiop", "asdfghjkl", "zxcvbnm" }.Select(x => x.ToHashSet());
        return words.Where(w => rows.Any(s => w.ToLower().All(s.Contains))).ToArray();
    }
}
// @lc code=end

