using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=447 lang=csharp
 *
 * [447] 回旋镖的数量
 *
 * https://leetcode-cn.com/problems/number-of-boomerangs/description/
 *
 * algorithms
 * Easy (58.63%)
 * Likes:    113
 * Dislikes: 0
 * Total Accepted:    16.3K
 * Total Submissions: 27.8K
 * Testcase Example:  '[[0,0],[1,0],[2,0]]'
 *
 * 给定平面上 n 对不同的点，“回旋镖” 是由点表示的元组 (i, j, k) ，其中 i 和 j 之间的距离和 i 和 k
 * 之间的距离相等（需要考虑元组的顺序）。
 * 
 * 找到所有回旋镖的数量。你可以假设 n 最大为 500，所有点的坐标在闭区间 [-10000, 10000] 中。
 * 
 * 示例:
 * 
 * 
 * 输入:
 * [[0,0],[1,0],[2,0]]
 * 
 * 输出:
 * 2
 * 
 * 解释:
 * 两个回旋镖为 [[1,0],[0,0],[2,0]] 和 [[1,0],[2,0],[0,0]]
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int NumberOfBoomerangs(int[][] points) {
        int ans = 0;
        for(int i = 0;i<points.Length;i++) {
            Dictionary<int, int> record = new Dictionary<int, int>();
            for(int j = 0;j<points.Length;j++) {
                if(j == i) continue;
                int distance = Distance(points[i], points[j]);
                if(!record.ContainsKey(distance)) record.Add(distance, 0);
                record[distance]++;
            }
            foreach(var value in record.Values) {
                if(value >= 2) ans += value * (value - 1);
            }
        }
        return ans;
    }
    private int Distance(int[] x, int[] y) {
        return (x[0] - y[0]) * (x[0] - y[0]) + (x[1] - y[1]) * (x[1] - y[1]);
    }
}
// @lc code=end

