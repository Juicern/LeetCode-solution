/*
 * @lc app=leetcode.cn id=639 lang=csharp
 *
 * [639] 解码方法 2
 *
 * https://leetcode-cn.com/problems/decode-ways-ii/description/
 *
 * algorithms
 * Hard (28.21%)
 * Likes:    62
 * Dislikes: 0
 * Total Accepted:    2.3K
 * Total Submissions: 8.2K
 * Testcase Example:  '"*"'
 *
 * 一条包含字母 A-Z 的消息通过以下的方式进行了编码：
 * 
 * 'A' -> 1
 * 'B' -> 2
 * ...
 * 'Z' -> 26
 * 
 * 
 * 除了上述的条件以外，现在加密字符串可以包含字符 '*'了，字符'*'可以被当做1到9当中的任意一个数字。
 * 
 * 给定一条包含数字和字符'*'的加密信息，请确定解码方法的总数。
 * 
 * 同时，由于结果值可能会相当的大，所以你应当对10^9 + 7取模。（翻译者标注：此处取模主要是为了防止溢出）
 * 
 * 示例 1 :
 * 
 * 输入: "*"
 * 输出: 9
 * 解释: 加密的信息可以被解密为: "A", "B", "C", "D", "E", "F", "G", "H", "I".
 * 
 * 
 * 示例 2 :
 * 
 * 输入: "1*"
 * 输出: 9 + 9 = 18（翻译者标注：这里1*可以分解为1,* 或者当做1*来处理，所以结果是9+9=18）
 * 
 * 
 * 说明 :
 * 
 * 
 * 输入的字符串长度范围是 [1, 10^5]。
 * 输入的字符串只会包含字符 '*' 和 数字'0' - '9'。
 * 
 * 
 */

// @lc code=start
public class Solution {
    private static int MOD = 1_000_000_007;
    public int NumDecodings(string s) {
        int n = s.Length;
        var dp = new int[n];
        return Helper(s, 0, n, dp);
    }
    private int Helper(string s, int start, int end, int[] dp) {
        if(start >= end) return 1;
        if(dp[start] != 0) return dp[start];
        if(s[start] >= '3' && s[start] <= '9') return dp[start] = Helper(s, start + 1, end, dp);
        if(s[start] == '2') {
            if(start  + 1 == end) return dp[start] = 1;
            else if(s[start + 1] == '0') return dp[start] = Helper(s, start + 2, end, dp);
            else if(s[start + 1 ] >= '1' && s[start + 1] <= '6') {
                return dp[start] = (Helper(s, start + 1, end, dp) + Helper(s, start + 2, end, dp)) % MOD;
            }
            else if(s[start + 1] >= '7' && s[start + 1] <= '9') {
                return dp[start] = Helper(s, start +1 , end, dp);
            }
            else if(s[start + 1] == '*') {
                return dp[start] = (Helper(s, start + 1, end, dp) + 6 * Helper(s, start + 2, end, dp)) % MOD;
            }
        }
        if(s[start] == '1') {
            if(start  + 1 == end) return dp[start] = 1;
            else if(s[start + 1 ] == '0') return dp[start] = Helper(s, start + 2, end, dp);
            else if(s[start + 1 ] >= '1' && s[start + 1] <= '9') {
                return dp[start] = (Helper(s, start + 1, end, dp) + Helper(s, start + 2, end, dp)) % MOD;
            }
            else if(s[start + 1] == '*') {
                return dp[start] = (Helper(s, start + 1, end, dp) + 9 * Helper(s, start + 2, end, dp)) % MOD;
            }
        }
        if(s[start]== '*') {
            if(start + 1 == end) return dp[start] = 9;
            else if(s[start + 1] == '0') return dp[start] = (2 * Helper(s, start + 2, end, dp)) % MOD;
            else if(s[start + 1 ] >= '1' && s[start + 1] <= '6') {
                return dp[start] = (9 * Helper(s, start + 1, end, dp) + 2 * Helper(s, start + 2, end, dp)) % MOD;
            }
            else if(s[start + 1] >= '7' && s[start + 1] <= '9') {
                return dp[start] = (9 * Helper(s, start + 1, end, dp) + Helper(s, start + 2, end, dp)) % MOD;
            }
            else if(s[start + 1] == '*') {
                return dp[start] = (9 * Helper(s, start + 1, end, dp) + 15 * Helper(s, start + 2, end, dp)) % MOD;
            }
        }
        return dp[start] = 0;
    }
}
// @lc code=end

