/*
 * @lc app=leetcode.cn id=897 lang=csharp
 *
 * [897] 递增顺序查找树
 *
 * https://leetcode-cn.com/problems/increasing-order-search-tree/description/
 *
 * algorithms
 * Easy (73.29%)
 * Likes:    124
 * Dislikes: 0
 * Total Accepted:    20.2K
 * Total Submissions: 27.5K
 * Testcase Example:  '[5,3,6,2,4,null,8,1,null,null,null,7,9]'
 *
 * 给你一个树，请你 按中序遍历 重新排列树，使树中最左边的结点现在是树的根，并且每个结点没有左子结点，只有一个右子结点。
 * 
 * 
 * 
 * 示例 ：
 * 
 * 输入：[5,3,6,2,4,null,8,1,null,null,null,7,9]
 * 
 * ⁠      5
 * ⁠     / \
 * ⁠   3    6
 * ⁠  / \    \
 * ⁠ 2   4    8
 * /        / \ 
 * 1        7   9
 * 
 * 输出：[1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9]
 * 
 * ⁠1
 * \
 * 2
 * \
 * 3
 * \
 * 4
 * \
 * 5
 * \
 * 6
 * \
 * 7
 * \
 * 8
 * \
 * ⁠                9  
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 给定树中的结点数介于 1 和 100 之间。
 * 每个结点都有一个从 0 到 1000 范围内的唯一整数值。
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
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    TreeNode pre;
    public TreeNode IncreasingBST(TreeNode root) {
        TreeNode dummy = new TreeNode();
        pre = dummy;
        Helper(root); 
        return dummy.right;
    }
    public void Helper(TreeNode root) {
        if(root == null) return;
        Helper(root.left);
        pre.right = root;
        root.left = null;
        pre = pre.right;
        Helper(root.right);
    }
}
// @lc code=end

