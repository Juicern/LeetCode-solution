using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=515 lang=csharp
 *
 * [515] 在每个树行中找最大值
 *
 * https://leetcode-cn.com/problems/find-largest-value-in-each-tree-row/description/
 *
 * algorithms
 * Medium (60.32%)
 * Likes:    68
 * Dislikes: 0
 * Total Accepted:    12.6K
 * Total Submissions: 20.8K
 * Testcase Example:  '[1,3,2,5,3,null,9]'
 *
 * 您需要在二叉树的每一行中找到最大的值。
 * 
 * 示例：
 * 
 * 
 * 输入: 
 * 
 * ⁠         1
 * ⁠        / \
 * ⁠       3   2
 * ⁠      / \   \  
 * ⁠     5   3   9 
 * 
 * 输出: [1, 3, 9]
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
    public IList<int> LargestValues(TreeNode root) {
        var ans = new List<int>();
        if(root == null) return ans;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0) {
            int size = queue.Count;
            int max = int.MinValue;
            for(int i=0;i<size;i++) {
                var node = queue.Dequeue();
                max = Math.Max(max, node.val);
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right!=null) queue.Enqueue(node.right);
            }
            ans.Add(max);
        }
        return ans;
    }
}
// @lc code=end

