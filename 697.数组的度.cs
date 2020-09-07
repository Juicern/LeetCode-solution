using System.Numerics;
using System;
using System.Threading;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;
/*
 * @lc app=leetcode.cn id=697 lang=csharp
 *
 * [697] 数组的度
 *
 * https://leetcode-cn.com/problems/degree-of-an-array/description/
 *
 * algorithms
 * Easy (52.64%)
 * Likes:    121
 * Dislikes: 0
 * Total Accepted:    15.5K
 * Total Submissions: 29.2K
 * Testcase Example:  '[1,2,2,3,1]'
 *
 * 给定一个非空且只包含非负数的整数数组 nums, 数组的度的定义是指数组里任一元素出现频数的最大值。
 * 
 * 你的任务是找到与 nums 拥有相同大小的度的最短连续子数组，返回其长度。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1, 2, 2, 3, 1]
 * 输出: 2
 * 解释: 
 * 输入数组的度是2，因为元素1和2的出现频数最大，均为2.
 * 连续子数组里面拥有相同度的有如下所示:
 * [1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
 * 最短连续子数组[2, 2]的长度为2，所以返回2.
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [1,2,2,3,1,4,2]
 * 输出: 6
 * 
 * 
 * 注意:
 * 
 * 
 * nums.length 在1到50,000区间范围内。
 * nums[i] 是一个在0到49,999范围内的整数。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int FindShortestSubArray(int[] nums)
    {
        Dictionary<int, int> left = new Dictionary<int, int>();
        Dictionary<int, int> right = new Dictionary<int, int>();
        Dictionary<int, int> count = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int x = nums[i];
            if (!left.ContainsKey(x)) left.Add(x, i);
            if (right.ContainsKey(x)) right[x] = i;
            else right.Add(x, i);
            if (count.ContainsKey(x)) count[x]++;
            else count.Add(x, 1);
        }
        int ans = nums.Length;
        int degree = count.Values.Max();
        foreach (int key in count.Keys)
        {
            if (count[key] == degree)
            {
                ans = Math.Min(ans, right[key] - left[key] + 1);
            }
        }
        return ans;
    }
}
// @lc code=end

