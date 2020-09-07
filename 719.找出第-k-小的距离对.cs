using System;
/*
 * @lc app=leetcode.cn id=719 lang=csharp
 *
 * [719] 找出第 k 小的距离对
 *
 * https://leetcode-cn.com/problems/find-k-th-smallest-pair-distance/description/
 *
 * algorithms
 * Hard (31.94%)
 * Likes:    77
 * Dislikes: 0
 * Total Accepted:    3.5K
 * Total Submissions: 11K
 * Testcase Example:  '[1,3,1]\n1'
 *
 * 给定一个整数数组，返回所有数对之间的第 k 个最小距离。一对 (A, B) 的距离被定义为 A 和 B 之间的绝对差值。
 * 
 * 示例 1:
 * 
 * 
 * 输入：
 * nums = [1,3,1]
 * k = 1
 * 输出：0 
 * 解释：
 * 所有数对如下：
 * (1,3) -> 2
 * (1,1) -> 0
 * (3,1) -> 2
 * 因此第 1 个最小距离的数对是 (1,1)，它们之间的距离为 0。
 * 
 * 
 * 提示:
 * 
 * 
 * 2 <= len(nums) <= 10000.
 * 0 <= nums[i] < 1000000.
 * 1 <= k <= len(nums) * (len(nums) - 1) / 2.
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private int findPair(int[] nums, int target)
    {
        int end = 0;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            while (end < nums.Length && nums[end] - nums[i] <= target) end++;
            count += end - i - 1;
        }
        return count;
    }
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0;
        int right = nums[nums.Length - 1] - nums[0];
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (findPair(nums, mid) < k) left = mid + 1;
            else right = mid;
        }
        return left;
    }
}
// @lc code=end

