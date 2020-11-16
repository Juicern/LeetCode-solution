/*
 * @lc app=leetcode.cn id=372 lang=typescript
 *
 * [372] 超级次方
 *
 * https://leetcode-cn.com/problems/super-pow/description/
 *
 * algorithms
 * Medium (45.00%)
 * Likes:    88
 * Dislikes: 0
 * Total Accepted:    8K
 * Total Submissions: 17.7K
 * Testcase Example:  '2\n[3]'
 *
 * 你的任务是计算 a^b 对 1337 取模，a 是一个正整数，b 是一个非常大的正整数且会以数组形式给出。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：a = 2, b = [3]
 * 输出：8
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：a = 2, b = [1,0]
 * 输出：1024
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入：a = 1, b = [4,3,3,8,5,2]
 * 输出：1
 * 
 * 
 * 示例 4：
 * 
 * 
 * 输入：a = 2147483647, b = [2,0,0]
 * 输出：1198
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * 1 
 * 0 
 * b 不含前导 0
 * 
 * 
 */

// @lc code=start
let MOD: number = 1337;
function superPow(a: number, b: number[]): number {
    if(b.length == 0) return 1;
    let last: number = b.pop() as number;
    return myPow(a, last) * myPow(superPow(a, b), 10) % MOD;
};
function myPow(a : number, b: number): number {
    if(b === 0) return 1;
    a = a % MOD;
    let ans : number = 1;
    for(let i = 0;i<b;i++){
        ans *= a;
        ans %= MOD;
    }
    return ans;
}
// @lc code=end

