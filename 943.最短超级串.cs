/*
 * @lc app=leetcode.cn id=943 lang=csharp
 *
 * [943] 最短超级串
 *
 * https://leetcode-cn.com/problems/find-the-shortest-superstring/description/
 *
 * algorithms
 * Hard (40.21%)
 * Likes:    39
 * Dislikes: 0
 * Total Accepted:    750
 * Total Submissions: 1.8K
 * Testcase Example:  '["alex","loves","leetcode"]'
 *
 * 给定一个字符串数组 A，找到以 A 中每个字符串作为子字符串的最短字符串。
 * 
 * 我们可以假设 A 中没有字符串是 A 中另一个字符串的子字符串。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：["alex","loves","leetcode"]
 * 输出："alexlovesleetcode"
 * 解释："alex"，"loves"，"leetcode" 的所有排列都会被接受。
 * 
 * 示例 2：
 * 
 * 输入：["catg","ctaagt","gcta","ttca","atgcatc"]
 * 输出："gctaagttcatgcatc"
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 12
 * 1 <= A[i].length <= 20
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string ShortestSuperstring(string[] A) {
        int n = A.Length;
        int[,] graph = new int[n, n];
        
        // build the graph
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                graph[i, j] = calc(A[i], A[j]);
                graph[j, i] = calc(A[j], A[i]);
            }
        }
        
        int[,] dp = new int[1 << n, n];
        int[,] path = new int[1 << n, n];
        int last = -1, min = int.MaxValue;
		
        // start TSP DP
        for (int i = 1; i < (1 << n); i++) {
            for (int j = 0; j < n; j++) {
                dp[i, j] = int.MaxValue;
                if ((i & (1 << j)) > 0) {
                    int prev = i - (1 << j);
                    if (prev == 0) {
                        dp[i, j] = A[j].Length;
                    } else {
                        for (int k = 0; k < n; k++) {
                            if (dp[prev, k] < int.MaxValue && dp[prev, k] + graph[k, j] < dp[i, j]) {
                                dp[i, j] = dp[prev, k] + graph[k, j];
                                path[i, j] = k;
                            }
                        }
                    }
                }
                if (i == (1 << n) - 1 && dp[i, j] < min) {
                    min = dp[i, j];
                    last = j;
                }
            }
        }
        
        // build the path
        StringBuilder sb = new StringBuilder();
        int cur = (1 << n) - 1;
        var stack = new Stack<int>();
        while (cur > 0) {
            stack.Push(last);
            int temp = cur;
            cur -= (1 << last);
            last = path[temp, last];
        }
		
        // build the result
        int l = stack.Pop();
        sb.Append(A[l]);
        while (stack.Any()) {
            int j = stack.Pop();
            sb.Append(A[j].Substring(A[j].Length - graph[l, j]));
            l = j;
        }
        
        return sb.ToString();
    }
    
    private int calc(string a, string b) {
        for (int i = 1; i < a.Length; i++) {
            if (b.StartsWith(a.Substring(i))) {
                return b.Length - a.Length + i;
            }
        }
        return b.Length;
    }
}
// @lc code=end

