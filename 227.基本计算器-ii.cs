/*
 * @lc app=leetcode.cn id=227 lang=csharp
 *
 * [227] 基本计算器 II
 *
 * https://leetcode-cn.com/problems/basic-calculator-ii/description/
 *
 * algorithms
 * Medium (38.87%)
 * Likes:    282
 * Dislikes: 0
 * Total Accepted:    37.4K
 * Total Submissions: 93.6K
 * Testcase Example:  '"3+2*2"'
 *
 * 给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。
 * 
 * 整数除法仅保留整数部分。
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：s = "3+2*2"
 * 输出：7
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：s = " 3/2 "
 * 输出：1
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入：s = " 3+5 / 2 "
 * 输出：5
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * s 由整数和算符 ('+', '-', '*', '/') 组成，中间由一些空格隔开
 * s 表示一个 有效表达式
 * 表达式中的所有整数都是非负整数，且在范围 [0, 2^31 - 1] 内
 * 题目数据保证答案是一个 32-bit 整数
 * 
 * 
 * 
 * 
 */

// @lc code=start
using System.Collections.Generic;
using System.Linq;
using System;
public class Solution {
    public int Calculate(string s) {
        var ans = new List<int>();
        char preSign = '+';
        int num = 0;
        int n = s.Length;
        for (int i = 0; i < n; ++i) {
            if (char.IsDigit(s[i])) {
                num = num * 10 + (s[i] - '0');
            }
            if ((!char.IsDigit(s[i]) && s[i] != ' ' )|| i == n - 1) {
                switch(preSign) {
                    case '+':
                        ans.Add(num);
                        break;
                    case '-':
                        ans.Add(-num);
                        break;
                    case '*':
                        ans[ans.Count - 1] *= num;
                        break;
                    case '/':
                        ans[ans.Count - 1] /= num;
                        break;
                }
                preSign = s[i];
                num = 0;
            }
        }
        foreach(var number in ans) {
            Console.WriteLine(number);
        }
        return ans.Sum(x => x);
    }
}
// @lc code=end

