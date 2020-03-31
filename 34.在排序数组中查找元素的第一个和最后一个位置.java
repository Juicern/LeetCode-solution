/*
 * @lc app=leetcode.cn id=34 lang=java
 *
 * [34] 在排序数组中查找元素的第一个和最后一个位置
 */

// @lc code=start
class Solution {
    public int[] searchRange(int[] nums, int target) {
        if(nums == null || nums.length == 0){
            return new int[]{-1,-1};
        }
        if(nums.length == 1){
            return nums[0] == target ? new int[]{0,0} : new int[]{-1,-1};
        }
        int start = leftSearch(nums,target);
        int end = rightSearch(nums,target);
        return new int[]{start,end};
    }
    public int leftSearch(int[] nums,int target){
        int left = 0;
        int right = nums.length-1;
        while(left <= right){
            int mod = (left + right)/2;
            if(nums[mod] == target){
                right = mod-1;
            }
            if(nums[mod] < target){
                left = mod + 1;
            }
            if(nums[mod] > target){
                right = mod - 1;
            }
        }
        if(left == nums.length){ //注意处理下标越界的情况
            return -1;
        }
        return nums[left] == target ? left : -1;
    }
    public int rightSearch(int[] nums,int target){
        int left = 0;
        int right = nums.length-1;
        while(left <= right){
            int mod = (left + right)/2;
            if(nums[mod] < target){
                left = mod + 1;
            }
            if(nums[mod] > target){
                right = mod - 1;
            }
            if(nums[mod] == target){
                left = mod+1;
            }
        }
        if(right < 0){ //注意处理下标越界的情况
            return right;
        }
        return nums[right] == target ? right : -1;
    }
}
// @lc code=end

