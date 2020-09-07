/*
 * @lc app=leetcode.cn id=1020 lang=csharp
 *
 * [1020] 飞地的数量
 */

// @lc code=start
public class Solution
{
    private int row, col;
    private int[][] graph;
    public int NumEnclaves(int[][] A)
    {   
        if(A.Length==0) return 0;
        this.graph =  A;
        this.row = graph.Length;
        this.col = graph[0].Length;
        for(int i=0;i<row;i++)
        {
            dfs(i, 0);
            dfs(i, col-1);
        }
        for(int j=0;j<col;j++)
        {
            dfs(0, j);
            dfs(row-1, j);
        }
        int count = 0;
        foreach(int[] row in graph)
        {
            foreach(int num in row)
            {
                if(num==1) count++;
            }
        }
        return count;
    }
    private void dfs(int i, int j)
    {
        if(i<0 || j<0 || i>=row || j>=col || graph[i][j]==0) return;
        graph[i][j] = 0;
        dfs(i+1, j);
        dfs(i-1, j);
        dfs(i, j+1);
        dfs(i, j-1);
    }
}
// @lc code=end

