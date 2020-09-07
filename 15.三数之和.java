import java.util.*;

/*
 * @lc app=leetcode.cn id=15 lang=java
 *
 * [15] 三数之和
 *
 * https://leetcode-cn.com/problems/3sum/description/
 *
 * algorithms
 * Medium (25.18%)
 * Likes:    1859
 * Dislikes: 0
 * Total Accepted:    165K
 * Total Submissions: 641.7K
 * Testcase Example:  '[-1,0,1,2,-1,-4]'
 *
 * 给定一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0
 * ？找出所有满足条件且不重复的三元组。
 * 
 * 注意：答案中不可以包含重复的三元组。
 * 
 * 
 * 
 * 示例：
 * 
 * 给定数组 nums = [-1, 0, 1, 2, -1, -4]，
 * 
 * 满足要求的三元组集合为：
 * [
 * ⁠ [-1, 0, 1],
 * ⁠ [-1, -1, 2]
 * ]
 * 
 * 
 */

// @lc code=start
class Solution {
    public List<List<Integer>> threeSum(int[] nums) {
        List<List<Integer>> ans = new LinkedList<>();
        Arrays.sort(nums);
        for (int i=0;i<nums.length;i++) {
            if(i>0 && nums[i]==nums[i-1]) continue;
            int left = i+1;
            int right = nums.length-1;
            while (left<right) {
                int sum = nums[left] + nums[right] + nums[i];
                if (sum==0) {
                    ans.add(Arrays.asList(nums[i], nums[left], nums[right]));
                    while(left<nums.length-1 && nums[left]==nums[left+1]) left++;
                    while(right>0 && nums[right]==nums[right-1]) right--;
                    left++;
                    right--;        
                }
                else if(sum<0) left++;
                else if(sum>0) right--;
            }
        }
        return ans;
    }
}
// @lc code=end

