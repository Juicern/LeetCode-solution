using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=407 lang=csharp
 *
 * [407] 接雨水 II
 *
 * https://leetcode-cn.com/problems/trapping-rain-water-ii/description/
 *
 * algorithms
 * Hard (40.02%)
 * Likes:    187
 * Dislikes: 0
 * Total Accepted:    3.7K
 * Total Submissions: 9.3K
 * Testcase Example:  '[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]'
 *
 * 给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。
 * 
 * 
 * 
 * 示例：
 * 
 * 给出如下 3x6 的高度图:
 * [
 * ⁠ [1,4,3,1,3,2],
 * ⁠ [3,2,1,3,2,4],
 * ⁠ [2,3,3,2,3,1]
 * ]
 * 
 * 返回 4 。
 * 
 * 
 * 
 * 
 * 如上图所示，这是下雨前的高度图[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]] 的状态。
 * 
 * 
 * 
 * 
 * 
 * 下雨后，雨水将会被存储在这些方块中。总的接雨水量是4。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= m, n <= 110
 * 0 <= heightMap[i][j] <= 20000
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int TrapRainWater(int[][] heightMap) {
        int n = heightMap.Length;
        int m = heightMap[0].Length;
        var visits = new bool[n,m];
        var list = new SortedList<int, int[]>();
        for(int i=0;i<n;i++) {
            for(int j =0;j<m;j++) {
                if(i==0 || i==n-1 || j==0 || j==m-1) {
                    list.Add(heightMap[i][j], new int[]{i, j});
                    visits[i, j] = true;
                }
            }
        }
        int ans = 0;
        var directions = { -1, 0, 1, 0, -1};
        while(list.Count > 0) {
            var point = list.Last();
            list.Remove(list.Last());
            
        }
    }
}
// @lc code=end

