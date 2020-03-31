import java.util.*;

/*
 * @lc app=leetcode.cn id=66 lang=java
 *
 * [66] 加一
 *
 * https://leetcode-cn.com/problems/plus-one/description/
 *
 * algorithms
 * Easy (42.59%)
 * Likes:    439
 * Dislikes: 0
 * Total Accepted:    128.2K
 * Total Submissions: 295.2K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一个由整数组成的非空数组所表示的非负整数，在该数的基础上加一。
 * 
 * 最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
 * 
 * 你可以假设除了整数 0 之外，这个整数不会以零开头。
 * 
 * 示例 1:
 * 
 * 输入: [1,2,3]
 * 输出: [1,2,4]
 * 解释: 输入数组表示数字 123。
 * 
 * 
 * 示例 2:
 * 
 * 输入: [4,3,2,1]
 * 输出: [4,3,2,2]
 * 解释: 输入数组表示数字 4321。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int[] plusOne(int[] digits) {
        Stack<Integer> ans = new Stack<>();
        int n = digits.length;
        int carry = 1;
        for(int i=0;i<n;i++){
            if(carry==0) ans.push(digits[n-1-i]);
            else{
                int num = digits[n-1-i] + 1;
                ans.push(num%10);
                carry = num/10;
            }
        }
        if(carry == 1) ans.push(1);
        int size = ans.size();
        int[] res = new int[size];
        for(int i=0;i<size;i++){
            res[i] = ans.pop();
        }
        return res;
    }
}
// @lc code=end

