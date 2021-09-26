/*
 * @lc app=leetcode id=14 lang=golang
 *
 * [14] Longest Common Prefix
 */

package leetcodesolution

// @lc code=start
func longestCommonPrefix(strs []string) string {
	if strs == nil || len(strs) == 0 {
		return ""
	}
	ans := make([]byte, 0)
	for i := 0; i < len(strs[0]); i++ {
		curr := strs[0][i]
		for _, str := range strs {
			if i >= len(str) || str[i] != curr {
				return string(ans)
			}
		}
		ans = append(ans, curr)
	}
	return string(ans)
}

// @lc code=end
