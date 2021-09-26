/*
 * @lc app=leetcode id=14 lang=javascript
 *
 * [14] Longest Common Prefix
 */

// @lc code=start
/**
 * @param {string[]} strs
 * @return {string}
 */
var longestCommonPrefix = function (strs) {
    if (strs == null || strs.length == 0) {
        return ""
    }
    ans = ""
    for (let i = 0; i < strs[0].length; i++) {
        let curr = strs[0][i]
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

