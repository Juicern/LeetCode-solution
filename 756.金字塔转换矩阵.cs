using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=756 lang=csharp
 *
 * [756] 金字塔转换矩阵
 *
 * https://leetcode-cn.com/problems/pyramid-transition-matrix/description/
 *
 * algorithms
 * Medium (54.92%)
 * Likes:    33
 * Dislikes: 0
 * Total Accepted:    2.3K
 * Total Submissions: 4.2K
 * Testcase Example:  '"ABC"\n["ABD","BCE","DEF","FFF"]'
 *
 * 现在，我们用一些方块来堆砌一个金字塔。 每个方块用仅包含一个字母的字符串表示。
 * 
 * 使用三元组表示金字塔的堆砌规则如下：
 * 
 * 对于三元组(A, B, C) ，“C”为顶层方块，方块“A”、“B”分别作为方块“C”下一层的的左、右子块。当且仅当(A, B,
 * C)是被允许的三元组，我们才可以将其堆砌上。
 * 
 * 初始时，给定金字塔的基层 bottom，用一个字符串表示。一个允许的三元组列表 allowed，每个三元组用一个长度为 3 的字符串表示。
 * 
 * 如果可以由基层一直堆到塔尖就返回 true，否则返回 false。
 * 
 * 
 * 
 * 示例 1:
 * 
 * 输入: bottom = "BCD", allowed = ["BCG", "CDE", "GEA", "FFF"]
 * 输出: true
 * 解析:
 * 可以堆砌成这样的金字塔:
 * ⁠   A
 * ⁠  / \
 * ⁠ G   E
 * ⁠/ \ / \
 * B   C   D
 * 
 * 因为符合('B', 'C', 'G'), ('C', 'D', 'E') 和 ('G', 'E', 'A') 三种规则。
 * 
 * 
 * 示例 2:
 * 
 * 输入: bottom = "AABA", allowed = ["AAA", "AAB", "ABA", "ABB", "BAC"]
 * 输出: false
 * 解析:
 * 无法一直堆到塔尖。
 * 注意, 允许存在像 (A, B, C) 和 (A, B, D) 这样的三元组，其中 C != D。
 * 
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * bottom 的长度范围在 [2, 8]。
 * allowed 的长度范围在[0, 200]。
 * 方块的标记字母范围为{'A', 'B', 'C', 'D', 'E', 'F', 'G'}。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool PyramidTransition(string bottom, IList<string> allowed) {
        var dict = new Dictionary<string, List<char>>();
        foreach(var a in allowed){
            var key = a.Substring(0,2);
            if(!dict.ContainsKey(key))
                dict[key] = new List<char>();
            dict[key].Add(a[2]);
        }
        return Helper(bottom, 1, string.Empty, dict);
    }
    
    private bool Helper(string cur, int i, string next, Dictionary<string, List<char>> dict){
        if(cur.Length == 1) return true;
        var key = cur.Substring(i-1, 2);
        //var key = new string(new []{cur[i-1], cur[i]});
        
        if(!dict.ContainsKey(key)) return false;
        
        foreach(var c in dict[key]){
            if(i == cur.Length - 1){
                if(Helper(next+c, 1, string.Empty, dict))
                    return true;
            }
            else{
                if(Helper(cur, i+1, next+c, dict))
                    return true;
            }
        }
        return false;
    }
}
/*
public class Solution
{
    private string allowedString = "ABCDEFG";
    public Dictionary<string, int> Convert(IList<string> allowed)
    {
        int[] nums = { 1, 2, 4, 8, 16, 32, 64 };
        Dictionary<string, int> dic = new Dictionary<string, int>();
        foreach (string allow in allowed)
        {
            int num = nums[allow[2] - 'A'];
            string str = allow.Substring(0, 2);
            if (dic.ContainsKey(str)) dic[str] += num;
            else dic.Add(str, num);
        }
        return dic;
    }
    public bool DealNextFloor(Dictionary<string, int> dic, string bottom, string origin, int k)
    {
        if (k == origin.Length - 1)
        {
            return origin.Length == 1 || DealNextFloor(dic, "", bottom, 0);
        }
        string key = allowedString.Substring(k, 2);
        if (!dic.ContainsKey(key)) return false;
        int value = dic[key];
        if (value > 0)
        {
            for (int i = 0; i < 7; i++)
            {
                if ((value >> i & 1) == 1)
                {
                    if (DealNextFloor(dic, bottom + allowedString[i], origin, k + 1)) return true;
                }
            }
        }
        return false;
    }
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        Dictionary<string, int> dic = Convert(allowed);
        return DealNextFloor(dic, "", bottom, 0);
    }
}
*/
// @lc code=end

