/*
 * @lc app=leetcode id=14 lang=typescript
 *
 * [14] Longest Common Prefix
 */

// @lc code=start
function longestCommonPrefix(strs: string[]): string {
    if (strs == null || strs.length == 0) {
        return ""
    }
    let ans: string = ""
    for (let i = 0; i < strs[0].length; i++) {
        let curr: string = strs[0][i]
        for (let str of strs) {
            if (i >= str.length || str[i] != curr) {
                return ans
            }
        }
        ans += curr
    }
    return ans
};
// @lc code=end

