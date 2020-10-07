/*
 * @lc app=leetcode.cn id=1000 lang=javascript
 *
 * [1000] 合并石头的最低成本
 *
 * https://leetcode-cn.com/problems/minimum-cost-to-merge-stones/description/
 *
 * algorithms
 * Hard (35.98%)
 * Likes:    100
 * Dislikes: 0
 * Total Accepted:    2K
 * Total Submissions: 5.6K
 * Testcase Example:  '[3,2,4,1]\n2'
 *
 * 有 N 堆石头排成一排，第 i 堆中有 stones[i] 块石头。
 * 
 * 每次移动（move）需要将连续的 K 堆石头合并为一堆，而这个移动的成本为这 K 堆石头的总数。
 * 
 * 找出把所有石头合并成一堆的最低成本。如果不可能，返回 -1 。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：stones = [3,2,4,1], K = 2
 * 输出：20
 * 解释：
 * 从 [3, 2, 4, 1] 开始。
 * 合并 [3, 2]，成本为 5，剩下 [5, 4, 1]。
 * 合并 [4, 1]，成本为 5，剩下 [5, 5]。
 * 合并 [5, 5]，成本为 10，剩下 [10]。
 * 总成本 20，这是可能的最小值。
 * 
 * 
 * 示例 2：
 * 
 * 输入：stones = [3,2,4,1], K = 3
 * 输出：-1
 * 解释：任何合并操作后，都会剩下 2 堆，我们无法再进行合并。所以这项任务是不可能完成的。.
 * 
 * 
 * 示例 3：
 * 
 * 输入：stones = [3,5,1,2,6], K = 3
 * 输出：25
 * 解释：
 * 从 [3, 5, 1, 2, 6] 开始。
 * 合并 [5, 1, 2]，成本为 8，剩下 [3, 8, 6]。
 * 合并 [3, 8, 6]，成本为 17，剩下 [17]。
 * 总成本 25，这是可能的最小值。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= stones.length <= 30
 * 2 <= K <= 30
 * 1 <= stones[i] <= 100
 * 
 * 
 */

// @lc code=start
/**
 * @param {number[]} stones
 * @param {number} K
 * @return {number}
 */
var mergeStones = function (stones, K) {
    if ((stones.length - 1) % (K - 1) !== 0) return -1;
    if (stones.length === 1) return 0;
    let sumArr = [];
    for (let i = 0, sum = 0; i < stones.length; i++) {
        sum = sumArr[i] = sum + stones[i];
    }
    let hash = {};
    return f(0, stones.length - 1, 1);

    function sum(start, end) {
        let res = sumArr[end] - sumArr[start] + stones[start]
        // console.log(res,start,end)
        return res;
    }

    //将[i,j]的stones转换为k堆所需要的最低成本
    function f(start, end, k) {
        let key = start + ":" + end + ":" + k;
        if (hash[key] != undefined) return hash[key];
        if (k === 1) {
            let part1 = f(start, end, K);
            let part2 = sum(start, end);
            return hash[key] = part1 + part2;
        }
        let result = Infinity;
        for (let m = start + k - 2; m < end; m++) {
            let part1 = (m - start + 1 == k - 1 || start == m) ? 0 : f(start, m, k - 1);
            let part2 = m + 1 === end ? 0 : f(m + 1, end, 1);
            result = Math.min(part1 + part2, result);
        }
        return hash[key] = result;
    }
};

// @lc code=end

