using System.Runtime.Serialization.Formatters;
using System.Linq.Expressions;
using System.Text;
using System;
using System.Linq;
/*
 * @lc app=leetcode.cn id=488 lang=csharp
 *
 * [488] 祖玛游戏
 *
 * https://leetcode-cn.com/problems/zuma-game/description/
 *
 * algorithms
 * Hard (41.68%)
 * Likes:    52
 * Dislikes: 0
 * Total Accepted:    1.8K
 * Total Submissions: 4.4K
 * Testcase Example:  '"WRRBBW"\n"RB"'
 *
 * 回忆一下祖玛游戏。现在桌上有一串球，颜色有红色(R)，黄色(Y)，蓝色(B)，绿色(G)，还有白色(W)。 现在你手里也有几个球。
 * 
 * 
 * 每一次，你可以从手里的球选一个，然后把这个球插入到一串球中的某个位置上（包括最左端，最右端）。接着，如果有出现三个或者三个以上颜色相同的球相连的话，就把它们移除掉。重复这一步骤直到桌上所有的球都被移除。
 * 
 * 找到插入并可以移除掉桌上所有球所需的最少的球数。如果不能移除桌上所有的球，输出 -1 。
 * 
 * 
 * 示例:
 * 输入: "WRRBBW", "RB" 
 * 输出: -1 
 * 解释: WRRBBW -> WRR[R]BBW -> WBBW -> WBB[B]W -> WW
 * （翻译者标注：手上球已经用完，桌上还剩两个球无法消除，返回-1）
 * 
 * 输入: "WWRRBBWW", "WRBRW" 
 * 输出: 2 
 * 解释: WWRRBBWW -> WWRR[R]BBWW -> WWBBWW -> WWBB[B]WW -> WWWW -> empty
 * 
 * 输入:"G", "GGGGG" 
 * 输出: 2 
 * 解释: G -> G[G] -> GG[G] -> empty 
 * 
 * 输入: "RBYYBBRRB", "YRBGB" 
 * 输出: 3 
 * 解释: RBYYBBRRB -> RBYY[Y]BBRRB -> RBBBRRB -> RRRB -> B -> B[B] -> BB[B] ->
 * empty 
 * 
 * 
 * 标注:
 * 
 * 
 * 你可以假设桌上一开始的球中，不会有三个及三个以上颜色相同且连着的球。
 * 桌上的球不会超过20个，输入的数据中代表这些球的字符串的名字是 "board" 。
 * 你手中的球不会超过5个，输入的数据中代表这些球的字符串的名字是 "hand"。
 * 输入的两个字符串均为非空字符串，且只包含字符 'R','Y','B','G','W'。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private int result = int.MaxValue;
    private int[] map = new int[26];
    private char[] colors = {'R', 'Y', 'B', 'G', 'W'};
    public int FindMinStep(string board, string hand)
    {
        for(int i = 0;i<hand.Length;i++) {
            map[hand[i] - 'A']++;
        }
        Dfs(new StringBuilder(board), 0);
        return result == int.MaxValue ? -1 : result;
    }
    private void Dfs(StringBuilder board, int step) {
        if(step >= result) {
            return;
        }
        if(board.Length == 0) {
            result = Math.Min(step, result);
            return;
        }
        for(int i = 0;i<board.Length;i++) {
            char c = board[i];
            int j  = i;
            while(j + 1 < board.Length && board[j+1]== c) {
                j++;
            }
            if(j == i && map[c - 'A'] >= 2) {
                var tmp = new StringBuilder(board);
                tmp.Insert(i, c + "" + c);
                map[c - 'A'] -= 2;
                Dfs(Eliminate(tmp), step + 2);
                map[c - 'A'] += 2;
            }
            else if(j == i+1) {
                if(map[c - 'A'] >= 1) {
                    var tmp = new StringBuilder(board);
                    tmp.Insert(i, c);
                    map[c - 'A']--;
                    Dfs(Eliminate(tmp), step + 1);
                    map[c - 'A']++;
                }
                foreach(var color in colors) {
                    if(color == c) {
                        continue;
                    }
                    if(map[color - 'A'] >= 1) {
                        var tmp = new StringBuilder(board);
                        tmp.Insert(i+1, color);
                        map[color - 'A']--;
                        Dfs(Eliminate(tmp), step+1);
                        map[color - 'A']++;
                    }
                }
            }
        }
    }
    private StringBuilder Eliminate(StringBuilder sb) {
        bool flag = true;
        while(flag) {
            flag = false;
            for(int i = 0;i<sb.Length;i++) {
                int j = i + 1;
                while(j < sb.Length && sb[j] == sb[i]) {
                    j++;
                }
                if(j - i >= 3) {
                    sb.Remove(i, j);
                    flag = true;
                }
            }
        }
        return sb;
    }

}
// @lc code=end

