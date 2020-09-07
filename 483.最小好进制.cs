using System;
/*
 * @lc app=leetcode.cn id=483 lang=csharp
 *
 * [483] 最小好进制
 *
 * https://leetcode-cn.com/problems/smallest-good-base/description/
 *
 * algorithms
 * Hard (37.89%)
 * Likes:    30
 * Dislikes: 0
 * Total Accepted:    1.2K
 * Total Submissions: 3K
 * Testcase Example:  '"13"'
 *
 * 对于给定的整数 n, 如果n的k（k>=2）进制数的所有数位全为1，则称 k（k>=2）是 n 的一个好进制。
 * 
 * 以字符串的形式给出 n, 以字符串的形式返回 n 的最小好进制。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入："13"
 * 输出："3"
 * 解释：13 的 3 进制是 111。
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入："4681"
 * 输出："8"
 * 解释：4681 的 8 进制是 11111。
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入："1000000000000000000"
 * 输出："999999999999999999"
 * 解释：1000000000000000000 的 999999999999999999 进制是 11。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * n的取值范围是 [3, 10^18]。
 * 输入总是有效且没有前导 0。
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public string SmallestGoodBase(string n)
    {
        long N = long.Parse(n);
        for (int m = 59; m >= 2; m--)
        {
            long k = (long)Math.Pow(N, 1.0 / m);
            if (k <= 1) continue;
            long tmp = 0;
            for (int i = 0; i <= m; i++)
            {
                tmp = k * tmp + 1;
            }
            if (tmp == N) return k.ToString();
        }
        return (N - 1).ToString();
    }
}
// @lc code=end

