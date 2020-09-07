/*
 * @lc app=leetcode.cn id=780 lang=csharp
 *
 * [780] 到达终点
 *
 * https://leetcode-cn.com/problems/reaching-points/description/
 *
 * algorithms
 * Hard (27.63%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    1.4K
 * Total Submissions: 4.9K
 * Testcase Example:  '9\n5\n12\n8'
 *
 * 从点 (x, y) 可以转换到 (x, x+y)  或者 (x+y, y)。
 * 
 * 给定一个起点 (sx, sy) 和一个终点 (tx, ty)，如果通过一系列的转换可以从起点到达终点，则返回 True ，否则返回 False。
 * 
 * 
 * 示例:
 * 输入: sx = 1, sy = 1, tx = 3, ty = 5
 * 输出: True
 * 解释:
 * 可以通过以下一系列转换从起点转换到终点：
 * (1, 1) -> (1, 2)
 * (1, 2) -> (3, 2)
 * (3, 2) -> (3, 5)
 * 
 * 输入: sx = 1, sy = 1, tx = 2, ty = 2
 * 输出: False
 * 
 * 输入: sx = 1, sy = 1, tx = 1, ty = 1
 * 输出: True
 * 
 * 
 * 
 * 注意:
 * 
 * 
 * sx, sy, tx, ty 是范围在 [1, 10^9] 的整数。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public bool ReachingPoints(int sx, int sy, int tx, int ty)
    {
        if (sx > tx || sy > ty) return false;
        if (sx == tx && sy == ty) return true;
        if (tx == ty) return false;
        int nx, ny;
        if (tx > ty)
        {
            nx = (sx / ty) * ty + tx % ty;
            ny = ty;
        }
        else
        {
            nx = tx;
            ny = (sy / tx) * tx + ty % tx;
        }
        if (nx == tx && ny == ty) return false;
        return ReachingPoints(sx, sy, nx, ny);
    }
}
// @lc code=end

