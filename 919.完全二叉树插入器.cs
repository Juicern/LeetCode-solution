using System.Reflection.Emit;
/*
 * @lc app=leetcode.cn id=919 lang=csharp
 *
 * [919] 完全二叉树插入器
 *
 * https://leetcode-cn.com/problems/complete-binary-tree-inserter/description/
 *
 * algorithms
 * Medium (61.46%)
 * Likes:    32
 * Dislikes: 0
 * Total Accepted:    3.5K
 * Total Submissions: 5.7K
 * Testcase Example:  '["CBTInserter","insert","get_root"]\n[[[1]],[2],[]]'
 *
 * 完全二叉树是每一层（除最后一层外）都是完全填充（即，节点数达到最大）的，并且所有的节点都尽可能地集中在左侧。
 * 
 * 设计一个用完全二叉树初始化的数据结构 CBTInserter，它支持以下几种操作：
 * 
 * 
 * CBTInserter(TreeNode root) 使用头节点为 root 的给定树初始化该数据结构；
 * CBTInserter.insert(int v)  向树中插入一个新节点，节点类型为 TreeNode，值为 v
 * 。使树保持完全二叉树的状态，并返回插入的新节点的父节点的值；
 * CBTInserter.get_root() 将返回树的头节点。
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：inputs = ["CBTInserter","insert","get_root"], inputs = [[[1]],[2],[]]
 * 输出：[null,1,[1,2]]
 * 
 * 
 * 示例 2：
 * 
 * 输入：inputs = ["CBTInserter","insert","insert","get_root"], inputs =
 * [[[1,2,3,4,5,6]],[7],[8],[]]
 * 输出：[null,3,4,[1,2,3,4,5,6,7,8]]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 最初给定的树是完全二叉树，且包含 1 到 1000 个节点。
 * 每个测试用例最多调用 CBTInserter.insert  操作 10000 次。
 * 给定节点或插入节点的每个值都在 0 到 5000 之间。
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
public class CBTInserter {
    List<TreeNode> lst;
    public CBTInserter(TreeNode root) {
        lst = new List<TreeNode>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Any()) {
            var node = queue.Dequeue();
            lst.Add(node);
            if(node.left != null) queue.Enqueue(node.left);
            if(node.right != null) queue.Enqueue(node.right);
        }
    }
    
    public int Insert(int v) {
        var node = new TreeNode(v);
        lst.Add(node);
        int parent = lst.Count / 2 - 1;
        if (lst.Count % 2 == 0) {
            lst[parent].left = node;
        }
        else {
            lst[parent].right = node;
        }
        return lst[parent].val;
    }
    
    public TreeNode Get_root() {
        return lst.Any() ? lst[0]: null;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */
// @lc code=end

