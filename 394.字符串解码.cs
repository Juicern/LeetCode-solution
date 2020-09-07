/*
 * @lc app=leetcode.cn id=394 lang=csharp
 *
 * [394] 字符串解码
 *
 * https://leetcode-cn.com/problems/decode-string/description/
 *
 * algorithms
 * Medium (52.72%)
 * Likes:    404
 * Dislikes: 0
 * Total Accepted:    50.1K
 * Total Submissions: 95.1K
 * Testcase Example:  '"3[a]2[bc]"'
 *
 * 给定一个经过编码的字符串，返回它解码后的字符串。
 * 
 * 编码规则为: k[encoded_string]，表示其中方括号内部的 encoded_string 正好重复 k 次。注意 k 保证为正整数。
 * 
 * 你可以认为输入字符串总是有效的；输入字符串中没有额外的空格，且输入的方括号总是符合格式要求的。
 * 
 * 此外，你可以认为原始数据不包含数字，所有的数字只表示重复的次数 k ，例如不会出现像 3a 或 2[4] 的输入。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：s = "3[a]2[bc]"
 * 输出："aaabcbc"
 * 
 * 
 * 示例 2：
 * 
 * 输入：s = "3[a2[c]]"
 * 输出："accaccacc"
 * 
 * 
 * 示例 3：
 * 
 * 输入：s = "2[abc]3[cd]ef"
 * 输出："abcabccdcdcdef"
 * 
 * 
 * 示例 4：
 * 
 * 输入：s = "abc3[cd]xyz"
 * 输出："abccdcdcdxyz"
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string DecodeString(string s) {
        if(s == null || s.Length == 0) return string.Empty;
        var stack = new Stack<char>();
        for(int i =0;i<s.Length;i++) {
            if(s[i] != ']') stack.Push(s[i]);
            else {
                var temp = new List<char>();
                int count = 0;
                int k = 0;
                while(stack.Any() && stack.Peek() != '[') temp.Add(stack.Pop());
                if(stack.Any() && stack.Peek() == '[') stack.Pop();
                while(stack.Any() && stack.Peek() >= '0' && stack.Peek() <= '9') {
                    count += (stack.Pop() - '0') * (int)(Math.Pow(10, k++));
                }
                for(int l = 0;l<count;l++) {
                    for(int m = temp.Count - 1;m>=0;m--){
                        stack.Push(temp[m]);
                    }
                }
            }
        }
        return new string(stack.ToArray().Reverse().ToArray());
    }
}
// @lc code=end

