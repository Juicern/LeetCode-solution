/*
 * @lc app=leetcode.cn id=866 lang=cpp
 *
 * [866] 回文素数
 *
 * https://leetcode-cn.com/problems/prime-palindrome/description/
 *
 * algorithms
 * Medium (21.64%)
 * Likes:    55
 * Dislikes: 0
 * Total Accepted:    5.6K
 * Total Submissions: 25.9K
 * Testcase Example:  '6'
 *
 * 求出大于或等于 N 的最小回文素数。
 * 
 * 回顾一下，如果一个数大于 1，且其因数只有 1 和它自身，那么这个数是素数。
 * 
 * 例如，2，3，5，7，11 以及 13 是素数。
 * 
 * 回顾一下，如果一个数从左往右读与从右往左读是一样的，那么这个数是回文数。
 * 
 * 例如，12321 是回文数。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：6
 * 输出：7
 * 
 * 
 * 示例 2：
 * 
 * 输入：8
 * 输出：11
 * 
 * 
 * 示例 3：
 * 
 * 输入：13
 * 输出：101
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= N <= 10^8
 * 答案肯定存在，且小于 2 * 10^8。
 * 
 * 
 * 
 * 
 * 
 * 
 */

// @lc code=start
class Solution {
public:
    int primePalindrome(int N) {
        while (true) {
            if(N == reverse(N) && isPrime(N)) return N;
            N++;
            if(10000000 < N && N < 100000000) N = 100000000;
        }
    }
    bool isPrime(int N) {
        if(N < 2) return false;
        int R = (int)sqrt(N);
        for (int d = 2;d<=R;d++) {
            if(N % d == 0) return false;
        }
        return true;
    } 
    int reverse(int N) {
        int ans = 0;
        while(N > 0) {
            ans = 10 * ans + (N % 10);
            N /= 10;
        }
        return ans;
    }
};
// @lc code=end

