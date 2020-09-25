using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=106 lang=csharp
 *
 * [106] 从中序与后序遍历序列构造二叉树
 *
 * https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
 *
 * algorithms
 * Medium (69.44%)
 * Likes:    337
 * Dislikes: 0
 * Total Accepted:    61.6K
 * Total Submissions: 87.4K
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
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    int post_index;
    int[] postorder;
    int[] inorder;
    Dictionary<int, int> dic = new Dictionary<int, int>();
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        this.postorder = postorder;
        this.inorder = inorder;
        post_index = postorder.Length  - 1;
        int index = 0;
        foreach(var val in inorder) {
            dic.Add(val, index++);
        }
        return Helper(0, inorder.Length - 1);
    }
    public TreeNode Helper(int left, int right) {
        if(left > right) return null;
        int root_val = postorder[post_index];
        var root = new TreeNode(root_val);
        int index = dic[root_val];
        post_index--;
        root.right = Helper(index + 1, right);
        root.left = Helper(left, index - 1);
        return root;
    }
}
// @lc code=end

