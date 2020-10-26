using System.Text;
/*
 * @lc app=leetcode.cn id=917 lang=csharp
 *
 * [917] 仅仅反转字母
 *
 * https://leetcode-cn.com/problems/reverse-only-letters/description/
 *
 * algorithms
 * Easy (56.07%)
 * Likes:    63
 * Dislikes: 0
 * Total Accepted:    19.2K
 * Total Submissions: 34.2K
 * Testcase Example:  '"ab-cd"'
 *
 * 给定一个字符串 S，返回 “反转后的” 字符串，其中不是字母的字符都保留在原地，而所有字母的位置发生反转。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入："ab-cd"
 * 输出："dc-ba"
 * 
 * 
 * 示例 2：
 * 
 * 输入："a-bC-dEf-ghIj"
 * 输出："j-Ih-gfE-dCba"
 * 
 * 
 * 示例 3：
 * 
 * 输入："Test1ng-Leet=code-Q!"
 * 输出："Qedo1ct-eeLg=ntse-T!"
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * S.length <= 100
 * 33 <= S[i].ASCIIcode <= 122 
 * S 中不包含 \ or "
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string ReverseOnlyLetters(string S) {
        Stack<char> letters = new Stack<char>();
        foreach(var ch in S) {
            if(char.IsLetter(ch)) letters.Push(ch);
        }
        StringBuilder ans = new StringBuilder();
        foreach(var ch in S) {
            if(char.IsLetter(ch)) {
                ans.Append(letters.Pop());
            }
            else ans.Append(ch);
        }
        return ans.ToString();
    }
}
// @lc code=end

