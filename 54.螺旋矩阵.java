import java.util.ArrayList;
import java.util.List;

/*
 * @lc app=leetcode.cn id=54 lang=java
 *
 * [54] 螺旋矩阵
 *
 * https://leetcode-cn.com/problems/spiral-matrix/description/
 *
 * algorithms
 * Medium (38.30%)
 * Likes:    316
 * Dislikes: 0
 * Total Accepted:    44.9K
 * Total Submissions: 115.2K
 * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
 *
 * 给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。
 * 
 * 示例 1:
 * 
 * 输入:
 * [
 * ⁠[ 1, 2, 3 ],
 * ⁠[ 4, 5, 6 ],
 * ⁠[ 7, 8, 9 ]
 * ]
 * 输出: [1,2,3,6,9,8,7,4,5]
 * 
 * 
 * 示例 2:
 * 
 * 输入:
 * [
 * ⁠ [1, 2, 3, 4],
 * ⁠ [5, 6, 7, 8],
 * ⁠ [9,10,11,12]
 * ]
 * 输出: [1,2,3,4,8,12,11,10,9,5,6,7]
 * 
 * 
 */

// @lc code=start
class Solution {
    public List<Integer> spiralOrder(int[][] matrix) {
        List<Integer> ans = new ArrayList<>();
        int row = matrix.length;
        if(row==0) return ans;
        int col = matrix[0].length;
        for(int i=0;i<Integer.min(row, col)/2;i++){
            //right
            for(int j=i;j<col-i-1;j++) ans.add(matrix[i][j]);
            //down
            for(int j=i;j<row-i-1;j++) ans.add(matrix[j][col-1-i]);
            //left
            if(row-1-i == i || i == col-1-i) break;
            for(int j=i;j<col-i-1;j++) ans.add(matrix[row-1-i][col-1-j]);
            //up
            for(int j=i;j<row-i-1;j++) ans.add(matrix[row-1-j][i]);
        }
        if((row%2==0 && col%2==0) || (row%2==1 && col%2==0 && row>col) || (row%2==0 && col%2==1 && col>row)) return ans;
        if(row>col){
            for(int i=col/2;i<row-col/2;i++) ans.add(matrix[i][col/2]);
        }
        else{
            for(int i=row/2;i<col-row/2;i++) ans.add(matrix[row/2][i]);
        }
        return ans;
    }
}
// @lc code=end

