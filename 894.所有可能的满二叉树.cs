using System.Security.Cryptography;
/*
 * @lc app=leetcode.cn id=894 lang=csharp
 *
 * [894] 所有可能的满二叉树
 *
 * https://leetcode-cn.com/problems/all-possible-full-binary-trees/description/
 *
 * algorithms
 * Medium (74.41%)
 * Likes:    109
 * Dislikes: 0
 * Total Accepted:    6.3K
 * Total Submissions: 8.5K
 * Testcase Example:  '7'
 *
 * 满二叉树是一类二叉树，其中每个结点恰好有 0 或 2 个子结点。
 * 
 * 返回包含 N 个结点的所有可能满二叉树的列表。 答案的每个元素都是一个可能树的根结点。
 * 
 * 答案中每个树的每个结点都必须有 node.val=0。
 * 
 * 你可以按任何顺序返回树的最终列表。
 * 
 * 
 * 
 * 示例：
 * 
 * 输入：7
 * 
 * 输出：[[0,0,0,null,null,0,0,null,null,0,0],[0,0,0,null,null,0,0,0,0],[0,0,0,0,0,0,0],[0,0,0,0,0,null,null,null,null,0,0],[0,0,0,0,0,null,null,0,0]]
 * 解释：
 * 
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= N <= 20
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
    public IList<TreeNode> AllPossibleFBT(int N) {
        var ans = new List<TreeNode>();
        if((N&1) == 0) return ans;
        if(N==1) {
            ans.Add(new TreeNode(0));
            return ans;
        }
        N--;
        for(int i=1;i<N;i+=2) {
            var left = AllPossibleFBT(i);
            var right = AllPossibleFBT(N - i);
            foreach(var l in left) {
                foreach(var r in right) {
                    var node = new TreeNode(0);
                    node.left = l;
                    node.right = r;
                    ans.Add(node);
                }
            }
        }
        return ans;
    }
}
// @lc code=end

