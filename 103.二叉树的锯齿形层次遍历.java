/*
 * @lc app=leetcode.cn id=103 lang=java
 *
 * [103] 二叉树的锯齿形层次遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/description/
 *
 * algorithms
 * Medium (53.10%)
 * Likes:    160
 * Dislikes: 0
 * Total Accepted:    36.7K
 * Total Submissions: 68.2K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其节点值的锯齿形层次遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
 * 
 * 例如：
 * 给定二叉树 [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回锯齿形层次遍历如下：
 * 
 * [
 * ⁠ [3],
 * ⁠ [20,9],
 * ⁠ [15,7]
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
    List<List<Integer>> ans = new LinkedList<>();
    // 省略两种层级遍历的代码片段

    private void insert(TreeNode node, int level) {
        List<Integer> list = level >= ans.size() ? null : ans.get(level);
        if (list == null) {
            list = new LinkedList<>();
            list.add(node.val);
            ans.add(list);
        } else {
            boolean isOdd = (level & 1) == 1;
            list.add(isOdd ? 0 : list.size(), node.val);
        }
    }

    public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
        helper(root, 0);
        return ans;
    }

    private void helper(TreeNode root, int level) {
        if (root == null) {
            return;
        }
        insert(root, level);
        
        helper(root.left, level + 1);
        helper(root.right, level + 1);
    }
}

// @lc code=end

