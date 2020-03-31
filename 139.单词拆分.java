/*
 * @lc app=leetcode.cn id=139 lang=java
 *
 * [139] 单词拆分
 *
 * https://leetcode-cn.com/problems/word-break/description/
 *
 * algorithms
 * Medium (42.96%)
 * Likes:    345
 * Dislikes: 0
 * Total Accepted:    39.9K
 * Total Submissions: 91K
 * Testcase Example:  '"leetcode"\n["leet","code"]'
 *
 * 给定一个非空字符串 s 和一个包含非空单词列表的字典 wordDict，判定 s 是否可以被空格拆分为一个或多个在字典中出现的单词。
 * 
 * 说明：
 * 
 * 
 * 拆分时可以重复使用字典中的单词。
 * 你可以假设字典中没有重复的单词。
 * 
 * 
 * 示例 1：
 * 
 * 输入: s = "leetcode", wordDict = ["leet", "code"]
 * 输出: true
 * 解释: 返回 true 因为 "leetcode" 可以被拆分成 "leet code"。
 * 
 * 
 * 示例 2：
 * 
 * 输入: s = "applepenapple", wordDict = ["apple", "pen"]
 * 输出: true
 * 解释: 返回 true 因为 "applepenapple" 可以被拆分成 "apple pen apple"。
 * 注意你可以重复使用字典中的单词。
 * 
 * 
 * 示例 3：
 * 
 * 输入: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
 * 输出: false
 * 
 * 
 */

// @lc code=start
class Solution {
    Set<String> wordsDict;
    Boolean[] memo; 
    public boolean backtrace(String s, int start, int end){
        if(start==end) return true;
        if(memo[start]!=null){
            return memo[start];
        }
        for(int i=start+1;i<=end;i++){
            if(wordsDict.contains(s.substring(start, i)) && backtrace(s, i, end)){
                return memo[start] = true;
            }    
        }
        return memo[start] = false;
        
    }
    public boolean wordBreak(String s, List<String> wordDict) {
        if(s.length()==0) return false;
        wordsDict = new HashSet<>(wordDict);
        memo = new Boolean[s.length()];
        return backtrace(s, 0, s.length());
    }
}
// @lc code=end

