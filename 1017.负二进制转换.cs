using System;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode.cn id=1017 lang=csharp
 *
 * [1017] 负二进制转换
 *
 * https://leetcode-cn.com/problems/convert-to-base-2/description/
 *
 * algorithms
 * Medium (54.14%)
 * Likes:    30
 * Dislikes: 0
 * Total Accepted:    2.5K
 * Total Submissions: 4.5K
 * Testcase Example:  '2'
 *
 * 给出数字 N，返回由若干 "0" 和 "1"组成的字符串，该字符串为 N 的负二进制（base -2）表示。
 * 
 * 除非字符串就是 "0"，否则返回的字符串中不能含有前导零。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：2
 * 输出："110"
 * 解释：(-2) ^ 2 + (-2) ^ 1 = 2
 * 
 * 
 * 示例 2：
 * 
 * 输入：3
 * 输出："111"
 * 解释：(-2) ^ 2 + (-2) ^ 1 + (-2) ^ 0 = 3
 * 
 * 
 * 示例 3：
 * 
 * 输入：4
 * 输出："100"
 * 解释：(-2) ^ 2 = 4
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 <= N <= 10^9
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string BaseNeg2(int N) {
        StringBuilder ans = new StringBuilder();
        while(N != 0) {
            int mod = N % -2;
            N /= -2;
            if(mod == -1) {
                ans.Append(1);
                N++;
            }
            else ans.Append(mod);
        }
        if(ans.Length == 0) return "0";
        var res= ans.ToString().ToArray();
        Array.Reverse(res);
        return new string(res);
    }
}
// @lc code=end

