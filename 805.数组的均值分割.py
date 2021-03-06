#
# @lc app=leetcode.cn id=805 lang=python3
#
# [805] 数组的均值分割
#
# https://leetcode-cn.com/problems/split-array-with-same-average/description/
#
# algorithms
# Hard (27.61%)
# Likes:    53
# Dislikes: 0
# Total Accepted:    1.8K
# Total Submissions: 6.4K
# Testcase Example:  '[1,2,3,4,5,6,7,8]'
#
# 给定的整数数组 A ，我们要将 A数组 中的每个元素移动到 B数组 或者 C数组中。（B数组和C数组在开始的时候都为空）
#
# 返回true ，当且仅当在我们的完成这样的移动后，可使得B数组的平均值和C数组的平均值相等，并且B数组和C数组都不为空。
#
#
# 示例:
# 输入:
# [1,2,3,4,5,6,7,8]
# 输出: true
# 解释: 我们可以将数组分割为 [1,4,5,8] 和 [2,3,6,7], 他们的平均值都是4.5。
#
#
# 注意:
#
#
# A 数组的长度范围为 [1, 30].
# A[i] 的数据范围为 [0, 10000].
#
#
#

# @lc code=start


class Solution:
    def splitArraySameAverage(self, A: List[int]) -> bool:
        def Helper(A: List[int], start: int, n: int, target: int) -> bool:
            if n == 0:
                return target == 0
            if n * A[start] > target:
                return False
            for i in range(start, len(A) - n + 1):
                if i > start and A[i] == A[i - 1]:
                    continue
                if Helper(A, i + 1, n - 1, target - A[i]):
                    return True
            return False
        n = len(A)
        s = sum(A)
        A.sort()
        for i in range(1,  n // 2 + 1):
            remaider = s * i % n
            target = s * i / n
            if remaider == 0 and Helper(A, 0, i, target):
                return True
        return False

# @lc code=end
