#
# @lc app=leetcode.cn id=447 lang=python3
#
# [447] 回旋镖的数量
#
# https://leetcode-cn.com/problems/number-of-boomerangs/description/
#
# algorithms
# Easy (58.63%)
# Likes:    113
# Dislikes: 0
# Total Accepted:    16.3K
# Total Submissions: 27.8K
# Testcase Example:  '[[0,0],[1,0],[2,0]]'
#
# 给定平面上 n 对不同的点，“回旋镖” 是由点表示的元组 (i, j, k) ，其中 i 和 j 之间的距离和 i 和 k
# 之间的距离相等（需要考虑元组的顺序）。
# 
# 找到所有回旋镖的数量。你可以假设 n 最大为 500，所有点的坐标在闭区间 [-10000, 10000] 中。
# 
# 示例:
# 
# 
# 输入:
# [[0,0],[1,0],[2,0]]
# 
# 输出:
# 2
# 
# 解释:
# 两个回旋镖为 [[1,0],[0,0],[2,0]] 和 [[1,0],[2,0],[0,0]]
# 
# 
#

# @lc code=start
class Solution:
    def numberOfBoomerangs(self, points: List[List[int]]) -> int:
        ans = 0
        for i in range(len(points)):
            record = {}
            for j in range(len(points)) :
                if i== j: continue
                distance = (points[i][0] - points[j][0]) ** 2 + (points[i][1] - points[j][1]) ** 2
                if not distance in record: record[distance] = 0
                record[distance] += 1
            for value in record.values() :
                ans += value * (value -1)
        return ans
        
# @lc code=end

