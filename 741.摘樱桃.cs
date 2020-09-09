using System;
/*
 * @lc app=leetcode.cn id=741 lang=csharp
 *
 * [741] 摘樱桃
 *
 * https://leetcode-cn.com/problems/cherry-pickup/description/
 *
 * algorithms
 * Hard (33.52%)
 * Likes:    100
 * Dislikes: 0
 * Total Accepted:    2.2K
 * Total Submissions: 6.5K
 * Testcase Example:  '[[0,1,-1],[1,0,-1],[1,1,1]]'
 *
 * 一个N x N的网格(grid) 代表了一块樱桃地，每个格子由以下三种数字的一种来表示：
 * 
 * 
 * 0 表示这个格子是空的，所以你可以穿过它。
 * 1 表示这个格子里装着一个樱桃，你可以摘到樱桃然后穿过它。
 * -1 表示这个格子里有荆棘，挡着你的路。
 * 
 * 
 * 你的任务是在遵守下列规则的情况下，尽可能的摘到最多樱桃：
 * 
 * 
 * 从位置 (0, 0) 出发，最后到达 (N-1, N-1) ，只能向下或向右走，并且只能穿越有效的格子（即只可以穿过值为0或者1的格子）；
 * 当到达 (N-1, N-1) 后，你要继续走，直到返回到 (0, 0) ，只能向上或向左走，并且只能穿越有效的格子；
 * 当你经过一个格子且这个格子包含一个樱桃时，你将摘到樱桃并且这个格子会变成空的（值变为0）；
 * 如果在 (0, 0) 和 (N-1, N-1) 之间不存在一条可经过的路径，则没有任何一个樱桃能被摘到。
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入: grid =
 * [[0, 1, -1],
 * ⁠[1, 0, -1],
 * ⁠[1, 1,  1]]
 * 输出: 5
 * 解释： 
 * 玩家从（0,0）点出发，经过了向下走，向下走，向右走，向右走，到达了点(2, 2)。
 * 在这趟单程中，总共摘到了4颗樱桃，矩阵变成了[[0,1,-1],[0,0,-1],[0,0,0]]。
 * 接着，这名玩家向左走，向上走，向上走，向左走，返回了起始点，又摘到了1颗樱桃。
 * 在旅程中，总共摘到了5颗樱桃，这是可以摘到的最大值了。
 * 
 * 
 * 说明:
 * 
 * 
 * grid 是一个 N * N 的二维数组，N的取值范围是1 <= N <= 50。
 * 每一个 grid[i][j] 都是集合 {-1, 0, 1}其中的一个数。
 * 可以保证起点 grid[0][0] 和终点 grid[N-1][N-1] 的值都不会是 -1。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    int[,,] dp;
    int[][] grid;
    int n;
    public int CherryPickup(int[][] grid)
    {
        this.grid = grid;
        n = grid.Length;
        dp = new int[n, n, n];
        for(int i = 0;i< n;i++) {
            for(int j = 0;j<n;j++) {
                for(int k = 0;k<n;k++) {
                    dp[i, j, k] = int.MinValue;
                }
            }
        }
        return Math.Max(0, Helper(0, 0, 0));
    }
    public int Helper(int r1, int c1, int c2) {
        int r2 = r1 + c1 - c2;
        if (n == r1 || n == c1 || n == r2 || n== c2 || grid[r1][c1] == -1 || grid[r2][c2] == -1) {
            return int.MinValue;
        }
        if(r1 == n - 1 && c1 == n - 1) {
            return grid[r1][c1];
        }
        if(dp[r1, c1, c2] != int.MinValue){
            return dp[r1, c1, c2];
        }
        int ans = grid[r1][c1];
        if (c1 != c2) ans += grid[r2][c2];
        ans += Math.Max(Math.Max(Helper(r1, c1+ 1, c2 + 1), Helper(r1 + 1, c1, c2 + 1 )), Math.Max(Helper(r1, c1 + 1, c2), Helper(r1 + 1, c1, c2)));
        dp[r1, c1, c2] = ans;
        return ans;
    }
    
}
// @lc code=end

