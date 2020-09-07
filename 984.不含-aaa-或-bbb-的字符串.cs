using System.Text;
/*
 * @lc app=leetcode.cn id=984 lang=csharp
 *
 * [984] 不含 AAA 或 BBB 的字符串
 *
 * https://leetcode-cn.com/problems/string-without-aaa-or-bbb/description/
 *
 * algorithms
 * Medium (38.41%)
 * Likes:    49
 * Dislikes: 0
 * Total Accepted:    5.1K
 * Total Submissions: 13.2K
 * Testcase Example:  '1\n2'
 *
 * 给定两个整数 A 和 B，返回任意字符串 S，要求满足：
 * 
 * 
 * S 的长度为 A + B，且正好包含 A 个 'a' 字母与 B 个 'b' 字母；
 * 子串 'aaa' 没有出现在 S 中；
 * 子串 'bbb' 没有出现在 S 中。
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：A = 1, B = 2
 * 输出："abb"
 * 解释："abb", "bab" 和 "bba" 都是正确答案。
 * 
 * 
 * 示例 2：
 * 
 * 输入：A = 4, B = 1
 * 输出："aabaa"
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 <= A <= 100
 * 0 <= B <= 100
 * 对于给定的 A 和 B，保证存在满足要求的 S。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string StrWithout3a3b(int A, int B) {
        StringBuilder sb = new StringBuilder();
        bool nextA = A > B;
        while(A + B > 0) {
            if (nextA && A > 0) {
                if(A % 2 == 0 && A > B) {
                    sb.Append("aa");
                    A -= 2;
                }
                else {
                    sb.Append("a");
                    A -= 1;
                }
            }
            else if(B > 0) {
                if(B % 2 == 0 && B > A) {
                    sb.Append("bb");
                    B -= 2;
                }
                else {
                    sb.Append("b");
                    B -= 1;
                }
            }
            nextA = !nextA;
        }
        return sb.ToString();
    }
}
// @lc code=end

