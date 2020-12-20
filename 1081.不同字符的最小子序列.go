/*
 * @lc app=leetcode.cn id=1081 lang=golang
 *
 * [1081] 不同字符的最小子序列
 *
 * https://leetcode-cn.com/problems/smallest-subsequence-of-distinct-characters/description/
 *
 * algorithms
 * Medium (50.56%)
 * Likes:    50
 * Dislikes: 0
 * Total Accepted:    4.6K
 * Total Submissions: 8.9K
 * Testcase Example:  '"cdadabcc"'
 *
 * 返回字符串 text 中按字典序排列最小的子序列，该子序列包含 text 中所有不同字符一次。
 *
 *
 *
 * 示例 1：
 *
 * 输入："cdadabcc"
 * 输出："adbc"
 *
 *
 * 示例 2：
 *
 * 输入："abcd"
 * 输出："abcd"
 *
 *
 * 示例 3：
 *
 * 输入："ecbacba"
 * 输出："eacb"
 *
 *
 * 示例 4：
 *
 * 输入："leetcode"
 * 输出："letcod"
 *
 *
 *
 *
 * 提示：
 *
 *
 * 1 <= text.length <= 1000
 * text 由小写英文字母组成
 *
 *
 *
 *
 * 注意：本题目与 316 https://leetcode-cn.com/problems/remove-duplicate-letters/ 相同
 *
 */

// @lc code=start
func smallestSubsequence(s string) string {
	counts := [26]int{}
	stack := []rune{}
	set := map[rune]bool{}
	for _, letter := range s {
		counts[letter-'a']++
	}
	for _, letter := range s {
		if _, ok := set[letter]; !ok {
			for len(stack) > 0 && stack[len(stack)-1] > letter && counts[stack[len(stack)-1]-'a'] > 0 {
				delete(set, stack[len(stack)-1])
				stack = stack[:len(stack)-1]
			}
			stack = append(stack, letter)
			set[letter] = true
		}
		counts[letter-'a']--
	}
	return string(stack)
}

// @lc code=endD
