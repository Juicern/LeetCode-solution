/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 *
 * https://leetcode-cn.com/problems/subsets/description/
 *
 * algorithms
 * Medium (77.89%)
 * Likes:    786
 * Dislikes: 0
 * Total Accepted:    145.7K
 * Total Submissions: 185.2K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一组不含重复元素的整数数组 nums，返回该数组所有可能的子集（幂集）。
 * 
 * 说明：解集不能包含重复的子集。
 * 
 * 示例:
 * 
 * 输入: nums = [1,2,3]
 * 输出:
 * [
 * ⁠ [3],
 * [1],
 * [2],
 * [1,2,3],
 * [1,3],
 * [2,3],
 * [1,2],
 * []
 * ]
 * 
 */

// @lc code=start
public class Solution {
    List<IList<int>> ans  = new List<IList<int>>();
    LinkedList<int> pre = new LinkedList<int>();
    public IList<IList<int>> Subsets(int[] nums) {
        Dfs(0, nums);
        return ans;
    }
    public void Dfs(int cur, int[] nums) {
        if(cur == nums.Length) {
            ans.Add(new List<int>(pre));
            return;
        }
        pre.AddLast(nums[cur]);
        Dfs(cur  + 1, nums);
        pre.RemoveLast();
        Dfs(cur + 1, nums);
    }
}
// @lc code=end

