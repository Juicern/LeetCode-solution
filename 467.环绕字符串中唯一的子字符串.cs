/*
 * @lc app=leetcode.cn id=467 lang=csharp
 *
 * [467] 环绕字符串中唯一的子字符串
 *
 * https://leetcode-cn.com/problems/unique-substrings-in-wraparound-string/description/
 *
 * algorithms
 * Medium (40.90%)
 * Likes:    88
 * Dislikes: 0
 * Total Accepted:    3.4K
 * Total Submissions: 8.2K
 * Testcase Example:  '"a"'
 *
 * 把字符串 s 看作是“abcdefghijklmnopqrstuvwxyz”的无限环绕字符串，所以 s
 * 看起来是这样的："...zabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcd....". 
 * 
 * 现在我们有了另一个字符串 p 。你需要的是找出 s 中有多少个唯一的 p 的非空子串，尤其是当你的输入是字符串 p ，你需要输出字符串 s 中 p
 * 的不同的非空子串的数目。 
 * 
 * 注意: p 仅由小写的英文字母组成，p 的大小可能超过 10000。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入: "a"
 * 输出: 1
 * 解释: 字符串 S 中只有一个"a"子字符。
 * 
 * 
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: "cac"
 * 输出: 2
 * 解释: 字符串 S 中的字符串“cac”只有两个子串“a”、“c”。.
 * 
 * 
 * 
 * 
 * 示例 3:
 * 
 * 
 * 输入: "zab"
 * 输出: 6
 * 解释: 在字符串 S 中有六个子串“z”、“a”、“b”、“za”、“ab”、“zab”。.
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int FindSubstringInWraproundString(string p) {
        var n = p.Length;
        if (n == 0) return 0;
        var counts = new int[26];
        var local = 1;
        counts[p[0] - 'a'] = 1;
        for (int i = 1; i < n; i++) {
            var pre = p[i - 1] - 'a';
            var cur = p[i] - 'a';
            if ((cur - pre + 26) % 26 == 1) {
				// abc => [1,2,3] when c: c, bc, abc (count: 3)
                local++;
            } else {
                local = 1;
            }
            counts[cur] = Math.Max(counts[cur], local);
        }
        return counts.Sum();
    }
}
// @lc code=end

