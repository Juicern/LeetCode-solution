/*
 * @lc app=leetcode.cn id=42 lang=java
 *
 * [42] 接雨水
 *
 * https://leetcode-cn.com/problems/trapping-rain-water/description/
 *
 * algorithms
 * Hard (48.07%)
 * Likes:    907
 * Dislikes: 0
 * Total Accepted:    59.9K
 * Total Submissions: 122K
 * Testcase Example:  '[0,1,0,2,1,0,1,3,2,1,2,1]'
 *
 * 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
 * 
 * 
 * 
 * 上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 感谢
 * Marcos 贡献此图。
 * 
 * 示例:
 * 
 * 输入: [0,1,0,2,1,0,1,3,2,1,2,1]
 * 输出: 6
 * 
 */

// @lc code=start
class Solution {
    public int trap(int[] height) {
        if(height.length==0) return 0;
        int ans = 0;
        int len = height.length;
        int[] left_max = new int[len];
        int[] right_max = new int[len];
        left_max[0] = height[0];
        right_max[len-1] = height[len-1];
        for(int i=1;i<len;i++){
            left_max[i] = Integer.max(left_max[i-1], height[i]);
        }
        for(int i=len-2;i>=0;i--){
            right_max[i] = Integer.max(right_max[i+1], height[i]);
        }
        for(int i=0;i<len;i++){
            ans += Integer.min(left_max[i], right_max[i]) - height[i];
        }
        return ans;
    }
}
// @lc code=end

