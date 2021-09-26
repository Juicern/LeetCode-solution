/*
 * @lc app=leetcode id=13 lang=csharp
 *
 * [13] Roman to Integer
 */

// @lc code=start
public class Solution
{
    public int RomanToInt(string s)
    {
        var roman = new Dictionary<char, int>() {
            {'M', 1000},
            {'D', 500},
            {'C', 100},
            {'L', 50},
            {'X', 10},
            {'V', 5},
            {'I', 1},
        };
        int z = 0;
        for (int i = 0; i < s.Length - 1; i++)
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
        return z + roman[s[s.Length - 1]];
    }
}
// @lc code=end

