import java.util.*;

/*
 * @lc app=leetcode.cn id=22 lang=java
 *
 * [22] 括号生成
 *
 * https://leetcode-cn.com/problems/generate-parentheses/description/
 *
 * algorithms
 * Medium (72.94%)
 * Likes:    775
 * Dislikes: 0
 * Total Accepted:    79.1K
 * Total Submissions: 107.7K
 * Testcase Example:  '3'
 *
 * 给出 n 代表生成括号的对数，请你写出一个函数，使其能够生成所有可能的并且有效的括号组合。
 * 
 * 例如，给出 n = 3，生成结果为：
 * 
 * [
 * ⁠ "((()))",
 * ⁠ "(()())",
 * ⁠ "(())()",
 * ⁠ "()(())",
 * ⁠ "()()()"
 * ]
 * 
 * 
 */

// @lc code=start
class Solution {
    List<String> ans = new ArrayList<>();
    public void check(String answer, String checked, int num){
        if(num==0){
            if(checked.length()==0) ans.add(answer);
            return;
        }
        if(checked.length()==0) check(answer+"(", checked+"(", num-1);
        else{
            check(answer+"(", checked+"(", num-1);
            check(answer+")", checked.substring(0, checked.length()-1), num-1);
        }
    }
    public List<String> generateParenthesis(int n) {
        check("", "", n*2);
        return ans;
    }
}
// @lc code=end

