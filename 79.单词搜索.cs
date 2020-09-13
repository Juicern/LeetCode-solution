/*
 * @lc app=leetcode.cn id=79 lang=csharp
 *
 * [79] 单词搜索
 *
 * https://leetcode-cn.com/problems/word-search/description/
 *
 * algorithms
 * Medium (42.38%)
 * Likes:    592
 * Dislikes: 0
 * Total Accepted:    96K
 * Total Submissions: 222.7K
 * Testcase Example:  '[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]\n"ABCCED"'
 *
 * 给定一个二维网格和一个单词，找出该单词是否存在于网格中。
 * 
 * 单词必须按照字母顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
 * 
 * 
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
 * 给定 word = "ABCCED", 返回 true
 * 给定 word = "SEE", 返回 true
 * 给定 word = "ABCB", 返回 false
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * board 和 word 中只包含大写和小写英文字母。
 * 1 <= board.length <= 200
 * 1 <= board[i].length <= 200
 * 1 <= word.length <= 10^3
 * 
 * 
 */

// @lc code=start
public class Solution
{
    char[][] board;
    int n;
    int m;
    public bool Exist(char[][] board, string word)
    {
        this.board = board;
        this.n = board.Length;
        this.m = board[0].Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (Dfs(word, 0, i, j, new bool[n, m])) return true;
            }
        }
        return false;
    }
    private bool Dfs(string word, int start, int row, int col, bool[,] visited)
    {
        if (word.Length == start) return true;
        if (row < 0 || row >= n || col < 0 || col >= m || visited[row, col] || board[row][col] != word[start]) return false;
        visited[row, col] = true;
        if (Dfs(word, start + 1, row + 1, col, visited) || Dfs(word, start + 1, row, col + 1, visited) || Dfs(word, start + 1, row - 1, col, visited) || Dfs(word, start + 1, row, col - 1, visited)) return true;
        visited[row, col] = false;
        return false;
    }
}
// @lc code=end

