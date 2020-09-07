/*
 * @lc app=leetcode.cn id=1022 lang=csharp
 *
 * [1022] 从根到叶的二进制数之和
 *
 * https://leetcode-cn.com/problems/sum-of-root-to-leaf-binary-numbers/description/
 *
 * algorithms
 * Easy (63.11%)
 * Likes:    51
 * Dislikes: 0
 * Total Accepted:    7.2K
 * Total Submissions: 11.5K
 * Testcase Example:  '[1,0,1,0,1,0,1]'
 *
 * 给出一棵二叉树，其上每个结点的值都是 0 或 1 。每一条从根到叶的路径都代表一个从最高有效位开始的二进制数。例如，如果路径为 0 -> 1 -> 1
 * -> 0 -> 1，那么它表示二进制数 01101，也就是 13 。
 * 
 * 对树上的每一片叶子，我们都要找出从根到该叶子的路径所表示的数字。
 * 
 * 以 10^9 + 7 为模，返回这些数字之和。
 * 
 * 
 * 
 * 示例：
 * 
 * 
 * 
 * 输入：[1,0,1,0,1,0,1]
 * 输出：22
 * 解释：(100) + (101) + (110) + (111) = 4 + 5 + 6 + 7 = 22
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 树中的结点数介于 1 和 1000 之间。
 * node.val 为 0 或 1 。
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
    int ans = 0;
    private void helper(TreeNode root, int pre) {
        if(root==null) return;
        if(root.left== null && root.right==null) {
            ans += (pre<<1) + root.val;
            return;
        }
        helper(root.left, (pre<<1) + root.val);
        helper(root.right, (pre<<1) + root.val);
    }
    public int SumRootToLeaf(TreeNode root) {
        helper(root, 0);
        return ans;
    }
}
// @lc code=end

