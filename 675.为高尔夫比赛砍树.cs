using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=675 lang=csharp
 *
 * [675] 为高尔夫比赛砍树
 *
 * https://leetcode-cn.com/problems/cut-off-trees-for-golf-event/description/
 *
 * algorithms
 * Hard (35.99%)
 * Likes:    45
 * Dislikes: 0
 * Total Accepted:    1.2K
 * Total Submissions: 3.4K
 * Testcase Example:  '[[1,2,3],[0,0,4],[7,6,5]]'
 *
 * 你被请来给一个要举办高尔夫比赛的树林砍树. 树林由一个非负的二维数组表示， 在这个数组中：
 * 
 * 
 * 0 表示障碍，无法触碰到.
 * 1 表示可以行走的地面.
 * 比 1 大的数 表示一颗允许走过的树的高度.
 * 
 * 
 * 每一步，你都可以向上、下、左、右四个方向之一移动一个单位，如果你站的地方有一棵树，那么你可以决定是否要砍倒它。
 * 
 * 你被要求按照树的高度从低向高砍掉所有的树，每砍过一颗树，树的高度变为 1 。
 * 
 * 你将从（0，0）点开始工作，你应该返回你砍完所有树需要走的最小步数。 如果你无法砍完所有的树，返回 -1 。
 * 
 * 可以保证的是，没有两棵树的高度是相同的，并且你至少需要砍倒一棵树。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: 
 * [
 * ⁠[1,2,3],
 * ⁠[0,0,4],
 * ⁠[7,6,5]
 * ]
 * 输出: 6
 * 
 * 
 * 示例 2:
 * 
 * 输入: 
 * [
 * ⁠[1,2,3],
 * ⁠[0,0,0],
 * ⁠[7,6,5]
 * ]
 * 输出: -1
 * 
 * 
 * 示例 3:
 * 
 * 输入: 
 * [
 * ⁠[2,3,4],
 * ⁠[0,0,5],
 * ⁠[8,7,6]
 * ]
 * 输出: 6
 * 解释: (0,0) 位置的树，你可以直接砍去，不用算步数
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= forest.length <= 50
 * 1 <= forest[i].length <= 50
 * 0 <= forest[i][j] <= 10^9
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int CutOffTree(IList<IList<int>> forest)
    {
        int[] dx = new int[] { 1, -1, 0, 0 };
        int[] dy = new int[] { 0, 0, 1, -1 };
        int ans = 0;
        var list = new SortedList<int, Tuple<int, int>>();
        var queue = new Queue<int[]>();
        var visited = new bool[forest.Count, forest[0].Count];
        for (int i = 0; i < forest.Count; i++)
        {
            for (int j = 0; j < forest[0].Count; j++)
            {
                if (forest[i][j] != 0)
                {
                    list.Add(forest[i][j], new Tuple<int, int>(i, j));
                }
            }
        }
        queue.Enqueue(new int[] { 0, 0 });
        visited[0, 0] = true;
        foreach (var item in list.Values)
        {
            bool found = false;
            int distance = -1;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                distance++;
                while (count > 0)
                {
                    int[] cur = queue.Dequeue();
                    if (cur[0] == item.Item1 && cur[1] == item.Item2)
                    {
                        found = true;
                        ans += distance;
                        break;
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            int newX = cur[0] + dx[i];
                            int newY = cur[1] + dy[i];
                            if (newX > -1 && newX < forest.Count && newY > -1 && newY < forest[0].Count && forest[newX][newY] != 0 && !visited[newX, newY])
                            {
                                visited[newX, newY] = true;
                                queue.Enqueue(new int[] { newX, newY });
                            }
                        }
                    }
                    count--;
                }
                if (found)
                {
                    queue.Clear();
                    queue.Enqueue(new int[] { item.Item1, item.Item2 });
                    visited = new bool[forest.Count, forest[0].Count];
                    visited[item.Item1, item.Item2] = true;
                    break;
                }
            }
            if (!found) return -1;
        }
        return ans;
    }
}
// @lc code=end

