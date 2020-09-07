import java.util.*;

/*
 * @lc app=leetcode.cn id=297 lang=java
 *
 * [297] 二叉树的序列化与反序列化
 *
 * https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/description/
 *
 * algorithms
 * Hard (43.61%)
 * Likes:    172
 * Dislikes: 0
 * Total Accepted:    19.9K
 * Total Submissions: 43.1K
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
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */

public class Codec {

    public String serialize(TreeNode root) {      //用StringBuilder
        StringBuilder res = ser_help(root, new StringBuilder());
        return res.toString();
    }
    
    public StringBuilder ser_help(TreeNode root, StringBuilder str){
        if(null == root){
            str.append("null,");
            return str;
        }
        str.append(root.val); 
        str.append(",");
        str = ser_help(root.left, str);
        str = ser_help(root.right, str);
        return str;
    }

    public TreeNode deserialize(String data) {
        String[] str_word = data.split(",");
        List<String> list_word = new LinkedList<String>(Arrays.asList(str_word));
        return deser_help(list_word);
    }
    
    public TreeNode deser_help(List<String> li){
        if(li.get(0).equals("null")){
            li.remove(0);
            return null;
        }
        TreeNode res = new TreeNode(Integer.valueOf(li.get(0)));
        li.remove(0);
        res.left = deser_help(li);
        res.right = deser_help(li);
        return res;
    }
}
/*
public class Codec {
    private class Node {
        TreeNode node;
        int index;
        public Node(TreeNode node, int index) {
            this.node = node;
            this.index = index;
        }
    }
    // Encodes a tree to a single string.
    public String serialize(TreeNode root) {
        Queue<Node> queue = new LinkedList<>();
        StringBuilder str = new StringBuilder();
        if(root==null) return str.toString();
        queue.add(new Node(root, 1));
        int pre = 0;
        while(queue.size()!=0){
            Node tmp = queue.poll();
            for(int i=1;i<tmp.index-pre;i++) str.append(" null");
            str.append(" " + tmp.node.val);
            pre = tmp.index;
            if(tmp.node.left!=null) queue.add(new Node(tmp.node.left, 2*tmp.index));
            if(tmp.node.right!=null) queue.add(new Node(tmp.node.right, 2*tmp.index+1));
        }
        return str.toString().trim();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(String data) {
        if(data==null || data.length()==0) return null;
        String[] strs = data.split(" ");
        TreeNode[] node = new TreeNode[strs.length+1];
        for(int i=0;i<strs.length;i++){
            if(strs[i].equals("null")) node[i+1] = null;
            else node[i+1] = new TreeNode(Integer.valueOf(strs[i]));
        }
        for(int i=1;i<node.length;i++){
            if(node[i]!=null){
                if(2*i<node.length) node[i].left = node[2*i];
                else node[i].left = null;
                if(2*i+1<node.length) node[i].right = node[2*i+1];
                else node[i].right = null;
            }
        }
        return node[1];
    }
}
*/

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
// @lc code=end

