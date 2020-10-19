/*
 * @lc app=leetcode.cn id=932 lang=csharp
 *
 * [932] 漂亮数组
 *
 * https://leetcode-cn.com/problems/beautiful-array/description/
 *
 * algorithms
 * Medium (60.02%)
 * Likes:    92
 * Dislikes: 0
 * Total Accepted:    5.1K
 * Total Submissions: 8.5K
 * Testcase Example:  '4'
 *
 * 对于某些固定的 N，如果数组 A 是整数 1, 2, ..., N 组成的排列，使得：
 * 
 * 对于每个 i < j，都不存在 k 满足 i < k < j 使得 A[k] * 2 = A[i] + A[j]。
 * 
 * 那么数组 A 是漂亮数组。
 * 
 * 
 * 
 * 给定 N，返回任意漂亮数组 A（保证存在一个）。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：4
 * 输出：[2,1,4,3]
 * 
 * 
 * 示例 2：
 * 
 * 输入：5
 * 输出：[3,1,2,5,4]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= N <= 1000
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    Dictionary<int, int[]> dic;
    public int[] BeautifulArray(int N) {
        dic = new Dictionary<int, int[]>();
        return F(N);
    }
    private int[] F(int n) {
        if(dic.ContainsKey(n)) return dic[n];
        if(n == 1) return new int[]{1};
        var ans = new int[n];
        int i = 0;
        foreach(var x in F((n + 1) / 2)) {
            ans[i++] = 2 * x - 1;
        }
        foreach(var x in F(n/ 2)) {
            ans[i++] = 2 * x;
        }
        dic.Add(n, ans);
        return ans;
    }
}
// @lc code=end

