using System;
/*
 * @lc app=leetcode.cn id=128 lang=csharp
 *
 * [128] 最长连续序列
 *
 * https://leetcode-cn.com/problems/longest-consecutive-sequence/description/
 *
 * algorithms
 * Hard (51.95%)
 * Likes:    544
 * Dislikes: 0
 * Total Accepted:    78.8K
 * Total Submissions: 151.4K
 * Testcase Example:  '[100,4,200,1,3,2]'
 *
 * 给定一个未排序的整数数组，找出最长连续序列的长度。
 * 
 * 要求算法的时间复杂度为 O(n)。
 * 
 * 示例:
 * 
 * 输入: [100, 4, 200, 1, 3, 2]
 * 输出: 4
 * 解释: 最长连续序列是 [1, 2, 3, 4]。它的长度为 4。
 * 
 */

// @lc code=start
public class Solution {
    public int LongestConsecutive(int[] nums) {
        int ans = 0;
        var set = new HashSet<int>();
        foreach(var num in nums) {
            set.Add(num);
        }
        foreach(var num in set) {
            if(!set.Contains(num - 1)) {
                int cur = num;
                int count = 0;
                while(set.Contains(cur)) {
                    cur++;
                    count++;
                }
                ans = Math.Max(ans, count);
            }
        }
        return ans;
    }
}
// @lc code=end

