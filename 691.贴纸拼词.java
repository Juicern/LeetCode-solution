/*
 * @lc app=leetcode.cn id=691 lang=java
 *
 * [691] 贴纸拼词
 *
 * https://leetcode-cn.com/problems/stickers-to-spell-word/description/
 *
 * algorithms
 * Hard (44.10%)
 * Likes:    49
 * Dislikes: 0
 * Total Accepted:    1.3K
 * Total Submissions: 3K
 * Testcase Example:  '["with","example","science"]\n"thehat"'
 *
 * 我们给出了 N 种不同类型的贴纸。每个贴纸上都有一个小写的英文单词。
 * 
 * 你希望从自己的贴纸集合中裁剪单个字母并重新排列它们，从而拼写出给定的目标字符串 target。
 * 
 * 如果你愿意的话，你可以不止一次地使用每一张贴纸，而且每一张贴纸的数量都是无限的。
 * 
 * 拼出目标 target 所需的最小贴纸数量是多少？如果任务不可能，则返回 -1。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：
 * 
 * ["with", "example", "science"], "thehat"
 * 
 * 
 * 输出：
 * 
 * 3
 * 
 * 
 * 解释：
 * 
 * 我们可以使用 2 个 "with" 贴纸，和 1 个 "example" 贴纸。
 * 把贴纸上的字母剪下来并重新排列后，就可以形成目标 “thehat“ 了。
 * 此外，这是形成目标字符串所需的最小贴纸数量。
 * 
 * 
 * 示例 2：
 * 
 * 输入：
 * 
 * ["notice", "possible"], "basicbasic"
 * 
 * 
 * 输出：
 * 
 * -1
 * 
 * 
 * 解释：
 * 
 * 我们不能通过剪切给定贴纸的字母来形成目标“basicbasic”。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * stickers 长度范围是 [1, 50]。
 * stickers 由小写英文单词组成（不带撇号）。
 * target 的长度在 [1, 15] 范围内，由小写字母组成。
 * 在所有的测试案例中，所有的单词都是从 1000 个最常见的美国英语单词中随机选取的，目标是两个随机单词的串联。
 * 时间限制可能比平时更具挑战性。预计 50 个贴纸的测试案例平均可在35ms内解决。
 * 
 * 
 * 
 * 
 */

// @lc code=start
class Solution {
    public int minStickers(String[] stickers, String target) {
        int m = stickers.length;
        int[][] mp = new int[m][26];
        Map<String, Integer> dp = new HashMap<>();
        for (int i = 0; i < m; i++)
            for (char c : stickers[i].toCharArray()) mp[i][c - 'a']++;
        dp.put("", 0);
        return helper(dp, mp, target);
    }

    private int helper(Map<String, Integer> dp, int[][] mp, String target) {
        if (dp.containsKey(target)) return dp.get(target);
        int ans = Integer.MAX_VALUE, n = mp.length;
        int[] tar = new int[26];
        for (char c : target.toCharArray()) tar[c - 'a']++;
        for (int i = 0; i < n; i++) {
            if (mp[i][target.charAt(0) - 'a'] == 0) continue;
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < 26; j++) {
                if (tar[j] > 0)
                    for (int k = 0; k < Math.max(0, tar[j] - mp[i][j]); k++)
                        sb.append((char) ('a' + j));
            }
            String s = sb.toString();
            int tmp = helper(dp, mp, s);
            if (tmp != -1) ans = Math.min(ans, 1 + tmp);
        }
        dp.put(target, ans == Integer.MAX_VALUE ? -1 : ans);
        return dp.get(target);
    }
}
// @lc code=end

