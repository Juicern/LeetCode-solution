/*
 * @lc app=leetcode id=13 lang=typescript
 *
 * [13] Roman to Integer
 */

// @lc code=start

const hash = {
    I: 1,
    V: 5,
    X: 10,
    L: 50,
    C: 100,
    D: 500,
    M: 1000,
};

function romanToInt(s: string): number {
    let ans = hash[s[s.length - 1]];

    for (let i = 0; i < s.length - 1; i++) {
        if (hash[s[i]] < hash[s[i + 1]]) ans -= hash[s[i]];
        else ans += hash[s[i]];
    }

    return ans;
}
// @lc code=end

