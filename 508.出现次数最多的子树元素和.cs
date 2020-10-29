using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=508 lang=csharp
 *
 * [508] 出现次数最多的子树元素和
 *
 * https://leetcode-cn.com/problems/most-frequent-subtree-sum/description/
 *
 * algorithms
 * Medium (65.17%)
 * Likes:    89
 * Dislikes: 0
 * Total Accepted:    8.9K
 * Total Submissions: 13.7K
 * Testcase Example:  '[5,2,-3]'
 *
 * 给你一个二叉树的根结点，请你找出出现次数最多的子树元素和。一个结点的「子树元素和」定义为以该结点为根的二叉树上所有结点的元素之和（包括结点本身）。
 * 
 * 你需要返回出现次数最多的子树元素和。如果有多个元素出现的次数相同，返回所有出现次数最多的子树元素和（不限顺序）。
 * 
 * 
 * 
 * 示例 1：
 * 输入:
 * 
 * ⁠ 5
 * ⁠/  \
 * 2   -3
 * 
 * 
 * 返回 [2, -3, 4]，所有的值均只出现一次，以任意顺序返回所有值。
 * 
 * 示例 2：
 * 输入：
 * 
 * ⁠ 5
 * ⁠/  \
 * 2   -5
 * 
 * 
 * 返回 [2]，只有 2 出现两次，-5 只出现 1 次。
 * 
 * 
 * 
 * 提示： 假设任意子树元素和均可以用 32 位有符号整数表示。
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
    Dictionary<int, int> dict;
    int max;
    List<int> ans;
    public int[] FindFrequentTreeSum(TreeNode root) {
        dict = new Dictionary<int, int>();
        max = 0;
        ans = new List<int>();
        Dfs(root);
        return ans.ToArray();
    }
    private int Dfs(TreeNode root) {
        if(root == null) return 0;
        int num = root.val + Dfs(root.left) + Dfs(root.right);
        dict[num] = dict.GetValueOrDefault(num) + 1;
        if(dict[num] == max) ans.Add(num);
        if(dict[num] > max) {
            ans.Clear();
            ans.Add(num);
            max = dict[num];
        }
        return num;
    }
}
// @lc code=end

