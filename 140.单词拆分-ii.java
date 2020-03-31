/*
 * @lc app=leetcode.cn id=140 lang=java
 *
 * [140] 单词拆分 II
 *
 * https://leetcode-cn.com/problems/word-break-ii/description/
 *
 * algorithms
 * Hard (37.56%)
 * Likes:    130
 * Dislikes: 0
 * Total Accepted:    12.5K
 * Total Submissions: 33.1K
 * Testcase Example:  '"catsanddog"\n["cat","cats","and","sand","dog"]'
 *
 * 给定一个非空字符串 s 和一个包含非空单词列表的字典
 * wordDict，在字符串中增加空格来构建一个句子，使得句子中所有的单词都在词典中。返回所有这些可能的句子。
 * 
 * 说明：
 * 
 * 
 * 分隔时可以重复使用字典中的单词。
 * 你可以假设字典中没有重复的单词。
 * 
 * 
 * 示例 1：
 * 
 * 输入:
 * s = "catsanddog"
 * wordDict = ["cat", "cats", "and", "sand", "dog"]
 * 输出:
 * [
 * "cats and dog",
 * "cat sand dog"
 * ]
 * 
 * 
 * 示例 2：
 * 
 * 输入:
 * s = "pineapplepenapple"
 * wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
 * 输出:
 * [
 * "pine apple pen apple",
 * "pineapple pen apple",
 * "pine applepen apple"
 * ]
 * 解释: 注意你可以重复使用字典中的单词。
 * 
 * 
 * 示例 3：
 * 
 * 输入:
 * s = "catsandog"
 * wordDict = ["cats", "dog", "sand", "and", "cat"]
 * 输出:
 * []
 * 
 * 
 */

// @lc code=start
class Solution {
    public List<String> wordBreak(String s, List<String> wordDict) {
        int n = s.length();
        boolean[] dp = new boolean[n + 1];
        dp[0] = true;
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j < i; j++) {
                if (dp[j] && wordDict.contains(s.substring(j, i))) {
                    dp[i] = true;
                    break;//[i]是套在[j]外面的，一旦是True时，没有必要再次判断
                }
            }
        }
        List<String> resList = new ArrayList<>();
        if (dp[n]) {
            dfs(s, wordDict, dp, n, resList, new ArrayList<String>());
            return resList;
        }
        return resList;
    }

    /**
     *
     * @param s 原字符
     * @param wordDict 字典
     * @param dp 动态数组，dp[i]表示以s[i-1]结尾的字符串能否被wordDict拆分，换句话说，
     *           以s[i-1]结尾的字符串拆分为一个或者多个字符串，是否都出现在wordDict中，在wordDict中都能找到
     * @param end 字符s的索引位置
     * @param resList 结果集
     * @param levelList 当前层的结果集
     */
    private void dfs(String s, List<String> wordDict, boolean[] dp, int end, List<String> resList, ArrayList<String> levelList) {
        if (end == 0) {
            //退出条件
            StringBuilder sb = new StringBuilder();
//            System.out.println(JSON.toJSONString(levelList));
            //levelList加入的顺序是倒置的，倒着遍历
            for (int i = levelList.size() - 1; i >= 0; i--) {
                sb.append(levelList.get(i)).append(" ");
            }
            sb.deleteCharAt(sb.length() - 1);//为了去掉最后一个组装后的空格
            resList.add(sb.toString());
            return;
        }
        for (int i = 0; i < end; i++) {
            if (dp[i]) {
                //i到end的位置，去头取尾
                String sub = s.substring(i, end);
                if (wordDict.contains(sub)) {
                    levelList.add(sub);
                    dfs(s, wordDict, dp, i, resList, levelList);
                    levelList.remove(levelList.size() - 1);
                }
            }
        }
    }
}
// @lc code=end

