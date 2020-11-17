/*
 * @lc app=leetcode.cn id=396 lang=typescript
 *
 * [396] 旋转函数
 *
 * https://leetcode-cn.com/problems/rotate-function/description/
 *
 * algorithms
 * Medium (40.62%)
 * Likes:    60
 * Dislikes: 0
 * Total Accepted:    5.2K
 * Total Submissions: 12.9K
 * Testcase Example:  '[]'
 *
 * 给定一个长度为 n 的整数数组 A 。
 *
 * 假设 Bk 是数组 A 顺时针旋转 k 个位置后的数组，我们定义 A 的“旋转函数” F 为：
 *
 * F(k) = 0 * Bk[0] + 1 * Bk[1] + ... + (n-1) * Bk[n-1]。
 *
 * 计算F(0), F(1), ..., F(n-1)中的最大值。
 *
 * 注意:
 * 可以认为 n 的值小于 10^5。
 *
 * 示例:
 *
 *
 * A = [4, 3, 2, 6]
 *
 * F(0) = (0 * 4) + (1 * 3) + (2 * 2) + (3 * 6) = 0 + 3 + 4 + 18 = 25
 * F(1) = (0 * 6) + (1 * 4) + (2 * 3) + (3 * 2) = 0 + 4 + 6 + 6 = 16
 * F(2) = (0 * 2) + (1 * 6) + (2 * 4) + (3 * 3) = 0 + 6 + 8 + 9 = 23
 * F(3) = (0 * 3) + (1 * 2) + (2 * 6) + (3 * 4) = 0 + 2 + 12 + 12 = 26
 *
 * 所以 F(0), F(1), F(2), F(3) 中的最大值是 F(3) = 26 。
 *
 *
 */
// @lc code=start
function maxRotateFunction(A) {
    var sum = 0;
    var cur = 0;
    for (var i = 0; i < A.length; i++) {
        sum += A[i];
        cur += A[i] * i;
    }
    var ans = cur;
    for (var i = A.length - 1; i >= 0; i--) {
        cur += sum - A[i] * A.length;
        ans = Math.max(ans, cur);
    }
    return ans;
}
;
// @lc code=end
