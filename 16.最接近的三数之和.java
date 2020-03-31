import java.util.*;
/*
 * @lc app=leetcode.cn id=16 lang=java
 *
 * [16] 最接近的三数之和
 *
 * https://leetcode-cn.com/problems/3sum-closest/description/
 *
 * algorithms
 * Medium (42.61%)
 * Likes:    367
 * Dislikes: 0
 * Total Accepted:    77.4K
 * Total Submissions: 179.6K
 * Testcase Example:  '[-1,2,1,-4]\n1'
 *
 * 给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target
 * 最接近。返回这三个数的和。假定每组输入只存在唯一答案。
 * 
 * 例如，给定数组 nums = [-1，2，1，-4], 和 target = 1.
 * 
 * 与 target 最接近的三个数的和为 2. (-1 + 2 + 1 = 2).
 * 
 * 
 */

// @lc code=start
class Solution {
    public int threeSumClosest(int[] nums, int target) {
        Arrays.sort(nums);
        int result = nums[0]+ nums[1] + nums[2];
        int distance = Integer.MAX_VALUE;
        for(int i=0;i<nums.length;i++){
            int left = i+1;
            int right = nums.length-1; 
            while(left < right){
                int sum = nums[i] + nums[left] + nums[right];
                if(sum==target){
                    return target;
                }
                else if(sum < target){
                    left++;
                    if(target-sum < distance){
                        distance = target - sum;
                        result = sum;
                    }
                }
                else{
                    right--;
                    if(sum-target < distance){
                        distance = sum- target;
                        result = sum;
                    }
                }
            }
        }
        return result;
    }
}
// @lc code=end

