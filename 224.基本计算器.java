import java.util.*;
/*
 * @lc app=leetcode.cn id=224 lang=java
 *
 * [224] 基本计算器
 *
 * https://leetcode-cn.com/problems/basic-calculator/description/
 *
 * algorithms
 * Hard (36.68%)
 * Likes:    164
 * Dislikes: 0
 * Total Accepted:    11.5K
 * Total Submissions: 31.1K
 * Testcase Example:  '"1 + 1"'
 *
 * 实现一个基本的计算器来计算一个简单的字符串表达式的值。
 * 
 * 字符串表达式可以包含左括号 ( ，右括号 )，加号 + ，减号 -，非负整数和空格  。
 * 
 * 示例 1:
 * 
 * 输入: "1 + 1"
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 输入: " 2-1 + 2 "
 * 输出: 3
 * 
 * 示例 3:
 * 
 * 输入: "(1+(4+5+2)-3)+(6+8)"
 * 输出: 23
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
        int result = 0;
        int curNum = 0;
        int sign = 1;
        for(int i=0;i<s.length();i++){
            char ch = s.charAt(i);
            if(ch==' ') continue;
            if(Character.isDigit(ch)){
                curNum = curNum*10 + ch-'0';
            }
            else if(ch=='+'){
                result += sign*curNum;
                sign = 1;
                curNum = 0;
            }
            else if(ch=='-'){
                result += sign*curNum;
                sign = -1;
                curNum = 0;
            }
            else if(ch=='('){
                st.push(result);
                st.push(sign);
                sign = 1;
                result = 0;
            }
            else if(ch==')'){
                result += sign*curNum;
                result *= st.pop();
                result += st.pop();
                curNum = 0;
            }
        }
        return result + sign*curNum;
    }
}
// @lc code=end

