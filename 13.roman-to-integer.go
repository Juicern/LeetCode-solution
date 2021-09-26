/*
 * @lc app=leetcode id=13 lang=golang
 *
 * [13] Roman to Integer
 */
package leetcodesolution

// @lc code=start
func romanToInt(s string) int {
	roman := map[byte]int{
		'M': 1000,
		'D': 500,
		'C': 100,
		'L': 50,
		'X': 10,
		'V': 5,
		'I': 1,
	}
	z := 0
	for i := 0; i < len(s)-1; i++ {
		if roman[s[i]] < roman[s[i+1]] {
			z -= roman[s[i]]
		} else {
			z += roman[s[i]]
		}
	}
	return z + roman[s[len(s)-1]]
}

// @lc code=end
