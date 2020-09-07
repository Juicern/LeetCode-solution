/*
 * @lc app=leetcode.cn id=643 lang=java
 *
 * [643] 子数组最大平均数 I
 *
 * https://leetcode-cn.com/problems/maximum-average-subarray-i/description/
 *
 * algorithms
 * Easy (38.25%)
 * Likes:    86
 * Dislikes: 0
 * Total Accepted:    13.9K
 * Total Submissions: 36.2K
 * Testcase Example:  '[1,12,-5,-6,50,3]\n4'
 *
 * 给定 n 个整数，找出平均数最大且长度为 k 的连续子数组，并输出该最大平均数。
 * 
 * 示例 1:
 * 
 * 输入: [1,12,-5,-6,50,3], k = 4
 * 输出: 12.75
 * 解释: 最大平均数 (12-5-6+50)/4 = 51/4 = 12.75
 * 
 * 
 * 
 * 
 * 注意:
 * 
 * 
 * 1 <= k <= n <= 30,000。
 * 所给数据范围 [-10,000，10,000]。
 * 
 * 
 */

// @lc code=start
class Solution {
    public double findMaxAverage(int[] nums, int k) {
        double max = Double.MIN_VALUE;
        int sum = 0;
        for (int i=0;i<k;i++) sum += nums[i];
        max = sum*1.0 / k;
        for (int i=1;i<=nums.length-k;i++) {
            sum = sum - nums[i-1] + nums[i+k-1];
            max = Math.max(max, sum*1.0 / k);
        }
        return max;
    }
}
// @lc code=end

