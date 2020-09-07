/*
 * @lc app=leetcode.cn id=713 lang=csharp
 *
 * [713] 乘积小于K的子数组
 *
 * https://leetcode-cn.com/problems/subarray-product-less-than-k/description/
 *
 * algorithms
 * Medium (35.29%)
 * Likes:    117
 * Dislikes: 0
 * Total Accepted:    6.2K
 * Total Submissions: 17.6K
 * Testcase Example:  '[10,5,2,6]\n100'
 *
 * 给定一个正整数数组 nums。
 * 
 * 找出该数组内乘积小于 k 的连续的子数组的个数。
 * 
 * 示例 1:
 * 
 * 
 * 输入: nums = [10,5,2,6], k = 100
 * 输出: 8
 * 解释: 8个乘积小于100的子数组分别为: [10], [5], [2], [6], [10,5], [5,2], [2,6], [5,2,6]。
 * 需要注意的是 [10,5,2] 并不是乘积小于100的子数组。
 * 
 * 
 * 说明:
 * 
 * 
 * 0 < nums.length <= 50000
 * 0 < nums[i] < 1000
 * 0 <= k < 10^6
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1) return 0;
        int mul = 1;
        int ans = 0;
        int left = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            mul *= nums[right];
            while(mul>=k) mul /= nums[left++];
            ans += right-left+1;
        }
        return ans;
    }
}
// @lc code=end

