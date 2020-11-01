/*
 * @lc app=leetcode.cn id=739 lang=javascript
 *
 * [739] 每日温度
 *
 * https://leetcode-cn.com/problems/daily-temperatures/description/
 *
 * algorithms
 * Medium (65.08%)
 * Likes:    554
 * Dislikes: 0
 * Total Accepted:    111.7K
 * Total Submissions: 171.5K
 * Testcase Example:  '[73,74,75,71,69,72,76,73]'
 *
 * 请根据每日 气温 列表，重新生成一个列表。对应位置的输出为：要想观测到更高的气温，至少需要等待的天数。如果气温在这之后都不会升高，请在该位置用 0
 * 来代替。
 * 
 * 例如，给定一个列表 temperatures = [73, 74, 75, 71, 69, 72, 76, 73]，你的输出应该是 [1, 1, 4,
 * 2, 1, 1, 0, 0]。
 * 
 * 提示：气温 列表长度的范围是 [1, 30000]。每个气温的值的均为华氏度，都是在 [30, 100] 范围内的整数。
 * 
 */

// @lc code=start
/**
 * @param {number[]} T
 * @return {number[]}
 */
var dailyTemperatures = function(T) {
    let len = T.length;
    let ans = new Array(len).fill(0);
    let stack = [];
    for(let i = 0;i<len;i++) {
        let temp = T[i];
        while(stack.length > 0 && temp > T[stack[stack.length - 1]]){
            let index = stack.pop();
            ans[index] = i - index;
        }
        stack.push(i);
    }
    return ans;
};
// @lc code=end

