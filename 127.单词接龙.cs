/*
 * @lc app=leetcode.cn id=127 lang=csharp
 *
 * [127] 单词接龙
 *
 * https://leetcode-cn.com/problems/word-ladder/description/
 *
 * algorithms
 * Medium (44.00%)
 * Likes:    598
 * Dislikes: 0
 * Total Accepted:    78.7K
 * Total Submissions: 175.1K
 * Testcase Example:  '"hit"\n"cog"\n["hot","dot","dog","lot","log","cog"]'
 *
 * 给定两个单词（beginWord 和 endWord）和一个字典，找到从 beginWord 到 endWord
 * 的最短转换序列的长度。转换需遵循如下规则：
 * 
 * 
 * 每次转换只能改变一个字母。
 * 转换过程中的中间单词必须是字典中的单词。
 * 
 * 
 * 说明:
 * 
 * 
 * 如果不存在这样的转换序列，返回 0。
 * 所有单词具有相同的长度。
 * 所有单词只由小写字母组成。
 * 字典中不存在重复的单词。
 * 你可以假设 beginWord 和 endWord 是非空的，且二者不相同。
 * 
 * 
 * 示例 1:
 * 
 * 输入:
 * beginWord = "hit",
 * endWord = "cog",
 * wordList = ["hot","dot","dog","lot","log","cog"]
 * 
 * 输出: 5
 * 
 * 解释: 一个最短转换序列是 "hit" -> "hot" -> "dot" -> "dog" -> "cog",
 * ⁠    返回它的长度 5。
 * 
 * 
 * 示例 2:
 * 
 * 输入:
 * beginWord = "hit"
 * endWord = "cog"
 * wordList = ["hot","dot","dog","lot","log"]
 * 
 * 输出: 0
 * 
 * 解释: endWord "cog" 不在字典中，所以无法进行转换。
 * 
 */

// @lc code=start
public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        int count = 1;
        int countInLevel = 0;
        var queue = new Queue<string>();
        string currentWord = string.Empty;
        var set = new HashSet<string>(wordList);
        char[] temp = null;

        queue.Enqueue(beginWord);

        while (queue.Any())
        {
            countInLevel = queue.Count();

            while (countInLevel-- > 0)
            {
                currentWord = queue.Dequeue();

                if (currentWord == endWord)
                    return count;

                temp = currentWord.ToCharArray();
                for (int i = 0; i <= temp.Length - 1; i++)
                {
                    temp = currentWord.ToCharArray();

                    for (int j = 0; j < 26; j++)
                    {
                        temp[i] = (char)('a' + j);

                        if (set.Contains(new string(temp)))
                        {
                            queue.Enqueue(new string(temp));
                            set.Remove(new string(temp));
                        }
                    }
                }
            }

            count++;
        }

        return 0;
    }
}
// @lc code=end

