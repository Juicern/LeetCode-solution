/*
 * @lc app=leetcode.cn id=132 lang=java
 *
 * [132] 分割回文串 II
 *
 * https://leetcode-cn.com/problems/palindrome-partitioning-ii/description/
 *
 * algorithms
 * Hard (41.29%)
 * Likes:    112
 * Dislikes: 0
 * Total Accepted:    8.4K
 * Total Submissions: 19.7K
 * Testcase Example:  '"aab"'
 *
 * 给定一个字符串 s，将 s 分割成一些子串，使每个子串都是回文串。
 * 
 * 返回符合要求的最少分割次数。
 * 
 * 示例:
 * 
 * 输入: "aab"
 * 输出: 1
 * 解释: 进行一次分割就可将 s 分割成 ["aa","b"] 这样两个回文子串。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int minCut(String s) {
        if(s.length()<2) return 0;
        boolean[][] checkPalindrome = new boolean[s.length()][s.length()];
        for(int i=0;i<s.length();i++){
            for(int j=0;j<=i;j++){
                if(s.charAt(i)==s.charAt(j) &&(i-j<2 || checkPalindrome[j+1][i-1])) checkPalindrome[j][i] = true;
            }
        }
        int[] dp = new int[s.length()];
        for(int i=0;i<s.length();i++) dp[i] = i;
        for(int i=1;i<s.length();i++){
            if(checkPalindrome[0][i]){
                dp[i] = 0;
                continue;
            }
            for(int j=0;j<i;j++){
                if(checkPalindrome[j+1][i]) dp[i] = Integer.min(dp[i], dp[j]+1);
            }
        }
        return dp[s.length()-1];
    }
}
// @lc code=end

