import java.util.*;

/*
 * @lc app=leetcode.cn id=46 lang=java
 *
 * [46] 全排列
 *
 * https://leetcode-cn.com/problems/permutations/description/
 *
 * algorithms
 * Medium (73.64%)
 * Likes:    555
 * Dislikes: 0
 * Total Accepted:    85.8K
 * Total Submissions: 115.5K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一个没有重复数字的序列，返回其所有可能的全排列。
 * 
 * 示例:
 * 
 * 输入: [1,2,3]
 * 输出:
 * [
 * ⁠ [1,2,3],
 * ⁠ [1,3,2],
 * ⁠ [2,1,3],
 * ⁠ [2,3,1],
 * ⁠ [3,1,2],
 * ⁠ [3,2,1]
 * ]
 * 
 */

// @lc code=start
class Solution {
    private void backTrace(int len, int first, List<List<Integer>> ans, ArrayList<Integer> nums){
        if(first == len) ans.add(new ArrayList<>(nums));
        for(int i=first;i<len;i++){
            Collections.swap(nums, i, first);
            backTrace(len, first+1, ans, nums);
            Collections.swap(nums, i, first);
        }
    }
    public List<List<Integer>> permute(int[] nums) {
        List<List<Integer>> ans = new ArrayList<>();
        ArrayList<Integer> nums_lst = new ArrayList<>();
        for(int num : nums) nums_lst.add(num);
        int len = nums.length;
        backTrace(len, 0, ans, nums_lst);
        return ans;
    }
}
// @lc code=end

