#
# @lc app=leetcode id=14 lang=python3
#
# [14] Longest Common Prefix
#

from typing import List

# @lc code=start


class Solution:
    def longestCommonPrefix(self, strs: List[str]) -> str:
        if len(strs) == 0:
            return ""
        ans = ""
        for i in range(len(strs[0])):
            curr = strs[0][i]
            for str in strs:
                if i >= len(str) or str[i] != curr:
                    return ans
            ans += curr
        return ans


# @lc code=end
