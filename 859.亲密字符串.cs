/*
 * @lc app=leetcode.cn id=859 lang=csharp
 *
 * [859] 亲密字符串
 *
 * https://leetcode-cn.com/problems/buddy-strings/description/
 *
 * algorithms
 * Easy (29.07%)
 * Likes:    115
 * Dislikes: 0
 * Total Accepted:    18.2K
 * Total Submissions: 62.5K
 * Testcase Example:  '"ab"\n"ba"'
 *
 * 给定两个由小写字母构成的字符串 A 和 B ，只要我们可以通过交换 A 中的两个字母得到与 B 相等的结果，就返回 true ；否则返回 false
 * 。
 * 
 * 交换字母的定义是取两个下标 i 和 j （下标从 0 开始），只要 i!=j 就交换 A[i] 和 A[j] 处的字符。例如，在 "abcd"
 * 中交换下标 0 和下标 2 的元素可以生成 "cbad" 。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入： A = "ab", B = "ba"
 * 输出： true
 * 解释： 你可以交换 A[0] = 'a' 和 A[1] = 'b' 生成 "ba"，此时 A 和 B 相等。
 * 
 * 示例 2：
 * 
 * 
 * 输入： A = "ab", B = "ab"
 * 输出： false
 * 解释： 你只能交换 A[0] = 'a' 和 A[1] = 'b' 生成 "ba"，此时 A 和 B 不相等。
 * 
 * 
 * 示例 3:
 * 
 * 
 * 输入： A = "aa", B = "aa"
 * 输出： true
 * 解释： 你可以交换 A[0] = 'a' 和 A[1] = 'a' 生成 "aa"，此时 A 和 B 相等。
 * 
 * 示例 4：
 * 
 * 
 * 输入： A = "aaaaaaabc", B = "aaaaaaacb"
 * 输出： true
 * 
 * 
 * 示例 5：
 * 
 * 
 * 输入： A = "", B = "aa"
 * 输出： false
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 
 * 0 
 * A 和 B 仅由小写字母构成。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool BuddyStrings(string A, string B) {
        if(A.Length != B.Length) return false;
        int count = 2;
        int index = 0;
        for(int i = 0;i<A.Length;i++) {
            if(A[i] != B[i]) {
                if(count == 0) return false;
                if(count == 1) {
                    if(B[i] != A[index] || A[i] != B[index]) return false;
                    count--;
                }
                if(count == 2) {
                    index = i;
                    count--;
                }
            }
        }
        if(count == 1) return false;
        if(count == 2) {
            for(int i = 0;i<26;i++) {
                if(A.IndexOf((char)(i + 'a')) != A.LastIndexOf((char)(i + 'a'))) return true;
            }
            return false;
        }
        return true;
    }
}
// @lc code=end

