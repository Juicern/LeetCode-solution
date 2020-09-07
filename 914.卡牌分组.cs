using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=914 lang=csharp
 *
 * [914] 卡牌分组
 *
 * https://leetcode-cn.com/problems/x-of-a-kind-in-a-deck-of-cards/description/
 *
 * algorithms
 * Easy (39.31%)
 * Likes:    156
 * Dislikes: 0
 * Total Accepted:    38.2K
 * Total Submissions: 97.1K
 * Testcase Example:  '[1,2,3,4,4,3,2,1]'
 *
 * 给定一副牌，每张牌上都写着一个整数。
 * 
 * 此时，你需要选定一个数字 X，使我们可以将整副牌按下述规则分成 1 组或更多组：
 * 
 * 
 * 每组都有 X 张牌。
 * 组内所有的牌上都写着相同的整数。
 * 
 * 
 * 仅当你可选的 X >= 2 时返回 true。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[1,2,3,4,4,3,2,1]
 * 输出：true
 * 解释：可行的分组是 [1,1]，[2,2]，[3,3]，[4,4]
 * 
 * 
 * 示例 2：
 * 
 * 输入：[1,1,1,2,2,2,3,3]
 * 输出：false
 * 解释：没有满足要求的分组。
 * 
 * 
 * 示例 3：
 * 
 * 输入：[1]
 * 输出：false
 * 解释：没有满足要求的分组。
 * 
 * 
 * 示例 4：
 * 
 * 输入：[1,1]
 * 输出：true
 * 解释：可行的分组是 [1,1]
 * 
 * 
 * 示例 5：
 * 
 * 输入：[1,1,2,2,2,2]
 * 输出：true
 * 解释：可行的分组是 [1,1]，[2,2]，[2,2]
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= deck.length <= 10000
 * 0 <= deck[i] < 10000
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int gcd(int m, int n)
    {
        return n == 0 ? m : gcd(n, m % n);
    }
    public bool HasGroupsSizeX(int[] deck)
    {
        var dic = new Dictionary<int, int>();
        foreach (var num in deck)
        {
            if (!dic.ContainsKey(num)) dic.Add(num, 1);
            else dic[num]++;
        }
        int k = 0;
        foreach (var key in dic.Keys)
        {
            if (k == 0) k = dic[key];
            else
            {
                k = gcd(k, dic[key]);
                if (k < 2) return false;
            }
        }
        return k >= 2;
    }
}
// @lc code=end

