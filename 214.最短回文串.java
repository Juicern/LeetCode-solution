/*
 * @lc app=leetcode.cn id=214 lang=java
 *
 * [214] 最短回文串
 *
 * https://leetcode-cn.com/problems/shortest-palindrome/description/
 *
 * algorithms
 * Hard (31.09%)
 * Likes:    124
 * Dislikes: 0
 * Total Accepted:    6.7K
 * Total Submissions: 21.5K
 * Testcase Example:  '"aacecaaa"'
 *
 * 给定一个字符串 s，你可以通过在字符串前面添加字符将其转换为回文串。找到并返回可以用这种方式转换的最短回文串。
 * 
 * 示例 1:
 * 
 * 输入: "aacecaaa"
 * 输出: "aaacecaaa"
 * 
 * 
 * 示例 2:
 * 
 * 输入: "abcd"
 * 输出: "dcbabcd"
 * 
 */

// @lc code=start
class Solution {
	public static String shortestPalindrome(String s) {
		StringBuilder r = new StringBuilder(s).reverse();
		String str = s + "#" + r;
		int[] next = next(str);
		String prefix = r.substring(0, r.length() - next[str.length()]);
		return prefix + s;
	}

	// next数组
	private static int[] next(String P) {
		int[] next = new int[P.length() + 1];
		next[0] = -1;
		int k = -1;
		int i = 1;
		while (i < next.length) {
			if (k == -1 || P.charAt(k) == P.charAt(i - 1)) {
				next[i++] = ++k;
            } 
            else {
				k = next[k];
			}
		}
		return next;
	}
}
// @lc code=end

