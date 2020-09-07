/*
 * @lc app=leetcode.cn id=907 lang=csharp
 *
 * [907] 子数组的最小值之和
 */

// @lc code=start
public class Solution {
    int MOD = 1_000_000_007;
    public int SumSubarrayMins(int[] A) {
        int ans = 0;
        int dot = 0;
        var stack = new Stack<Pair>();
        for(int i = 0;i< A.Length;i++) {
            int count = 1;
            while(stack.Count > 0 && stack.Peek().value >= A[i]) {
                count += stack.Peek().count;
                dot -= stack.Peek().value * stack.Peek().count;
                stack.Pop();
            }
            stack.Push(new Pair(A[i], count));
            dot += A[i] * count;
            ans += dot;
            ans %= MOD;
        }
        return ans;
    }
}
public class Pair {
    public int value;
    public int count;
    public Pair(int value, int count) {
        this.value = value;
        this.count = count;
    }
}
// @lc code=end

