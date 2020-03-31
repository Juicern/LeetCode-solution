import java.util.*;
/*
 * @lc app=leetcode.cn id=31 lang=java
 *
 * [31] 下一个排列
 *
 * https://leetcode-cn.com/problems/next-permutation/description/
 *
 * algorithms
 * Medium (32.58%)
 * Likes:    399
 * Dislikes: 0
 * Total Accepted:    45K
 * Total Submissions: 136.6K
 * Testcase Example:  '[1,2,3]'
 *
 * 实现获取下一个排列的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。
 * 
 * 如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。
 * 
 * 必须原地修改，只允许使用额外常数空间。
 * 
 * 以下是一些例子，输入位于左侧列，其相应输出位于右侧列。
 * 1,2,3 → 1,3,2
 * 3,2,1 → 1,2,3
 * 1,1,5 → 1,5,1
 * 
 */

// @lc code=start
class Solution {
    public void nextPermutation(int[] nums) {
        int swap_index1 = nums.length-1;
        int swap_index2 = nums.length-1;
        int swap = nums[nums.length-1];
        boolean flag = false;
        for(int i=nums.length-2;i>=0;i--){
            if(nums[i]<nums[i+1]){
                swap_index1 = i;
                swap = nums[i];
                flag = true;
                break;
            }
        }
        if(!flag){
            Arrays.sort(nums);
            return;
        }
        for(int i=swap_index1+1;i<nums.length;i++){
            if(nums[i]<=swap){
                swap_index2 = i-1;
                break;
            }
        }
        nums[swap_index1] = nums[swap_index2];
        nums[swap_index2] = swap;
        int start = swap_index1+1;
        int end = nums.length-1;
        while(start<end){
            int tmp = nums[start];
            nums[start] = nums[end];
            nums[end] = tmp;
            start++;
            end--;
        }
    }
}
// @lc code=end

