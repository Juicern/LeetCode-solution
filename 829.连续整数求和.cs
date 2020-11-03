/*
 * @lc app=leetcode.cn id=829 lang=csharp
 *
 * [829] 连续整数求和
 *
 * https://leetcode-cn.com/problems/consecutive-numbers-sum/description/
 *
 * algorithms
 * Hard (34.32%)
 * Likes:    86
 * Dislikes: 0
 * Total Accepted:    5.9K
 * Total Submissions: 17K
 * Testcase Example:  '5'
 *
 * 给定一个正整数 N，试求有多少组连续正整数满足所有数字之和为 N?
 * 
 * 示例 1:
 * 
 * 
 * 输入: 5
 * 输出: 2
 * 解释: 5 = 5 = 2 + 3，共有两组连续整数([5],[2,3])求和后为 5。
 * 
 * 示例 2:
 * 
 * 
 * 输入: 9
 * 输出: 3
 * 解释: 9 = 9 = 4 + 5 = 2 + 3 + 4
 * 
 * 示例 3:
 * 
 * 
 * 输入: 15
 * 输出: 4
 * 解释: 15 = 15 = 8 + 7 = 4 + 5 + 6 = 1 + 2 + 3 + 4 + 5
 * 
 * 说明: 1 <= N <= 10 ^ 9
 * 
 */

// @lc code=start
public class Solution {
    public int ConsecutiveNumbersSum(int N) {
        int ans = 0;
        for(int i = 1;i<=N;i++) {
            double min = i  * (i + 1) / 2.0;
            if(N < min) break;
            if(i % 2 == 1) {
                if(N % i == 0) ans++;    
            }
            else {
                if((N + i / 2) % i == 0) ans++;
            }
        }
        return ans;
    }
}
// @lc code=end
