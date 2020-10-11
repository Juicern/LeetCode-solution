#
# @lc app=leetcode.cn id=476 lang=python3
#
# [476] 数字的补数
#
# https://leetcode-cn.com/problems/number-complement/description/
#
# algorithms
# Easy (69.21%)
# Likes:    184
# Dislikes: 0
# Total Accepted:    26.2K
# Total Submissions: 37.8K
# Testcase Example:  '5'
#
# 给定一个正整数，输出它的补数。补数是对该数的二进制表示取反。
# 
# 
# 
# 
# 
# 
# 示例 1:
# 
# 输入: 5
# 输出: 2
# 解释: 5 的二进制表示为 101（没有前导零位），其补数为 010。所以你需要输出 2 。
# 
# 
# 示例 2:
# 
# 输入: 1
# 输出: 0
# 解释: 1 的二进制表示为 1（没有前导零位），其补数为 0。所以你需要输出 0 。
# 
# 
# 
# 
# 注意:
# 
# 
# 给定的整数保证在 32 位带符号整数的范围内。
# 你可以假定二进制数不包含前导零位。
# 本题与 1009 https://leetcode-cn.com/problems/complement-of-base-10-integer/ 相同
# 
# 
#

# @lc code=start
class Solution:
    def findComplement(self, num: int) -> int:
        count = 0
        temp = num
        while temp:
            count+=1
            temp>>=1
        return num ^((1<<count) - 1)
# @lc code=end

