using System.Text;
using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=854 lang=csharp
 *
 * [854] 相似度为 K 的字符串
 *
 * https://leetcode-cn.com/problems/k-similar-strings/description/
 *
 * algorithms
 * Hard (31.86%)
 * Likes:    56
 * Dislikes: 0
 * Total Accepted:    2.3K
 * Total Submissions: 7.1K
 * Testcase Example:  '"ab"\n"ba"'
 *
 * 如果可以通过将 A 中的两个小写字母精确地交换位置 K 次得到与 B 相等的字符串，我们称字符串 A 和 B 的相似度为 K（K 为非负整数）。
 * 
 * 给定两个字母异位词 A 和 B ，返回 A 和 B 的相似度 K 的最小值。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：A = "ab", B = "ba"
 * 输出：1
 * 
 * 
 * 示例 2：
 * 
 * 输入：A = "abc", B = "bca"
 * 输出：2
 * 
 * 
 * 示例 3：
 * 
 * 输入：A = "abac", B = "baca"
 * 输出：2
 * 
 * 
 * 示例 4：
 * 
 * 输入：A = "aabc", B = "abca"
 * 输出：2
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length == B.length <= 20
 * A 和 B 只包含集合 {'a', 'b', 'c', 'd', 'e', 'f'} 中的小写字母。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int KSimilarity(string A, string B) {
        var queue = new Queue<string>();
        var visited = new HashSet<string>();
        queue.Enqueue(A);
        int ans = 0;
        while(queue.Any()) {
            int size = queue.Count;
            for(int i = 0 ;i< size;i++) {
                var s = queue.Dequeue();
                if(visited.Contains(s)) continue;
                visited.Add(s);
                int j = 0;
                while(s[j] == B[j]) {
                    j ++;
                    if( j == A.Length) return ans;
                }
                for(int k = j+1;k<s.Length;k++) {
                    if(s[k] != B[k] && B[j] == s[k]) {
                        var S = new StringBuilder(s);
                        var tmp = S[k];
                        S[k] = S[j];
                        S[j] = tmp;
                        queue.Enqueue(S.ToString());
                    }
                }
            }
            ans++;
        }
        return -1;
    }
}
// @lc code=end

