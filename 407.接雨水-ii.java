import java.util.PriorityQueue;

/*
 * @lc app=leetcode.cn id=407 lang=java
 *
 * [407] 接雨水 II
 *
 * https://leetcode-cn.com/problems/trapping-rain-water-ii/description/
 *
 * algorithms
 * Hard (40.02%)
 * Likes:    187
 * Dislikes: 0
 * Total Accepted:    3.7K
 * Total Submissions: 9.3K
 * Testcase Example:  '[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]'
 *
 * 给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。
 * 
 * 
 * 
 * 示例：
 * 
 * 给出如下 3x6 的高度图:
 * [
 * ⁠ [1,4,3,1,3,2],
 * ⁠ [3,2,1,3,2,4],
 * ⁠ [2,3,3,2,3,1]
 * ]
 * 
 * 返回 4 。
 * 
 * 
 * 
 * 
 * 如上图所示，这是下雨前的高度图[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]] 的状态。
 * 
 * 
 * 
 * 
 * 
 * 下雨后，雨水将会被存储在这些方块中。总的接雨水量是4。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= m, n <= 110
 * 0 <= heightMap[i][j] <= 20000
 * 
 * 
 */

// @lc code=start
class Solution {
    public int trapRainWater(int[][] heightMap) {
        int ans = 0;
        int n = heightMap.length;
        int m = heightMap[0].length;
        PriorityQueue<Point> queue = new PriorityQueue<>((o1, o2) -> o1.height - o2.height);
        boolean[][] visited = new boolean[n][m];
        int[][] directions = { { -1, 0 }, { 0, -1 }, { 0, 1 }, { 1, 0 } };
        for (int i = 0; i < n; i++) {
            visited[i][0] = true;
            visited[i][m - 1] = true;
            queue.offer(new Point(i, 0, heightMap[i][0]));
            queue.offer(new Point(i, m - 1, heightMap[i][m - 1]));
        }
        for (int i = 1; i < m - 1; i++) {
            visited[0][i] = true;
            visited[n - 1][i] = true;
            queue.offer(new Point(0, i, heightMap[0][i]));
            queue.offer(new Point(n - 1, i, heightMap[n - 1][i]));
        }
        while (!queue.isEmpty()) {
            Point point = queue.poll();
            for (int[] direction : directions) {
                int x = point.x + direction[0];
                int y = point.y + direction[1];
                if (x >= 0 && x < n && y >= 0 && y < m && !visited[x][y]) {
                    ans += Math.max(0, point.height - heightMap[x][y]);
                    visited[x][y] = true;
                    queue.offer(new Point(x, y, Math.max(point.height, heightMap[x][y])));
                }
            }
        }
        return ans;
    }
}

public class Point {
    public int x;
    public int y;
    public int height;

    public Point(int x, int y, int height) {
        this.x = x;
        this.y = y;
        this.height = height;
    }
}
// @lc code=end
