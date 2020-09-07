using System.Text;
/*
 * @lc app=leetcode.cn id=1092 lang=csharp
 *
 * [1092] 最短公共超序列
 *
 * https://leetcode-cn.com/problems/shortest-common-supersequence/description/
 *
 * algorithms
 * Hard (44.03%)
 * Likes:    41
 * Dislikes: 0
 * Total Accepted:    1.4K
 * Total Submissions: 3.1K
 * Testcase Example:  '"abac"\n"cab"'
 *
 * 给出两个字符串 str1 和 str2，返回同时以 str1 和 str2
 * 作为子序列的最短字符串。如果答案不止一个，则可以返回满足条件的任意一个答案。
 * 
 * （如果从字符串 T 中删除一些字符（也可能不删除，并且选出的这些字符可以位于 T 中的 任意位置），可以得到字符串 S，那么 S 就是 T
 * 的子序列）
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：str1 = "abac", str2 = "cab"
 * 输出："cabac"
 * 解释：
 * str1 = "abac" 是 "cabac" 的一个子串，因为我们可以删去 "cabac" 的第一个 "c"得到 "abac"。 
 * str2 = "cab" 是 "cabac" 的一个子串，因为我们可以删去 "cabac" 末尾的 "ac" 得到 "cab"。
 * 最终我们给出的答案是满足上述属性的最短字符串。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= str1.length, str2.length <= 1000
 * str1 和 str2 都由小写英文字母组成。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        string lcs = GetLCS(str1, str2);
        StringBuilder ans = new StringBuilder();
        int i = 0;
        int j = 0;
        foreach (char ch in lcs)
        {
            while (str1[i] != ch)
            {
                ans.Append(str1[i++]);
            }
            while (str2[j] != ch)
            {
                ans.Append(str2[j++]);
            }
            ans.Append(ch);
            i++;
            j++;
        }
        ans.Append(str1.Substring(i)).Append(str2.Substring(j));
        return ans.ToString();

    }
    private string GetLCS(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        var ans = new string[m + 1, n + 1];
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 || j == 0)
                {
                    ans[i, j] = string.Empty;
                }
                else if (str1[i - 1] == str2[j - 1])
                {
                    ans[i, j] = ans[i - 1, j - 1] + str1[i - 1];
                }
                else
                {
                    if (ans[i - 1, j].Length > ans[i, j - 1].Length)
                    {
                        ans[i, j] = ans[i - 1, j];
                    }
                    else
                    {
                        ans[i, j] = ans[i, j - 1];
                    }
                }
            }
        }
        return ans[m, n];
    }
}
// @lc code=end

