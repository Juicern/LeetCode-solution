#
# @lc app=leetcode.cn id=850 lang=python3
#
# [850] 矩形面积 II
#
# https://leetcode-cn.com/problems/rectangle-area-ii/description/
#
# algorithms
# Hard (42.09%)
# Likes:    56
# Dislikes: 0
# Total Accepted:    1.4K
# Total Submissions: 3.4K
# Testcase Example:  '[[0,0,2,2],[1,0,2,3],[1,0,3,1]]'
#
# 我们给出了一个（轴对齐的）矩形列表 rectangles 。 对于 rectangle[i] = [x1, y1, x2,
# y2]，其中（x1，y1）是矩形 i 左下角的坐标，（x2，y2）是该矩形右上角的坐标。
# 
# 找出平面中所有矩形叠加覆盖后的总面积。 由于答案可能太大，请返回它对 10 ^ 9 + 7 取模的结果。
# 
# 
# 
# 示例 1：
# 
# 输入：[[0,0,2,2],[1,0,2,3],[1,0,3,1]]
# 输出：6
# 解释：如图所示。
# 
# 
# 示例 2：
# 
# 输入：[[0,0,1000000000,1000000000]]
# 输出：49
# 解释：答案是 10^18 对 (10^9 + 7) 取模的结果， 即 (10^9)^2 → (-7)^2 = 49 。
# 
# 
# 提示：
# 
# 
# 1 <= rectangles.length <= 200
# rectanges[i].length = 4
# 0 <= rectangles[i][j] <= 10^9
# 矩形叠加覆盖后的总面积不会超越 2^63 - 1 ，这意味着可以用一个 64 位有符号整数来保存面积结果。
# 
# 
#

# @lc code=start
'''
统计所有x, y的数值，并且从小到大排序，分别把值映射成0, 1, 2, 3, 4, 5
然后用新的映射后的坐标一个一个填充方块，最后统计不重复的方块的位置，把每个
方块的位置再映射回来，计算方块本来代表的面积，把所有面积加和就是答案
'''


from typing import List
class Solution:
    def rectangleArea(self, rectangles: List[List[int]]) -> int:
        all_x, all_y = set(), set()
        for x1, y1, x2, y2 in rectangles:
            all_x.add(x1)
            all_x.add(x2)
            all_y.add(y1)
            all_y.add(y2)

        all_x = list(all_x)
        all_x.sort()
        all_y = list(all_y)
        all_y.sort()

        x_map = {val: i for i, val in enumerate(all_x)}
        y_map = {val: i for i, val in enumerate(all_y)}
        area = [[0 for _ in range(len(y_map))] for _ in range(len(x_map))]

        for x1, y1, x2, y2 in rectangles:
            for x in range(x_map[x1], x_map[x2]):
                for y in range(y_map[y1], y_map[y2]):
                    area[x][y] = 1

        ans = 0
        for x in range(len(x_map)):
            for y in range(len(y_map)):
                if area[x][y]:
                    ans += (all_x[x+1] - all_x[x]) * (all_y[y+1] - all_y[y])
                    if ans > 1000000007:
                        ans %= 1000000007
        return ans
        
# @lc code=end

