using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=890 lang=csharp
 *
 * [890] 查找和替换模式
 *
 * https://leetcode-cn.com/problems/find-and-replace-pattern/description/
 *
 * algorithms
 * Medium (71.66%)
 * Likes:    75
 * Dislikes: 0
 * Total Accepted:    6.4K
 * Total Submissions: 8.9K
 * Testcase Example:  '["abc","deq","mee","aqq","dkd","ccc"]\n"abb"'
 *
 * 你有一个单词列表 words 和一个模式  pattern，你想知道 words 中的哪些单词与模式匹配。
 * 
 * 如果存在字母的排列 p ，使得将模式中的每个字母 x 替换为 p(x) 之后，我们就得到了所需的单词，那么单词与模式是匹配的。
 * 
 * （回想一下，字母的排列是从字母到字母的双射：每个字母映射到另一个字母，没有两个字母映射到同一个字母。）
 * 
 * 返回 words 中与给定模式匹配的单词列表。
 * 
 * 你可以按任何顺序返回答案。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：words = ["abc","deq","mee","aqq","dkd","ccc"], pattern = "abb"
 * 输出：["mee","aqq"]
 * 解释：
 * "mee" 与模式匹配，因为存在排列 {a -> m, b -> e, ...}。
 * "ccc" 与模式不匹配，因为 {a -> c, b -> c, ...} 不是排列。
 * 因为 a 和 b 映射到同一个字母。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= words.length <= 50
 * 1 <= pattern.length = words[i].length <= 20
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var ans = new List<string>();
        Dictionary<char, int> dic = new Dictionary<char, int>();
        int index = 0;
        List<int> patternMode = new List<int>();
        foreach(var letter in pattern) {
            if(!dic.ContainsKey(letter)) dic.Add(letter, index++);
            patternMode.Add(dic[letter]);
        }
        foreach(var word in words) {
            dic.Clear();
            var mode = new List<int>();
            index = 0;
            int i;
            for(i = 0;i<word.Length;i++) {
                if(!dic.ContainsKey(word[i])) dic.Add(word[i], index++);
                mode.Add(dic[word[i]]);
                if(mode[i] != patternMode[i]) break;
            }
            if(i == word.Length) ans.Add(word);
        }
        return ans;
    }
}
// @lc code=end

