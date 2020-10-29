/*
 * @lc app=leetcode.cn id=463 lang=csharp
 *
 * [463] 岛屿的周长
 *
 * https://leetcode-cn.com/problems/island-perimeter/description/
 *
 * algorithms
 * Easy (68.37%)
 * Likes:    265
 * Dislikes: 0
 * Total Accepted:    25.6K
 * Total Submissions: 37.5K
 * Testcase Example:  '[[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]'
 *
 * 给定一个包含 0 和 1 的二维网格地图，其中 1 表示陆地 0 表示水域。
 * 
 * 网格中的格子水平和垂直方向相连（对角线方向不相连）。整个网格被水完全包围，但其中恰好有一个岛屿（或者说，一个或多个表示陆地的格子相连组成的岛屿）。
 * 
 * 岛屿中没有“湖”（“湖” 指水域在岛屿内部且不和岛屿周围的水相连）。格子是边长为 1 的正方形。网格为长方形，且宽度和高度均不超过 100
 * 。计算这个岛屿的周长。
 * 
 * 
 * 
 * 示例 :
 * 
 * 输入:
 * [[0,1,0,0],
 * ⁠[1,1,1,0],
 * ⁠[0,1,0,0],
 * ⁠[1,1,0,0]]
 * 
 * 输出: 16
 * 
 * 解释: 它的周长是下面图片中的 16 个黄色的边：
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int ans = 0;
        var dir_x = new int[]{0, 0, -1, 1};
        var dir_y = new int[]{-1, 1, 0, 0};
        for(int i = 0;i<grid.Length;i++) {
            for(int j = 0;j<grid[0].Length;j++) {
                if(grid[i][j] == 1) {
                    for(int k = 0;k<4;k++){
                        int x = i + dir_x[k];
                        int y = j + dir_y[k];
                        if(x <0 || x>= grid.Length || y< 0 || y >= grid[0].Length || grid[x][y] == 0) ans++;
                    }
                    
                }
            }
        }
        return ans;
    }
}
// @lc code=end

