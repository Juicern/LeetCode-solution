/*
 * @lc app=leetcode.cn id=14 lang=java
 *
 * [14] 最长公共前缀
 *
 * https://leetcode-cn.com/problems/longest-common-prefix/description/
 *
 * algorithms
 * Easy (35.88%)
 * Likes:    896
 * Dislikes: 0
 * Total Accepted:    194.9K
 * Total Submissions: 536.6K
 * Testcase Example:  '["flower","flow","flight"]'
 *
 * 编写一个函数来查找字符串数组中的最长公共前缀。
 * 
 * 如果不存在公共前缀，返回空字符串 ""。
 * 
 * 示例 1:
 * 
 * 输入: ["flower","flow","flight"]
 * 输出: "fl"
 * 
 * 
 * 示例 2:
 * 
 * 输入: ["dog","racecar","car"]
 * 输出: ""
 * 解释: 输入不存在公共前缀。
 * 
 * 
 * 说明:
 * 
 * 所有输入只包含小写字母 a-z 。
 * 
 */

// @lc code=start
class Solution {
    public String longestCommonPrefix(String[] strs) {
        if(strs.length==0) return "";
        if(strs.length==1) return strs[0];
        String result = "";
        int index = 0;
        while(index<strs[0].length()){
            String flag = strs[0].substring(index, index+1);
            for(int i=1;i<strs.length;i++){
                if(index == strs[i].length() || !flag.equals(strs[i].substring(index, index+1))) return result;
            }
            result += flag;
            index++;
        }
        return result;
    }
}
// @lc code=end

