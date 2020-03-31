import java.util.*;

/*
 * @lc app=leetcode.cn id=47 lang=java
 *
 * [47] 全排列 II
 *
 * https://leetcode-cn.com/problems/permutations-ii/description/
 *
 * algorithms
 * Medium (56.59%)
 * Likes:    237
 * Dislikes: 0
 * Total Accepted:    42.7K
 * Total Submissions: 74.5K
 * Testcase Example:  '[1,1,2]'
 *
 * 给定一个可包含重复数字的序列，返回所有不重复的全排列。
 * 
 * 示例:
 * 
 * 输入: [1,1,2]
 * 输出:
 * [
 * ⁠ [1,1,2],
 * ⁠ [1,2,1],
 * ⁠ [2,1,1]
 * ]
 * 
 */

// @lc code=start
class Solution {
    private void backTrace(int len, int first, List<List<Integer>> ans, ArrayList<Integer> nums){
        if(first == len) ans.add(new ArrayList<>(nums));
        Set<Integer> s = new HashSet<>();
        for(int i=first;i<len;i++){
            if(s.contains(nums.get(i))) continue;
            Collections.swap(nums, i, first);
            backTrace(len, first+1, ans, nums);
            Collections.swap(nums, i, first);
            s.add(nums.get(i));
        }
    }
    public List<List<Integer>> permuteUnique(int[] nums) {
        List<List<Integer>> ans = new ArrayList<>();
        ArrayList<Integer> nums_lst = new ArrayList<>();
        Arrays.sort(nums);
        for(int num : nums) nums_lst.add(num);
        int len = nums.length;
        backTrace(len, 0, ans, nums_lst);
        return ans;
    }
}
// @lc code=end

