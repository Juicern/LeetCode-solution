#
# @lc app=leetcode.cn id=1012 lang=python3
#
# [1012] 至少有 1 位重复的数字
#
# https://leetcode-cn.com/problems/numbers-with-repeated-digits/description/
#
# algorithms
# Hard (31.43%)
# Likes:    74
# Dislikes: 0
# Total Accepted:    2.3K
# Total Submissions: 7.4K
# Testcase Example:  '20'
#
# 给定正整数 N，返回小于等于 N 且具有至少 1 位重复数字的正整数的个数。
# 
# 
# 
# 示例 1：
# 
# 输入：20
# 输出：1
# 解释：具有至少 1 位重复数字的正数（<= 20）只有 11 。
# 
# 
# 示例 2：
# 
# 输入：100
# 输出：10
# 解释：具有至少 1 位重复数字的正数（<= 100）有 11，22，33，44，55，66，77，88，99 和 100 。
# 
# 
# 示例 3：
# 
# 输入：1000
# 输出：262
# 
# 
# 
# 
# 提示：
# 
# 
# 1 <= N <= 10^9
# 
# 
#

# @lc code=start
class Solution:
    def numDupDigitsAtMostN(self, n: int) -> int:
        temp = n
        digits = []
        while n > 0 : 
            digits.append(n % 10)
            n //= 10
        k = len(digits)
        used = [0] * 10
        total = 0
        for i in range(1, k) :
            total += 9 * perm(9, i - 1)
        for i in range(k - 1, -1, - 1):
            num = digits[i]
            for j in range(1 if i == k - 1 else 0, num) :
                if used[j] != 0 : continue
                total += perm(10 - (k - i), i)
            used[num] += 1
            if used[num] > 1: break
            if i == 0 : total += 1
        return temp - total

        
# @lc code=end

