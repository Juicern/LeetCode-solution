using System;
/*
 * @lc app=leetcode.cn id=435 lang=csharp
 *
 * [435] 无重叠区间
 *
 * https://leetcode-cn.com/problems/non-overlapping-intervals/description/
 *
 * algorithms
 * Medium (45.91%)
 * Likes:    226
 * Dislikes: 0
 * Total Accepted:    26.9K
 * Total Submissions: 58.5K
 * Testcase Example:  '[[1,2]]'
 *
 * 给定一个区间的集合，找到需要移除区间的最小数量，使剩余区间互不重叠。
 * 
 * 注意:
 * 
 * 
 * 可以认为区间的终点总是大于它的起点。
 * 区间 [1,2] 和 [2,3] 的边界相互“接触”，但没有相互重叠。
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入: [ [1,2], [2,3], [3,4], [1,3] ]
 * 
 * 输出: 1
 * 
 * 解释: 移除 [1,3] 后，剩下的区间没有重叠。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [ [1,2], [1,2], [1,2] ]
 * 
 * 输出: 2
 * 
 * 解释: 你需要移除两个 [1,2] 来使剩下的区间没有重叠。
 * 
 * 
 * 示例 3:
 * 
 * 
 * 输入: [ [1,2], [2,3] ]
 * 
 * 输出: 0
 * 
 * 解释: 你不需要移除任何区间，因为它们已经是无重叠的了。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length == 0) return 0;
        Array.Sort(intervals, (a, b) => a[1] - b[1]);
        int ans = 1;
        int x_end = intervals[0][1];
        foreach(var interval in intervals) {
            int start = interval[0];
            if (start >= x_end) {
                ans++;
                x_end = interval[1];
            }
        }
        return intervals.Length - ans;
    }
}
// @lc code=end

