/*
 * @lc app=leetcode.cn id=803 lang=csharp
 *
 * [803] 打砖块
 *
 * https://leetcode-cn.com/problems/bricks-falling-when-hit/description/
 *
 * algorithms
 * Hard (25.93%)
 * Likes:    59
 * Dislikes: 0
 * Total Accepted:    1K
 * Total Submissions: 4K
 * Testcase Example:  '[[1,0,0,0],[1,1,1,0]]\n[[1,0]]'
 *
 * 我们有一组包含1和0的网格；其中1表示砖块。 当且仅当一块砖直接连接到网格的顶部，或者它至少有一块相邻（4 个方向之一）砖块不会掉落时，它才不会落下。
 * 
 * 我们会依次消除一些砖块。每当我们消除 (i, j) 位置时， 对应位置的砖块（若存在）会消失，然后其他的砖块可能因为这个消除而落下。
 * 
 * 返回一个数组表示每次消除操作对应落下的砖块数目。
 * 
 * 示例 1：
 * 输入：
 * grid = [[1,0,0,0],[1,1,1,0]]
 * hits = [[1,0]]
 * 输出: [2]
 * 解释: 
 * 如果我们消除(1, 0)位置的砖块, 在(1, 1) 和(1, 2) 的砖块会落下。所以我们应该返回2。
 * 
 * 示例 2：
 * 输入：
 * grid = [[1,0,0,0],[1,1,0,0]]
 * hits = [[1,1],[1,0]]
 * 输出：[0,0]
 * 解释：
 * 当我们消除(1, 0)的砖块时，(1, 1)的砖块已经由于上一步消除而消失了。所以每次消除操作不会造成砖块落下。注意(1,
 * 0)砖块不会记作落下的砖块。
 * 
 * 注意:
 * 
 * 
 * 网格的行数和列数的范围是[1, 200]。
 * 消除的数字不会超过网格的区域。
 * 可以保证每次的消除都不相同，并且位于网格的内部。
 * 一个消除的位置可能没有砖块，如果这样的话，就不会有砖块落下。
 * 
 * 
 */

// @lc code=start

public class Solution
{
    private static readonly (int di, int dj)[] _directions = { (0, 1), (1, 0), (0, -1), (-1, 0) };

    private int Join(int node, int[,] backward, ISet<int> stableCells)
    {
        if (!stableCells.Add(node))
        {
            return 0;
        }

        int res = 1;
        int n = backward.GetLength(0);
        int m = backward.GetLength(1);

        int r = node / m;
        int c = node % m;

        foreach (var dir in _directions)
        {
            int newI = r + dir.di;
            int newJ = c + dir.dj;
            int l = newI * m + newJ;

            if (newI >= 0 && newI < n && newJ >= 0 && newJ < m && backward[newI, newJ] == 1 && !stableCells.Contains(l) && newI != 0)
            {
                res += Join(l, backward, stableCells);
            }
        }

        return res;
    }

    public int[] HitBricks(int[][] grid, int[][] hits)
    {
        int n = grid.Length;
        int[] res = new int[hits.Length];
        int m = grid[0].Length;
        int[,] backward = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                backward[i, j] = grid[i][j];
            }
        }

        foreach (var hit in hits)
        {
            backward[hit[0], hit[1]] = 0;
        }

        ISet<int> stableCells = new HashSet<int>();
        for (int j = 0; j < m; j++)
        {
            if (backward[0, j] == 1)
            {
                Join(j, backward, stableCells);
            }
        }

        for (int i = hits.Length - 1; i >= 0; i--)
        {
            var hit = hits[i];
            var linear = hit[0] * m + hit[1];

            if (grid[hit[0]][hit[1]] == 0)
            {
                continue;
            }

            backward[hit[0], hit[1]] = 1;

            if (hit[0] == 0)
            {
                res[i] = Join(linear, backward, stableCells) - 1;
                continue;
            }

            foreach (var dir in _directions)
            {
                int newI = hit[0] + dir.di;
                int newJ = hit[1] + dir.dj;
                int l = newI * m + newJ;

                if (newI >= 0 && newI < n && newJ >= 0 && newJ < m && backward[newI, newJ] == 1 && stableCells.Contains(l))
                {
                    res[i] = Join(linear, backward, stableCells) - 1;
                    break;
                }
            }
        }

        return res;
    }
}
// @lc code=end

