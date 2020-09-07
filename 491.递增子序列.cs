using System.Xml.Linq;
using System.Linq;
/*
 * @lc app=leetcode.cn id=491 lang=csharp
 *
 * [491] 递增子序列
 *
 * https://leetcode-cn.com/problems/increasing-subsequences/description/
 *
 * algorithms
 * Medium (48.70%)
 * Likes:    96
 * Dislikes: 0
 * Total Accepted:    7.8K
 * Total Submissions: 16.1K
 * Testcase Example:  '[4,6,7,7]'
 *
 * 给定一个整型数组, 你的任务是找到所有该数组的递增子序列，递增子序列的长度至少是2。
 * 
 * 示例:
 * 
 * 
 * 输入: [4, 6, 7, 7]
 * 输出: [[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7],
 * [4,7,7]]
 * 
 * 说明:
 * 
 * 
 * 给定数组的长度不会超过15。
 * 数组中的整数范围是 [-100,100]。
 * 给定数组中可能包含重复数字，相等的数字应该被视为递增的一种情况。
 * 
 * 
 */

// @lc code=start
public class Solution {
    IList<IList<int>> ans = new List<IList<int>>();
    public IList<IList<int>> FindSubsequences(int[] nums) {
        Dfs(0, new List<int>(), nums);
        return ans;
    }
    private void Dfs(int index, List<int> subsequences, int[] nums) {
        var set = new HashSet<int>();
        for(int i = index; i < nums.Length;i++)         {
            if ((subsequences.Count > 0 && subsequences[subsequences.Count - 1] > nums[i]) || set.Contains(nums[i]))
                continue;
            set.Add(nums[i]);
            subsequences.Add(nums[i]);
            if (subsequences.Count != 1) {
                ans.Add(subsequences.ToList());
            }
            Dfs(i+1, subsequences, nums);
            subsequences.RemoveAt(subsequences.Count - 1);
        }
    }
}
// @lc code=end

