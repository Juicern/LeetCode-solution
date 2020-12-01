/*
 * @lc app=leetcode.cn id=34 lang=csharp
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 *
 * https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
 *
 * algorithms
 * Medium (40.60%)
 * Likes:    724
 * Dislikes: 0
 * Total Accepted:    170.2K
 * Total Submissions: 410.2K
 * Testcase Example:  '[5,7,7,8,8,10]\n8'
 *
 * 给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
 * 
 * 如果数组中不存在目标值 target，返回 [-1, -1]。
 * 
 * 进阶：
 * 
 * 
 * 你可以设计并实现时间复杂度为 O(log n) 的算法解决此问题吗？
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：nums = [5,7,7,8,8,10], target = 8
 * 输出：[3,4]
 * 
 * 示例 2：
 * 
 * 
 * 输入：nums = [5,7,7,8,8,10], target = 6
 * 输出：[-1,-1]
 * 
 * 示例 3：
 * 
 * 
 * 输入：nums = [], target = 0
 * 输出：[-1,-1]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 
 * -10^9 
 * nums 是一个非递减数组
 * -10^9 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int left = BinarySearch(nums, target, true);
        if(left >= nums.Length || nums[left] != target) return new int[]{-1, -1};
        int right = BinarySearch(nums, target, false) - 1;
        return new int[]{left, right};
    }
    public int BinarySearch(int[] nums, int target, bool lower) {
        int left = 0;
        int right = nums.Length - 1;
        int ans  = nums.Length;
        while(left <= right) {

            int mid = (right - left) / 2 + left;
            if(nums[mid] > target ||(nums[mid] == target) && lower) {
                right = mid -1;
                ans = mid;
            }
            else {
                left  = mid + 1;
            }
        }
        return ans;
    }

}
// @lc code=end

