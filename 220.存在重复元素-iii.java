import java.util.*;

/*
 * @lc app=leetcode.cn id=220 lang=java
 *
 * [220] 存在重复元素 III
 *
 * https://leetcode-cn.com/problems/contains-duplicate-iii/description/
 *
 * algorithms
 * Medium (25.68%)
 * Likes:    158
 * Dislikes: 0
 * Total Accepted:    15.1K
 * Total Submissions: 58.4K
 * Testcase Example:  '[1,2,3,1]\n3\n0'
 *
 * 给定一个整数数组，判断数组中是否有两个不同的索引 i 和 j，使得 nums [i] 和 nums [j] 的差的绝对值最大为 t，并且 i 和 j
 * 之间的差的绝对值最大为 ķ。
 * 
 * 示例 1:
 * 
 * 输入: nums = [1,2,3,1], k = 3, t = 0
 * 输出: true
 * 
 * 示例 2:
 * 
 * 输入: nums = [1,0,1,1], k = 1, t = 2
 * 输出: true
 * 
 * 示例 3:
 * 
 * 输入: nums = [1,5,9,1,5,9], k = 2, t = 3
 * 输出: false
 * 
 */

// @lc code=start
class Solution {
    public boolean containsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        TreeSet<Integer> ts = new TreeSet<>();
        for(int i=0;i<nums.length;i++){
            Integer s = ts.ceiling(nums[i]);
            if(s!=null && s<=nums[i]+t) return true;
            Integer g = ts.floor(nums[i]);
            if(g!=null && nums[i]<=g+t) return true;
            ts.add(nums[i]);
            if(ts.size()>k) ts.remove(nums[i-k]);
        }
        return false;
    }
}
// @lc code=end

