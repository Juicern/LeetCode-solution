import java.awt.List;
import java.util.ArrayList;

/*
 * @lc app=leetcode.cn id=199 lang=java
 *
 * [199] 二叉树的右视图
 *
 * https://leetcode-cn.com/problems/binary-tree-right-side-view/description/
 *
 * algorithms
 * Medium (62.59%)
 * Likes:    149
 * Dislikes: 0
 * Total Accepted:    21.7K
 * Total Submissions: 33.9K
 * Testcase Example:  '[1,2,3,null,5,null,4]'
 *
 * 给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
 * 
 * 示例:
 * 
 * 输入: [1,2,3,null,5,null,4]
 * 输出: [1, 3, 4]
 * 解释:
 * 
 * ⁠  1            <---
 * ⁠/   \
 * 2     3         <---
 * ⁠\     \
 * ⁠ 5     4       <---
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
    private List<Integer> ans = new ArrayList<>();
    public void helper(TreeNode root, int level){
        if(root==null) return;
        if(ans.size()==level) ans.add(root.val);
        helper(root.right, level+1);
        helper(root.left, level+1);
        return;
    }
    public List<Integer> rightSideView(TreeNode root) {
        helper(root, 0);
        return ans;
    }
}
// @lc code=end

