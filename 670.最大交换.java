/*
 * @lc app=leetcode.cn id=670 lang=java
 *
 * [670] 最大交换
 *
 * https://leetcode-cn.com/problems/maximum-swap/description/
 *
 * algorithms
 * Medium (40.06%)
 * Likes:    71
 * Dislikes: 0
 * Total Accepted:    5.6K
 * Total Submissions: 13.9K
 * Testcase Example:  '2736'
 *
 * 给定一个非负整数，你至多可以交换一次数字中的任意两位。返回你能得到的最大值。
 * 
 * 示例 1 :
 * 
 * 
 * 输入: 2736
 * 输出: 7236
 * 解释: 交换数字2和数字7。
 * 
 * 
 * 示例 2 :
 * 
 * 
 * 输入: 9973
 * 输出: 9973
 * 解释: 不需要交换。
 * 
 * 
 * 注意:
 * 
 * 
 * 给定数字的范围是 [0, 10^8]
 * 
 * 
 */

// @lc code=start
class Solution {
    public int maximumSwap(int num) {
        char[] A = Integer.toString(num).toCharArray();
        int[] last = new int[10];
        for (int i = 0; i < A.length; i++) {
            last[A[i] - '0'] = i;
        }
        for (int i = 0; i < A.length; i++) {
            for (int d = 9; d > A[i] - '0'; d--) {
                if (last[d] > i) {
                    char tmp = A[i];
                    A[i] = A[last[d]];
                    A[last[d]] = tmp;
                    return Integer.valueOf(new String(A));
                }
            }
        }
        return num;
    }
}
// @lc code=end
