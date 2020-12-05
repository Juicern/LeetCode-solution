/*
 * @lc app=leetcode.cn id=856 lang=golang
 *
 * [856] 括号的分数
 *
 * https://leetcode-cn.com/problems/score-of-parentheses/description/
 *
 * algorithms
 * Medium (60.97%)
 * Likes:    162
 * Dislikes: 0
 * Total Accepted:    10.8K
 * Total Submissions: 17.7K
 * Testcase Example:  '"()"'
 *
 * 给定一个平衡括号字符串 S，按下述规则计算该字符串的分数：
 *
 *
 * () 得 1 分。
 * AB 得 A + B 分，其中 A 和 B 是平衡括号字符串。
 * (A) 得 2 * A 分，其中 A 是平衡括号字符串。
 *
 *
 *
 *
 * 示例 1：
 *
 * 输入： "()"
 * 输出： 1
 *
 *
 * 示例 2：
 *
 * 输入： "(())"
 * 输出： 2
 *
 *
 * 示例 3：
 *
 * 输入： "()()"
 * 输出： 2
 *
 *
 * 示例 4：
 *
 * 输入： "(()(()))"
 * 输出： 6
 *
 *
 *
 *
 * 提示：
 *
 *
 * S 是平衡括号字符串，且只含有 ( 和 ) 。
 * 2 <= S.length <= 50
 *
 *
 */

// @lc code=start
func scoreOfParentheses(S string) int {
	ans, count := 0, 0
	for i, b := range []byte(S) {
		if b == '(' {
			count++
		} else {
			count--
			if S[i-1] == '(' {
				ans += 1 << count
			}
		}
	}
	return ans
}

// @lc code=end
