using System;
/*
 * @lc app=leetcode.cn id=1033 lang=csharp
 *
 * [1033] 移动石子直到连续
 *
 * https://leetcode-cn.com/problems/moving-stones-until-consecutive/description/
 *
 * algorithms
 * Easy (38.13%)
 * Likes:    27
 * Dislikes: 0
 * Total Accepted:    7.6K
 * Total Submissions: 19.9K
 * Testcase Example:  '1\n2\n5'
 *
 * 三枚石子放置在数轴上，位置分别为 a，b，c。
 * 
 * 每一回合，我们假设这三枚石子当前分别位于位置 x, y, z 且 x < y < z。从位置 x 或者是位置 z
 * 拿起一枚石子，并将该石子移动到某一整数位置 k 处，其中 x < k < z 且 k != y。
 * 
 * 当你无法进行任何移动时，即，这些石子的位置连续时，游戏结束。
 * 
 * 要使游戏结束，你可以执行的最小和最大移动次数分别是多少？ 以长度为 2 的数组形式返回答案：answer = [minimum_moves,
 * maximum_moves]
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：a = 1, b = 2, c = 5
 * 输出：[1, 2]
 * 解释：将石子从 5 移动到 4 再移动到 3，或者我们可以直接将石子移动到 3。
 * 
 * 
 * 示例 2：
 * 
 * 输入：a = 4, b = 3, c = 2
 * 输出：[0, 0]
 * 解释：我们无法进行任何移动。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= a <= 100
 * 1 <= b <= 100
 * 1 <= c <= 100
 * a != b, b != c, c != a
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int[] NumMovesStones(int a, int b, int c)
    {
        var arr = new[] { a, b, c };
        Array.Sort(arr);

        int min = arr[0],
            mid = arr[1],
            max = arr[2];

        if (max - min == 2)
        {
            return new[] { 0, 0 };
        }

        if (max - mid == 1 || mid - min == 1)
        {
            return new[] { 1, Math.Max(max - mid - 1, mid - min - 1) };
        }
        return new[] { Math.Min(2, Math.Min(max - mid - 1, mid - min - 1)), max - min - 2 };
    }
}

// @lc code=end

