import java.util.*;
/*
 * @lc app=leetcode.cn id=513 lang=java
 *
 * [513] 找树左下角的值
 *
 * https://leetcode-cn.com/problems/find-bottom-left-tree-value/description/
 *
 * algorithms
 * Medium (69.21%)
 * Likes:    76
 * Dislikes: 0
 * Total Accepted:    12.7K
 * Total Submissions: 18.3K
 * Testcase Example:  '[2,1,3]'
 *
 * 给定一个二叉树，在树的最后一行找到最左边的值。
 * 
 * 示例 1:
 * 
 * 
 * 输入:
 * 
 * ⁠   2
 * ⁠  / \
 * ⁠ 1   3
 * 
 * 输出:
 * 1
 * 
 * 
 * 
 * 
 * 示例 2: 
 * 
 * 
 * 输入:
 * 
 * ⁠       1
 * ⁠      / \
 * ⁠     2   3
 * ⁠    /   / \
 * ⁠   4   5   6
 * ⁠      /
 * ⁠     7
 * 
 * 输出:
 * 7
 * 
 * 
 * 
 * 
 * 注意: 您可以假设树（即给定的根节点）不为 NULL。
 * 
 */

import javax.swing.tree.TreeNode;

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
    public int findBottomLeftValue(TreeNode root) {
        Queue<TreeNode> queue = new LinkedList<>();
        queue.offer(root);
        int left = root.val;
        while(!queue.isEmpty()) {
            int size = queue.size();
            left = queue.peek().val;
            for(int i=0;i<size;i++) {
                TreeNode tmp = queue.poll();
                if(tmp.left!=null) queue.offer(tmp.left);
                if(tmp.right!=null) queue.offer(tmp.right);
            }
        }
        return left;
    }
}
// @lc code=end

