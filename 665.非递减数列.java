/*
 * @lc app=leetcode.cn id=665 lang=java
 *
 * [665] 非递减数列
 *
 * https://leetcode-cn.com/problems/non-decreasing-array/description/
 *
 * algorithms
 * Easy (22.16%)
 * Likes:    261
 * Dislikes: 0
 * Total Accepted:    18.2K
 * Total Submissions: 82K
 * Testcase Example:  '[4,2,3]'
 *
 * 给你一个长度为 n 的整数数组，请你判断在 最多 改变 1 个元素的情况下，该数组能否变成一个非递减数列。
 * 
 * 我们是这样定义一个非递减数列的： 对于数组中所有的 i (1 <= i < n)，总满足 array[i] <= array[i + 1]。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: nums = [4,2,3]
 * 输出: true
 * 解释: 你可以通过把第一个4变成1来使得它成为一个非递减数列。
 * 
 * 
 * 示例 2:
 * 
 * 输入: nums = [4,2,1]
 * 输出: false
 * 解释: 你不能在只改变一个元素的情况下将其变为非递减数列。
 * 
 * 
 * 
 * 
 * 说明：
 * 
 * 
 * 1 <= n <= 10 ^ 4
 * - 10 ^ 5 <= nums[i] <= 10 ^ 5
 * 
 * 
 */

// @lc code=start
class Solution {
    public boolean checkPossibility(int[] nums) {
        boolean flag = true;
        if(nums.length==1) return true;
        if(nums[0] > nums[1]) {
            nums[0] = nums[1];
            flag = false;
        }
        for(int i=1;i<nums.length;i++) { 
            if(nums[i] >= nums[i-1]) { 
                if(i<nums.length-1 && nums[i] > nums[i+1] && nums[i+1] >= nums[i-1]) {
                    if(!flag) return false;
                    nums[i] = nums[i-1];
                    flag = false;
                }
            }
            else if(nums[i] < nums[i-1]) {
                if(!flag) return false;
                nums[i] = nums[i-1];
                flag = false;
            }
        }
        return true;
    }
}
// @lc code=end
