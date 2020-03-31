import java.util.*;

/*
 * @lc app=leetcode.cn id=107 lang=java
 *
 * [107] 二叉树的层次遍历 II
 *
 * https://leetcode-cn.com/problems/binary-tree-level-order-traversal-ii/description/
 *
 * algorithms
 * Easy (63.77%)
 * Likes:    199
 * Dislikes: 0
 * Total Accepted:    46.1K
 * Total Submissions: 71.4K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其节点值自底向上的层次遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）
 * 
 * 例如：
 * 给定二叉树 [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回其自底向上的层次遍历为：
 * 
 * [
 * ⁠ [15,7],
 * ⁠ [9,20],
 * ⁠ [3]
 * ]
 * 
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
    List<List<Integer>> ans = new ArrayList<>();
    
    public void levels(TreeNode root, int level){
        if(ans.size()==level) ans.add(0, new ArrayList<Integer>());
        ans.get(ans.size()-level-1).add(root.val);
        if(root.left!=null) levels(root.left, level+1);
        if(root.right!=null) levels(root.right, level+1);
        return;
    }
    
    public List<List<Integer>> levelOrderBottom(TreeNode root) {
        if(root==null) return ans;
        levels(root, 0);
        return ans;
    }
}
// @lc code=end

