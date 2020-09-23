#include <string>
#include <vector>
using namespace std;
/*
 * @lc app=leetcode.cn id=5 lang=cpp
 *
 * [5] 最长回文子串
 *
 * https://leetcode-cn.com/problems/longest-palindromic-substring/description/
 *
 * algorithms
 * Medium (31.73%)
 * Likes:    2715
 * Dislikes: 0
 * Total Accepted:    383.7K
 * Total Submissions: 1.2M
 * Testcase Example:  '"babad"'
 *
 * 给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
 * 
 * 示例 1：
 * 
 * 输入: "babad"
 * 输出: "bab"
 * 注意: "aba" 也是一个有效答案。
 * 
 * 
 * 示例 2：
 * 
 * 输入: "cbbd"
 * 输出: "bb"
 * 
 * 
 */

// @lc code=start
class Solution
{
public:
    string longestPalindrome(string s)
    {
        int n = s.size();
        int start = 0;
        int end = 0;
        for(int i = 0;i<n;i++) {
            auto [left1, right1] = helper(s, i, i);
            auto [left2, right2] = helper(s, i, i + 1);
            if (right1 - left1 > end - start) {
                start = left1;
                end = right1;
            }
            if (right2 - left2 > end - start) {
                start = left2;
                end = right2;
            }
        }
        return s.substr(start, end - start + 1);
    }
    pair<int, int> helper(const string& s, int left, int right) 
    {
        while(left >= 0 && right < s.size() && s[left] == s[right]) {
            left--;
            right++;
        }
        return {left+ 1, right - 1};
    }
};
// @lc code=end
