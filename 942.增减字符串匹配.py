#
# @lc app=leetcode.cn id=942 lang=python3
#
# [942] 增减字符串匹配
#
# https://leetcode-cn.com/problems/di-string-match/description/
#
# algorithms
# Easy (72.17%)
# Likes:    189
# Dislikes: 0
# Total Accepted:    18.2K
# Total Submissions: 25.2K
# Testcase Example:  '"IDID"'
#
# 给定只含 "I"（增大）或 "D"（减小）的字符串 S ，令 N = S.length。
# 
# 返回 [0, 1, ..., N] 的任意排列 A 使得对于所有 i = 0, ..., N-1，都有：
# 
# 
# 如果 S[i] == "I"，那么 A[i] < A[i+1]
# 如果 S[i] == "D"，那么 A[i] > A[i+1]
# 
# 
# 
# 
# 示例 1：
# 
# 输入："IDID"
# 输出：[0,4,1,3,2]
# 
# 
# 示例 2：
# 
# 输入："III"
# 输出：[0,1,2,3]
# 
# 
# 示例 3：
# 
# 输入："DDI"
# 输出：[3,2,0,1]
# 
# 
# 
# 提示：
# 
# 
# 1 <= S.length <= 10000
# S 只包含字符 "I" 或 "D"。
# 
# 
#

# @lc code=start
class Solution:
    def diStringMatch(self, S: str) -> List[int]:
        low = 0
        high = len(S)
        ans = []
        for letter in S:
            if letter == 'I' :
                ans.append(low)
                low += 1
            else :
                ans.append(high)
                high -= 1
        ans.append(low)
        return ans
# @lc code=end

