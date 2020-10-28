/*
 * @lc app=leetcode.cn id=438 lang=csharp
 *
 * [438] 找到字符串中所有字母异位词
 *
 * https://leetcode-cn.com/problems/find-all-anagrams-in-a-string/description/
 *
 * algorithms
 * Medium (47.12%)
 * Likes:    395
 * Dislikes: 0
 * Total Accepted:    42.8K
 * Total Submissions: 90.7K
 * Testcase Example:  '"cbaebabacd"\n"abc"'
 *
 * 给定一个字符串 s 和一个非空字符串 p，找到 s 中所有是 p 的字母异位词的子串，返回这些子串的起始索引。
 * 
 * 字符串只包含小写英文字母，并且字符串 s 和 p 的长度都不超过 20100。
 * 
 * 说明：
 * 
 * 
 * 字母异位词指字母相同，但排列不同的字符串。
 * 不考虑答案输出的顺序。
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入:
 * s: "cbaebabacd" p: "abc"
 * 
 * 输出:
 * [0, 6]
 * 
 * 解释:
 * 起始索引等于 0 的子串是 "cba", 它是 "abc" 的字母异位词。
 * 起始索引等于 6 的子串是 "bac", 它是 "abc" 的字母异位词。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入:
 * s: "abab" p: "ab"
 * 
 * 输出:
 * [0, 1, 2]
 * 
 * 解释:
 * 起始索引等于 0 的子串是 "ab", 它是 "ab" 的字母异位词。
 * 起始索引等于 1 的子串是 "ba", 它是 "ab" 的字母异位词。
 * 起始索引等于 2 的子串是 "ab", 它是 "ab" 的字母异位词。
 * 
 * 
 */

// @lc code=start
public class Solution 
{
    public IList<int> FindAnagrams(string s, string p) 
    {
        int[] freq1 = new int[26], freq2 = new int[26];
        var result = new List<int>();
        foreach(var ch in p)
            freq1[ch - 'a']++;
        
        for(int i = 0; i < s.Length; i++)
        {
            freq2[s[i] - 'a']++;
            if(i - p.Length >= 0)
                freq2[s[i - p.Length] -'a']--;
            if(i >= p.Length - 1 && IsEqual(freq1, freq2))
                result.Add(i - p.Length + 1);
        }
        
        return result;
    }
    
    private bool IsEqual(int[] freq1, int[] freq2)
    {
        for(int i = 0; i < freq1.Length; i++)
            if(freq1[i] != freq2[i])
                return false;
        return true;
    }
}
// @lc code=end

