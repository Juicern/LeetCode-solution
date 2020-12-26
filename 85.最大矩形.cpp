/*
 * @lc app=leetcode.cn id=85 lang=cpp
 *
 * [85] 最大矩形
 *
 * https://leetcode-cn.com/problems/maximal-rectangle/description/
 *
 * algorithms
 * Hard (48.80%)
 * Likes:    718
 * Dislikes: 0
 * Total Accepted:    54K
 * Total Submissions: 108.3K
 * Testcase Example:  '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]'
 *
 * 给定一个仅包含 0 和 1 、大小为 rows x cols 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：matrix =
 * [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
 * 输出：6
 * 解释：最大矩形如上图所示。
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：matrix = []
 * 输出：0
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入：matrix = [["0"]]
 * 输出：0
 * 
 * 
 * 示例 4：
 * 
 * 
 * 输入：matrix = [["1"]]
 * 输出：1
 * 
 * 
 * 示例 5：
 * 
 * 
 * 输入：matrix = [["0","0"]]
 * 输出：0
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * rows == matrix.length
 * cols == matrix[0].length
 * 0 
 * matrix[i][j] 为 '0' 或 '1'
 * 
 * 
 */

// @lc code=start
#include <vector>
using namespace std;
class Solution
{
public:
    int maximalRectangle(vector<vector<char>> &matrix)
    {
        if (matrix.empty())
            return 0;
        int rows = matrix.size(), cols = matrix[0].size();

        int res = 0;
        vector<vector<int>> vec(rows, vector<int>(cols));
        for (int row = 0; row < rows; ++row)
        {
            for (int col = 0; col < cols; ++col)
            {
                if (matrix[row][col] == '1')
                    vec[row][col] = (col == 0 ? 0 : vec[row][col - 1]) + 1;

                int width = vec[row][col];
                for (int k = row; k >= 0; --k)
                {
                    if (vec[k][col] == 0)
                        break; // 剪枝
                    width = min(width, vec[k][col]);
                    res = max(res, width * (row - k + 1));
                }
            }
        }
        return res;
    }
};
// @lc code=end
