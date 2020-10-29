using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=525 lang=csharp
 *
 * [525] 连续数组
 *
 * https://leetcode-cn.com/problems/contiguous-array/description/
 *
 * algorithms
 * Medium (44.19%)
 * Likes:    185
 * Dislikes: 0
 * Total Accepted:    7.5K
 * Total Submissions: 17K
 * Testcase Example:  '[0,1]'
 *
 * 给定一个二进制数组, 找到含有相同数量的 0 和 1 的最长连续子数组（的长度）。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: [0,1]
 * 输出: 2
 * 说明: [0, 1] 是具有相同数量0和1的最长连续子数组。
 * 
 * 示例 2:
 * 
 * 输入: [0,1,0]
 * 输出: 2
 * 说明: [0, 1] (或 [1, 0]) 是具有相同数量0和1的最长连续子数组。
 * 
 * 
 * 
 * 注意: 给定的二进制数组的长度不会超过50000。
 * 
 */

// @lc code=start
public class Solution {
    public int FindMaxLength(int[] nums) {
        var dict = new Dictionary<int, int>();
        dict[0] = -1;
        int maxLen = 0;
        int count = 0;
        for (int i = 0;i<nums.Length;i++) {
            count += (nums[i] == 1 ? 1 : -1);
            if(dict.ContainsKey(count)) {
                maxLen = Math.Max(maxLen, i - dict[count]);
            }
            else {
                dict[count] = i;
            }
        }
        return maxLen;
    }
}
// @lc code=end

