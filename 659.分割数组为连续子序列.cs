using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=659 lang=csharp
 *
 * [659] 分割数组为连续子序列
 *
 * https://leetcode-cn.com/problems/split-array-into-consecutive-subsequences/description/
 *
 * algorithms
 * Medium (42.51%)
 * Likes:    123
 * Dislikes: 0
 * Total Accepted:    4.9K
 * Total Submissions: 11.4K
 * Testcase Example:  '[1,2,3,3,4,5]'
 *
 * 给你一个按升序排序的整数数组 num（可能包含重复数字），请你将它们分割成一个或多个子序列，其中每个子序列都由连续整数组成且长度至少为 3 。
 * 
 * 如果可以完成上述分割，则返回 true ；否则，返回 false 。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入: [1,2,3,3,4,5]
 * 输出: True
 * 解释:
 * 你可以分割出这样两个连续子序列 : 
 * 1, 2, 3
 * 3, 4, 5
 * 
 * 
 * 
 * 
 * 示例 2：
 * 
 * 输入: [1,2,3,3,4,4,5,5]
 * 输出: True
 * 解释:
 * 你可以分割出这样两个连续子序列 : 
 * 1, 2, 3, 4, 5
 * 3, 4, 5
 * 
 * 
 * 
 * 
 * 示例 3：
 * 
 * 输入: [1,2,3,4,4,5]
 * 输出: False
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 输入的数组长度范围为 [1, 10000]
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool IsPossible(int[] nums) {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        Dictionary<int, int> tails = new Dictionary<int, int>();
        foreach(var num in nums) {
            if(!counts.ContainsKey(num)) counts.Add(num, 0);
            counts[num]++;
        }
        foreach(var num in nums ){
            if(!counts.ContainsKey(num)) continue;
            if(tails.ContainsKey(num -1)) {
                tails[num - 1]--;
                if(tails[num - 1] == 0) tails.Remove(num - 1);
                if(!tails.ContainsKey(num)) tails.Add(num, 0);
                tails[num]++;
                counts[num]--;
                if(counts[num] == 0) counts.Remove(num);
            } 
            else if(counts.ContainsKey(num + 1) && counts.ContainsKey(num + 2)) {
                counts[num]--;
                if(counts[num] == 0) counts.Remove(num);
                counts[num + 1]--;
                if(counts[num + 1] == 0) counts.Remove(num + 1);
                counts[num + 2]--;
                if(counts[num + 2] == 0) counts.Remove(num + 2);
                if(!tails.ContainsKey(num + 2)) tails.Add(num + 2, 0);
                tails[num + 2]++;
            }
            else {
                return false;
            }
        } 
        return true;
    }
}
// @lc code=end

