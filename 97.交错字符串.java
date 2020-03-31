/*
 * @lc app=leetcode.cn id=97 lang=java
 *
 * [97] 交错字符串
 *
 * https://leetcode-cn.com/problems/interleaving-string/description/
 *
 * algorithms
 * Hard (38.27%)
 * Likes:    140
 * Dislikes: 0
 * Total Accepted:    10.7K
 * Total Submissions: 27.5K
 * Testcase Example:  '"aabcc"\n"dbbca"\n"aadbbcbcac"'
 *
 * 给定三个字符串 s1, s2, s3, 验证 s3 是否是由 s1 和 s2 交错组成的。
 * 
 * 示例 1:
 * 
 * 输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
 * 输出: false
 * 
 */

// @lc code=start
class Solution {
    char[] ch1, ch2, ch3;
    public boolean isCom(int i, int j, int k){
        if(i==ch1.length && j==ch2.length && k== ch3.length) return true;
        if(i<ch1.length && j<ch2.length && ch1[i]==ch3[k] && ch2[j]==ch3[k]){
            return isCom(i+1, j, k+1) || isCom(i, j+1, k+1);
        }
        else if(i<ch1.length && ch1[i]==ch3[k]) return isCom(i+1, j, k+1);
        else if(j<ch2.length && ch2[j]==ch3[k]) return isCom(i, j+1, k+1);
        return false;
    }
    public boolean isInterleave(String s1, String s2, String s3) {
        ch1 = s1.toCharArray();
        ch2 = s2.toCharArray();
        ch3 = s3.toCharArray();
        if(ch1.length + ch2.length != ch3.length) return false;
        return isCom(0,0,0);
    }
}
// @lc code=end

