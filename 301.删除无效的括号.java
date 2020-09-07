import java.util.*;
/*
 * @lc app=leetcode.cn id=301 lang=java
 *
 * [301] 删除无效的括号
 *
 * https://leetcode-cn.com/problems/remove-invalid-parentheses/description/
 *
 * algorithms
 * Hard (44.74%)
 * Likes:    141
 * Dislikes: 0
 * Total Accepted:    8.3K
 * Total Submissions: 18.1K
 * Testcase Example:  '"()())()"'
 *
 * 删除最小数量的无效括号，使得输入的字符串有效，返回所有可能的结果。
 * 
 * 说明: 输入可能包含了除 ( 和 ) 以外的字符。
 * 
 * 示例 1:
 * 
 * 输入: "()())()"
 * 输出: ["()()()", "(())()"]
 * 
 * 
 * 示例 2:
 * 
 * 输入: "(a)())()"
 * 输出: ["(a)()()", "(a())()"]
 * 
 * 
 * 示例 3:
 * 
 * 输入: ")("
 * 输出: [""]
 * 
 */

// @lc code=start
class Solution {
    private Set<String> ans = new HashSet<>();

    private void recurse(String s, int index, int leftCount, int rightCount, int leftRem, int rightRem, StringBuilder exp) {
        if (index==s.length()) {
            if (leftRem==0 && rightRem==0) this.ans.add(exp.toString());
        }
        else {
            char ch = s.charAt(index);
            int len = exp.length();
            if (ch=='(' && leftRem>0) {
                this.recurse(s, index+1, leftCount, rightCount, leftRem-1, rightRem, exp);
            }
            else if (ch==')' && rightRem>0) {
                this.recurse(s, index+1, leftCount, rightCount, leftRem, rightRem-1, exp);
            }
            exp.append(ch);
            if (ch!='(' && ch!=')') {
                this.recurse(s, index+1, leftCount, rightCount, leftRem, rightRem, exp);
            }
            else if (ch=='(') {
                this.recurse(s, index+1, leftCount+1, rightCount, leftRem, rightRem, exp);
            }
            else if (ch==')' && rightCount < leftCount) {
                this.recurse(s, index+1, leftCount, rightCount+1, leftRem, rightRem, exp);
            }
            exp.deleteCharAt(len);
        }
    }

    public List<String> removeInvalidParentheses(String s) {
        int left = 0;
        int right = 0;
        for (int i=0;i<s.length();i++) {
            if (s.charAt(i)=='(') left++;
            else if (s.charAt(i)==')') {
                right = left==0 ? right+1 : right;
                left = left>0 ? left-1 : left;
            }
        }
        this.recurse(s, 0, 0, 0, left, right, new StringBuilder());
        return new ArrayList<String>(this.ans);
    }
}
// @lc code=end

