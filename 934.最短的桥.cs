/*
 * @lc app=leetcode.cn id=934 lang=csharp
 *
 * [934] 最短的桥
 *
 * https://leetcode-cn.com/problems/shortest-bridge/description/
 *
 * algorithms
 * Medium (45.09%)
 * Likes:    106
 * Dislikes: 0
 * Total Accepted:    9K
 * Total Submissions: 20K
 * Testcase Example:  '[[0,1],[1,0]]'
 *
 * 在给定的二维二进制数组 A 中，存在两座岛。（岛是由四面相连的 1 形成的一个最大组。）
 * 
 * 现在，我们可以将 0 变为 1，以使两座岛连接起来，变成一座岛。
 * 
 * 返回必须翻转的 0 的最小数目。（可以保证答案至少是 1。）
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[[0,1],[1,0]]
 * 输出：1
 * 
 * 
 * 示例 2：
 * 
 * 输入：[[0,1,0],[0,0,0],[0,0,1]]
 * 输出：2
 * 
 * 
 * 示例 3：
 * 
 * 输入：[[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
 * 输出：1
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length = A[0].length <= 100
 * A[i][j] == 0 或 A[i][j] == 1
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution
{
    Queue<int> q = new Queue<int>();
    int[,] dir = new int[4, 2] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
    public int ShortestBridge(int[][] A)
    {
        bool colorDone = false;
        int Col = A[0].Length;
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A[0].Length; j++)
            {
                if (A[i][j] == 1)
                {
                    if (colorDone == true)
                    {
                        q.Enqueue(i * Col + j);
                    }
                    else
                    {
                        ColorIsland(A, i, j);
                        colorDone = true;
                    }
                }
            }
        }
        return BFS(A);
    }

    private int BFS(int[][] A)
    {
        int steps = 0;
        int Col = A[0].Length;
        while (q.Count() != 0)
        {
            int size = q.Count();
            for (int s = 0; s < size; s++)
            {
                int val = q.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newi = val / Col + dir[i, 0];
                    int newj = val % Col + dir[i, 1];
                    if (newi >= 0 && newj >= 0 && newi < A.Length && newj < A[0].Length)
                    {
                        if (A[newi][newj] == 0)
                        {
                            q.Enqueue(newi * Col + newj);
                            A[newi][newj] = 1;
                        }
                        if (A[newi][newj] == 2)
                            return steps;
                    }
                }
            }
            steps++;
        }
        return steps;
    }

    private void ColorIsland(int[][] A, int i, int j)
    {
        Stack<int> s = new Stack<int>();
        int Col = A[0].Length;
        s.Push(i * Col + j);
        A[i][j] = 2;
        while (s.Count != 0)
        {
            int val = s.Pop();
            for (int ii = 0; ii < 4; ii++)
            {
                int newi = val / Col + dir[ii, 0];
                int newj = val % Col + dir[ii, 1];
                if (newi >= 0 && newj >= 0 && newi < A.Length && newj < A[0].Length
                  && A[newi][newj] == 1)
                {
                    s.Push(newi * Col + newj);
                    A[newi][newj] = 2;
                }
            }
        }
        return;
    }
}
// @lc code=end

