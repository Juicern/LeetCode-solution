/*
 * @lc app=leetcode.cn id=884 lang=csharp
 *
 * [884] 两句话中的不常见单词
 */

// @lc code=start
public class Solution {
    public string[] UncommonFromSentences(string A, string B) {
        var dic = new Dictionary<string, int>();
        foreach(string word in A.Split(" ")) {
            if(!dic.ContainsKey(word)) dic.Add(word, 0);
            dic[word]++;
        }
        foreach(string word in B.Split(" ")) {
            if(!dic.ContainsKey(word)) dic.Add(word, 0);
            dic[word]++;
        }
        var ans = new List<string>();
        foreach(var key in dic.Keys) {
            if(dic[key] == 1) ans.Add(key);
        }
        return ans.ToArray();
    }
}
// @lc code=end

