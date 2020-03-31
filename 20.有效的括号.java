import java.util.*;

/*
 * @lc app=leetcode.cn id=20 lang=java
 *
 * [20] 有效的括号
 *
 * https://leetcode-cn.com/problems/valid-parentheses/description/
 *
 * algorithms
 * Easy (40.60%)
 * Likes:    1412
 * Dislikes: 0
 * Total Accepted:    213.3K
 * Total Submissions: 520.7K
 * Testcase Example:  '"()"'
 *
 * 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
 * 
 * 有效字符串需满足：
 * 
 * 
 * 左括号必须用相同类型的右括号闭合。
 * 左括号必须以正确的顺序闭合。
 * 
 * 
 * 注意空字符串可被认为是有效字符串。
 * 
 * 示例 1:
 * 
 * 输入: "()"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: "()[]{}"
 * 输出: true
 * 
 * 
 * 示例 3:
 * 
 * 输入: "(]"
 * 输出: false
 * 
 * 
 * 示例 4:
 * 
 * 输入: "([)]"
 * 输出: false
 * 
 * 
 * 示例 5:
 * 
 * 输入: "{[]}"
 * 输出: true
 * 
 */

// @lc code=start
class Solution {
    public boolean isValid(String s) {
        char[] ch = s.toCharArray();
        Map<Character, Character> m = new HashMap<>();
        m.put(')', '(');
        m.put(']', '[');
        m.put('}', '{');
        Stack<Character> st = new Stack<Character>();
        for(int i=0;i<s.length();i++){
            if(ch[i]=='(' || ch[i]=='['|| ch[i]=='{') st.push(ch[i]);
            else{
                if(st.empty()) return false;
                if(st.peek() != m.get(ch[i])) return false;
                st.pop();
            }
        }
        if(!st.empty()) return false;
        return true;
    }
}
// @lc code=end

