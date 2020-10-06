#
# @lc app=leetcode.cn id=977 lang=python3
#
# [977] 有序数组的平方
#
# https://leetcode-cn.com/problems/squares-of-a-sorted-array/description/
#
# algorithms
# Easy (71.58%)
# Likes:    127
# Dislikes: 0
# Total Accepted:    48.1K
# Total Submissions: 67.2K
# Testcase Example:  '[-4,-1,0,3,10]'
#
# 给定一个按非递减顺序排序的整数数组 A，返回每个数字的平方组成的新数组，要求也按非递减顺序排序。
# 
# 
# 
# 示例 1：
# 
# 输入：[-4,-1,0,3,10]
# 输出：[0,1,9,16,100]
# 
# 
# 示例 2：
# 
# 输入：[-7,-3,2,3,11]
# 输出：[4,9,9,49,121]
# 
# 
# 
# 
# 提示：
# 
# 
# 1 <= A.length <= 10000
# -10000 <= A[i] <= 10000
# A 已按非递减顺序排序。
# 
# 
#

# @lc code=start
class Solution:
    def sortedSquares(self, A: List[int]) -> List[int]:
        ans = []
        cur = 0
        while cur < len(A): 
            if A[cur] >= 0 : break
            cur += 1
        p1 = cur - 1
        p2 = cur
        while p1 >= 0 or p2 < len(A) :
            if p1 < 0:
                ans.append(A[p2] * A[p2])
                p2 += 1
            elif p2 >= len(A) :
                ans.append(A[p1] * A[p1])
                p1 -= 1
            else :
                if -A[p1] > A[p2] :
                    ans.append(A[p2] * A[p2])
                    p2 += 1
                else :
                    ans.append(A[p1] * A[p1])
                    p1 -= 1
        return ans

        
# @lc code=end

