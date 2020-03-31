/*
 * @lc app=leetcode.cn id=43 lang=java
 *
 * [43] 字符串相乘
 *
 * https://leetcode-cn.com/problems/multiply-strings/description/
 *
 * algorithms
 * Medium (41.32%)
 * Likes:    278
 * Dislikes: 0
 * Total Accepted:    47.5K
 * Total Submissions: 113.7K
 * Testcase Example:  '"2"\n"3"'
 *
 * 给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。
 * 
 * 示例 1:
 * 
 * 输入: num1 = "2", num2 = "3"
 * 输出: "6"
 * 
 * 示例 2:
 * 
 * 输入: num1 = "123", num2 = "456"
 * 输出: "56088"
 * 
 * 说明：
 * 
 * 
 * num1 和 num2 的长度小于110。
 * num1 和 num2 只包含数字 0-9。
 * num1 和 num2 均不以零开头，除非是数字 0 本身。
 * 不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。
 * 
 * 
 */

// @lc code=start
class Solution {
    public String multiply(String num1, String num2) {
        if(num1.equals("0") || num2.equals("0")) return "0";
        char[] ch1 = num1.toCharArray();
        char[] ch2 = num2.toCharArray();
        int[] n1 = new int[ch1.length];
        int[] n2 = new int[ch2.length];
        for(int i=0;i<ch1.length;i++) n1[i] = ch1[ch1.length-1-i]-'0';
        for(int i=0;i<ch2.length;i++) n2[i] = ch2[ch2.length-1-i]-'0';
        String ans = "";
        int carry = 0;
        int n = 0;
        while(n<=(ch1.length-1)+(ch2.length-1)){
            int store = carry;
            for(int i=0;i<=n;i++){
                if(i>=ch1.length || n-i>=ch2.length) continue;
                store += n1[i]*n2[n-i];
            }
            carry = store/10;
            ans = store%10 + ans;
            n++;
        }
        if(carry!=0) ans = carry + ans;
        return ans;
    }
}
// @lc code=end

