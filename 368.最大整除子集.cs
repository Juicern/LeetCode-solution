using System;
using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode.cn id=368 lang=csharp
 *
 * [368] 最大整除子集
 *
 * https://leetcode-cn.com/problems/largest-divisible-subset/description/
 *
 * algorithms
 * Medium (38.05%)
 * Likes:    121
 * Dislikes: 0
 * Total Accepted:    8.2K
 * Total Submissions: 21.6K
 * Testcase Example:  '[1,2,3]'
 *
 * 给出一个由无重复的正整数组成的集合，找出其中最大的整除子集，子集中任意一对 (Si，Sj) 都要满足：Si % Sj = 0 或 Sj % Si =
 * 0。
 * 
 * 如果有多个目标子集，返回其中任何一个均可。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: [1,2,3]
 * 输出: [1,2] (当然, [1,3] 也正确)
 * 
 * 
 * 示例 2:
 * 
 * 输入: [1,2,4,8]
 * 输出: [1,2,4,8]
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return nums;
        }

        Array.Sort(nums);
        int max = 0, index = -1;
        int[] d = new int[nums.Length];
        int[] pre = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            d[i] = 1;
            pre[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && d[i] < (1 + d[j]))
                {
                    d[i] = 1 + d[j];
                    pre[i] = j;
                }
            }

            if (d[i] > max)
            {
                max = d[i];
                index = i;
            }
        }

        List<int> result = new List<int>();
        while (index >= 0)
        {
            result.Add(nums[index]);
            index = pre[index];
        }

        return result;
    }
}
// @lc code=end

