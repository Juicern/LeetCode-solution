/*
 * @lc app=leetcode.cn id=304 lang=java
 *
 * [304] 二维区域和检索 - 矩阵不可变
 *
 * https://leetcode-cn.com/problems/range-sum-query-2d-immutable/description/
 *
 * algorithms
 * Medium (41.85%)
 * Likes:    79
 * Dislikes: 0
 * Total Accepted:    7.7K
 * Total Submissions: 17.6K
 * Testcase Example:  '["NumMatrix","sumRegion","sumRegion","sumRegion"]\n' +
  '[[[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]],[2,1,4,3],[1,1,2,2],[1,2,2,4]]'
 *
 * 给定一个二维矩阵，计算其子矩形范围内元素的总和，该子矩阵的左上角为 (row1, col1) ，右下角为 (row2, col2)。
 * 
 * 
 * 上图子矩阵左上角 (row1, col1) = (2, 1) ，右下角(row2, col2) = (4, 3)，该子矩形内元素的总和为 8。
 * 
 * 示例:
 * 
 * 给定 matrix = [
 * ⁠ [3, 0, 1, 4, 2],
 * ⁠ [5, 6, 3, 2, 1],
 * ⁠ [1, 2, 0, 1, 5],
 * ⁠ [4, 1, 0, 1, 7],
 * ⁠ [1, 0, 3, 0, 5]
 * ]
 * 
 * sumRegion(2, 1, 4, 3) -> 8
 * sumRegion(1, 1, 2, 2) -> 11
 * sumRegion(1, 2, 2, 4) -> 12
 * 
 * 
 * 说明:
 * 
 * 
 * 你可以假设矩阵不可变。
 * 会多次调用 sumRegion 方法。
 * 你可以假设 row1 ≤ row2 且 col1 ≤ col2。
 * 
 * 
 */

// @lc code=start
class NumMatrix {
    private int[][] sumMatrix;
    public NumMatrix(int[][] matrix) {
        int m = matrix.length;
        int n = 0;
        if(m>0){ 
            n = matrix[0].length;
            sumMatrix = new int[m][n];
            sumMatrix[0][0] = matrix[0][0];
            for(int i=1;i<m;i++) sumMatrix[i][0] = sumMatrix[i-1][0] + matrix[i][0];
            for(int i=1;i<n;i++) sumMatrix[0][i] = sumMatrix[0][i-1] + matrix[0][i];
            for(int i=1;i<m;i++){
                for(int j=1;j<n;j++){
                    sumMatrix[i][j] = sumMatrix[i-1][j] + sumMatrix[i][j-1] - sumMatrix[i-1][j-1] + matrix[i][j];
                }
            }
        }
    }
    
    public int sumRegion(int row1, int col1, int row2, int col2) {
        if(row1==0 && col1==0) return sumMatrix[row2][col2];
        if(row1==0) return sumMatrix[row2][col2] - sumMatrix[row2][col1-1];
        if(col1==0) return sumMatrix[row2][col2] -sumMatrix[row1-1][col2];
        return sumMatrix[row2][col2] - sumMatrix[row2][col1-1] - sumMatrix[row1-1][col2] + sumMatrix[row1-1][col1-1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.sumRegion(row1,col1,row2,col2);
 */
// @lc code=end

