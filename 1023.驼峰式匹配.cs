/*
 * @lc app=leetcode.cn id=1023 lang=csharp
 *
 * [1023] 驼峰式匹配
 *
 * https://leetcode-cn.com/problems/camelcase-matching/description/
 *
 * algorithms
 * Medium (53.36%)
 * Likes:    16
 * Dislikes: 0
 * Total Accepted:    3.4K
 * Total Submissions: 6.4K
 * Testcase Example:  '["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"]\n"FB"'
 *
 * 如果我们可以将小写字母插入模式串 pattern 得到待查询项 query，那么待查询项与给定模式串匹配。（我们可以在任何位置插入每个字符，也可以插入
 * 0 个字符。）
 * 
 * 给定待查询列表 queries，和模式串 pattern，返回由布尔值组成的答案列表 answer。只有在待查项 queries[i] 与模式串
 * pattern 匹配时， answer[i] 才为 true，否则为 false。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：queries =
 * ["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"], pattern =
 * "FB"
 * 输出：[true,false,true,true,false]
 * 示例：
 * "FooBar" 可以这样生成："F" + "oo" + "B" + "ar"。
 * "FootBall" 可以这样生成："F" + "oot" + "B" + "all".
 * "FrameBuffer" 可以这样生成："F" + "rame" + "B" + "uffer".
 * 
 * 示例 2：
 * 
 * 输入：queries =
 * ["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"], pattern =
 * "FoBa"
 * 输出：[true,false,true,false,false]
 * 解释：
 * "FooBar" 可以这样生成："Fo" + "o" + "Ba" + "r".
 * "FootBall" 可以这样生成："Fo" + "ot" + "Ba" + "ll".
 * 
 * 
 * 示例 3：
 * 
 * 输出：queries =
 * ["FooBar","FooBarTest","FootBall","FrameBuffer","ForceFeedBack"], pattern =
 * "FoBaT"
 * 输入：[false,true,false,false,false]
 * 解释： 
 * "FooBarTest" 可以这样生成："Fo" + "o" + "Ba" + "r" + "T" + "est".
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= queries.length <= 100
 * 1 <= queries[i].length <= 100
 * 1 <= pattern.length <= 100
 * 所有字符串都仅由大写和小写英文字母组成。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<bool> CamelMatch(string[] queries, string pattern) {
        var ans = new List<bool>();
        foreach(var querie in queries) {
            ans.Add(Check(querie, pattern));
        }
        return ans;
    }
    public bool Check(string s, string pattern) {
        int index = 0;
        foreach(var letter in s) {
            if(index < pattern.Length && letter == pattern[index]) index++;
            else if(letter >= 'A' && letter <= 'Z') return false;
        }
        return index == pattern.Length;
    }
}
// @lc code=end

