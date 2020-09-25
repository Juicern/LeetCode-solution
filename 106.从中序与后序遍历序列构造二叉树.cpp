#include<vector>
#include<unordered_map>
using namespace std;
/*
 * @lc app=leetcode.cn id=106 lang=cpp
 *
 * [106] 从中序与后序遍历序列构造二叉树
 *
 * https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/description/
 *
 * algorithms
 * Medium (69.44%)
 * Likes:    337
 * Dislikes: 0
 * Total Accepted:    61.6K
 * Total Submissions: 87.4K
 * Testcase Example:  '[9,3,15,20,7]\n[9,15,7,20,3]'
 *
 * 根据一棵树的中序遍历与后序遍历构造二叉树。
 * 
 * 注意:
 * 你可以假设树中没有重复的元素。
 * 
 * 例如，给出
 * 
 * 中序遍历 inorder = [9,3,15,20,7]
 * 后序遍历 postorder = [9,15,7,20,3]
 * 
 * 返回如下的二叉树：
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    int post_index;
    unordered_map<int, int> map;
    TreeNode* buildTree(vector<int>& inorder, vector<int>& postorder) {
        post_index = (int)postorder.size() -1;
        int index = 0;
        for(auto &val : inorder) {
            map[val] = index++;
        }
        return helper(0, (int)inorder.size() - 1, inorder, postorder);
    }
    TreeNode* helper(int left, int right, vector<int> &inorder, vector<int>& postorder) {
        if(left > right) return nullptr;
        int root_val = postorder[post_index];
        TreeNode *root = new TreeNode(root_val);
        post_index--;
        int index = map[root_val];
        root->right = helper(index +1 , right, inorder, postorder);
        root->left = helper(left , index - 1, inorder, postorder);
        return root;
    }
};
// @lc code=end

