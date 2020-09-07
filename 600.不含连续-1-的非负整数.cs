/*
 * @lc app=leetcode.cn id=600 lang=csharp
 *
 * [600] 不含连续1的非负整数
 *
 * https://leetcode-cn.com/problems/non-negative-integers-without-consecutive-ones/description/
 *
 * algorithms
 * Hard (31.90%)
 * Likes:    62
 * Dislikes: 0
 * Total Accepted:    2.3K
 * Total Submissions: 7.1K
 * Testcase Example:  '1'
 *
 * 给定一个正整数 n，找出小于或等于 n 的非负整数中，其二进制表示不包含 连续的1 的个数。
 * 
 * 示例 1:
 * 
 * 输入: 5
 * 输出: 5
 * 解释: 
 * 下面是带有相应二进制表示的非负整数<= 5：
 * 0 : 0
 * 1 : 1
 * 2 : 10
 * 3 : 11
 * 4 : 100
 * 5 : 101
 * 其中，只有整数3违反规则（有两个连续的1），其他5个满足规则。
 * 
 * 说明: 1 <= n <= 10^9
 * 
 */

// @lc code=start
public class Solution
{

    public int FindIntegers(int num)
    {
        if (num == 0)
        {
            return 1;
        }
        else if (num == 1)
        {
            return 2;
        }

        string s = Convert.ToString(num, 2);

        int len = s.Length;

        var dp1 = new int[len];
        var dp0 = new int[len];
        dp0[len - 1] = 1;
        dp1[len - 1] = 1;

        for (int i = len - 2; i >= 0; i--)
        {
            dp0[i] = dp0[i + 1] + dp1[i + 1];
            dp1[i] = dp0[i + 1];
        }

        int result = dp1[0] + dp0[0];

        for (int i = 1; i < len; i++)
        {
            if (s[i] == '1')
            {
                if (s[i - 1] == '1')
                {
                    break;
                }
            }
            else if (s[i - 1] == '0')
            {
                result -= dp1[i];
            }
        }

        return result;
    }
}
// @lc code=end

