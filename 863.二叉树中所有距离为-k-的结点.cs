using System.Diagnostics;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=863 lang=csharp
 *
 * [863] 二叉树中所有距离为 K 的结点
 *
 * https://leetcode-cn.com/problems/all-nodes-distance-k-in-binary-tree/description/
 *
 * algorithms
 * Medium (50.61%)
 * Likes:    139
 * Dislikes: 0
 * Total Accepted:    6.3K
 * Total Submissions: 12.4K
 * Testcase Example:  '[3,5,1,6,2,0,8,null,null,7,4]\n5\n2'
 *
 * 给定一个二叉树（具有根结点 root）， 一个目标结点 target ，和一个整数值 K 。
 * 
 * 返回到目标结点 target 距离为 K 的所有结点的值的列表。 答案可以以任何顺序返回。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, K = 2
 * 输出：[7,4,1]
 * 解释：
 * 所求结点为与目标结点（值为 5）距离为 2 的结点，
 * 值分别为 7，4，以及 1
 * 
 * 
 * 
 * 注意，输入的 "root" 和 "target" 实际上是树上的结点。
 * 上面的输入仅仅是对这些对象进行了序列化描述。
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 给定的树是非空的。
 * 树上的每个结点都具有唯一的值 0 <= node.val <= 500 。
 * 目标结点 target 是树上的结点。
 * 0 <= K <= 1000.
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
    Dictionary<TreeNode, List<TreeNode>> map = new Dictionary<TreeNode, List<TreeNode>>();
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        List<int> result = new List<int>();
        if(root == null) return result;
        if(K == 0) {
            result.Add(target.val);
            return result;
        }
        BuildGraph(root, null);
        var visited = new HashSet<TreeNode>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(target);
        visited.Add(target);
        while(K > 0) {
            K--;
            int n = queue.Count;
            for(int i = 0;i<n;i++) {
                var cur = queue.Dequeue();
                var cur_list = map[cur];
                for(int j = 0;j<cur_list.Count;j++) {
                    var next = cur_list[j];
                    if(!visited.Contains(next)) {
                        if(K == 0) {
                            result.Add(next.val);
                        }
                        visited.Add(next);
                        queue.Enqueue(next);
                    }
                }
            }
            if(K == 0) return result;
        }
        return result;
    }
    private void BuildGraph(TreeNode root, TreeNode parent) {
        if(root == null) return;
        if(map.ContainsKey(root)) return;
        map.Add(root, new List<TreeNode>());
        if(parent != null) {
            map[parent].Add(root);
            map[root].Add(parent);
        }
        BuildGraph(root.left, root);
        BuildGraph(root.right, root);
    }
}
// @lc code=end

