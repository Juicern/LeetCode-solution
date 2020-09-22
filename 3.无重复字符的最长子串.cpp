#include <string>
#include <unordered_set>
using namespace std;
/*
 * @lc app=leetcode.cn id=3 lang=cpp
 *
 * [3] 无重复字符的最长子串
 *
 * https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/description/
 *
 * algorithms
 * Medium (35.53%)
 * Likes:    4354
 * Dislikes: 0
 * Total Accepted:    669.1K
 * Total Submissions: 1.9M
 * Testcase Example:  '"abcabcbb"'
 *
 * 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
 * 
 * 示例 1:
 * 
 * 输入: "abcabcbb"
 * 输出: 3 
 * 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
 * 
 * 
 * 示例 2:
 * 
 * 输入: "bbbbb"
 * 输出: 1
 * 解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
 * 
 * 
 * 示例 3:
 * 
 * 输入: "pwwkew"
 * 输出: 3
 * 解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
 * 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
 * 
 * 
 */

// @lc code=start
class Solution
{
public:
    int lengthOfLongestSubstring(string s)
    {
        unordered_set<char> set;
        int n = s.size();
        int j = 0;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (i != 0)
            {
                set.erase(s[i - 1]);
            }
            while (j < n && !set.count(s[j]))
            {
                set.insert(s[j]);
                j++;
            }
            ans = max(ans, j - i);
        }
        return ans;
    }
};
// @lc code=end
