/*
 * @lc app=leetcode.cn id=306 lang=java
 *
 * [306] 累加数
 *
 * https://leetcode-cn.com/problems/additive-number/description/
 *
 * algorithms
 * Medium (31.54%)
 * Likes:    61
 * Dislikes: 0
 * Total Accepted:    5.4K
 * Total Submissions: 16.9K
 * Testcase Example:  '"112358"'
 *
 * 累加数是一个字符串，组成它的数字可以形成累加序列。
 * 
 * 一个有效的累加序列必须至少包含 3 个数。除了最开始的两个数以外，字符串中的其他数都等于它之前两个数相加的和。
 * 
 * 给定一个只包含数字 '0'-'9' 的字符串，编写一个算法来判断给定输入是否是累加数。
 * 
 * 说明: 累加序列里的数不会以 0 开头，所以不会出现 1, 2, 03 或者 1, 02, 3 的情况。
 * 
 * 示例 1:
 * 
 * 输入: "112358"
 * 输出: true 
 * 解释: 累加序列为: 1, 1, 2, 3, 5, 8 。1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
 * 
 * 
 * 示例 2:
 * 
 * 输入: "199100199"
 * 输出: true 
 * 解释: 累加序列为: 1, 99, 100, 199。1 + 99 = 100, 99 + 100 = 199
 * 
 * 进阶:
 * 你如何处理一个溢出的过大的整数输入?
 * 
 */

// @lc code=start
class Solution {
    public boolean isAdditiveNumber(String num) {
        if(num.length()<3) return false;
        return helper(num, 0, 0, 0, 0);
    }
    public boolean helper(String num, int start, long sum, long pre, int count) {
        if(start==num.length() && count>2) return true;
        for(int i=start+1;i<=num.length();i++) {
            long tmp;
            try{
                tmp = Long.parseLong(num, start, i, 10);
            }
            catch(NumberFormatException e){
                return false;
            }
            if(String.valueOf(tmp).length() < i-start) return false;
            if(count==0) if(helper(num, i, 0, tmp, count+1)) return true;
            if(count<2 || sum==tmp) if(helper(num, i, pre + tmp, tmp, count+1)) return true;
        }
        return false;
    }
}
// @lc code=end

