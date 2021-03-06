using System;
using System.Linq;
/*
 * @lc app=leetcode.cn id=410 lang=csharp
 *
 * [410] 分割数组的最大值
 *
 * https://leetcode-cn.com/problems/split-array-largest-sum/description/
 *
 * algorithms
 * Hard (42.86%)
 * Likes:    160
 * Dislikes: 0
 * Total Accepted:    6.8K
 * Total Submissions: 15.8K
 * Testcase Example:  '[7,2,5,10,8]\n2'
 *
 * 给定一个非负整数数组和一个整数 m，你需要将这个数组分成 m 个非空的连续子数组。设计一个算法使得这 m 个子数组各自和的最大值最小。
 * 
 * 注意:
 * 数组长度 n 满足以下条件:
 * 
 * 
 * 1 ≤ n ≤ 1000
 * 1 ≤ m ≤ min(50, n)
 * 
 * 
 * 示例: 
 * 
 * 
 * 输入:
 * nums = [7,2,5,10,8]
 * m = 2
 * 
 * 输出:
 * 18
 * 
 * 解释:
 * 一共有四种方法将nums分割为2个子数组。
 * 其中最好的方式是将其分为[7,2,5] 和 [10,8]，
 * 因为此时这两个子数组各自的和的最大值为18，在所有情况中最小。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int SplitArray(int[] nums, int m)
    {
        long left = nums.Max();
        long right = 0;
        foreach (int num in nums)
        {
            right += num;
        }
        while (left < right)
        {
            long mid = left + (right - left) / 2;
            long temp = 0;
            int count = 1;
            foreach (int num in nums)
            {
                temp += num;
                if (temp > mid)
                {
                    temp = num;
                    count++;
                }
            }
            if (count > m) left = mid + 1;
            else right = mid;
        }
        return (int)left;
    }
}
// @lc code=end

