import java.util.*;
/*
 * @lc app=leetcode.cn id=233 lang=java
 *
 * [233] 数字 1 的个数
 *
 * https://leetcode-cn.com/problems/number-of-digit-one/description/
 *
 * algorithms
 * Hard (31.82%)
 * Likes:    111
 * Dislikes: 0
 * Total Accepted:    6.3K
 * Total Submissions: 18.3K
 * Testcase Example:  '13'
 *
 * 给定一个整数 n，计算所有小于等于 n 的非负整数中数字 1 出现的个数。
 * 
 * 示例:
 * 
 * 输入: 13
 * 输出: 6 
 * 解释: 数字 1 出现在以下数字中: 1, 10, 11, 12, 13 。
 * 
 */

// @lc code=start
class Solution {
    //xyzabcd
    public int countDigitOne(int n) {
        int res = 0;
        for(long mul=1;mul<=n;mul*=10){
            long xyz = n/(mul*10);
            long a = n%(mul*10)/mul;
            long bcd = n%mul;
            if(a==0) res += xyz*mul;
            else if(a==1) res += 1 + bcd + xyz*mul;
            else{
                res += mul*(xyz+1);
            }
        }
        return res;
    }
}
// @lc code=end

