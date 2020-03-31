import java.util.*;

/*
 * @lc app=leetcode.cn id=179 lang=java
 *
 * [179] 最大数
 *
 * https://leetcode-cn.com/problems/largest-number/description/
 *
 * algorithms
 * Medium (35.09%)
 * Likes:    243
 * Dislikes: 0
 * Total Accepted:    24.8K
 * Total Submissions: 69.4K
 * Testcase Example:  '[10,2]'
 *
 * 给定一组非负整数，重新排列它们的顺序使之组成一个最大的整数。
 * 
 * 示例 1:
 * 
 * 输入: [10,2]
 * 输出: 210
 * 
 * 示例 2:
 * 
 * 输入: [3,30,34,5,9]
 * 输出: 9534330
 * 
 * 说明: 输出结果可能非常大，所以你需要返回一个字符串而不是整数。
 * 
 */

// @lc code=start
class Solution {
    private class LargeComparer implements Comparator<String>{
        @Override
        public int compare(String a, String b){
            String order1 = a + b;
            String order2 = b + a;
            return order2.compareTo(order1);
        }
    }
    public String largestNumber(int[] nums) {
        String[] asStr = new String[nums.length];
        for(int i=0;i<nums.length;i++){
            asStr[i] = String.valueOf(nums[i]);
        }
        Arrays.sort(asStr, new LargeComparer());
        if(asStr[0].equals("0")) return "0";
        String res = new String();
        for(String str : asStr){
            res += str;
        }
        return res;
    }
}
// @lc code=end

