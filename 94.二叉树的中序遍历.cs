/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-inorder-traversal/description/
 *
 * algorithms
 * Medium (72.66%)
 * Likes:    671
 * Dislikes: 0
 * Total Accepted:    235.6K
 * Total Submissions: 323.6K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的中序 遍历。
 * 
 * 示例:
 * 
 * 输入: [1,null,2,3]
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  3
 * 
 * 输出: [1,3,2]
 * 
 * 进阶: 递归算法很简单，你可以通过迭代算法完成吗？
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
    List<int> ans = new List<int>();
    public IList<int> InorderTraversal(TreeNode root) {
        Helper(root);
        return ans;
    }
    private void Helper(TreeNode root) {
        if(root == null) return;
        Helper(root.left);
        ans.Add(root.val);
        Helper(root.right);
    }
}
// @lc code=end

