import java.util.*;

/*
 * @lc app=leetcode.cn id=128 lang=java
 *
 * [128] 最长连续序列
 *
 * https://leetcode-cn.com/problems/longest-consecutive-sequence/description/
 *
 * algorithms
 * Hard (47.40%)
 * Likes:    265
 * Dislikes: 0
 * Total Accepted:    29.6K
 * Total Submissions: 61.4K
 * Testcase Example:  '[100,4,200,1,3,2]'
 *
 * 给定一个未排序的整数数组，找出最长连续序列的长度。
 * 
 * 要求算法的时间复杂度为 O(n)。
 * 
 * 示例:
 * 
 * 输入: [100, 4, 200, 1, 3, 2]
 * 输出: 4
 * 解释: 最长连续序列是 [1, 2, 3, 4]。它的长度为 4。
 * 
 */

// @lc code=start
class Solution {
    public int longestConsecutive(int[] nums) {
        Map<Integer, Integer> m = new HashMap<>();
        int max = 0;
        for(int num : nums){
            if(m.containsKey(num)) continue;
            int length = 1;
            if(m.containsKey(num-1) && m.containsKey(num+1)){
                length = m.get(num-1) + m.get(num+1) + 1;
                m.put(num, length);
                m.put(num - m.get(num-1), length);
                m.put(num + m.get(num+1), length);
            }
            else if(m.containsKey(num-1)){
                length = m.get(num-1) + 1;
                m.put(num, length);
                m.put(num-m.get(num-1), length);
            }
            else if(m.containsKey(num+1)){
                length = m.get(num+1) + 1;
                m.put(num, length);
                m.put(num+m.get(num+1), length);
            }
            else m.put(num, length);
            max = Integer.max(length, max);
        }
        return max;
    }
}
// @lc code=end

