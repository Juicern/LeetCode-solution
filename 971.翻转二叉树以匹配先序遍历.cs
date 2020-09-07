using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=971 lang=csharp
 *
 * [971] 翻转二叉树以匹配先序遍历
 *
 * https://leetcode-cn.com/problems/flip-binary-tree-to-match-preorder-traversal/description/
 *
 * algorithms
 * Medium (45.10%)
 * Likes:    35
 * Dislikes: 0
 * Total Accepted:    2.2K
 * Total Submissions: 4.9K
 * Testcase Example:  '[1,2]\n[2,1]'
 *
 * 给定一个有 N 个节点的二叉树，每个节点都有一个不同于其他节点且处于 {1, ..., N} 中的值。
 * 
 * 通过交换节点的左子节点和右子节点，可以翻转该二叉树中的节点。
 * 
 * 考虑从根节点开始的先序遍历报告的 N 值序列。将这一 N 值序列称为树的行程。
 * 
 * （回想一下，节点的先序遍历意味着我们报告当前节点的值，然后先序遍历左子节点，再先序遍历右子节点。）
 * 
 * 我们的目标是翻转最少的树中节点，以便树的行程与给定的行程 voyage 相匹配。 
 * 
 * 如果可以，则返回翻转的所有节点的值的列表。你可以按任何顺序返回答案。
 * 
 * 如果不能，则返回列表 [-1]。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 
 * 输入：root = [1,2], voyage = [2,1]
 * 输出：[-1]
 * 
 * 
 * 示例 2：
 * 
 * 
 * 
 * 输入：root = [1,2,3], voyage = [1,3,2]
 * 输出：[1]
 * 
 * 
 * 示例 3：
 * 
 * 
 * 
 * 输入：root = [1,2,3], voyage = [1,2,3]
 * 输出：[]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= N <= 100
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
    List<int> flipped;
    int index = 0;
    int[] voyage;
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage) {
        flipped = new List<int>();
        this.voyage = voyage;
        Dfs(root);
        if(flipped.Any() && flipped[0] == -1) {
            flipped.Clear();
            flipped.Add(-1);
        }
        return flipped;
    }
    private void Dfs(TreeNode root) {
        if(root != null) {
            if(root.val != voyage[index]) {
                flipped.Clear();
                flipped.Add( -1);
                return;
            }
            index++;
            if(root.left != null && root.left.val != voyage[index]) {
                flipped.Add(root.val);
                Dfs(root.right);
                Dfs(root.left);
            }
            else {
                Dfs(root.left);
                Dfs(root.right);
            }
        }
    }
}
// @lc code=end

