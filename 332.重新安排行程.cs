using System.Collections.ObjectModel;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=332 lang=csharp
 *
 * [332] 重新安排行程
 *
 * https://leetcode-cn.com/problems/reconstruct-itinerary/description/
 *
 * algorithms
 * Medium (38.40%)
 * Likes:    139
 * Dislikes: 0
 * Total Accepted:    9K
 * Total Submissions: 23.5K
 * Testcase Example:  '[["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]'
 *
 * 给定一个机票的字符串二维数组 [from,
 * to]，子数组中的两个成员分别表示飞机出发和降落的机场地点，对该行程进行重新规划排序。所有这些机票都属于一个从JFK（肯尼迪国际机场）出发的先生，所以该行程必须从
 * JFK 出发。
 * 
 * 说明:
 * 
 * 
 * 如果存在多种有效的行程，你可以按字符自然排序返回最小的行程组合。例如，行程 ["JFK", "LGA"] 与 ["JFK", "LGB"]
 * 相比就更小，排序更靠前
 * 所有的机场都用三个大写字母表示（机场代码）。
 * 假定所有机票至少存在一种合理的行程。
 * 
 * 
 * 示例 1:
 * 
 * 输入: [["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
 * 输出: ["JFK", "MUC", "LHR", "SFO", "SJC"]
 * 
 * 
 * 示例 2:
 * 
 * 输入: [["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
 * 输出: ["JFK","ATL","JFK","SFO","ATL","SFO"]
 * 解释: 另一种有效的行程是 ["JFK","SFO","ATL","JFK","ATL","SFO"]。但是它自然排序更大更靠后。
 * 
 */

// @lc code=start
public class Solution
{
    Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
    List<string> ans = new List<string>();
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        foreach (var ticket in tickets)
        {
            var src = ticket[0];
            var dst = ticket[1];
            if (!dic.ContainsKey(src)) dic.Add(src, new List<string>());
            dic[src].Add(dst);
        }
        foreach(var value in dic.Values)
        {
            value.Sort();
        }
        Dfs("JFK");
        ans.Reverse();
        return ans;
    }
    private void Dfs(string cur)
    {
        while (dic.ContainsKey(cur) && dic[cur].Any())
        {
            var next = dic[cur][0];
            dic[cur].RemoveAt(0);
            Dfs(next);
        }
        ans.Add(cur);
    }
}
// @lc code=end

