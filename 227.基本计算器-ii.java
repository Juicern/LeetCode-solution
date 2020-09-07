import java.util.*;
/*
 * @lc app=leetcode.cn id=227 lang=java
 *
 * [227] 基本计算器 II
 *
 * https://leetcode-cn.com/problems/basic-calculator-ii/description/
 *
 * algorithms
 * Medium (34.47%)
 * Likes:    117
 * Dislikes: 0
 * Total Accepted:    13.6K
 * Total Submissions: 38.7K
 * Testcase Example:  '"3+2*2"'
 *
 * 实现一个基本的计算器来计算一个简单的字符串表达式的值。
 * 
 * 字符串表达式仅包含非负整数，+， - ，*，/ 四种运算符和空格  。 整数除法仅保留整数部分。
 * 
 * 示例 1:
 * 
 * 输入: "3+2*2"
 * 输出: 7
 * 
 * 
 * 示例 2:
 * 
 * 输入: " 3/2 "
 * 输出: 1
 * 
 * 示例 3:
 * 
 * 输入: " 3+5 / 2 "
 * 输出: 5
 * 
 * 
 * 说明：
 * 
 * 
 * 你可以假设所给定的表达式都是有效的。
 * 请不要使用内置的库函数 eval。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int calculate(String s) {
        Stack<Integer> st = new Stack<>();
        if(s.length()==0) return 0;
        int flag = 1;   //1->+ -1->-
        int mflag = 0;  //1->* -1->/ 0->null
        for(int i=0;i<s.length();i++){
            char ch = s.charAt(i);
            if(Character.isDigit(ch)){
                int result = 0;
                while(i<s.length() && Character.isDigit(s.charAt(i))){
                    result = result*10 + s.charAt(i)-'0';
                    i++;
                }
                i--;
                if(flag==1){
                    st.push(result);
                }
                else if(flag==-1){
                    st.push(-result);
                }
                else if(mflag==1){
                    st.push(st.pop()*result);
                }
                else if(mflag==-1){
                    st.push(st.pop()/result);
                }
            }
            else if(ch=='+'){
                flag = 1;
                mflag = 0;
            }
            else if(ch=='-'){
                flag = -1;
                mflag = 0;
            }
            else if(ch=='*'){
                mflag = 1;
                flag = 0;
            }
            else if(ch=='/'){
                mflag = -1;
                flag = 0;
            }
        }
        int ans = 0;
        while(st.size()>0){
            ans += st.pop();
        }
        return ans;
    }
}
// @lc code=end

