using System;
/*
 * @lc app=leetcode.cn id=679 lang=csharp
 *
 * [679] 24 点游戏
 *
 * https://leetcode-cn.com/problems/24-game/description/
 *
 * algorithms
 * Hard (44.29%)
 * Likes:    112
 * Dislikes: 0
 * Total Accepted:    5.4K
 * Total Submissions: 12.1K
 * Testcase Example:  '[4,1,8,7]'
 *
 * 你有 4 张写有 1 到 9 数字的牌。你需要判断是否能通过 *，/，+，-，(，) 的运算得到 24。
 * 
 * 示例 1:
 * 
 * 输入: [4, 1, 8, 7]
 * 输出: True
 * 解释: (8-4) * (7-1) = 24
 * 
 * 
 * 示例 2:
 * 
 * 输入: [1, 2, 1, 2]
 * 输出: False
 * 
 * 
 * 注意:
 * 
 * 
 * 除法运算符 / 表示实数除法，而不是整数除法。例如 4 / (1 - 2/3) = 12 。
 * 每个运算符对两个数进行运算。特别是我们不能用 - 作为一元运算符。例如，[1, 1, 1, 1] 作为输入时，表达式 -1 - 1 - 1 - 1
 * 是不允许的。
 * 你不能将数字连接在一起。例如，输入为 [1, 2, 1, 2] 时，不能写成 12 + 12 。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public double EPS = 0.001;
    public bool JudgePoint24(int[] nums)
    {
        double[] n = new double[4];
        for (int i = 0; i < 4; i++)
        {
            n[i] = nums[i];
        }
        return Dfs(n);
    }
    private bool Dfs(double[] nums)
    {
        int n = nums.Length;
        if (n == 1) return Math.Abs(nums[0] - 24) < EPS;
        double[] left = new double[n - 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                double a = nums[i];
                double b = nums[j];
                for (int k = 0, l = 0; k < n; k++)
                {
                    if (k != i && k != j)
                    {
                        left[l] = nums[k];
                        l++;
                    }
                }
                left[n - 2] = a + b;
                if (Dfs(left)) return true;
                left[n - 2] = a - b;
                if (Dfs(left)) return true;
                left[n - 2] = a * b;
                if (Dfs(left)) return true;
                left[n - 2] = a / b;
                if (Dfs(left)) return true;
                left[n - 2] = b - a;
                if (Dfs(left)) return true;
                left[n - 2] = b / a;
                if (Dfs(left)) return true;
            }
        }
        return false;
    }
}
// @lc code=end

