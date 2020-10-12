using System.Text;
using System;
/*
 * @lc app=leetcode.cn id=833 lang=csharp
 *
 * [833] 字符串中的查找与替换
 *
 * https://leetcode-cn.com/problems/find-and-replace-in-string/description/
 *
 * algorithms
 * Medium (40.63%)
 * Likes:    40
 * Dislikes: 0
 * Total Accepted:    3.2K
 * Total Submissions: 7.9K
 * Testcase Example:  '"abcd"\n[0, 2]\n["a", "cd"]\n["eee", "ffff"]'
 *
 * 对于某些字符串 S，我们将执行一些替换操作，用新的字母组替换原有的字母组（不一定大小相同）。
 * 
 * 每个替换操作具有 3 个参数：起始索引 i，源字 x 和目标字 y。规则是如果 x 从原始字符串 S 中的位置 i 开始，那么我们将用 y 替换出现的
 * x。如果没有，我们什么都不做。
 * 
 * 举个例子，如果我们有 S = “abcd” 并且我们有一些替换操作 i = 2，x = “cd”，y = “ffff”，那么因为 “cd” 从原始字符串
 * S 中的位置 2 开始，我们将用 “ffff” 替换它。
 * 
 * 再来看 S = “abcd” 上的另一个例子，如果我们有替换操作 i = 0，x = “ab”，y = “eee”，以及另一个替换操作 i = 2，x
 * = “ec”，y = “ffff”，那么第二个操作将不执行任何操作，因为原始字符串中 S[2] = 'c'，与 x[0] = 'e' 不匹配。
 * 
 * 所有这些操作同时发生。保证在替换时不会有任何重叠： S = "abc", indexes = [0, 1], sources = ["ab","bc"]
 * 不是有效的测试用例。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：S = "abcd", indexes = [0,2], sources = ["a","cd"], targets =
 * ["eee","ffff"]
 * 输出："eeebffff"
 * 解释：
 * "a" 从 S 中的索引 0 开始，所以它被替换为 "eee"。
 * "cd" 从 S 中的索引 2 开始，所以它被替换为 "ffff"。
 * 
 * 
 * 示例 2：
 * 
 * 输入：S = "abcd", indexes = [0,2], sources = ["ab","ec"], targets =
 * ["eee","ffff"]
 * 输出："eeecd"
 * 解释：
 * "ab" 从 S 中的索引 0 开始，所以它被替换为 "eee"。
 * "ec" 没有从原始的 S 中的索引 2 开始，所以它没有被替换。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 <= indexes.length = sources.length = targets.length <= 100
 * 0 < indexes[i] < S.length <= 1000
 * 给定输入中的所有字符都是小写字母。
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        int n = S.Length;
        int[] match = new int[n];
        Array.Fill(match, -1);
        int index;
        for(int i  = 0;i<indexes.Length;i++) {
            index = indexes[i];
            if (S.Substring(index, sources[i].Length).Equals(sources[i])) {
                match[index] = i;
            }
        }
        StringBuilder ans = new StringBuilder();
        index = 0;
        while(index < n) {
            if(match[index] >= 0) {
                ans.Append(targets[match[index]]);
                index += sources[match[index]].Length;
            }
            else{
                ans.Append(S[index++]);
            }
        }
        return ans.ToString();
    }
}
// @lc code=end

