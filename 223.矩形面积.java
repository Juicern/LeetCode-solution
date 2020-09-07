/*
 * @lc app=leetcode.cn id=223 lang=java
 *
 * [223] 矩形面积
 *
 * https://leetcode-cn.com/problems/rectangle-area/description/
 *
 * algorithms
 * Medium (42.13%)
 * Likes:    59
 * Dislikes: 0
 * Total Accepted:    7.9K
 * Total Submissions: 18.5K
 * Testcase Example:  '-3\n0\n3\n4\n0\n-1\n9\n2'
 *
 * 在二维平面上计算出两个由直线构成的矩形重叠后形成的总面积。
 * 
 * 每个矩形由其左下顶点和右上顶点坐标表示，如图所示。
 * 
 * 
 * 
 * 示例:
 * 
 * 输入: -3, 0, 3, 4, 0, -1, 9, 2
 * 输出: 45
 * 
 * 说明: 假设矩形面积不会超出 int 的范围。
 * 
 */

// @lc code=start
class Solution {
    public int computeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
        long x = (long)Math.min(C, G) - (long)Math.max(A, E);
        long y = (long)Math.min(D, H) - (long)Math.max(B, F);
        long echo = 0;
        if(x>0 && y>0) echo = x*y;
        return (int)((long)(C-A)*(long)(D-B) + (long)(G-E)*(long)(H-F) - echo);
    }
}
// @lc code=end

