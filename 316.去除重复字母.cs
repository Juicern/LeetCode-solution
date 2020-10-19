using System;
using System.Text;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=316 lang=csharp
 *
 * [316] 去除重复字母
 *
 * https://leetcode-cn.com/problems/remove-duplicate-letters/description/
 *
 * algorithms
 * Medium (41.67%)
 * Likes:    244
 * Dislikes: 0
 * Total Accepted:    21.7K
 * Total Submissions: 51.9K
 * Testcase Example:  '"bcabc"'
 *
 * 给你一个字符串 s ，请你去除字符串中重复的字母，使得每个字母只出现一次。需保证 返回结果的字典序最小（要求不能打乱其他字符的相对位置）。
 * 
 * 注意：该题与 1081
 * https://leetcode-cn.com/problems/smallest-subsequence-of-distinct-characters
 * 相同
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：s = "bcabc"
 * 输出："abc"
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：s = "cbacdcbc"
 * 输出："acdb"
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * s 由小写英文字母组成
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string RemoveDuplicateLetters(string s) {
        var stack = new Stack<char>();
        var seen = new HashSet<char>();
        var dic = new Dictionary<char, int>();
        int n = s.Length;
        foreach(var letter in s) {
            if (!dic.ContainsKey(letter)) dic.Add(letter, 0);
            dic[letter]++;
        }
        foreach(var letter in s) {
            if(!stack.Any()) {
                stack.Push(letter);
                seen.Add(letter);
                dic[letter]--;
            }
            else {
                if(seen.Contains(letter)) {
                    dic[letter]--;
                    continue;
                }
                if(letter > stack.Peek()) {
                    stack.Push(letter);
                    seen.Add(letter);
                    dic[letter]--;
                }
                else {
                    while(stack.Any() && letter <= stack.Peek() && dic[stack.Peek()] > 0) {                        
                        seen.Remove(stack.Pop());
                    }
                    stack.Push(letter);
                    seen.Add(letter);
                    dic[letter]--;
                }
            }
        }
        var ans = stack.ToArray();
        Array.Reverse(ans);
        return new string(ans);
    }
}
// @lc code=end

