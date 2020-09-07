/*
 * @lc app=leetcode.cn id=472 lang=csharp
 *
 * [472] 连接词
 *
 * https://leetcode-cn.com/problems/concatenated-words/description/
 *
 * algorithms
 * Hard (44.19%)
 * Likes:    46
 * Dislikes: 0
 * Total Accepted:    3.2K
 * Total Submissions: 7.3K
 * Testcase Example:  '["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]'
 *
 * 给定一个不含重复单词的列表，编写一个程序，返回给定单词列表中所有的连接词。
 * 
 * 连接词的定义为：一个字符串完全是由至少两个给定数组中的单词组成的。
 * 
 * 示例:
 * 
 * 
 * 输入:
 * ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
 * 
 * 输出: ["catsdogcats","dogcatsdog","ratcatdogcat"]
 * 
 * 解释: "catsdogcats"由"cats", "dog" 和 "cats"组成; 
 * ⁠    "dogcatsdog"由"dog", "cats"和"dog"组成; 
 * ⁠    "ratcatdogcat"由"rat", "cat", "dog"和"cat"组成。
 * 
 * 
 * 说明:
 * 
 * 
 * 给定数组的元素总数不超过 10000。
 * 给定数组中元素的长度总和不超过 600000。
 * 所有输入字符串只包含小写字母。
 * 不需要考虑答案输出的顺序。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public class TrieNode
    {
        public TrieNode[] Children = new TrieNode[26];
        public bool IsWord;
        public static void Insert(TrieNode root, string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }
                node = node.Children[index];
            }
            node.IsWord = true;
        }
        public static bool Search(TrieNode root, string word, int start, int concatCount)
        {
            TrieNode node = root;
            for (int i = start; i < word.Length; i++)
            {
                int index = word[i] - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }
                node = node.Children[index];
                if (node.IsWord)
                {
                    if (i == word.Length - 1)
                    {
                        return concatCount >= 1;
                    }
                    if (Search(root, word, i + 1, concatCount + 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        IList<string> result = new List<string>();
        TrieNode root = new TrieNode();
        foreach (var word in words)
        {
            TrieNode.Insert(root, word);
        }
        foreach (var word in words)
        {
            if (TrieNode.Search(root, word, 0, 0))
            {
                result.Add(word);
            }
        }
        return result;
    }
}
// @lc code=end

