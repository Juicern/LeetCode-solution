using System;
/*
 * @lc app=leetcode.cn id=318 lang=csharp
 *
 * [318] 最大单词长度乘积
 *
 * https://leetcode-cn.com/problems/maximum-product-of-word-lengths/description/
 *
 * algorithms
 * Medium (64.57%)
 * Likes:    115
 * Dislikes: 0
 * Total Accepted:    10.5K
 * Total Submissions: 16.2K
 * Testcase Example:  '["abcw","baz","foo","bar","xtfn","abcdef"]'
 *
 * 给定一个字符串数组 words，找到 length(word[i]) * length(word[j])
 * 的最大值，并且这两个单词不含有公共字母。你可以认为每个单词只包含小写字母。如果不存在这样的两个单词，返回 0。
 * 
 * 示例 1:
 * 
 * 输入: ["abcw","baz","foo","bar","xtfn","abcdef"]
 * 输出: 16 
 * 解释: 这两个单词为 "abcw", "xtfn"。
 * 
 * 示例 2:
 * 
 * 输入: ["a","ab","abc","d","cd","bcd","abcd"]
 * 输出: 4 
 * 解释: 这两个单词为 "ab", "cd"。
 * 
 * 示例 3:
 * 
 * 输入: ["a","aa","aaa","aaaa"]
 * 输出: 0 
 * 解释: 不存在这样的两个单词。
 * 
 */

// @lc code=start
public class Solution {
    public int MaxProduct(string[] words) {
        int ans = 0;
        int n = words.Length;
        var arr  = new int[n];
        for(int i = 0;i<n;i++) {
            foreach(var letter in words[i]) {
                arr[i] |= 1<<(letter - 'a');
            }
        }
        for(int i = 0;i<n;i++) {
            for(int j = i + 1;j<n;j++) {
                if((arr[i] & arr[j]) == 0) ans = Math.Max(ans, words[i].Length * words[j].Length);
            }
        }
        return ans;
    }
}
// @lc code=end

