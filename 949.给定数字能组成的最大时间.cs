using System;
/*
 * @lc app=leetcode.cn id=949 lang=csharp
 *
 * [949] 给定数字能组成的最大时间
 *
 * https://leetcode-cn.com/problems/largest-time-for-given-digits/description/
 *
 * algorithms
 * Easy (35.27%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    5.1K
 * Total Submissions: 14.5K
 * Testcase Example:  '[1,2,3,4]'
 *
 * 给定一个由 4 位数字组成的数组，返回可以设置的符合 24 小时制的最大时间。
 * 
 * 最小的 24 小时制时间是 00:00，而最大的是 23:59。从 00:00 （午夜）开始算起，过得越久，时间越大。
 * 
 * 以长度为 5 的字符串返回答案。如果不能确定有效时间，则返回空字符串。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[1,2,3,4]
 * 输出："23:41"
 * 
 * 
 * 示例 2：
 * 
 * 输入：[5,5,5,5]
 * 输出：""
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * A.length == 4
 * 0 <= A[i] <= 9
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public string LargestTimeFromDigits(int[] A)
    {
        int ans = -1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == j) continue;
                for (int k = 0; k < 4; k++)
                {
                    if (k == i || k == j) continue;
                    int l = 6 - i - j - k;
                    int hours = 10 * A[i] + A[j];
                    int mins = 10 * A[k] + A[l];
                    if (hours < 24 && mins < 60)
                    {
                        ans = Math.Max(ans, hours*60 + mins);
                    }
                }
            }
        }
        return (ans >= 0) ? string.Format("{0:D2}:{1:D2}", ans / 60, ans % 60) : "";
    }
}
// @lc code=end

