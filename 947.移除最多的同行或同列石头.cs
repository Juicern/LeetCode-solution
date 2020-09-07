using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=947 lang=csharp
 *
 * [947] 移除最多的同行或同列石头
 *
 * https://leetcode-cn.com/problems/most-stones-removed-with-same-row-or-column/description/
 *
 * algorithms
 * Medium (50.86%)
 * Likes:    54
 * Dislikes: 0
 * Total Accepted:    2.5K
 * Total Submissions: 4.9K
 * Testcase Example:  '[[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]'
 *
 * 我们将石头放置在二维平面中的一些整数坐标点上。每个坐标点上最多只能有一块石头。
 * 
 * 每次 move 操作都会移除一块所在行或者列上有其他石头存在的石头。
 * 
 * 请你设计一个算法，计算最多能执行多少次 move 操作？
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：stones = [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]]
 * 输出：5
 * 
 * 
 * 示例 2：
 * 
 * 输入：stones = [[0,0],[0,2],[1,1],[2,0],[2,2]]
 * 输出：3
 * 
 * 
 * 示例 3：
 * 
 * 输入：stones = [[0,0]]
 * 输出：0
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= stones.length <= 1000
 * 0 <= stones[i][j] < 10000
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int RemoveStones(int[][] stones) {
        var dsu = new DSU(20000);
        foreach(var stone in stones) {
            dsu.Union(stone[0], stone[1] + 10000);
        }
        var seen = new HashSet<int>();
        foreach(var stone in stones) {
            seen.Add(dsu.Find(stone[0]));
        }
        return stones.Length  - seen.Count;
    }
}
public class DSU{
    public int[] parent;
    public DSU(int n) {
        parent = new int[n];
        for(int i=0;i<n;i++) parent[i] = i;
    }
    public int Find(int x) {
        if(parent[x] != x) parent[x] = Find(parent[x]);
        return parent[x];
    }
    public void Union(int x, int y) {
        parent[Find(x)] = Find(y);
    }
}
// @lc code=end

