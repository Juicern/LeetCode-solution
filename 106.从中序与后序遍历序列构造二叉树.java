import java.util.*;
/*
 * @lc app=leetcode.cn id=106 lang=java
 *
 * [106] 从中序与后序遍历序列构造二叉树
 *
 * https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
 *
 * algorithms
 * Medium (66.33%)
 * Likes:    166
 * Dislikes: 0
 * Total Accepted:    27K
 * Total Submissions: 40.2K
 * Testcase Example:  '[9,3,15,20,7]\n[9,15,7,20,3]'
 *
 * 根据一棵树的中序遍历与后序遍历构造二叉树。
 * 
 * 注意:
 * 你可以假设树中没有重复的元素。
 * 
 * 例如，给出
 * 
 * 中序遍历 inorder = [9,3,15,20,7]
 * 后序遍历 postorder = [9,15,7,20,3]
 * 
 * 返回如下的二叉树：
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
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
    public int[] inorder;
    public int[] postorder;
    public int post_index;
    public Map<Integer, Integer> idx_map = new HashMap<>();

    public TreeNode helper(int in_left, int in_right){
        if(in_left==in_right) return null;
        int root_val = postorder[post_index];
        TreeNode root = new TreeNode(root_val);
        int root_index = idx_map.get(root_val);
        post_index--;
        root.right = helper(root_index+1, in_right);
        root.left = helper(in_left, root_index);
        return root;
    }

    public TreeNode buildTree(int[] inorder, int[] postorder) {
        this.inorder = inorder;
        this.postorder = postorder;
        int index = 0;
        for(int val : inorder) idx_map.put(val, index++);
        post_index = inorder.length-1;
        return helper(0, inorder.length);
    }
}
// @lc code=end

