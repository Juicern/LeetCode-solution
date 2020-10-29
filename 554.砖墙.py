#
# @lc app=leetcode.cn id=554 lang=python3
#
# [554] 砖墙
#
# https://leetcode-cn.com/problems/brick-wall/description/
#
# algorithms
# Medium (38.73%)
# Likes:    104
# Dislikes: 0
# Total Accepted:    15.3K
# Total Submissions: 39.5K
# Testcase Example:  '[[1,2,2,1],[3,1,2],[1,3,2],[2,4],[3,1,2],[1,3,1,1]]'
#
# 你的面前有一堵矩形的、由多行砖块组成的砖墙。 这些砖块高度相同但是宽度不同。你现在要画一条自顶向下的、穿过最少砖块的垂线。
# 
# 砖墙由行的列表表示。 每一行都是一个代表从左至右每块砖的宽度的整数列表。
# 
# 如果你画的线只是从砖块的边缘经过，就不算穿过这块砖。你需要找出怎样画才能使这条线穿过的砖块数量最少，并且返回穿过的砖块数量。
# 
# 你不能沿着墙的两个垂直边缘之一画线，这样显然是没有穿过一块砖的。
# 
# 
# 
# 示例：
# 
# 输入: [[1,2,2,1],
# ⁠     [3,1,2],
# ⁠     [1,3,2],
# ⁠     [2,4],
# ⁠     [3,1,2],
# ⁠     [1,3,1,1]]
# 
# 输出: 2
# 
# 解释: 
# 
# 
# 
# 
# 
# 提示：
# 
# 
# 每一行砖块的宽度之和应该相等，并且不能超过 INT_MAX。
# 每一行砖块的数量在 [1,10,000] 范围内， 墙的高度在 [1,10,000] 范围内， 总的砖块数量不超过 20,000。
# 
# 
#

# @lc code=start
class Solution:
    def leastBricks(self, wall: List[List[int]]) -> int:
        maxLen = 0
        dict = {}
        for row in wall:
            _sum = 0
            for num in row:
                _sum += num
                if _sum == sum(row): break
                if _sum in dict: dict[_sum] += 1
                else : dict[_sum] = 1
                maxLen = max(maxLen, dict[_sum])
        return len(wall) - maxLen
# @lc code=end

