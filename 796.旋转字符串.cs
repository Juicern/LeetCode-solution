using System;
/*
 * @lc app=leetcode.cn id=796 lang=csharp
 *
 * [796] 旋转字符串
 *
 * https://leetcode-cn.com/problems/rotate-string/description/
 *
 * algorithms
 * Easy (51.23%)
 * Likes:    110
 * Dislikes: 0
 * Total Accepted:    15.1K
 * Total Submissions: 29.4K
 * Testcase Example:  '"abcde"\n"cdeab"'
 *
 * 给定两个字符串, A 和 B。
 * 
 * A 的旋转操作就是将 A 最左边的字符移动到最右边。 例如, 若 A = 'abcde'，在移动一次之后结果就是'bcdea'
 * 。如果在若干次旋转操作之后，A 能变成B，那么返回True。
 * 
 * 
 * 示例 1:
 * 输入: A = 'abcde', B = 'cdeab'
 * 输出: true
 * 
 * 示例 2:
 * 输入: A = 'abcde', B = 'abced'
 * 输出: false
 * 
 * 注意：
 * 
 * 
 * A 和 B 长度不超过 100。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool RotateString(string A, string B) {
        if(A.Length == 0 && B.Length == 0) return true;
        if(A.Length != B.Length) return false;
        for(int _ = 0;_<A.Length;_++) {
            A = A.Remove(0, 1) + A[0];
            if(A == B) return true;
        }
        return false;
    }
}
// @lc code=end

