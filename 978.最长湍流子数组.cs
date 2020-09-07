using System;
using System.Runtime.InteropServices;
/*
 * @lc app=leetcode.cn id=978 lang=csharp
 *
 * [978] 最长湍流子数组
 *
 * https://leetcode-cn.com/problems/longest-turbulent-subarray/description/
 *
 * algorithms
 * Medium (40.14%)
 * Likes:    39
 * Dislikes: 0
 * Total Accepted:    4.6K
 * Total Submissions: 11.3K
 * Testcase Example:  '[9,4,2,10,7,8,8,1,9]'
 *
 * 当 A 的子数组 A[i], A[i+1], ..., A[j] 满足下列条件时，我们称其为湍流子数组：
 * 
 * 
 * 若 i <= k < j，当 k 为奇数时， A[k] > A[k+1]，且当 k 为偶数时，A[k] < A[k+1]；
 * 或 若 i <= k < j，当 k 为偶数时，A[k] > A[k+1] ，且当 k 为奇数时， A[k] < A[k+1]。
 * 
 * 
 * 也就是说，如果比较符号在子数组中的每个相邻元素对之间翻转，则该子数组是湍流子数组。
 * 
 * 返回 A 的最大湍流子数组的长度。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[9,4,2,10,7,8,8,1,9]
 * 输出：5
 * 解释：(A[1] > A[2] < A[3] > A[4] < A[5])
 * 
 * 
 * 示例 2：
 * 
 * 输入：[4,8,12,16]
 * 输出：2
 * 
 * 
 * 示例 3：
 * 
 * 输入：[100]
 * 输出：1
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 40000
 * 0 <= A[i] <= 10^9
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int MaxTurbulenceSize(int[] A)
    {
        int ans = 1;
        int cur = 0;
        for (int i = 1; i < A.Length; i++)
        {
            int c = A[i].CompareTo(A[i - 1]);
            if (i == A.Length - 1 || c * A[i].CompareTo(A[i + 1]) != 1)
            {
                if (c != 0) ans = Math.Max(ans, i - cur + 1);
                cur = i;
            }
        }
        return ans;
    }
}
// @lc code=end

