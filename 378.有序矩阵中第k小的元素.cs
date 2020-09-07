/*
 * @lc app=leetcode.cn id=378 lang=csharp
 *
 * [378] 有序矩阵中第K小的元素
 *
 * https://leetcode-cn.com/problems/kth-smallest-element-in-a-sorted-matrix/description/
 *
 * algorithms
 * Medium (59.18%)
 * Likes:    227
 * Dislikes: 0
 * Total Accepted:    21.5K
 * Total Submissions: 36.3K
 * Testcase Example:  '[[1,5,9],[10,11,13],[12,13,15]]\n8'
 *
 * 给定一个 n x n 矩阵，其中每行和每列元素均按升序排序，找到矩阵中第k小的元素。
 * 请注意，它是排序后的第 k 小元素，而不是第 k 个不同的元素。
 * 
 * 
 * 
 * 示例:
 * 
 * matrix = [
 * ⁠  [ 1,  5,  9],
 * ⁠  [10, 11, 13],
 * ⁠  [12, 13, 15]
 * ],
 * k = 8,
 * 
 * 返回 13。
 * 
 * 
 * 
 * 
 * 提示：
 * 你可以假设 k 的值永远是有效的, 1 ≤ k ≤ n^2 。
 * 
 */

// @lc code=start
public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int row = matrix.Length;
        int col= matrix[0].Length;
        int left = matrix[0][0];
        int right = matrix[row - 1][col - 1];
        while(left <= right) {
            int mid  = left + (right - left) / 2;
            int count = FindNotBigThanMid(matrix, mid);
            if(count < k) {
                left = mid + 1;
            }
            else right = mid - 1;
        }
        return left;
    }
    private int FindNotBigThanMid(int[][] matrix, int mid) {
        int row = matrix.Length;
        int col= matrix[0].Length;
        int i = row - 1;
        int j = 0;
        int count = 0;
        while(i >=0 && j < row) {
            if(matrix[i][j] <= mid) {
                count += i + 1;
                j++;
            }
            else {
                i--;
            }
        }
        return count;
    }
}
// @lc code=end

