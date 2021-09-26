/*
 * @lc app=leetcode id=14 lang=cpp
 *
 * [14] Longest Common Prefix
 */
#include <string>
#include <vector>
using namespace std;

// @lc code=start
class Solution
{
public:
    string longestCommonPrefix(vector<string> &strs)
    {
        if (strs.size() == 0)
        {
            return "";
        }
        string ans;
        for (int i = 0; i < strs[0].size(); i++)
        {
            char curr = strs[0][i];
            for (const auto &str : strs)
            {
                if (i >= str.size() || str[i] != curr)
                {
                    return ans;
                }
            }
            ans += curr;
        }
        return ans;
    }
};
// @lc code=end
