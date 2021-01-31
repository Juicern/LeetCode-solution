using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=778 lang=csharp
 *
 * [778] 水位上升的泳池中游泳
 *
 * https://leetcode-cn.com/problems/swim-in-rising-water/description/
 *
 * algorithms
 * Hard (47.08%)
 * Likes:    68
 * Dislikes: 0
 * Total Accepted:    5.3K
 * Total Submissions: 11.2K
 * Testcase Example:  '[[0,2],[1,3]]'
 *
 * 在一个 N x N 的坐标方格 grid 中，每一个方格的值 grid[i][j] 表示在位置 (i,j) 的平台高度。
 * 
 * 现在开始下雨了。当时间为 t 时，此时雨水导致水池中任意位置的水位为 t
 * 。你可以从一个平台游向四周相邻的任意一个平台，但是前提是此时水位必须同时淹没这两个平台。假定你可以瞬间移动无限距离，也就是默认在方格内部游动是不耗时的。当然，在你游泳的时候你必须待在坐标方格里面。
 * 
 * 你从坐标方格的左上平台 (0，0) 出发。最少耗时多久你才能到达坐标方格的右下平台 (N-1, N-1)？
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: [[0,2],[1,3]]
 * 输出: 3
 * 解释:
 * 时间为0时，你位于坐标方格的位置为 (0, 0)。
 * 此时你不能游向任意方向，因为四个相邻方向平台的高度都大于当前时间为 0 时的水位。
 * 
 * 等时间到达 3 时，你才可以游向平台 (1, 1). 因为此时的水位是 3，坐标方格中的平台没有比水位 3
 * 更高的，所以你可以游向坐标方格中的任意位置
 * 
 * 
 * 示例2:
 * 
 * 输入:
 * [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
 * 输出: 16
 * 解释:
 * ⁠0  1  2  3  4
 * 24 23 22 21  5
 * 12 13 14 15 16
 * 11 17 18 19 20
 * 10  9  8  7  6
 * 
 * 最终的路线用加粗进行了标记。
 * 我们必须等到时间为 16，此时才能保证平台 (0, 0) 和 (4, 4) 是连通的
 * 
 * 
 * 
 * 
 * 提示:
 * 
 * 
 * 2 <= N <= 50.
 * grid[i][j] 位于区间 [0, ..., N*N - 1] 内。
 * 
 * 
 */

// @lc code=start
public class Solution {
    readonly (int, int)[] dirs = new (int, int)[]{(0, -1), (1, 0), (0, 1), (-1, 0)};
    public int SwimInWater(int[][] grid) {
        var n = grid.Length;
        var uf = new UnionFind(n * n);
        var height_pos = new (int, int)[n * n];
        for(int i = 0; i< n;++i) {
            for(int j = 0;j<n;++j) {
                height_pos[grid[i][j]] = (i, j); 
            }
        }
        for (var height = 0; height  < n * n; ++hFeight) {
            var (pos_x, pos_y) = height_pos[height];
            foreach(var (dir_x, dir_y) in dirs) {
                var new_pos_x = pos_x + dir_x;
                var new_pos_y = pos_y + dir_y;
                if(new_pos_x >= 0 && new_pos_x < n && new_pos_y >= 0 && new_pos_y < n && grid[new_pos_x][new_pos_y] <= height) {
                    uf.Merge(pos_x * n + pos_y, new_pos_x * n + new_pos_y);
                }
            }
            if(uf.IsConnected(0, n * n - 1)) return height;
        }
        return -1;
    }
}
public class UnionFind{
    int[] parent;
    int n;
    public UnionFind(int _n) {
        n = _n;
        parent = new int[n];
        for(int i = 0; i < n; ++i) {
            parent[i] = i;
        }
    }
    public void Merge(int _x, int _y) {
        var root_x = Find(_x);
        var root_y = Find(_y);
        if(root_x == root_y) return;
        parent[root_x] = root_y;
    }
    private int Find(int _x) {
        if(parent[_x] == _x) return _x;
        return parent[_x] = Find(parent[_x]);
    }
    public bool IsConnected(int _x, int _y) {
        return Find(_x) == Find(_y);
    }
}
// @lc code=end

