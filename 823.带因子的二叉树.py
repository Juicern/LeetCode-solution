#
# @lc app=leetcode.cn id=823 lang=python3
#
# [823] 带因子的二叉树
#
# https://leetcode-cn.com/problems/binary-trees-with-factors/description/
#
# algorithms
# Medium (41.69%)
# Likes:    43
# Dislikes: 0
# Total Accepted:    1.9K
# Total Submissions: 4.5K
# Testcase Example:  '[2,4]'
#
# 给出一个含有不重复整数元素的数组，每个整数均大于 1。
# 
# 我们用这些整数来构建二叉树，每个整数可以使用任意次数。
# 
# 其中：每个非叶结点的值应等于它的两个子结点的值的乘积。
# 
# 满足条件的二叉树一共有多少个？返回的结果应模除 10 ** 9 + 7。
# 
# 
# 
# 示例 1:
# 
# 
# 输入: A = [2, 4]
# 输出: 3
# 解释: 我们可以得到这些二叉树: [2], [4], [4, 2, 2]
# 
# 示例 2:
# 
# 
# 输入: A = [2, 4, 5, 10]
# 输出: 7
# 解释: 我们可以得到这些二叉树: [2], [4], [5], [10], [4, 2, 2], [10, 2, 5], [10, 5, 2].
# 
# 
# 
# 提示:
# 
# 
# 1 <= A.length <= 1000.
# 2 <= A[i] <= 10 ^ 9.
# 
# 
#

# @lc code=start
class Solution:
    def numFactoredBinaryTrees(self, A: List[int]) -> int:
        ans = 0
        dic = {}
        A.sort()
        for num in A:
            value = 1
            for key in dic.keys():
                value += dic[key] * dic.get(num / key, 0)
            dic[num] = value
            ans += value
        return ans % (10 ** 9 + 7)
        
# @lc code=end

