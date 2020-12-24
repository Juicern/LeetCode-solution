/*
 * @lc app=leetcode.cn id=687 lang=cpp
 *
 * [687] 最长同值路径
 *
 * https://leetcode-cn.com/problems/longest-univalue-path/description/
 *
 * algorithms
 * Medium (42.23%)
 * Likes:    404
 * Dislikes: 0
 * Total Accepted:    26.9K
 * Total Submissions: 63.5K
 * Testcase Example:  '[5,4,5,1,1,5]'
 *
 * 给定一个二叉树，找到最长的路径，这个路径中的每个节点具有相同值。 这条路径可以经过也可以不经过根节点。
 * 
 * 注意：两个节点之间的路径长度由它们之间的边数表示。
 * 
 * 示例 1:
 * 
 * 输入:
 * 
 * 
 * ⁠             5
 * ⁠            / \
 * ⁠           4   5
 * ⁠          / \   \
 * ⁠         1   1   5
 * 
 * 
 * 输出:
 * 
 * 
 * 2
 * 
 * 
 * 示例 2:
 * 
 * 输入:
 * 
 * 
 * ⁠             1
 * ⁠            / \
 * ⁠           4   5
 * ⁠          / \   \
 * ⁠         4   4   5
 * 
 * 
 * 输出:
 * 
 * 
 * 2
 * 
 * 
 * 注意: 给定的二叉树不超过10000个结点。 树的高度不超过1000。
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
class Solution {
public:
    int ans = 0;
    int longestUnivaluePath(TreeNode* root) {
        helper(root);
        return ans;
    }
    int helper(TreeNode* node) {
        if(!node) return 0;
        int left = helper(node->left);
        int right = helper(node->right);
        int arrowLeft = 0;
        int arrowRight = 0;
        if(node->left && node->val == node->left->val) {
            arrowLeft += left + 1;
        }
        if(node->right && node->val == node->right->val) {
            arrowRight += right + 1;
        }
        ans = max(ans, arrowLeft + arrowRight);
        return max(arrowLeft, arrowRight);
    }
};
// @lc code=end

