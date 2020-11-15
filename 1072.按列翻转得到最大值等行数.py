#
# @lc app=leetcode.cn id=1072 lang=python3
#
# [1072] 按列翻转得到最大值等行数
#
# https://leetcode-cn.com/problems/flip-columns-for-maximum-number-of-equal-rows/description/
#
# algorithms
# Medium (54.70%)
# Likes:    33
# Dislikes: 0
# Total Accepted:    2.3K
# Total Submissions: 4.2K
# Testcase Example:  '[[0,1],[1,1]]'
#
# 给定由若干 0 和 1 组成的矩阵 matrix，从中选出任意数量的列并翻转其上的 每个 单元格。翻转后，单元格的值从 0 变成 1，或者从 1 变为 0
# 。
#
# 返回经过一些翻转后，行上所有值都相等的最大行数。
#
#
#
#
#
#
# 示例 1：
#
# 输入：[[0,1],[1,1]]
# 输出：1
# 解释：不进行翻转，有 1 行所有值都相等。
#
#
# 示例 2：
#
# 输入：[[0,1],[1,0]]
# 输出：2
# 解释：翻转第一列的值之后，这两行都由相等的值组成。
#
#
# 示例 3：
#
# 输入：[[0,0,0],[0,0,1],[1,1,0]]
# 输出：2
# 解释：翻转前两列的值之后，后两行由相等的值组成。
#
#
#
# 提示：
#
#
# 1 <= matrix.length <= 300
# 1 <= matrix[i].length <= 300
# 所有 matrix[i].length 都相等
# matrix[i][j] 为 0 或 1
#
#
#

# @lc code=start


class Solution:
    def maxEqualRowsAfterFlips(self, matrix: List[List[int]]) -> int:
        dic = {}
        for row in matrix:
            R = row.copy()
            if R[0] == 1:
                R = [1-i for i in R]
            R = tuple(R)
            dic[R] = dic.get(R, 0)+1
        return max(dic.values())

# @lc code=end
