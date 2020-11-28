using System.Security.AccessControl;
using System;
/*
 * @lc app=leetcode.cn id=493 lang=csharp
 *
 * [493] 翻转对
 *
 * https://leetcode-cn.com/problems/reverse-pairs/description/
 *
 * algorithms
 * Hard (28.87%)
 * Likes:    195
 * Dislikes: 0
 * Total Accepted:    13.5K
 * Total Submissions: 44.2K
 * Testcase Example:  '[1,3,2,3,1]'
 *
 * 给定一个数组 nums ，如果 i < j 且 nums[i] > 2*nums[j] 我们就将 (i, j) 称作一个重要翻转对。
 * 
 * 你需要返回给定数组中的重要翻转对的数量。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,3,2,3,1]
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [2,4,3,5,1]
 * 输出: 3
 * 
 * 
 * 注意:
 * 
 * 
 * 给定数组的长度不会超过50000。
 * 输入数组中的所有数字都在32位整数的表示范围内。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int ReversePairs(int[] nums) {
        if(nums.Length == 0) return 0;
        return Merge(nums, 0, nums.Length - 1);
    }
    private int Merge(int[] nums, int start, int end) {
        if(start == end) return 0;
        int mid = (end - start) / 2 + start;
        int ans = Merge(nums, start, mid) + Merge(nums, mid + 1, end);
        int p1 = start;
        int p2 = mid + 1;
        while(p1 <= mid) {
            while(p2 <= end && nums[p1] / 2.0 > nums[p2]) p2++;
            ans += p2 - mid - 1;
            p1++;
        }
        p1 = start;
        p2 = mid + 1;
        var temp = new int[end - start + 1];
        int index = 0;
        while(index < temp.Length) {
            if(p1 == mid + 1){
                temp[index++] = nums[p2++];
            }
            else if(p2 == end + 1) {
                temp[index++] = nums[p1++];
            }
            else {
                if(nums[p1] < nums[p2]) {
                    temp[index++] = nums[p1++];
                }
                else{
                    temp[index++] = nums[p2++];
                }
            }
        }
        for(int i = 0;i<temp.Length;i++) {
            nums[start + i] = temp[i];
        }
        return ans;
    }
}
// @lc code=end

