using System.Reflection.Emit;
/*
 * @lc app=leetcode.cn id=792 lang=csharp
 *
 * [792] 匹配子序列的单词数
 *
 * https://leetcode-cn.com/problems/number-of-matching-subsequences/description/
 *
 * algorithms
 * Medium (41.80%)
 * Likes:    77
 * Dislikes: 0
 * Total Accepted:    3.9K
 * Total Submissions: 9.4K
 * Testcase Example:  '"abcde"\n["a","bb","acd","ace"]'
 *
 * 给定字符串 S 和单词字典 words, 求 words[i] 中是 S 的子序列的单词个数。
 * 
 * 
 * 示例:
 * 输入: 
 * S = "abcde"
 * words = ["a", "bb", "acd", "ace"]
 * 输出: 3
 * 解释: 有三个是 S 的子序列的单词: "a", "acd", "ace"。
 * 
 * 
 * 注意:
 * 
 * 
 * 所有在words和 S 里的单词都只由小写字母组成。
 * S 的长度在 [1, 50000]。
 * words 的长度在 [1, 5000]。
 * words[i]的长度在[1, 50]。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int NumMatchingSubseq(string S, string[] words)
    {
        int ans = 0;
        var heads = new List<Node>[26];
        for (int i = 0; i < heads.Length; i++)
        {
            heads[i] = new List<Node>();
        }
        foreach (var word in words)
        {
            heads[word[0] - 'a'].Add(new Node(word, 0));
        }
        foreach (char letter in S)
        {
            var old_bucket = heads[letter - 'a'];
            heads[letter - 'a'] = new List<Node>();
            foreach (var node in old_bucket)
            {
                node.index++;
                if (node.index == node.word.Length)
                {
                    ans++;
                }
                else
                {
                    heads[node.word[node.index] - 'a'].Add(node);
                }
            }
            old_bucket.Clear();
        }
        return ans;
    }
    class Node
    {
        public int index;
        public string word;
        public Node(string word, int index)
        {
            this.index = index;
            this.word = word;
        }
    }
}
// @lc code=end

