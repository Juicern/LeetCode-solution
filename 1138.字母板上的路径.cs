using System.Text;
/*
 * @lc app=leetcode.cn id=1138 lang=csharp
 *
 * [1138] 字母板上的路径
 *
 * https://leetcode-cn.com/problems/alphabet-board-path/description/
 *
 * algorithms
 * Medium (40.24%)
 * Likes:    14
 * Dislikes: 0
 * Total Accepted:    3.3K
 * Total Submissions: 8.3K
 * Testcase Example:  '"leet"'
 *
 * 我们从一块字母板上的位置 (0, 0) 出发，该坐标对应的字符为 board[0][0]。
 * 
 * 在本题里，字母板为board = ["abcde", "fghij", "klmno", "pqrst", "uvwxy", "z"]，如下所示。
 * 
 * 
 * 
 * 我们可以按下面的指令规则行动：
 * 
 * 
 * 如果方格存在，'U' 意味着将我们的位置上移一行；
 * 如果方格存在，'D' 意味着将我们的位置下移一行；
 * 如果方格存在，'L' 意味着将我们的位置左移一列；
 * 如果方格存在，'R' 意味着将我们的位置右移一列；
 * '!' 会把在我们当前位置 (r, c) 的字符 board[r][c] 添加到答案中。
 * 
 * 
 * （注意，字母板上只存在有字母的位置。）
 * 
 * 返回指令序列，用最小的行动次数让答案和目标 target 相同。你可以返回任何达成目标的路径。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：target = "leet"
 * 输出："DDR!UURRR!!DDD!"
 * 
 * 
 * 示例 2：
 * 
 * 输入：target = "code"
 * 输出："RR!DDRR!UUL!R!"
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= target.length <= 100
 * target 仅含有小写英文字母。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string AlphabetBoardPath(string target) {
        var ans = new StringBuilder();
        int row_pre = 0;
        int col_pre = 0;
        for(int i=0;i<target.Length;i++) {
            int row_cur = (target[i] - 'a') / 5;
            int col_cur = (target[i] - 'a') % 5;
            if(row_pre==5 && col_pre==0) {
                for(int step=0;step<row_pre - row_cur;step++) {
                    ans.Append("U");
                }
                for(int step = 0;step< col_cur - col_pre;step++) {
                    ans.Append("R");
                }
            }
            else if(row_cur==5 && col_cur==0) {
                for(int step = 0;step< col_pre - col_cur;step++) {
                    ans.Append("L");
                }
                for(int step=0;step<row_cur - row_pre;step++) {
                    ans.Append("D");
                }
            }
            else {
                if(row_cur > row_pre) {
                    for(int step=0;step<row_cur - row_pre;step++) {
                        ans.Append("D");
                    }
                }
                else {
                    for(int step=0;step<row_pre - row_cur;step++) {
                        ans.Append("U");
                    }
                }
                if(col_cur > col_pre) {
                    for(int step = 0;step< col_cur - col_pre;step++) {
                        ans.Append("R");
                    }
                }
                else {
                    for(int step = 0;step< col_pre - col_cur;step++) {
                        ans.Append("L");
                    }
                }
            }
            ans.Append("!");
            row_pre = row_cur;
            col_pre= col_cur;
        }
        return ans.ToString();
    }
}
// @lc code=end

