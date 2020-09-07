using System;
/*
 * @lc app=leetcode.cn id=673 lang=csharp
 *
 * [673] 最长递增子序列的个数
 *
 * https://leetcode-cn.com/problems/number-of-longest-increasing-subsequence/description/
 *
 * algorithms
 * Medium (35.69%)
 * Likes:    183
 * Dislikes: 0
 * Total Accepted:    11K
 * Total Submissions: 30.7K
 * Testcase Example:  '[1,3,5,4,7]'
 *
 * 给定一个未排序的整数数组，找到最长递增子序列的个数。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,3,5,4,7]
 * 输出: 2
 * 解释: 有两个最长递增子序列，分别是 [1, 3, 4, 7] 和[1, 3, 5, 7]。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [2,2,2,2,2]
 * 输出: 5
 * 解释: 最长递增子序列的长度是1，并且存在5个子序列的长度为1，因此输出5。
 * 
 * 
 * 注意: 给定的数组长度不超过 2000 并且结果一定是32位有符号整数。
 * 
 */

// @lc code=start
public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return n;
        var lengths = new int[n];
        var counts = new int[n];
        Array.Fill(counts, 1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    if (lengths[j] >= lengths[i])
                    {
                        lengths[i] = lengths[j] + 1;
                        counts[i] = counts[j];
                    }
                    else if (lengths[j] + 1 == lengths[i])
                    {
                        counts[i] += counts[j];
                    }
                }
            }
        }
        int longest = 0;
        int ans = 0;
        foreach (var length in lengths)
        {
            longest = Math.Max(longest, length);
        }
        for (int i = 0; i < n; i++)
        {
            if (lengths[i] == longest) ans += counts[i];
        }
        return ans;
    }
}
// @lc code=end

