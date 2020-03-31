/*
 * @lc app=leetcode.cn id=152 lang=java
 *
 * [152] 乘积最大子序列
 *
 * https://leetcode-cn.com/problems/maximum-product-subarray/description/
 *
 * algorithms
 * Medium (36.66%)
 * Likes:    418
 * Dislikes: 0
 * Total Accepted:    41K
 * Total Submissions: 109K
 * Testcase Example:  '[2,3,-2,4]'
 *
 * 给定一个整数数组 nums ，找出一个序列中乘积最大的连续子序列（该序列至少包含一个数）。
 * 
 * 示例 1:
 * 
 * 输入: [2,3,-2,4]
 * 输出: 6
 * 解释: 子数组 [2,3] 有最大乘积 6。
 * 
 * 
 * 示例 2:
 * 
 * 输入: [-2,0,-1]
 * 输出: 0
 * 解释: 结果不能为 2, 因为 [-2,-1] 不是子数组。
 * 
 */

// @lc code=start
class Solution {
    public int maxProduct(int[] nums) {
        int max = Integer.MIN_VALUE, imax = 1, imin = 1;
        int n = nums.length;
        for(int i=0;i<n;i++){
            if(nums[i]<0){
                int tmp = imax;
                imax = imin;
                imin = tmp;
            }
            imax = Integer.max(nums[i], imax*nums[i]);
            imin = Integer.min(nums[i], imin*nums[i]);
            max = Integer.max(max, imax);
        }
        return max;
    }
}
// @lc code=end

