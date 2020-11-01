/*
 * @lc app=leetcode.cn id=140 lang=csharp
 *
 * [140] 单词拆分 II
 *
 * https://leetcode-cn.com/problems/word-break-ii/description/
 *
 * algorithms
 * Hard (38.65%)
 * Likes:    305
 * Dislikes: 0
 * Total Accepted:    27.5K
 * Total Submissions: 67.5K
 * Testcase Example:  '"catsanddog"\n["cat","cats","and","sand","dog"]'
 *
 * 给定一个非空字符串 s 和一个包含非空单词列表的字典
 * wordDict，在字符串中增加空格来构建一个句子，使得句子中所有的单词都在词典中。返回所有这些可能的句子。
 * 
 * 说明：
 * 
 * 
 * 分隔时可以重复使用字典中的单词。
 * 你可以假设字典中没有重复的单词。
 * 
 * 
 * 示例 1：
 * 
 * 输入:
 * s = "catsanddog"
 * wordDict = ["cat", "cats", "and", "sand", "dog"]
 * 输出:
 * [
 * "cats and dog",
 * "cat sand dog"
 * ]
 * 
 * 
 * 示例 2：
 * 
 * 输入:
 * s = "pineapplepenapple"
 * wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
 * 输出:
 * [
 * "pine apple pen apple",
 * "pineapple pen apple",
 * "pine applepen apple"
 * ]
 * 解释: 注意你可以重复使用字典中的单词。
 * 
 * 
 * 示例 3：
 * 
 * 输入:
 * s = "catsandog"
 * wordDict = ["cats", "dog", "sand", "and", "cat"]
 * 输出:
 * []
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        return Helper(s, wordDict, 0, new List<string>[s.Length]);
    }
    
    private List<string> Helper(string s, IList<string> dict, int i, List<string>[] cache)
    {
        if (cache[i] != null)
            return cache[i];
        
        List<string> cur = new List<string>();
        
        for (int j = i; j < s.Length; j++)
            if (dict.Contains(s.Substring(i, j - i + 1)))
            {
                if (j == s.Length - 1)
                    cur.Add(s.Substring(i, j - i + 1));
                else
                    foreach (var str in Helper(s, dict, j + 1, cache))
                        cur.Add(s.Substring(i, j - i + 1) + " " + str);
            }
        
        cache[i] = cur;
        
        return cache[i];
    }
}
// @lc code=end

