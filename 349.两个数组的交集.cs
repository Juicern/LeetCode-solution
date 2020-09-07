using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=349 lang=csharp
 *
 * [349] 两个数组的交集
 *
 * https://leetcode-cn.com/problems/intersection-of-two-arrays/description/
 *
 * algorithms
 * Easy (69.28%)
 * Likes:    187
 * Dislikes: 0
 * Total Accepted:    70.6K
 * Total Submissions: 101.8K
 * Testcase Example:  '[1,2,2,1]\n[2,2]'
 *
 * 给定两个数组，编写一个函数来计算它们的交集。
 * 
 * 示例 1:
 * 
 * 输入: nums1 = [1,2,2,1], nums2 = [2,2]
 * 输出: [2]
 * 
 * 
 * 示例 2:
 * 
 * 输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * 输出: [9,4]
 * 
 * 说明:
 * 
 * 
 * 输出结果中的每个元素一定是唯一的。
 * 我们可以不考虑输出结果的顺序。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var set = new HashSet<int>();
        var ans = new HashSet<int>();
        foreach(int num in nums1) {
            set.Add(num);
        }
        foreach(int num in nums2) {
            if(set.Contains(num)) ans.Add(num);
        }
        var res = new int[ans.Count];
        int index = 0;
        foreach(int num in ans) {
            res[index++] = num;
        }
        return res;
    }
}
// @lc code=end

