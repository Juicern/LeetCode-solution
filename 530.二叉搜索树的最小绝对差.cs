using System;
/*
 * @lc app=leetcode.cn id=530 lang=csharp
 *
 * [530] 二叉搜索树的最小绝对差
 *
 * https://leetcode-cn.com/problems/minimum-absolute-difference-in-bst/description/
 *
 * algorithms
 * Easy (58.27%)
 * Likes:    165
 * Dislikes: 0
 * Total Accepted:    33.4K
 * Total Submissions: 55.5K
 * Testcase Example:  '[1,null,3,2]'
 *
 * 给你一棵所有节点为非负值的二叉搜索树，请你计算树中任意两节点的差的绝对值的最小值。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：
 * 
 * ⁠  1
 * ⁠   \
 * ⁠    3
 * ⁠   /
 * ⁠  2
 * 
 * 输出：
 * 1
 * 
 * 解释：
 * 最小绝对差为 1，其中 2 和 1 的差的绝对值为 1（或者 2 和 3）。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 树中至少有 2 个节点。
 * 本题与 783 https://leetcode-cn.com/problems/minimum-distance-between-bst-nodes/
 * 相同
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
    public int GetMinimumDifference(TreeNode root) {
        int ans = int.MaxValue;
        int pre = -1;
        Dfs(root, ref ans, ref pre);
        return ans;
    }
    private void Dfs(TreeNode root, ref int ans, ref int pre) {
        if(root == null) return;
        Dfs(root.left, ref ans, ref pre);
        if(pre == -1) {
            pre = root.val;
        }
        else {
            ans = Math.Min(root.val - pre, ans);
            pre = root.val;
        }
        Dfs(root.right, ref ans, ref pre);
    }
}
// @lc code=end

