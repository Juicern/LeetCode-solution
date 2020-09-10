using System;
using System.ComponentModel;
/*
 * @lc app=leetcode.cn id=40 lang=csharp
 *
 * [40] 组合总和 II
 *
 * https://leetcode-cn.com/problems/combination-sum-ii/description/
 *
 * algorithms
 * Medium (62.55%)
 * Likes:    374
 * Dislikes: 0
 * Total Accepted:    91.2K
 * Total Submissions: 143.1K
 * Testcase Example:  '[10,1,2,7,6,1,5]\n8'
 *
 * 给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
 * 
 * candidates 中的每个数字在每个组合中只能使用一次。
 * 
 * 说明：
 * 
 * 
 * 所有数字（包括目标数）都是正整数。
 * 解集不能包含重复的组合。 
 * 
 * 
 * 示例 1:
 * 
 * 输入: candidates = [10,1,2,7,6,1,5], target = 8,
 * 所求解集为:
 * [
 * ⁠ [1, 7],
 * ⁠ [1, 2, 5],
 * ⁠ [2, 6],
 * ⁠ [1, 1, 6]
 * ]
 * 
 * 
 * 示例 2:
 * 
 * 输入: candidates = [2,5,2,1,2], target = 5,
 * 所求解集为:
 * [
 * [1,2,2],
 * [5]
 * ]
 * 
 */

// @lc code=start
public class Solution {
    int n;
    List<IList<int>> ans = new List<IList<int>>();
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        n = candidates.Length;
        Array.Sort(candidates);
        Dfs(candidates, 0, 0, new List<int>(), target);
        return ans;
    }
    private void Dfs(int[] candidates, int start, int sum, List<int> pre,  int target) {
        if(target == sum) {
            ans.Add(new List<int>(pre));
            return;
        }
        if(target < sum) return;
        for(int i = start; i< n;i++) {
            if(i > start && candidates[i] == candidates[i - 1]) continue;
            pre.Add(candidates[i]);
            Dfs(candidates, i + 1, sum + candidates[i], pre, target);
            pre.RemoveAt(pre.Count - 1);
        }
    }
}
// @lc code=end

