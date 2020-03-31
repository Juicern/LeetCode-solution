import java.util.*;
/*
 * @lc app=leetcode.cn id=95 lang=java
 *
 * [95] 不同的二叉搜索树 II
 *
 * https://leetcode-cn.com/problems/unique-binary-search-trees-ii/description/
 *
 * algorithms
 * Medium (60.90%)
 * Likes:    313
 * Dislikes: 0
 * Total Accepted:    22.7K
 * Total Submissions: 36.7K
 * Testcase Example:  '3'
 *
 * 给定一个整数 n，生成所有由 1 ... n 为节点所组成的二叉搜索树。
 * 
 * 示例:
 * 
 * 输入: 3
 * 输出:
 * [
 * [1,null,3,2],
 * [3,2,null,1],
 * [3,1,null,null,2],
 * [2,1,3],
 * [1,null,2,null,3]
 * ]
 * 解释:
 * 以上的输出对应以下 5 种不同结构的二叉搜索树：
 * 
 * ⁠  1         3     3      2      1
 * ⁠   \       /     /      / \      \
 * ⁠    3     2     1      1   3      2
 * ⁠   /     /       \                 \
 * ⁠  2     1         2                 3
 * 
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
    public List<TreeNode> getAns(int start, int end){
        List<TreeNode> ans = new ArrayList<>();
        if(start > end){
            ans.add(null);
            return ans;
        }
        if(start == end){
            TreeNode temp = new TreeNode(start);
            ans.add(temp);
            return ans;
        }
        for(int i=start;i<=end;i++){
            List<TreeNode> left = getAns(start, i-1);
            List<TreeNode> right = getAns(i+1, end);
            for(TreeNode l : left){
                for(TreeNode r : right){
                    TreeNode temp = new TreeNode(i);
                    temp.left = l;
                    temp.right = r;
                    ans.add(temp);
                }
            }
        }
        return ans;
    }
    public List<TreeNode> generateTrees(int n) {
        List<TreeNode> ans = new ArrayList<>();
        if(n==0) return ans;
        return getAns(1,n);
    }
}
// @lc code=end

