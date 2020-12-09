/*
 * @lc app=leetcode.cn id=899 lang=csharp
 *
 * [899] 有序队列
 *
 * https://leetcode-cn.com/problems/orderly-queue/description/
 *
 * algorithms
 * Hard (52.35%)
 * Likes:    42
 * Dislikes: 0
 * Total Accepted:    3.1K
 * Total Submissions: 5.8K
 * Testcase Example:  '"cba"\n1'
 *
 * 给出了一个由小写字母组成的字符串 S。然后，我们可以进行任意次数的移动。
 * 
 * 在每次移动中，我们选择前 K 个字母中的一个（从左侧开始），将其从原位置移除，并放置在字符串的末尾。
 * 
 * 返回我们在任意次数的移动之后可以拥有的按字典顺序排列的最小字符串。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：S = "cba", K = 1
 * 输出："acb"
 * 解释：
 * 在第一步中，我们将第一个字符（“c”）移动到最后，获得字符串 “bac”。
 * 在第二步中，我们将第一个字符（“b”）移动到最后，获得最终结果 “acb”。
 * 
 * 
 * 示例 2：
 * 
 * 输入：S = "baaca", K = 3
 * 输出："aaabc"
 * 解释：
 * 在第一步中，我们将第一个字符（“b”）移动到最后，获得字符串 “aacab”。
 * 在第二步中，我们将第三个字符（“c”）移动到最后，获得最终结果 “aaabc”。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= K <= S.length <= 1000
 * S 只由小写字母组成。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string OrderlyQueue(string S, int K) {
        if(K == 1) {
            string ans = S;
            for (int i = 1;i<S.Length;i++) {
                string t = S.Substring(i) + S.Substring(0, i);
                if(t.CompareTo(ans) < 0) ans = t;
            }
            return ans;
        }
        return new string(S.OrderBy(x => x).ToArray());
    }
}
// @lc code=end

