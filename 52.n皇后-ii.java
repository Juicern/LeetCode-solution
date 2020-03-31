/*
 * @lc app=leetcode.cn id=52 lang=java
 *
 * [52] N皇后 II
 *
 * https://leetcode-cn.com/problems/n-queens-ii/description/
 *
 * algorithms
 * Hard (77.21%)
 * Likes:    101
 * Dislikes: 0
 * Total Accepted:    17.5K
 * Total Submissions: 22.5K
 * Testcase Example:  '4'
 *
 * n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
 * 
 * 
 * 
 * 上图为 8 皇后问题的一种解法。
 * 
 * 给定一个整数 n，返回 n 皇后不同的解决方案的数量。
 * 
 * 示例:
 * 
 * 输入: 4
 * 输出: 2
 * 解释: 4 皇后问题存在如下两个不同的解法。
 * [
 * [".Q..",  // 解法 1
 * "...Q",
 * "Q...",
 * "..Q."],
 * 
 * ["..Q.",  // 解法 2
 * "Q...",
 * "...Q",
 * ".Q.."]
 * ]
 * 
 * 
 */

// @lc code=start
class Solution {
    int ans = 0;
    public int totalNQueens(int n) {
        char[][] board = new char[n][n];
        for (char[] chars : board) Arrays.fill(chars, '.');
        backtrace(board, 0);
        return ans;
    }
    
    private void backtrace(char[][] board, int row){
        if(board.length == row){
            ans++;
            return;
        }
        int n = board[row].length;
        for(int i=0;i<n;i++){
            if(!isvalid(board, row, i)) continue;
            board[row][i] = 'Q';
            backtrace(board, row+1);
            board[row][i] = '.';
        }
    }

    private boolean isvalid(char[][] board, int row, int col){
        int rows = board.length;
        //判断列
        for (char[] chars : board) if (chars[col] == 'Q') return false;
        //判断左上
        for (int i = row - 1, j = col + 1; i >= 0 && j < rows; i--, j++) {
            if (board[i][j] == 'Q') return false;
        }
        //判断右上
        for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--) {
            if (board[i][j] == 'Q') return false;
        }
        return true;
    }
}
// @lc code=end

