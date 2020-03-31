import java.util.*;

/*
 * @lc app=leetcode.cn id=102 lang=java
 *
 * [102] 二叉树的层次遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-level-order-traversal/description/
 *
 * algorithms
 * Medium (60.45%)
 * Likes:    403
 * Dislikes: 0
 * Total Accepted:    89.4K
 * Total Submissions: 146.4K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其按层次遍历的节点值。 （即逐层地，从左到右访问所有节点）。
 * 
 * 例如:
 * 给定二叉树: [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回其层次遍历结果：
 * 
 * [
 * ⁠ [3],
 * ⁠ [9,20],
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
    List<List<Integer>> ans = new ArrayList<>();
    public void bfs(TreeNode root, int level){
        if(ans.size()==level){
            ans.add(new ArrayList<Integer>());
        }
        ans.get(level).add(root.val);
        if(root.left!=null) bfs(root.left, level+1);
        if(root.right!=null) bfs(root.right, level+1);
    }
    public List<List<Integer>> levelOrder(TreeNode root) {
        if(root==null) return ans;
        bfs(root, 0);
        return ans;
    }
}
// @lc code=end

