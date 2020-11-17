/*
 * @lc app=leetcode.cn id=400 lang=typescript
 *
 * [400] 第N个数字
 *
 * https://leetcode-cn.com/problems/nth-digit/description/
 *
 * algorithms
 * Medium (38.49%)
 * Likes:    133
 * Dislikes: 0
 * Total Accepted:    11.8K
 * Total Submissions: 30.7K
 * Testcase Example:  '3'
 *
 * 在无限的整数序列 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...中找到第 n 个数字。
 *
 * 注意:
 * n 是正数且在32位整数范围内 ( n < 2^31)。
 *
 * 示例 1:
 *
 * 输入:
 * 3
 *
 * 输出:
 * 3
 *
 *
 * 示例 2:
 *
 * 输入:
 * 11
 *
 * 输出:
 * 0
 *
 * 说明:
 * 第11个数字在序列 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ... 里是0，它是10的一部分。
 *
 *
 */
// @lc code=start
function findNthDigit(n) {
    n -= 1;
    var count = 1;
    while (n > count * 9 * Math.pow(10, count - 1)) {
        n -= count * 9 * Math.pow(10, count - 1);
        count++;
    }
    var num = (Math.pow(10, count - 1) + n / count) + '';
    return Number(num[n % count]);
}
;
// @lc code=end
