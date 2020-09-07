import java.util.*;
/*
 * @lc app=leetcode.cn id=581 lang=java
 *
 * [581] 最短无序连续子数组
 *
 * https://leetcode-cn.com/problems/shortest-unsorted-continuous-subarray/description/
 *
 * algorithms
 * Easy (34.56%)
 * Likes:    289
 * Dislikes: 0
 * Total Accepted:    25.2K
 * Total Submissions: 72.8K
 * Testcase Example:  '[2,6,4,8,10,9,15]'
 *
 * 给定一个整数数组，你需要寻找一个连续的子数组，如果对这个子数组进行升序排序，那么整个数组都会变为升序排序。
 * 
 * 你找到的子数组应是最短的，请输出它的长度。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [2, 6, 4, 8, 10, 9, 15]
 * 输出: 5
 * 解释: 你只需要对 [6, 4, 8, 10, 9] 进行升序排序，那么整个表都会变为升序排序。
 * 
 * 
 * 说明 :
 * 
 * 
 * 输入的数组长度范围在 [1, 10,000]。
 * 输入的数组可能包含重复元素 ，所以升序的意思是<=。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int findUnsortedSubarray(int[] nums) {
        Stack<Integer> st = new Stack<>();
        int l = nums.length;
        int r = 0;
        for (int i=0;i<nums.length;i++) {
            while (!st.isEmpty() && nums[st.peek()] > nums[i]) {
                l = Math.min(l, st.pop());
            }
            st.push(i);
        }
        st.clear();
        for (int i=nums.length-1;i>=0;i--) {
            while (!st.isEmpty() && nums[st.peek()] < nums[i]) {
                r = Math.max(r, st.pop());
            }
            st.push(i);
        }
        return r-l>0 ? r-l+1 : 0;
    }
}
// @lc code=end

