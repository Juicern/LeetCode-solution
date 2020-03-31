/*
 * @lc app=leetcode.cn id=209 lang=java
 *
 * [209] 长度最小的子数组
 *
 * https://leetcode-cn.com/problems/minimum-size-subarray-sum/description/
 *
 * algorithms
 * Medium (40.82%)
 * Likes:    214
 * Dislikes: 0
 * Total Accepted:    32.6K
 * Total Submissions: 78.1K
 * Testcase Example:  '7\n[2,3,1,2,4,3]'
 *
 * 给定一个含有 n 个正整数的数组和一个正整数 s ，找出该数组中满足其和 ≥ s 的长度最小的连续子数组。如果不存在符合条件的连续子数组，返回 0。
 * 
 * 示例: 
 * 
 * 输入: s = 7, nums = [2,3,1,2,4,3]
 * 输出: 2
 * 解释: 子数组 [4,3] 是该条件下的长度最小的连续子数组。
 * 
 * 
 * 进阶:
 * 
 * 如果你已经完成了O(n) 时间复杂度的解法, 请尝试 O(n log n) 时间复杂度的解法。
 * 
 */

// @lc code=start
class Solution {
    public int minSubArrayLen(int s, int[] nums) {
        int left = 0;
        int right = 0;
        int res = nums.length+1;
        int sum = 0;
        while(left<nums.length){
            if(sum<s && right<nums.length){
                sum += nums[right];
                right++;
            }
            else{
                sum -= nums[left];
                left++;
            }
            if(sum>=s){
                res = Integer.min(res, right-left);
            }
        }
        return res==nums.length+1 ? 0 : res;
    }
}
// @lc code=end

