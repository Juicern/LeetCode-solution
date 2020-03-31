import java.util.*;

/*
 * @lc app=leetcode.cn id=200 lang=java
 *
 * [200] 岛屿数量
 *
 * https://leetcode-cn.com/problems/numsber-of-islands/description/
 *
 * algorithms
 * Medium (46.66%)
 * Likes:    420
 * Dislikes: 0
 * Total Accepted:    69K
 * Total Submissions: 144.6K
 * Testcase Example:  '[["1","1","1","1","0"],["1","1","0","1","0"],["1","1","0","0","0"],["0","0","0","0","0"]]'
 *
 * 给定一个由 '1'（陆地）和
 * '0'（水）组成的的二维网格，计算岛屿的数量。一个岛被水包围，并且它是通过水平方向或垂直方向上相邻的陆地连接而成的。你可以假设网格的四个边均被水包围。
 * 
 * 示例 1:
 * 
 * 输入:
 * 11110
 * 11010
 * 11000
 * 00000
 * 
 * 输出: 1
 * 
 * 
 * 示例 2:
 * 
 * 输入:
 * 11000
 * 11000
 * 00100
 * 00011
 * 
 * 输出: 3
 * 
 * 
 */

// @lc code=start
class Solution {
    private int find(int[] parent, int x){
        if(parent[x]==-1) return x;
        return find(parent, parent[x]);
    }
    private void union(int[] parent, int x, int y){
        int set_x = find(parent, x);
        int set_y = find(parent, y);
        if(set_x!=set_y) parent[set_x] = set_y;
    }
    public int numIslands(char[][] grid) {
        if(grid.length==0) return 0;
        int m = grid.length;
        int n = grid[0].length;
        int[] nums = new int[m*n];
        Arrays.fill(nums, -1);
        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++){
                if(grid[i][j]=='1'){
                    grid[i][j] = '0';
                    if(j<n-1 && grid[i][j+1]=='1') union(nums, i*n+j, i*n+j+1);
                    if(i<m-1 && grid[i+1][j]=='1') union(nums, i*n+j, i*n+n+j);
                }
                else nums[i*n+j] = -2;
            }
        }
        int count = 0;
        for(int num : nums){
            if(num==-1) count++;
        }
        return count;
    }
}
// @lc code=end

