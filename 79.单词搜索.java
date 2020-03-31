/*
 * @lc app=leetcode.cn id=79 lang=java
 *
 * [79] 单词搜索
 *
 * https://leetcode-cn.com/problems/word-search/description/
 *
 * algorithms
 * Medium (40.11%)
 * Likes:    337
 * Dislikes: 0
 * Total Accepted:    42.8K
 * Total Submissions: 104.7K
 * Testcase Example:  '[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]\n"ABCCED"'
 *
 * 给定一个二维网格和一个单词，找出该单词是否存在于网格中。
 * 
 * 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
 * 
 * 示例:
 * 
 * board =
 * [
 * ⁠ ['A','B','C','E'],
 * ⁠ ['S','F','C','S'],
 * ⁠ ['A','D','E','E']
 * ]
 * 
 * 给定 word = "ABCCED", 返回 true.
 * 给定 word = "SEE", 返回 true.
 * 给定 word = "ABCB", 返回 false.
 * 
 */

// @lc code=start
class Solution {
    public static int max_row;
    public static int max_col;
    public static String word;
    public static boolean[][] mark;

    public boolean isConnect(int start, char[][] board, int row, int col){
        if(start==word.length()) return true;
        if(row>=max_row || col>=max_col || row<0 || col<0) return false;
        if(mark[row][col]) return false;
        if(board[row][col]==word.charAt(start)){
            mark[row][col] = true;
            if(isConnect(start+1, board, row-1, col)) return true;
            if(isConnect(start+1, board, row+1, col)) return true;
            if(isConnect(start+1, board, row, col-1)) return true;
            if(isConnect(start+1, board, row, col+1)) return true;
            mark[row][col] = false;
        }
        return false;
    }

    public boolean exist(char[][] board, String word) {
        this.word = word;
        if(board.length==0 || word.length()==0) return false;
        max_row = board.length;
        max_col = board[0].length;
        mark = new boolean[max_row][max_col];
        for(int i=0;i<max_row;i++){
            for(int j=0;j<max_col;j++){
                if(isConnect(0, board, i ,j)) return true;
            }
        } 
        return false;
    }
}
// @lc code=end

