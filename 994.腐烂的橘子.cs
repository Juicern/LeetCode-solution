using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=994 lang=csharp
 *
 * [994] 腐烂的橘子
 *
 * https://leetcode-cn.com/problems/rotting-oranges/description/
 *
 * algorithms
 * Medium (50.79%)
 * Likes:    286
 * Dislikes: 0
 * Total Accepted:    35.5K
 * Total Submissions: 70K
 * Testcase Example:  '[[2,1,1],[1,1,0],[0,1,1]]'
 *
 * 在给定的网格中，每个单元格可以有以下三个值之一：
 * 
 * 
 * 值 0 代表空单元格；
 * 值 1 代表新鲜橘子；
 * 值 2 代表腐烂的橘子。
 * 
 * 
 * 每分钟，任何与腐烂的橘子（在 4 个正方向上）相邻的新鲜橘子都会腐烂。
 * 
 * 返回直到单元格中没有新鲜橘子为止所必须经过的最小分钟数。如果不可能，返回 -1。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 
 * 输入：[[2,1,1],[1,1,0],[0,1,1]]
 * 输出：4
 * 
 * 
 * 示例 2：
 * 
 * 输入：[[2,1,1],[0,1,1],[1,0,1]]
 * 输出：-1
 * 解释：左下角的橘子（第 2 行， 第 0 列）永远不会腐烂，因为腐烂只会发生在 4 个正向上。
 * 
 * 
 * 示例 3：
 * 
 * 输入：[[0,2]]
 * 输出：0
 * 解释：因为 0 分钟时已经没有新鲜橘子了，所以答案就是 0 。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= grid.length <= 10
 * 1 <= grid[0].length <= 10
 * grid[i][j] 仅为 0、1 或 2
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int OrangesRotting(int[][] grid) {
        Queue<int[]> q = new Queue<int[]>();
        for(int i=0;i<grid.Length;++i){
            for(int j=0;j<grid[i].Length;++j){
                if(grid[i][j] == 2)
                    q.Enqueue(new int[] {i,j});
            }
        }        
        
        int[][] dirs = new int[4][];
        dirs[0] = new int[] { 0,  1};
        dirs[1] = new int[] { 0, -1};
        dirs[2] = new int[] { 1,  0};
        dirs[3] = new int[] { -1, 0};
        
        int mins = 0;
        while(q.Count > 0){
            int cnt = q.Count;
            for(int i=0;i<cnt;++i){
                int[] cell = q.Dequeue();
                foreach(int[] d in dirs){
                    int row = cell[0] + d[0];
                    int col = cell[1] + d[1];
                    if(row >= 0 && col >= 0 && row < grid.Length && col < grid[0].Length && grid[row][col] == 1){
                        q.Enqueue(new int[]{row, col});
                        grid[row][col] = 2;
                    }
                }
            }
            if(q.Count > 0)
                mins++;
        }
        
        for(int i=0;i<grid.Length;++i){
            for(int j=0;j<grid[i].Length;++j){
                if(grid[i][j] == 1)
                    return -1;
            }
        }
        
        return mins;   
    }
}
// @lc code=end

