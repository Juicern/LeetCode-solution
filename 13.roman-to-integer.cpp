/*
 * @lc app=leetcode id=13 lang=cpp
 *
 * [13] Roman to Integer
 */

#include <string>
#include <unordered_map>
using namespace std;

// @lc code=start
class Solution
{
public:
    int romanToInt(string s)
    {
        unordered_map<char, int> roman{
            {'M', 1000},
            {'D', 500},
            {'C', 100},
            {'L', 50},
            {'X', 10},
            {'V', 5},
            {'I', 1},
        };
        int z = 0;
        for (int i = 0; i < s.size() - 1; i++)
        {
            if (roman[s[i]] < roman[s[i + 1]])
            {
                z -= roman[s[i]];
            }
            else
            {
                z += roman[s[i]];
            }
        }
        return z + roman[s[s.size() - 1]];
    }
};
// @lc code=end
