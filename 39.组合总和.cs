/*
 * @lc app=leetcode.cn id=39 lang=csharp
 *
 * [39] 组合总和
 *
 * https://leetcode-cn.com/problems/combination-sum/description/
 *
 * algorithms
 * Medium (69.62%)
 * Likes:    858
 * Dislikes: 0
 * Total Accepted:    136K
 * Total Submissions: 194.2K
 * Testcase Example:  '[2,3,6,7]\n7'
 *
 * 给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
 * 
 * candidates 中的数字可以无限制重复被选取。
 * 
 * 说明：
 * 
 * 
 * 所有数字（包括 target）都是正整数。
 * 解集不能包含重复的组合。 
 * 
 * 
 * 示例 1：
 * 
 * 输入：candidates = [2,3,6,7], target = 7,
 * 所求解集为：
 * [
 * ⁠ [7],
 * ⁠ [2,2,3]
 * ]
 * 
 * 
 * 示例 2：
 * 
 * 输入：candidates = [2,3,5], target = 8,
 * 所求解集为：
 * [
 * [2,2,2,2],
 * [2,3,3],
 * [3,5]
 * ]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= candidates.length <= 30
 * 1 <= candidates[i] <= 200
 * candidate 中的每个元素都是独一无二的。
 * 1 <= target <= 500
 * 
 * 
 */

// @lc code=start
public class Solution {
    List<IList<int>> ans = new List<IList<int>>();
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Helper(candidates, 0, 0, target, new List<int>());
        return ans;
    }
    private void Helper(int[] candidates, int start, int sum, int target, List<int> pre) {
        if(sum > target) return;
        if(sum == target) {
            ans.Add(new List<int>(pre));
        }
        for(int i = start; i< candidates.Length;i++) {
            pre.Add(candidates[i]);
            Helper(candidates, i, sum + candidates[i], target, pre);
            pre.RemoveAt(pre.Count - 1);
        }
    }
}
// @lc code=end

