/*
 * @lc app=leetcode.cn id=782 lang=csharp
 *
 * [782] 变为棋盘
 *
 * https://leetcode-cn.com/problems/transform-to-chessboard/description/
 *
 * algorithms
 * Hard (40.95%)
 * Likes:    26
 * Dislikes: 0
 * Total Accepted:    952
 * Total Submissions: 2.3K
 * Testcase Example:  '[[0,1,1,0],[0,1,1,0],[1,0,0,1],[1,0,0,1]]'
 *
 * 一个 N x N的 board 仅由 0 和 1 组成 。每次移动，你能任意交换两列或是两行的位置。
 * 
 * 输出将这个矩阵变为 “棋盘” 所需的最小移动次数。“棋盘” 是指任意一格的上下左右四个方向的值均与本身不同的矩阵。如果不存在可行的变换，输出 -1。
 * 
 * 示例:
 * 输入: board = [[0,1,1,0],[0,1,1,0],[1,0,0,1],[1,0,0,1]]
 * 输出: 2
 * 解释:
 * 一种可行的变换方式如下，从左到右：
 * 
 * 0110     1010     1010
 * 0110 --> 1010 --> 0101
 * 1001     0101     1010
 * 1001     0101     0101
 * 
 * 第一次移动交换了第一列和第二列。
 * 第二次移动交换了第二行和第三行。
 * 
 * 
 * 输入: board = [[0, 1], [1, 0]]
 * 输出: 0
 * 解释:
 * 注意左上角的格值为0时也是合法的棋盘，如：
 * 
 * 01
 * 10
 * 
 * 也是合法的棋盘.
 * 
 * 输入: board = [[1, 0], [1, 0]]
 * 输出: -1
 * 解释:
 * 任意的变换都不能使这个输入变为合法的棋盘。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * board 是方阵，且行列数的范围是[2, 30]。
 * board[i][j] 将只包含 0或 1。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int MovesToChessboard(int[][] board) {
        if(Check(board)) {
            var row = board[0];
            var col = new int[board.Length];
            for ( int i = 0; i < board.Length; i++) {
                col[i] = board[i][0];
            }
            return Find(row) + Find(col);
        }
        return -1;
    }
    private bool IsSame(int[] a, int[] b) {
        for ( int i = 0; i<a.Length; i++) {
            if(a[i] != b[i]) return false;
        }
        return true;
    }
    private bool IsOpposite(int[] a, int[] b) {
        for (int i = 0; i < a.Length; i++) {
            if (a[i] + b[i] != 1) return false; 
        }
        return true;
    }
    private bool Check(int[][] board) {
        var first  = board[0];
        int cntSame = 1;
        int cntOpposite = 0;
        //判断行
        for (int i = 1; i<board.Length; i++) {
            if (IsSame(first, board[i])) {
                cntSame++;
            }
            else if(IsOpposite(first, board[i])) {
                cntOpposite++;
            }
            else return false;
        }
        //判断列
        if (cntSame == cntOpposite || cntSame == cntOpposite + 1 || cntSame == cntOpposite - 1) {
            int cnt0 = 0;
            int cnt1 = 0;
            foreach(var num in first) {
                if (num == 0) cnt0++;
                else cnt1++;
            }
            if(cnt0 == cnt1 || cnt0 == cnt1 + 1 || cnt0 == cnt1 - 1) {
                return true;
            }
            else return false;
        }
        else return false;
    }
    private int Find(int[] tmp) {
        int start = 1;
        int error = 0;
        foreach(var num in tmp) {
            if (num != start) error++;
            start = 1- start;
        }
        if (tmp.Length % 2 == 0) {
            return Math.Min(tmp.Length - error, error) >> 1;
        }
        else {
            if(error % 2 == 0) return error >> 1;
            else return (tmp.Length - error) >> 1;
        }
    }
}
// @lc code=end

