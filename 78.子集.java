import java.util.*;

/*
 * @lc app=leetcode.cn id=78 lang=java
 *
 * [78] 子集
 *
 * https://leetcode-cn.com/problems/subsets/description/
 *
 * algorithms
 * Medium (76.07%)
 * Likes:    490
 * Dislikes: 0
 * Total Accepted:    68.3K
 * Total Submissions: 89K
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
class Solution {
    List<List<Integer>>res = new ArrayList<>();
    int[] nums;
    public void combine(int[] nums, int k) {
        int n = nums.length;
        if (k <= 0 || n <= 0){
            res.add(new ArrayList<>());
            return;
        }
        List<Integer> track = new ArrayList<>();
        backtrack(nums, k, 0, track);
        return;
    }

    private void backtrack(int[] nums, int k, int start, List<Integer> track) {
        int n = nums.length;
        // 到达树的底部
        if (k == track.size()) {
            res.add(new ArrayList<Integer>(track));
            return;
        }
        // 注意 i 从 start 开始递增
        for (int i=start;i<n;i++) {
            // 做选择
            track.add(nums[i]);
            backtrack(nums, k, i+1, track);
            // 撤销选择
            track.remove(track.size() - 1);
        }
    }

    public List<List<Integer>> subsets(int[] nums) {
        this.nums = nums;
        int n = nums.length;
        for(int i=0;i<=n;i++) combine(nums, i);
        return res;
    }
}
// @lc code=end

