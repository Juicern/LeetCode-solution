#
# @lc app=leetcode.cn id=227 lang=python3
#
# [227] 基本计算器 II
#
# https://leetcode-cn.com/problems/basic-calculator-ii/description/
#
# algorithms
# Medium (38.87%)
# Likes:    282
# Dislikes: 0
# Total Accepted:    37.4K
# Total Submissions: 93.6K
# Testcase Example:  '"3+2*2"'
#
# 给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。
# 
# 整数除法仅保留整数部分。
# 
# 
# 
# 
# 
# 示例 1：
# 
# 
# 输入：s = "3+2*2"
# 输出：7
# 
# 
# 示例 2：
# 
# 
# 输入：s = " 3/2 "
# 输出：1
# 
# 
# 示例 3：
# 
# 
# 输入：s = " 3+5 / 2 "
# 输出：5
# 
# 
# 
# 
# 提示：
# 
# 
# 1 
# s 由整数和算符 ('+', '-', '*', '/') 组成，中间由一些空格隔开
# s 表示一个 有效表达式
# 表达式中的所有整数都是非负整数，且在范围 [0, 2^31 - 1] 内
# 题目数据保证答案是一个 32-bit 整数
# 
# 
# 
# 
#

# @lc code=start
class Solution:
    def calculate(self, s: str) -> int:
        ops = {'+', '-', '*', '/'}
        ans = []
        num = 0
        preSign = '+'
        for i, v in enumerate(s):
            if v.isdigit():
                num = num * 10 + int(v)
            if v in ops or i == len(s) - 1:
                if preSign == '+':
                    ans.append(num)
                elif preSign == '-':
                    ans.append(-num)
                elif preSign == '*':
                    ans[-1] *= num
                elif preSign == '/':
                    ans[-1] = int(ans[-1] / num)
                preSign = v
                num = 0
        return sum(ans)
# @lc code=end

