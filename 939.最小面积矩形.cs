using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=939 lang=csharp
 *
 * [939] 最小面积矩形
 *
 * https://leetcode-cn.com/problems/minimum-area-rectangle/description/
 *
 * algorithms
 * Medium (42.43%)
 * Likes:    55
 * Dislikes: 0
 * Total Accepted:    3.4K
 * Total Submissions: 8K
 * Testcase Example:  '[[1,1],[1,3],[3,1],[3,3],[2,2]]'
 *
 * 给定在 xy 平面上的一组点，确定由这些点组成的矩形的最小面积，其中矩形的边平行于 x 轴和 y 轴。
 * 
 * 如果没有任何矩形，就返回 0。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[[1,1],[1,3],[3,1],[3,3],[2,2]]
 * 输出：4
 * 
 * 
 * 示例 2：
 * 
 * 输入：[[1,1],[1,3],[3,1],[3,3],[4,1],[4,3]]
 * 输出：2
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= points.length <= 500
 * 0 <= points[i][0] <= 40000
 * 0 <= points[i][1] <= 40000
 * 所有的点都是不同的。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int MinAreaRect(int[][] points) {
        var rows = new Dictionary<int, HashSet<int>>();
        var cols = new Dictionary<int, HashSet<int>>();
        foreach(var point in points) {
            int x = point[0];
            int y = point[1];
            if(!cols.ContainsKey(x)){
                cols.Add(x, new HashSet<int>());
            }
            if(!rows.ContainsKey(y)){
                rows.Add(y, new HashSet<int>());
            }
            cols[x].Add(y);
            rows[y].Add(x);
        }
        int min = int.MaxValue;
        foreach(var point in points){
            int x = point[0];
            int y = point[1];
            var rps = rows[y];
            var cps = cols[x];
            rps.Remove(x);
            cps.Remove(y);
            if(!rps.Any() || !cps.Any()) continue;
            foreach(var rp in rps) {
                int len = Math.Abs(rp - x);
                int width = int.MaxValue;
                foreach(var cp in cps){
                    if(!rows[cp].Contains(rp)) continue;
                    int newWidth = Math.Abs(cp - y);
                    width = Math.Min(width, newWidth);
                }
                if(width != int.MaxValue) {
                    int newArea = width * len;
                    min = Math.Min(min, newArea);
                }
            }
        }
        return min == int.MaxValue ? 0 : min;
    }
}
// @lc code=end

