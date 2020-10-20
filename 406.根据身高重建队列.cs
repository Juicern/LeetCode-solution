using System.Collections.Generic;
using System;
/*
 * @lc app=leetcode.cn id=406 lang=csharp
 *
 * [406] 根据身高重建队列
 *
 * https://leetcode-cn.com/problems/queue-reconstruction-by-height/description/
 *
 * algorithms
 * Medium (67.47%)
 * Likes:    512
 * Dislikes: 0
 * Total Accepted:    45.2K
 * Total Submissions: 66.9K
 * Testcase Example:  '[[7,0],[4,4],[7,1],[5,0],[6,1],[5,2]]'
 *
 * 假设有打乱顺序的一群人站成一个队列。 每个人由一个整数对(h, k)表示，其中h是这个人的身高，k是排在这个人前面且身高大于或等于h的人数。
 * 编写一个算法来重建这个队列。
 * 
 * 注意：
 * 总人数少于1100人。
 * 
 * 示例
 * 
 * 
 * 输入:
 * [[7,0], [4,4], [7,1], [5,0], [6,1], [5,2]]
 * 
 * 输出:
 * [[5,0], [7,0], [5,2], [6,1], [4,4], [7,1]]
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        Array.Sort(people, (a, b) => a[0] == b[0] ? a[1] - b[1] : b[0] - a[0]);
        var ans = new List<int[]>();
        foreach(var person in people) ans.Insert(person[1], person);
        return ans.ToArray();
    }          
}
// @lc code=end

