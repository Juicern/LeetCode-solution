/*
 * @lc app=leetcode.cn id=371 lang=csharp
 *
 * [371] 两整数之和
 *
 * https://leetcode-cn.com/problems/sum-of-two-integers/description/
 *
 * algorithms
 * Easy (55.99%)
 * Likes:    317
 * Dislikes: 0
 * Total Accepted:    38K
 * Total Submissions: 67.4K
 * Testcase Example:  '1\n2'
 *
 * 不使用运算符 + 和 - ​​​​​​​，计算两整数 ​​​​​​​a 、b ​​​​​​​之和。
 * 
 * 示例 1:
 * 
 * 输入: a = 1, b = 2
 * 输出: 3
 * 
 * 
 * 示例 2:
 * 
 * 输入: a = -2, b = 3
 * 输出: 1
 * 
 */

// @lc code=start
public class Solution
{
    public int GetSum(int a, int b)
    {
        if (a == 0) return b;
        if (b == 0) return a;
        int lower;
        int carrier;
        while (true)
        {
            lower = a ^ b;    // 计算低位
            carrier = a & b;  // 计算进位
            if (carrier == 0) break;
            a = lower;
            b = carrier << 1;
        }
        return lower;
    }
}
// @lc code=end

