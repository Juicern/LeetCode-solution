/*
 * @lc app=leetcode.cn id=764 lang=csharp
 *
 * [764] 最大加号标志
 */

// @lc code=start
public class Solution {
    public int OrderOfLargestPlusSign(int N, int[][] mines) {        
        int[,] grid = new int[N, N];
        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                grid[i, j] = 1;
        int minesCount = mines.GetLength(0);
        for (int i = 0; i < minesCount; i++)
            grid[mines[i][0], mines[i][1]] = 0;
        int[,] left = new int[N, N];
        int[,] right = new int[N, N];
        int[,] top = new int[N, N];
        int[,] bottom = new int[N, N];
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (grid[i, j] == 1)
                {
                    top[i, j] = (i - 1 >= 0) ? top[i - 1, j] + 1 : 1;
                    left[i, j] = (j - 1 >= 0) ? left[i, j - 1] + 1 : 1;
                }
                else
                {
                    left[i, j] = 0;
                    top[i, j] = 0;
                }
            }
        }
        int ans = 0;
        for (int i = N-1; i >=0; i--)
        {
            for (int j = N-1; j >=0; j--)
            {
                if (grid[i, j] == 1)
                {
                    bottom[i, j] = (i + 1 < N) ? bottom[i + 1, j] + 1 : 1;
                    right[i, j] = (j + 1 < N) ? right[i, j + 1] + 1 : 1;
                }
                else
                {
                    bottom[i, j] = 0;
                    right[i, j] = 0;
                }
                ans = Math.Max(ans, Math.Min(Math.Min(left[i,j], bottom[i,j]), Math.Min(right[i,j], top[i,j])));
            }
        }
        return ans;
    }
}
// @lc code=end

