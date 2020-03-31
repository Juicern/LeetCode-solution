/*
 * @lc app=leetcode.cn id=67 lang=java
 *
 * [67] 二进制求和
 *
 * https://leetcode-cn.com/problems/add-binary/description/
 *
 * algorithms
 * Easy (51.89%)
 * Likes:    320
 * Dislikes: 0
 * Total Accepted:    68.1K
 * Total Submissions: 130.3K
 * Testcase Example:  '"11"\n"1"'
 *
 * 给定两个二进制字符串，返回他们的和（用二进制表示）。
 * 
 * 输入为非空字符串且只包含数字 1 和 0。
 * 
 * 示例 1:
 * 
 * 输入: a = "11", b = "1"
 * 输出: "100"
 * 
 * 示例 2:
 * 
 * 输入: a = "1010", b = "1011"
 * 输出: "10101"
 * 
 */

// @lc code=start
class Solution {
    public String addBinary(String a, String b) {
        int length_a = a.length();
        int length_b = b.length();
        int n;
        if(length_a > length_b){
            n = length_a;
            for(int i=0;i<length_a-length_b;i++){
                b = "0" + b;
            }
        }
        else{
            n = length_b;
            for(int i=0;i<length_b-length_a;i++){
                a = "0" + a;
            }
        }
        String ans = "";
        int carry = 0;
        for(int i=0;i<n;i++){
            int a_num = a.charAt(n-1-i) -'0';
            int b_num = b.charAt(n-1-i) -'0';
            int temp = a_num + b_num + carry;           
            ans = temp%2 + ans;
            carry = temp/2;
        }
        if(carry == 1) ans = "1" + ans;
        return ans;
    }
}
// @lc code=end

