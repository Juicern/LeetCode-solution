#
# @lc app=leetcode.cn id=640 lang=python3
#
# [640] 求解方程
#
# https://leetcode-cn.com/problems/solve-the-equation/description/
#
# algorithms
# Medium (41.27%)
# Likes:    55
# Dislikes: 0
# Total Accepted:    7.7K
# Total Submissions: 18.6K
# Testcase Example:  '"x+5-3+x=6+x-2"'
#
# 求解一个给定的方程，将x以字符串"x=#value"的形式返回。该方程仅包含'+'，' - '操作，变量 x 和其对应系数。
#
# 如果方程没有解，请返回“No solution”。
#
# 如果方程有无限解，则返回“Infinite solutions”。
#
# 如果方程中只有一个解，要保证返回值 x 是一个整数。
#
# 示例 1：
#
# 输入: "x+5-3+x=6+x-2"
# 输出: "x=2"
#
#
# 示例 2:
#
# 输入: "x=x"
# 输出: "Infinite solutions"
#
#
# 示例 3:
#
# 输入: "2x=x"
# 输出: "x=0"
#
#
# 示例 4:
#
# 输入: "2x+3x-6x=x+2"
# 输出: "x=-1"
#
#
# 示例 5:
#
# 输入: "x=x+2"
# 输出: "No solution"
#
#
#

# @lc code=start
import math


class Solution:
    def solveEquation(self, equation: str) -> str:

        def get_ab(equation):
            equation = equation + '#'
            a, b = 0, 0
            stack = []
            flag = True
            flag1 = -1 if equation[0] == '-' else 1
            if equation[0] == '-':
                equation = equation[1:]
            for i in equation:
                if i in '-+#':
                    if flag:
                        b += flag1*int(''.join(stack))
                    else:
                        if not stack:
                            a += flag1
                        else:
                            a += flag1*int(''.join(stack))
                    flag = True
                    flag1 = -1 if i == '-' else 1
                    stack = []
                elif i in '0123456789':
                    stack.append(i)
                else:
                    flag = False
            return a, b

        e1, e2 = equation.split('=')
        e1 = get_ab(e1)
        e2 = get_ab(e2)
        if e1 == e2:
            return "Infinite solutions"
        elif e1[0] == e2[0]:
            return "No solution"
        else:
            return "x=%d" % ((e2[1]-e1[1])//(e1[0]-e2[0]))

# @lc code=end
