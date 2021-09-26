/*
 * @lc app=leetcode id=14 lang=csharp
 *
 * [14] Longest Common Prefix
 */

// @lc code=start
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        {
            return "";
        }
        string ans = "";
        for (int i = 0; i < strs[0].Length; i++)
        {
            char curr = strs[0][i];
            foreach (var str in strs)
            {
                if (i >= str.Length || curr != str[i])
                {
                    return ans;
                }
            }
            ans += curr;
        }
        return ans;
    }
}
// @lc code=end


