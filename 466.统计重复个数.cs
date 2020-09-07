/*
 * @lc app=leetcode.cn id=466 lang=csharp
 *
 * [466] 统计重复个数
 *
 * https://leetcode-cn.com/problems/count-the-repetitions/description/
 *
 * algorithms
 * Hard (37.68%)
 * Likes:    109
 * Dislikes: 0
 * Total Accepted:    10K
 * Total Submissions: 26.5K
 * Testcase Example:  '"acb"\n4\n"ab"\n2'
 *
 * 由 n 个连接的字符串 s 组成字符串 S，记作 S = [s,n]。例如，["abc",3]=“abcabcabc”。
 * 
 * 如果我们可以从 s2 中删除某些字符使其变为 s1，则称字符串 s1 可以从字符串 s2 获得。例如，根据定义，"abc" 可以从 “abdbec”
 * 获得，但不能从 “acbbe” 获得。
 * 
 * 现在给你两个非空字符串 s1 和 s2（每个最多 100 个字符长）和两个整数 0 ≤ n1 ≤ 10^6 和 1 ≤ n2 ≤
 * 10^6。现在考虑字符串 S1 和 S2，其中 S1=[s1,n1] 、S2=[s2,n2] 。
 * 
 * 请你找出一个可以满足使[S2,M] 从 S1 获得的最大整数 M 。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：
 * s1 ="acb",n1 = 4
 * s2 ="ab",n2 = 2
 * 
 * 返回：
 * 2
 * 
 * 
 */

// @lc code=start 
public class Solution
{
    public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
    {
        int i = 0;
        int j = 0;
        int fullS1Length = n1 * s1.Length;
        IDictionary<(int i, int j), (int i, int j)> repeatingMap = new Dictionary<(int i, int j), (int i, int j)>();
        while (i < fullS1Length)
        {
            var modI = i % s1.Length;
            var modJ = j % s2.Length;

            if (s1[modI] == s2[modJ])
            {

                if (repeatingMap.ContainsKey((modI, modJ)))
                {
                    (int i, int j) prevMatch = repeatingMap[(modI, modJ)];
                    var l1 = i - prevMatch.i;
                    var l2 = j - prevMatch.j;
                    var remains = (fullS1Length - i) / l1;
                    i += l1 * remains;
                    j += l2 * remains;

                    if (i >= fullS1Length)
                    {
                        return j / s2.Length / n2;
                    }
                }
                else
                {
                    repeatingMap[(modI, modJ)] = (i, j);
                }

                j++;
            }

            i++;
        }

        return j / s2.Length / n2;
    }
}
// @lc code=end

