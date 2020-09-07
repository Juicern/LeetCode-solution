/*
 * @lc app=leetcode.cn id=941 lang=csharp
 *
 * [941] 有效的山脉数组
 *
 * https://leetcode-cn.com/problems/valid-mountain-array/description/
 *
 * algorithms
 * Easy (35.28%)
 * Likes:    44
 * Dislikes: 0
 * Total Accepted:    9.9K
 * Total Submissions: 27.8K
 * Testcase Example:  '[2,1]'
 *
 * 给定一个整数数组 A，如果它是有效的山脉数组就返回 true，否则返回 false。
 * 
 * 让我们回顾一下，如果 A 满足下述条件，那么它是一个山脉数组：
 * 
 * 
 * A.length >= 3
 * 在 0 < i < A.length - 1 条件下，存在 i 使得：
 * 
 * A[0] < A[1] < ... A[i-1] < A[i] 
 * A[i] > A[i+1] > ... > A[A.length - 1]
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[2,1]
 * 输出：false
 * 
 * 
 * 示例 2：
 * 
 * 输入：[3,5,5]
 * 输出：false
 * 
 * 
 * 示例 3：
 * 
 * 输入：[0,3,2,1]
 * 输出：true
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 <= A.length <= 10000
 * 0 <= A[i] <= 10000 
 * 
 * 
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool ValidMountainArray(int[] A) {
        bool isInc = true;
        bool hasInc = false;
        bool hasDec = false;
        for(int i=1;i<A.Length;i++)
        {
            if(A[i] == A[i-1]) return false;
            if(A[i] > A[i-1]) {
                hasInc = true;
                if(isInc) continue;
                return false;
            }
            if(A[i] < A[i-1])
            {
                hasDec = true;
                if(isInc) isInc = false;
                else continue;
            }
        }
        if(!hasInc || !hasDec) return false;
        return true;
    }
}
// @lc code=end

