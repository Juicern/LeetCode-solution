/*
 * @lc app=leetcode.cn id=1036 lang=csharp
 *
 * [1036] 逃离大迷宫
 *
 * https://leetcode-cn.com/problems/escape-a-large-maze/description/
 *
 * algorithms
 * Hard (28.72%)
 * Likes:    41
 * Dislikes: 0
 * Total Accepted:    2.2K
 * Total Submissions: 7.6K
 * Testcase Example:  '[[0,1],[1,0]]\n[0,0]\n[0,2]'
 *
 * 在一个 10^6 x 10^6 的网格中，每个网格块的坐标为 (x, y)，其中 0 <= x, y < 10^6。
 * 
 * 我们从源方格 source 开始出发，意图赶往目标方格 target。每次移动，我们都可以走到网格中在四个方向上相邻的方格，只要该方格不在给出的封锁列表
 * blocked 上。
 * 
 * 只有在可以通过一系列的移动到达目标方格时才返回 true。否则，返回 false。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：blocked = [[0,1],[1,0]], source = [0,0], target = [0,2]
 * 输出：false
 * 解释：
 * 从源方格无法到达目标方格，因为我们无法在网格中移动。
 * 
 * 
 * 示例 2：
 * 
 * 输入：blocked = [], source = [0,0], target = [999999,999999]
 * 输出：true
 * 解释：
 * 因为没有方格被封锁，所以一定可以到达目标方格。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 <= blocked.length <= 200
 * blocked[i].length == 2
 * 0 <= blocked[i][j] < 10^6
 * source.length == target.length == 2
 * 0 <= source[i][j], target[i][j] < 10^6
 * source != target
 * 
 * 
 */

// @lc code=start
public class Solution
{
    int n, maxBlockNum, row, col;
    HashSet<string> set;
    int[] dirsX = new int[] { -1, 1, 0, 0 };
    int[] dirsY = new int[] { 0, 0, -1, 1 };
    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
    {
        n = blocked.Length;
        maxBlockNum = n * (n - 1) / 2;
        row = 1_000_000;
        col = 1_000_000;
        set = new HashSet<string>();
        foreach (var block in blocked)
        {
            set.Add(block[0] + " " + block[1]);
        }
        return IsEscape(source, target) && IsEscape(target, source);
    }
    public bool IsEscape(int[] sources, int[] target)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<int[]>();
        visited.Add(sources[0] + " " + sources[1]);
        queue.Enqueue(sources);
        int count = 1;
        while (queue.Any())
        {
            var node = queue.Dequeue();
            if (node[0] == target[0] && node[1] == target[1]) return true;
            for (int i = 0; i < 4; i++)
            {
                int x = node[0] + dirsX[i];
                int y = node[1] + dirsY[i];
                if (x >= 0 && x < row && y >= 0 && y < col && !visited.Contains(x + " " + y) && !set.Contains(x + " " + y))
                {
                    queue.Enqueue(new int[] { x, y });
                    visited.Add(x + " " + y);
                    count++;
                }
            }
            if (count > maxBlockNum) return true;
        }
        return false;
    }
}
// @lc code=end

