using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=962 lang=csharp
 *
 * [962] 最大宽度坡
 *
 * https://leetcode-cn.com/problems/maximum-width-ramp/description/
 *
 * algorithms
 * Medium (37.17%)
 * Likes:    55
 * Dislikes: 0
 * Total Accepted:    4.9K
 * Total Submissions: 12.9K
 * Testcase Example:  '[6,0,8,2,1,5]'
 *
 * 给定一个整数数组 A，坡是元组 (i, j)，其中  i < j 且 A[i] <= A[j]。这样的坡的宽度为 j - i。
 * 
 * 找出 A 中的坡的最大宽度，如果不存在，返回 0 。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[6,0,8,2,1,5]
 * 输出：4
 * 解释：
 * 最大宽度的坡为 (i, j) = (1, 5): A[1] = 0 且 A[5] = 5.
 * 
 * 
 * 示例 2：
 * 
 * 输入：[9,8,1,0,1,9,4,0,4,1]
 * 输出：7
 * 解释：
 * 最大宽度的坡为 (i, j) = (2, 9): A[2] = 1 且 A[9] = 1.
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 2 <= A.length <= 50000
 * 0 <= A[i] <= 50000
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int MaxWidthRamp(int[] A) {
        var st = new Stack<int>();
        st.Push(0);
        for(int i=1;i<A.Length;i++)
        {
            if(A[i] <= A[st.Peek()]) st.Push(i);
        }
        int max = 0;
        for(int i=A.Length-1;i>=0;i--)
        {
            while(st.Count!=0 && A[i] >= A[st.Peek()])
            {
                max = Math.Max(max, i - st.Peek());
                st.Pop();
            }
        }
        return max;
    }
}
// @lc code=end

