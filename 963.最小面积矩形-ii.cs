using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=963 lang=csharp
 *
 * [963] 最小面积矩形 II
 *
 * https://leetcode-cn.com/problems/minimum-area-rectangle-ii/description/
 *
 * algorithms
 * Medium (47.45%)
 * Likes:    25
 * Dislikes: 0
 * Total Accepted:    1.4K
 * Total Submissions: 3K
 * Testcase Example:  '[[1,2],[2,1],[1,0],[0,1]]'
 *
 * 给定在 xy 平面上的一组点，确定由这些点组成的任何矩形的最小面积，其中矩形的边不一定平行于 x 轴和 y 轴。
 * 
 * 如果没有任何矩形，就返回 0。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 
 * 输入：[[1,2],[2,1],[1,0],[0,1]]
 * 输出：2.00000
 * 解释：最小面积的矩形出现在 [1,2],[2,1],[1,0],[0,1] 处，面积为 2。
 * 
 * 示例 2：
 * 
 * 
 * 
 * 输入：[[0,1],[2,1],[1,1],[1,0],[2,0]]
 * 输出：1.00000
 * 解释：最小面积的矩形出现在 [1,0],[1,1],[2,1],[2,0] 处，面积为 1。
 * 
 * 
 * 示例 3：
 * 
 * 
 * 
 * 输入：[[0,3],[1,2],[3,1],[1,3],[2,1]]
 * 输出：0
 * 解释：没法从这些点中组成任何矩形。
 * 
 * 
 * 示例 4：
 * 
 * 
 * 
 * 输入：[[3,1],[1,1],[0,1],[2,1],[3,3],[3,2],[0,2],[2,3]]
 * 输出：2.00000
 * 解释：最小面积的矩形出现在 [2,1],[2,3],[3,3],[3,1] 处，面积为 2。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= points.length <= 50
 * 0 <= points[i][0] <= 40000
 * 0 <= points[i][1] <= 40000
 * 所有的点都是不同的。
 * 与真实值误差不超过 10^-5 的答案将视为正确结果。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public double MinAreaFreeRect(int[][] points)
    {
        if (points.Length < 4) return 0.0;
        double ans = double.MaxValue;
        var dic = new Dictionary<string, List<int[]>>();
        for (int i = 0; i < points.Length - 1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                int[] p1 = points[i];
                int[] p2 = points[j];
                double dis = Distance(p1, p2);
                double centerX = (double)(p1[0] + p2[0]) / 2;
                double centerY = (double)(p1[1] + p2[1]) / 2;
                var key = dis + " " + centerX + " " + centerY ;
                if (!dic.ContainsKey(key)) dic.Add(key, new List<int[]>());
                dic[key].Add(new int[] { i, j });
            }
        }
        foreach (var list in dic.Values)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    int p1 = list[i][0];
                    int p2 = list[j][0];
                    int p3 = list[j][1];
                    ans = Math.Min(ans, Distance(points[p1], points[p2]) * Distance(points[p1], points[p3]));
                }
            }
        }
        return ans == double.MaxValue ? 0.0 : ans;
    }
    public double Distance(int[] p1, int[] p2)
    {
        return Math.Sqrt((p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]));
    }
}
// @lc code=end

