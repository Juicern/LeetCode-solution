/*
 * @lc app=leetcode.cn id=888 lang=typescript
 *
 * [888] 公平的糖果交换
 *
 * https://leetcode-cn.com/problems/fair-candy-swap/description/
 *
 * algorithms
 * Easy (55.32%)
 * Likes:    81
 * Dislikes: 0
 * Total Accepted:    15.5K
 * Total Submissions: 27.9K
 * Testcase Example:  '[1,1]\n[2,2]'
 *
 * 爱丽丝和鲍勃有不同大小的糖果棒：A[i] 是爱丽丝拥有的第 i 块糖的大小，B[j] 是鲍勃拥有的第 j 块糖的大小。
 *
 * 因为他们是朋友，所以他们想交换一个糖果棒，这样交换后，他们都有相同的糖果总量。（一个人拥有的糖果总量是他们拥有的糖果棒大小的总和。）
 *
 * 返回一个整数数组 ans，其中 ans[0] 是爱丽丝必须交换的糖果棒的大小，ans[1] 是 Bob 必须交换的糖果棒的大小。
 *
 * 如果有多个答案，你可以返回其中任何一个。保证答案存在。
 *
 *
 *
 * 示例 1：
 *
 * 输入：A = [1,1], B = [2,2]
 * 输出：[1,2]
 *
 *
 * 示例 2：
 *
 * 输入：A = [1,2], B = [2,3]
 * 输出：[1,2]
 *
 *
 * 示例 3：
 *
 * 输入：A = [2], B = [1,3]
 * 输出：[2,3]
 *
 *
 * 示例 4：
 *
 * 输入：A = [1,2,5], B = [2,4]
 * 输出：[5,4]
 *
 *
 *
 *
 * 提示：
 *
 *
 * 1 <= A.length <= 10000
 * 1 <= B.length <= 10000
 * 1 <= A[i] <= 100000
 * 1 <= B[i] <= 100000
 * 保证爱丽丝与鲍勃的糖果总量不同。
 * 答案肯定存在。
 *
 *
 */
// @lc code=start
function fairCandySwap(A, B) {
    var set = new Set();
    var num1 = 0;
    var num2 = 0;
    for (var _i = 0, B_1 = B; _i < B_1.length; _i++) {
        var num = B_1[_i];
        num2 += num;
    }
    for (var _a = 0, A_1 = A; _a < A_1.length; _a++) {
        var num = A_1[_a];
        num1 += num;
        set.add(num);
    }
    for (var _b = 0, B_2 = B; _b < B_2.length; _b++) {
        var num = B_2[_b];
        if (set.has((num1 - num2 + 2 * num) / 2)) {
            return [(num1 - num2 + 2 * num) / 2, num];
        }
    }
    return [];
}
;
// @lc code=end
