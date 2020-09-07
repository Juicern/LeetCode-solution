/*
 * @lc app=leetcode.cn id=905 lang=csharp
 *
 * [905] 按奇偶排序数组
 *
 * https://leetcode-cn.com/problems/sort-array-by-parity/description/
 *
 * algorithms
 * Easy (68.64%)
 * Likes:    139
 * Dislikes: 0
 * Total Accepted:    35.2K
 * Total Submissions: 51.3K
 * Testcase Example:  '[3,1,2,4]'
 *
 * 给定一个非负整数数组 A，返回一个数组，在该数组中， A 的所有偶数元素之后跟着所有奇数元素。
 * 
 * 你可以返回满足此条件的任何数组作为答案。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：[3,1,2,4]
 * 输出：[2,4,3,1]
 * 输出 [4,2,3,1]，[2,4,1,3] 和 [4,2,1,3] 也会被接受。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 5000
 * 0 <= A[i] <= 5000
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[] SortArrayByParity(int[] A) {
        int odd = A.Length-1;
        int even = 0;
        int index = 0;
        int[] ans = new int[A.Length];
        while(index<A.Length)
        {
            if((A[index] & 1) == 1) ans[odd--] = A[index++];
            else ans[even++] = A[index++];
        }
        return ans;
    }
}
// @lc code=end

