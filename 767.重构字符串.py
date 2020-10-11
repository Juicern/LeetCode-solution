#
# @lc app=leetcode.cn id=767 lang=python3
#
# [767] 重构字符串
#
# https://leetcode-cn.com/problems/reorganize-string/description/
#
# algorithms
# Medium (42.59%)
# Likes:    131
# Dislikes: 0
# Total Accepted:    10.7K
# Total Submissions: 25.1K
# Testcase Example:  '"aab"'
#
# 给定一个字符串S，检查是否能重新排布其中的字母，使得两相邻的字符不同。
# 
# 若可行，输出任意可行的结果。若不可行，返回空字符串。
# 
# 示例 1:
# 
# 
# 输入: S = "aab"
# 输出: "aba"
# 
# 
# 示例 2:
# 
# 
# 输入: S = "aaab"
# 输出: ""
# 
# 
# 注意:
# 
# 
# S 只包含小写字母并且长度在[1, 500]区间内。
# 
# 
#

# @lc code=start
class Solution:
    def reorganizeString(self, S: str) -> str:
        len_s = len(S)
        tmp_list = []
        for c, x in sorted((S.count(x), x) for x in set(S)):
            if c > (len_s + 1)/2:
                return ''
            tmp_list.extend(c * x)
        res = [None] * len_s
        res[::2], res[1::2] = tmp_list[len_s//2:], tmp_list[:len_s//2]
        return ''.join(res)

# @lc code=end

