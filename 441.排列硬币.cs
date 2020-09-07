/*
 * @lc app=leetcode.cn id=441 lang=csharp
 *
 * [441] 排列硬币
 *
 * https://leetcode-cn.com/problems/arranging-coins/description/
 *
 * algorithms
 * Easy (40.83%)
 * Likes:    58
 * Dislikes: 0
 * Total Accepted:    21.4K
 * Total Submissions: 52.5K
 * Testcase Example:  '5'
 *
 * 你总共有 n 枚硬币，你需要将它们摆成一个阶梯形状，第 k 行就必须正好有 k 枚硬币。
 * 
 * 给定一个数字 n，找出可形成完整阶梯行的总行数。
 * 
 * n 是一个非负整数，并且在32位有符号整型的范围内。
 * 
 * 示例 1:
 * 
 * 
 * n = 5
 * 
 * 硬币可排列成以下几行:
 * ¤
 * ¤ ¤
 * ¤ ¤
 * 
 * 因为第三行不完整，所以返回2.
 * 
 * 
 * 示例 2:
 * 
 * 
 * n = 8
 * 
 * 硬币可排列成以下几行:
 * ¤
 * ¤ ¤
 * ¤ ¤ ¤
 * ¤ ¤
 * 
 * 因为第四行不完整，所以返回3.
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int ArrangeCoins(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        long left = 0;
        long right = n;
        while (left <= right)
        {
            long mid = left + (right - left) / 2;
            if (mid * mid + mid <= 2 * (long)n) left = mid + 1;
            else if (mid * mid - mid > 2 * (long)n) right = mid;
            else return (int)(mid - 1);
        }
        return (int)left;
    }
}
// @lc code=end

