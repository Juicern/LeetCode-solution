using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=542 lang=csharp
 *
 * [542] 01 矩阵
 *
 * https://leetcode-cn.com/problems/01-matrix/description/
 *
 * algorithms
 * Medium (44.70%)
 * Likes:    273
 * Dislikes: 0
 * Total Accepted:    33.6K
 * Total Submissions: 75.1K
 * Testcase Example:  '[[0,0,0],[0,1,0],[0,0,0]]'
 *
 * 给定一个由 0 和 1 组成的矩阵，找出每个元素到最近的 0 的距离。
 * 
 * 两个相邻元素间的距离为 1 。
 * 
 * 示例 1: 
 * 输入:
 * 
 * 
 * 0 0 0
 * 0 1 0
 * 0 0 0
 * 
 * 
 * 输出:
 * 
 * 
 * 0 0 0
 * 0 1 0
 * 0 0 0
 * 
 * 
 * 示例 2: 
 * 输入:
 * 
 * 
 * 0 0 0
 * 0 1 0
 * 1 1 1
 * 
 * 
 * 输出:
 * 
 * 
 * 0 0 0
 * 0 1 0
 * 1 2 1
 * 
 * 
 * 注意:
 * 
 * 
 * 给定矩阵的元素个数不超过 10000。
 * 给定矩阵中至少有一个元素是 0。
 * 矩阵中的元素只在四个方向上相邻: 上、下、左、右。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        int n = matrix.Length;
        int m = matrix[0].Length;
        for(int i=0;i<n;i++) {
            for(int j =0;j<m;j++) {
                if(matrix[i][j] != 0) {
                    var queue =new Queue<int[]>();
                    var searchVisited = new bool[n, m];
                    queue.Enqueue(new int[]{i, j});
                    int count = -1;
                    while(queue.Count > 0) {
                        int size = queue.Count;
                        for(int k=0;k<size;k++) {
                            var point = queue.Dequeue();
                            if(point[0] < 0 || point[0] >= n || point[1] < 0 || point[1] >= m || searchVisited[point[0], point[1]]) {
                                continue;
                            }
                            if(matrix[point[0]][point[1]] == 0) {
                                queue.Clear();
                                break;
                            }
                            searchVisited[point[0], point[1]] = true;
                            queue.Enqueue(new int[]{point[0] + 1, point[1]});
                            queue.Enqueue(new int[]{point[0], point[1] +1});
                            queue.Enqueue(new int[]{point[0], point[1] -1});
                            queue.Enqueue(new int[]{point[0] - 1, point[1]});
                        }
                        count++;
                    }
                    matrix[i][j] = count;
                }
            }
        }   
        return matrix;
    }
}
// @lc code=end

