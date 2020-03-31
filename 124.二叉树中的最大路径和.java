/*
 * @lc app=leetcode.cn id=124 lang=java
 *
 * [124] 二叉树中的最大路径和
 *
 * https://leetcode-cn.com/problems/binary-tree-maximum-path-sum/description/
 *
 * algorithms
 * Hard (38.79%)
 * Likes:    346
 * Dislikes: 0
 * Total Accepted:    28.4K
 * Total Submissions: 71.3K
 * Testcase Example:  '[1,2,3]'
 *
 * 给定一个非空二叉树，返回其最大路径和。
 * 
 * 本题中，路径被定义为一条从树中任意节点出发，达到任意节点的序列。该路径至少包含一个节点，且不一定经过根节点。
 * 
 * 示例 1:
 * 
 * 输入: [1,2,3]
 * 
 * ⁠      1
 * ⁠     / \
 * ⁠    2   3
 * 
 * 输出: 6
 * 
 * 
 * 示例 2:
 * 
 * 输入: [-10,9,20,null,null,15,7]
 * 
 * -10
 * / \
 * 9  20
 * /  \
 * 15   7
 * 
 * 输出: 42
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    int max_path = Integer.MIN_VALUE;
    public int max_gain(TreeNode root){
        if(root==null) return 0;
        int left_path = Integer.max(max_gain(root.left), 0);
        int right_path = Integer.max(max_gain(root.right), 0);
        int new_path = root.val + left_path + right_path;
        max_path = Integer.max(max_path, new_path);
        return root.val + Integer.max(left_path, right_path);
    } 
    public int maxPathSum(TreeNode root) {
        max_gain(root);
        return max_path;
    }
}
// @lc code=end

