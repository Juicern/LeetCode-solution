/*
 * @lc app=leetcode.cn id=594 lang=javascript
 *
 * [594] 最长和谐子序列
 *
 * https://leetcode-cn.com/problems/longest-harmonious-subsequence/description/
 *
 * algorithms
 * Easy (48.88%)
 * Likes:    130
 * Dislikes: 0
 * Total Accepted:    17K
 * Total Submissions: 34.8K
 * Testcase Example:  '[1,3,2,2,5,2,3,7]'
 *
 * 和谐数组是指一个数组里元素的最大值和最小值之间的差别正好是1。
 * 
 * 现在，给定一个整数数组，你需要在所有可能的子序列中找到最长的和谐子序列的长度。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,3,2,2,5,2,3,7]
 * 输出: 5
 * 原因: 最长的和谐数组是：[3,2,2,2,3].
 * 
 * 
 * 说明: 输入的数组长度最大不超过20,000.
 * 
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var findLHS = function(nums) {
    let ans = 0;
    let map = new Map();
    for(let num of nums) {
        map.set(num, (map.get(num) || 0) + 1);
        if(map.get(num - 1) === undefined && map.get(num + 1) ===  undefined) continue;
        ans = Math.max(ans, map.get(num) + Math.max(map.get(num - 1) || 0, map.get(num + 1) || 0));
    }
    return ans;
};
// @lc code=end

