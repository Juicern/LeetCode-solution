import java.util.*;
/*
 * @lc app=leetcode.cn id=273 lang=java
 *
 * [273] 整数转换英文表示
 *
 * https://leetcode-cn.com/problems/integer-to-english-words/description/
 *
 * algorithms
 * Hard (25.80%)
 * Likes:    61
 * Dislikes: 0
 * Total Accepted:    4.4K
 * Total Submissions: 16.7K
 * Testcase Example:  '123'
 *
 * 将非负整数转换为其对应的英文表示。可以保证给定输入小于 2^31 - 1 。
 * 
 * 示例 1:
 * 
 * 输入: 123
 * 输出: "One Hundred Twenty Three"
 * 
 * 
 * 示例 2:
 * 
 * 输入: 12345
 * 输出: "Twelve Thousand Three Hundred Forty Five"
 * 
 * 示例 3:
 * 
 * 输入: 1234567
 * 输出: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
 * 
 * 示例 4:
 * 
 * 输入: 1234567891
 * 输出: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven
 * Thousand Eight Hundred Ninety One"
 * 
 */

// @lc code=start
class Solution {
    Map<Integer, String> m = new HashMap<>();
    public String helper(int num){
        String ans = "";
        if(num>=100) ans += m.get(num/100) + " " + "Hundred" + " ";
        num = num%100;
        if(num<20) ans += m.get(num);
        else{
            ans += m.get(num/10*10) + " " + m.get(num%10);
        } 
        return ans.trim();
    }
    public String numberToWords(int num) {
        if(num==0) return "Zero";
        m.put(0, "");
        m.put(1, "One");
        m.put(2, "Two");
        m.put(3, "Three");
        m.put(4, "Four");
        m.put(5, "Five");
        m.put(6, "Six");
        m.put(7, "Seven");
        m.put(8, "Eight");
        m.put(9, "Nine");
        m.put(10, "Ten");
        m.put(11, "Eleven");
        m.put(12, "Twelve");
        m.put(13, "Thirteen");
        m.put(14, "Fourteen");
        m.put(15, "Fifteen");
        m.put(16, "Sixteen");
        m.put(17, "Seventeen");
        m.put(18, "Eighteen");
        m.put(19, "Nineteen");
        m.put(20, "Twenty");
        m.put(30, "Thirty");
        m.put(40, "Forty");
        m.put(50, "Fifty");
        m.put(60, "Sixty");
        m.put(70, "Seventy");
        m.put(80, "Eighty");
        m.put(90, "Ninety");
        String ans = "";
        String[] words = new String[4];
        words[0] = "";
        words[1] = "Thousand";
        words[2] = "Million";
        words[3] = "Billion";
        int index = 0;
        while(num!=0){
            if(num%1000!=0) ans = helper(num%1000) + " " + words[index] + " " + ans;
            index++;
            num /= 1000;
        }
        return ans.trim();
    }
}
// @lc code=end

