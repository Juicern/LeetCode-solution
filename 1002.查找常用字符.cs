using System;
using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=1002 lang=csharp
 *
 * [1002] 查找常用字符
 *
 * https://leetcode-cn.com/problems/find-common-characters/description/
 *
 * algorithms
 * Easy (67.03%)
 * Likes:    69
 * Dislikes: 0
 * Total Accepted:    12.4K
 * Total Submissions: 18.3K
 * Testcase Example:  '["bella","label","roller"]'
 *
 * 给定仅有小写字母组成的字符串数组 A，返回列表中的每个字符串中都显示的全部字符（包括重复字符）组成的列表。例如，如果一个字符在每个字符串中出现 3
 * 次，但不是 4 次，则需要在最终答案中包含该字符 3 次。
 * 
 * 你可以按任意顺序返回答案。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：["bella","label","roller"]
 * 输出：["e","l","l"]
 * 
 * 
 * 示例 2：
 * 
 * 输入：["cool","lock","cook"]
 * 输出：["c","o"]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= A.length <= 100
 * 1 <= A[i].length <= 100
 * A[i][j] 是小写字母
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<string> CommonChars(string[] A) {
        var count = new int[26];
        foreach(char ch in A[0])
        {
            count[ch - 'a']++;
        }
        for(int i = 1;i<A.Length;i++)
        {
            var tmp = new int[26];
            foreach(char ch in A[i])
            {
                tmp[ch - 'a']++;
            }
            for(int j=0;j<26;i++)
            {
                count[j] = Math.Min(count[j], tmp[j]);
            }
        }
        List<string> ans = new List<string>();
        for(int i=0;i<26;i++)
        {
            for(int j=0;j<count[i];j++)
            {
                ans.Add("" + (char)('a' + i));
            }
        }
        return ans;
    }
}
// @lc code=end

