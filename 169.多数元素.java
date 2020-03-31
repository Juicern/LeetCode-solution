import java.util.*;

/*
 * @lc app=leetcode.cn id=169 lang=java
 *
 * [169] 多数元素
 *
 * https://leetcode-cn.com/problems/majority-element/description/
 *
 * algorithms
 * Easy (61.19%)
 * Likes:    526
 * Dislikes: 0
 * Total Accepted:    147.3K
 * Total Submissions: 234.8K
 * Testcase Example:  '[3,2,3]'
 *
 * 给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。
 * 
 * 你可以假设数组是非空的，并且给定的数组总是存在多数元素。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: [3,2,3]
 * 输出: 3
 * 
 * 示例 2:
 * 
 * 输入: [2,2,1,1,1,2,2]
 * 输出: 2
 * 
 * 
 */

// @lc code=start
class Solution {
    public int majorityElement(int[] nums) {
        int n = nums.length;
        Map<Integer, Integer> m = new HashMap<>();
        for(int i=0;i<n;i++){
            m.put(nums[i], m.getOrDefault(nums[i], 0)+1);
            if(m.get(nums[i]) > n/2) return nums[i];
        }
        return -1;
    }
}
// @lc code=end

