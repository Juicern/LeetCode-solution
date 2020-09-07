using System.Collections.Generic;
using System.Numerics;
/*
 * @lc app=leetcode.cn id=417 lang=csharp
 *
 * [417] 太平洋大西洋水流问题
 *
 * https://leetcode-cn.com/problems/pacific-atlantic-water-flow/description/
 *
 * algorithms
 * Medium (41.73%)
 * Likes:    111
 * Dislikes: 0
 * Total Accepted:    8.6K
 * Total Submissions: 20.7K
 * Testcase Example:  '[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]'
 *
 * 给定一个 m x n 的非负整数矩阵来表示一片大陆上各个单元格的高度。“太平洋”处于大陆的左边界和上边界，而“大西洋”处于大陆的右边界和下边界。
 * 
 * 规定水流只能按照上、下、左、右四个方向流动，且只能从高到低或者在同等高度上流动。
 * 
 * 请找出那些水流既可以流动到“太平洋”，又能流动到“大西洋”的陆地单元的坐标。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 输出坐标的顺序不重要
 * m 和 n 都小于150
 * 
 * 
 * 
 * 
 * 示例：
 * 
 * 
 * 
 * 
 * 给定下面的 5x5 矩阵:
 * 
 * ⁠ 太平洋 ~   ~   ~   ~   ~ 
 * ⁠      ~  1   2   2   3  (5) *
 * ⁠      ~  3   2   3  (4) (4) *
 * ⁠      ~  2   4  (5)  3   1  *
 * ⁠      ~ (6) (7)  1   4   5  *
 * ⁠      ~ (5)  1   1   2   4  *
 * ⁠         *   *   *   *   * 大西洋
 * 
 * 返回:
 * 
 * [[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (上图中带括号的单元).
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private static int[, ] directions;
    private int m, n;
    private int[][] matrix;
    public IList<IList<int>> PacificAtlantic(int[][] matrix)
    {
        var ans = new List<IList<int>>();
        if (matrix.Length == 0) return ans;
        this.n = matrix.Length;
        this.m = matrix[0].Length;
        this.matrix = matrix;
        directions = new int[, ]{ { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        var canReachP = new bool[n, m];
        var canReachA = new bool[n, m];
        for (int i = 0; i < n; i++)
        {
            Dfs(i, 0, canReachP);
            Dfs(i, m - 1, canReachA);
        }
        for (int j = 0; j < m; j++)
        {
            Dfs(0, j, canReachP);
            Dfs(n - 1, j, canReachA);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (canReachA[i, j] && canReachP[i, j])
                {
                    var point = new List<int>();
                    point.Add(i);
                    point.Add(j);
                    ans.Add(point);
                }
            }
        }
        return ans;
    }
    private void Dfs(int x, int y, bool[,] canReach)
    {
        canReach[x, y] = true;
        for (int i = 0; i < 4; i++)
        {
            int newX = x + directions[i, 0];
            int newY = y + directions[i, 1];
            if (IsInMatrix(newX, newY) && matrix[x][y] <= matrix[newX][newY] && !canReach[newX, newY])
            {
                Dfs(newX, newY, canReach);
            }
        }
    }
    private bool IsInMatrix(int x, int y)
    {
        return x >= 0 && x < n && y >= 0 && y < m;
    }
}
// @lc code=end

