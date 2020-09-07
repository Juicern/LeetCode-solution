/*
 * @lc app=leetcode.cn id=329 lang=csharp
 *
 * [329] 矩阵中的最长递增路径
 */

// @lc code=start
public class Solution
{
    private int[][] dirs = new int[][]{new int[]{0, 1}, new int[]{1, 0}, new int[]{0, -1}, new int[]{-1, 0}};
    private int m, n;
    public int LongestIncreasingPath(int[][] matrix)
    {
        if (matrix.Length == 0 ) return 0;
        int ans  = 0;
        m = matrix.Length;
        n = matrix[0].Length;
        int[, ] cache = new int[m, n];
        for(int i=0;i<m;i++){
            for(int j=0;j<n;j++) {
                ans = Math.Max(ans, Dfs(matrix, i, j, cache));
            }
        }
        return ans;
    }
    public int Dfs(int[][] matrix, int i, int j, int[, ] cache) {
        if(cache[i,  j] != 0) return cache[i, j];
        foreach(var dir in dirs) {
            int x = i + dir[0];
            int y = j + dir[1];
            if(0 <= x && 0 <= y && x < m && y < n && matrix[x][y] > matrix[i][j])
                cache[i, j] = Math.Max(cache[i, j], Dfs(matrix, x, y, cache));
        }
        return ++cache[i, j];
    }
}
// @lc code=end

