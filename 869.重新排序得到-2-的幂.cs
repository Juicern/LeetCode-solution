using System.Linq;
using System;
/*
 * @lc app=leetcode.cn id=869 lang=csharp
 *
 * [869] 重新排序得到 2 的幂
 *
 * https://leetcode-cn.com/problems/reordered-power-of-2/description/
 *
 * algorithms
 * Medium (51.06%)
 * Likes:    33
 * Dislikes: 0
 * Total Accepted:    3.5K
 * Total Submissions: 6.9K
 * Testcase Example:  '1'
 *
 * 给定正整数 N ，我们按任何顺序（包括原始顺序）将数字重新排序，注意其前导数字不能为零。
 * 
 * 如果我们可以通过上述方式得到 2 的幂，返回 true；否则，返回 false。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：1
 * 输出：true
 * 
 * 
 * 示例 2：
 * 
 * 输入：10
 * 输出：false
 * 
 * 
 * 示例 3：
 * 
 * 输入：16
 * 输出：true
 * 
 * 
 * 示例 4：
 * 
 * 输入：24
 * 输出：false
 * 
 * 
 * 示例 5：
 * 
 * 输入：46
 * 输出：true
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= N <= 10^9
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool ReorderedPowerOf2(int N) {
        int[] A = Count(N);
        for(int i = 0;i<31;i++) {
            if(Enumerable.SequenceEqual(A, Count(1 << i))) return true;
        }
        return false;
    }
    private int[] Count(int N) {
        int[] ans = new int[10];
        while(N > 0) {
            ans[N % 10]++;
            N /= 10;
        }
        return ans;
    }
}
// @lc code=end

