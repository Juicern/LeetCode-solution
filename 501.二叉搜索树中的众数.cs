using System.Reflection.Emit;
/*
 * @lc app=leetcode.cn id=501 lang=csharp
 *
 * [501] 二叉搜索树中的众数
 *
 * https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/description/
 *
 * algorithms
 * Easy (45.68%)
 * Likes:    170
 * Dislikes: 0
 * Total Accepted:    22.8K
 * Total Submissions: 47.9K
 * Testcase Example:  '[1,null,2,2]'
 *
 * 给定一个有相同值的二叉搜索树（BST），找出 BST 中的所有众数（出现频率最高的元素）。
 * 
 * 假定 BST 有如下定义：
 * 
 * 
 * 结点左子树中所含结点的值小于等于当前结点的值
 * 结点右子树中所含结点的值大于等于当前结点的值
 * 左子树和右子树都是二叉搜索树
 * 
 * 
 * 例如：
 * 给定 BST [1,null,2,2],
 * 
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  2
 * 
 * 
 * 返回[2].
 * 
 * 提示：如果众数超过1个，不需考虑输出顺序
 * 
 * 进阶：你可以不使用额外的空间吗？（假设由递归产生的隐式调用栈的开销不被计算在内）
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
public class Solution
{
    int bases;
    int count;
    int maxCount;
    List<int> ans = new List<int>();
    public int[] FindMode(TreeNode root)
    {
        TreeNode cur = root;
        TreeNode pre = null;
        while (cur != null)
        {
            if (cur.left == null)
            {
                update(cur.val);
                cur = cur.right;
                continue;
            }
            pre = cur.left;
            while (pre.right != null && pre.right != cur)
            {
                pre = pre.right;
            }
            if (pre.right == null)
            {
                pre.right = cur;
                cur = cur.left;
            }
            else
            {
                pre.right = null;
                update(cur.val);
                cur = cur.right;
            }
        }
        return ans.ToArray();
    }
    public void update(int x)
    {
        if (x == bases) count++;
        else
        {
            count = 1;
            bases = x;
        }
        if (count == maxCount)
        {
            ans.Add(bases);
        }
        if (count > maxCount)
        {
            maxCount = count;
            ans.Clear();
            ans.Add(bases);
        }
    }
}
// @lc code=end

