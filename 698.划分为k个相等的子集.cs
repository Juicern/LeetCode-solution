/*
 * @lc app=leetcode.cn id=698 lang=csharp
 *
 * [698] 划分为k个相等的子集
 *
 * https://leetcode-cn.com/problems/partition-to-k-equal-sum-subsets/description/
 *
 * algorithms
 * Medium (42.83%)
 * Likes:    218
 * Dislikes: 0
 * Total Accepted:    14.1K
 * Total Submissions: 33K
 * Testcase Example:  '[4,3,2,3,5,2,1]\n4'
 *
 * 给定一个整数数组  nums 和一个正整数 k，找出是否有可能把这个数组分成 k 个非空子集，其总和都相等。
 * 
 * 示例 1：
 * 
 * 输入： nums = [4, 3, 2, 3, 5, 2, 1], k = 4
 * 输出： True
 * 说明： 有可能将其分成 4 个子集（5），（1,4），（2,3），（2,3）等于总和。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= k <= len(nums) <= 16
 * 0 < nums[i] < 10000
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        if(nums.Sum() % k != 0 || nums.Max() > nums.Sum() / k) return false;
        return BackTracking(nums, k, nums.Sum() / k, 0, 0, new bool[nums.Length + 1]);
    }
    private bool BackTracking(int[] nums, int k, int target, int start, int cur, bool[] used) {
        if(k == 0) return true;
        if(cur == target) 
        {
            return BackTracking(nums, k - 1, target, 0, 0, used);
        }
        for(int i = start; i < nums.Length; i++)
        {
            if(!used[i] && nums[i] + cur <= target) {
                used[i] = true;
                if(BackTracking(nums, k, target, i + 1, cur + nums[i], used)) return true;
                used[i] = false;
            }
        }
        return false;
    }
}
// @lc code=end

