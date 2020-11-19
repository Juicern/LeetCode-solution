using System;
/*
 * @lc app=leetcode.cn id=593 lang=csharp
 *
 * [593] 有效的正方形
 *
 * https://leetcode-cn.com/problems/valid-square/description/
 *
 * algorithms
 * Medium (44.05%)
 * Likes:    50
 * Dislikes: 0
 * Total Accepted:    5.6K
 * Total Submissions: 12.8K
 * Testcase Example:  '[0,0]\n[1,1]\n[1,0]\n[0,1]'
 *
 * 给定二维空间中四点的坐标，返回四点是否可以构造一个正方形。
 * 
 * 一个点的坐标（x，y）由一个有两个整数的整数数组表示。
 * 
 * 示例:
 * 
 * 
 * 输入: p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
 * 输出: True
 * 
 * 
 * 
 * 
 * 注意:
 * 
 * 
 * 所有输入整数都在 [-10000，10000] 范围内。
 * 一个有效的正方形有四个等长的正长和四个等角（90度角）。
 * 输入点没有顺序。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        int[][] points = {p1, p2, p3, p4};
        var set = new HashSet<double>();
        for(int i = 0;i<3;i++) {
            for(int j = i + 1;j<4;j++) {
                double d = Math.Pow(points[i][0] - points[j][0], 2) + Math.Pow(points[i][1] - points[j][1], 2) ;
                if(d == 0) return false;
                set.Add(d);
            }
        }
        return set.Count <= 2;
    }
}
// @lc code=end

