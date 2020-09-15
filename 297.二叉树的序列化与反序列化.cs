using System.Xml.Schema;
using System.Text;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=297 lang=csharp
 *
 * [297] 二叉树的序列化与反序列化
 *
 * https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/description/
 *
 * algorithms
 * Hard (51.88%)
 * Likes:    356
 * Dislikes: 0
 * Total Accepted:    49.7K
 * Total Submissions: 95.5K
 * Testcase Example:  '[1,2,3,null,null,4,5]'
 *
 * 
 * 序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方式重构得到原数据。
 * 
 * 请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 /
 * 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串反序列化为原始的树结构。
 * 
 * 示例: 
 * 
 * 你可以将以下二叉树：
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   3
 * ⁠    / \
 * ⁠   4   5
 * 
 * 序列化为 "[1,2,3,null,null,4,5]"
 * 
 * 提示: 这与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode
 * 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这个问题。
 * 
 * 说明: 不要使用类的成员 / 全局 / 静态变量来存储状态，你的序列化和反序列化算法应该是无状态的。
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
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null) return "[]";
        var ans = new List<string>(); 
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Any()) {
            var node = queue.Dequeue();
            if(node!=null) {
                ans.Add(node.val + "");
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else {
                ans.Add("null");
            }
        }
        return "[" + string.Join(",", ans) + "]";

    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data == "[]") return null;
        var vals = data.Substring(1, data.Length - 2).Split(',');
        var root = new TreeNode(int.Parse(vals[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;
        while(queue.Any()) {
            var node = queue.Dequeue();
            if(vals[index] != "null"){
                node.left = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.left);
            }
            index++;
            if(vals[index] != "null"){
                node.right = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.right);
            }
            index++;
        }
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
// @lc code=end

