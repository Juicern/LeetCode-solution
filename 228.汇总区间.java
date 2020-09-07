import java.util.*;

/*
 * @lc app=leetcode.cn id=228 lang=java
 *
 * [228] 汇总区间
 *
 * https://leetcode-cn.com/problems/summary-ranges/description/
 *
 * algorithms
 * Medium (50.54%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    8.3K
 * Total Submissions: 15.9K
 * Testcase Example:  '[0,1,2,4,5,7]'
 *
 * 给定一个无重复元素的有序整数数组，返回数组区间范围的汇总。
 * 
 * 示例 1:
 * 
 * 输入: [0,1,2,4,5,7]
 * 输出: ["0->2","4->5","7"]
 * 解释: 0,1,2 可组成一个连续的区间; 4,5 可组成一个连续的区间。
 * 
 * 示例 2:
 * 
 * 输入: [0,2,3,4,6,8,9]
 * 输出: ["0","2->4","6","8->9"]
 * 解释: 2,3,4 可组成一个连续的区间; 8,9 可组成一个连续的区间。
 * 
 */

// @lc code=start
class Solution {
    public List<String> summaryRanges(int[] nums) {
        List<String> ans = new ArrayList<>();
        int index = 0;
        while(index<nums.length){
            int tmp = index; 
            while(index+1<nums.length && nums[index]+1==nums[index+1]) index++;
            if(index==tmp){
                String res = "" + nums[tmp];
                ans.add(res);
            }
            else{
                String res= nums[tmp] + "->" + nums[index];
                ans.add(res);
            }
            index++;
        }
        return ans;
    }
}
// @lc code=end

