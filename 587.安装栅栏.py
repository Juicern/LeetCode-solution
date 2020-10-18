#
# @lc app=leetcode.cn id=587 lang=python3
#
# [587] 安装栅栏
#
# https://leetcode-cn.com/problems/erect-the-fence/description/
#
# algorithms
# Hard (33.29%)
# Likes:    55
# Dislikes: 0
# Total Accepted:    1.1K
# Total Submissions: 3.3K
# Testcase Example:  '[[1,1],[2,2],[2,0],[2,4],[3,3],[4,2]]'
#
# 在一个二维的花园中，有一些用 (x, y)
# 坐标表示的树。由于安装费用十分昂贵，你的任务是先用最短的绳子围起所有的树。只有当所有的树都被绳子包围时，花园才能围好栅栏。你需要找到正好位于栅栏边界上的树的坐标。
#
#
#
# 示例 1:
#
# 输入: [[1,1],[2,2],[2,0],[2,4],[3,3],[4,2]]
# 输出: [[1,1],[2,0],[4,2],[3,3],[2,4]]
# 解释:
#
#
#
# 示例 2:
#
# 输入: [[1,2],[2,2],[4,2]]
# 输出: [[1,2],[2,2],[4,2]]
# 解释:
#
# 即使树都在一条直线上，你也需要先用绳子包围它们。
#
#
#
#
# 注意:
#
#
# 所有的树应当被围在一起。你不能剪断绳子来包围树或者把树分成一组以上。
# 输入的整数在 0 到 100 之间。
# 花园至少有一棵树。
# 所有树的坐标都是不同的。
# 输入的点没有顺序。输出顺序也没有要求。
#
#

# @lc code=start


class Solution:
    def outerTrees(self, points: List[List[int]]) -> List[List[int]]:
        n = len(points)
        if n < 3:
            return points
        points.sort(key = lambda x:(x[0],x[1]))
        cross = lambda a,b,c:(b[0]-a[0])*(c[1]-b[1])-(b[1]-a[1])*(c[0]-b[0])
        
        low = []
        for p in points:
            while len(low) > 1 and cross(low[-2],low[-1],p) < 0:
                low.pop()
            low.append((p[0],p[1]))
        
        up = []
        for p in reversed(points):
            while len(up) > 1 and cross(up[-2],up[-1],p) < 0:
                up.pop()
            up.append((p[0],p[1]))
            
        return list(set(low[:-1] + up[:-1]))


# @lc code=end
