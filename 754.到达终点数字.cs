using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=754 lang=csharp
 *
 * [754] 到达终点数字
 *
 * https://leetcode-cn.com/problems/reach-a-number/description/
 *
 * algorithms
 * Medium (40.76%)
 * Likes:    116
 * Dislikes: 0
 * Total Accepted:    5.4K
 * Total Submissions: 13.1K
 * Testcase Example:  '1'
 *
 * 在一根无限长的数轴上，你站在0的位置。终点在target的位置。
 * 
 * 每次你可以选择向左或向右移动。第 n 次移动（从 1 开始），可以走 n 步。
 * 
 * 返回到达终点需要的最小移动次数。
 * 
 * 示例 1:
 * 
 * 
 * 输入: target = 3
 * 输出: 2
 * 解释:
 * 第一次移动，从 0 到 1 。
 * 第二次移动，从 1 到 3 。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: target = 2
 * 输出: 3
 * 解释:
 * 第一次移动，从 0 到 1 。
 * 第二次移动，从 1 到 -1 。
 * 第三次移动，从 -1 到 2 。
 * 
 * 
 * 注意:
 * 
 * 
 * target是在[-10^9, 10^9]范围中的非零整数。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int ReachNumber(int target) {
        target = Math.Abs(target);
        int maxPos = 0;
        int steps = 1;
        while(target > maxPos || (maxPos - target) % 2 != 0) {
            maxPos += steps++;
        }
        return steps - 1;
    }
}
// @lc code=end

