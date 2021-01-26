/*
 * @lc app=leetcode.cn id=1128 lang=csharp
 *
 * [1128] 等价多米诺骨牌对的数量
 *
 * https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/description/
 *
 * algorithms
 * Easy (47.05%)
 * Likes:    76
 * Dislikes: 0
 * Total Accepted:    19.6K
 * Total Submissions: 37K
 * Testcase Example:  '[[1,2],[2,1],[3,4],[5,6]]'
 *
 * 给你一个由一些多米诺骨牌组成的列表 dominoes。
 * 
 * 如果其中某一张多米诺骨牌可以通过旋转 0 度或 180 度得到另一张多米诺骨牌，我们就认为这两张牌是等价的。
 * 
 * 形式上，dominoes[i] = [a, b] 和 dominoes[j] = [c, d] 等价的前提是 a==c 且 b==d，或是 a==d 且
 * b==c。
 * 
 * 在 0 <= i < j < dominoes.length 的前提下，找出满足 dominoes[i] 和 dominoes[j] 等价的骨牌对
 * (i, j) 的数量。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：dominoes = [[1,2],[2,1],[3,4],[5,6]]
 * 输出：1
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= dominoes.length <= 40000
 * 1 <= dominoes[i][j] <= 9
 * 
 * 
 */
// @lc code=start
public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var dict = new Dictionary<(int, int), int>();
        foreach (var domino in dominoes)
        {
            if (dict.ContainsKey((domino[0], domino[1])))
            {
                dict[(domino[0], domino[1])]++;
            }
            else if (dict.ContainsKey((domino[1], domino[0])))
            {
                dict[(domino[1], domino[0])]++;
            }
            else
            {
                dict.Add((domino[0], domino[1]), 1);
            }
        }
        int ans = 0;
        foreach (var value in dict.Values)
        {
            ans += value * (value - 1) / 2;
        }
        return ans;
    }
}
// @lc code=end
