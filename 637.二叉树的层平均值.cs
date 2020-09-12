using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=637 lang=csharp
 *
 * [637] 二叉树的层平均值
 *
 * https://leetcode-cn.com/problems/average-of-levels-in-binary-tree/description/
 *
 * algorithms
 * Easy (65.08%)
 * Likes:    174
 * Dislikes: 0
 * Total Accepted:    36.6K
 * Total Submissions: 53.9K
 * Testcase Example:  '[3,9,20,15,7]'
 *
 * 给定一个非空二叉树, 返回一个由每层节点平均值组成的数组。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 输出：[3, 14.5, 11]
 * 解释：
 * 第 0 层的平均值是 3 ,  第1层是 14.5 , 第2层是 11 。因此返回 [3, 14.5, 11] 。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 节点值的范围在32位有符号整数范围内。
 * 
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<double> AverageOfLevels(TreeNode root) {
        List<double> ans = new List<double>();
        if(root == null) return ans;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Any()) {
            int count = queue.Count;
            long sum = 0;
            for(int i = 0; i< count; i++) {
                var node = queue.Dequeue();
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
                sum += node.val;
            }
            ans.Add(sum * 1.0/count);
        }
        return ans;
    }
}
// @lc code=end

