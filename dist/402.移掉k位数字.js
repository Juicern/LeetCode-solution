/*
 * @lc app=leetcode.cn id=402 lang=typescript
 *
 * [402] 移掉K位数字
 *
 * https://leetcode-cn.com/problems/remove-k-digits/description/
 *
 * algorithms
 * Medium (30.01%)
 * Likes:    323
 * Dislikes: 0
 * Total Accepted:    28.6K
 * Total Submissions: 94.9K
 * Testcase Example:  '"1432219"\n3'
 *
 * 给定一个以字符串表示的非负整数 num，移除这个数中的 k 位数字，使得剩下的数字最小。
 *
 * 注意:
 *
 *
 * num 的长度小于 10002 且 ≥ k。
 * num 不会包含任何前导零。
 *
 *
 * 示例 1 :
 *
 *
 * 输入: num = "1432219", k = 3
 * 输出: "1219"
 * 解释: 移除掉三个数字 4, 3, 和 2 形成一个新的最小的数字 1219。
 *
 *
 * 示例 2 :
 *
 *
 * 输入: num = "10200", k = 1
 * 输出: "200"
 * 解释: 移掉首位的 1 剩下的数字为 200. 注意输出不能有任何前导零。
 *
 *
 * 示例 3 :
 *
 *
 * 输入: num = "10", k = 2
 * 输出: "0"
 * 解释: 从原数字移除所有的数字，剩余为空就是0。
 *
 *
 */
// @lc code=start
function removeKdigits(num, k) {
    var stack = [];
    for (var _i = 0, num_1 = num; _i < num_1.length; _i++) {
        var digit = num_1[_i];
        while (stack.length > 0 && k > 0 && stack[stack.length - 1] > +digit) {
            stack.pop();
            k--;
        }
        stack.push(+digit);
    }
    for (var i = 0; i < k; i++)
        stack.pop();
    var ans = '';
    var isHeadZero = true;
    for (var _a = 0, stack_1 = stack; _a < stack_1.length; _a++) {
        var digit = stack_1[_a];
        if (isHeadZero && digit === 0)
            continue;
        isHeadZero = false;
        ans += digit;
    }
    if (ans.length === 0)
        return '0';
    return ans;
}
;
// @lc code=end
