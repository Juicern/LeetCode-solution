/*
 * @lc app=leetcode.cn id=331 lang=csharp
 *
 * [331] 验证二叉树的前序序列化
 *
 * https://leetcode-cn.com/problems/verify-preorder-serialization-of-a-binary-tree/description/
 *
 * algorithms
 * Medium (46.06%)
 * Likes:    248
 * Dislikes: 0
 * Total Accepted:    26.6K
 * Total Submissions: 56.2K
 * Testcase Example:  '"9,3,4,#,#,1,#,#,2,#,6,#,#"'
 *
 * 序列化二叉树的一种方法是使用前序遍历。当我们遇到一个非空节点时，我们可以记录下这个节点的值。如果它是一个空节点，我们可以使用一个标记值记录，例如 #。
 * 
 * ⁠    _9_
 * ⁠   /   \
 * ⁠  3     2
 * ⁠ / \   / \
 * ⁠4   1  #  6
 * / \ / \   / \
 * # # # #   # #
 * 
 * 
 * 例如，上面的二叉树可以被序列化为字符串 "9,3,4,#,#,1,#,#,2,#,6,#,#"，其中 # 代表一个空节点。
 * 
 * 给定一串以逗号分隔的序列，验证它是否是正确的二叉树的前序序列化。编写一个在不重构树的条件下的可行算法。
 * 
 * 每个以逗号分隔的字符或为一个整数或为一个表示 null 指针的 '#' 。
 * 
 * 你可以认为输入格式总是有效的，例如它永远不会包含两个连续的逗号，比如 "1,,3" 。
 * 
 * 示例 1:
 * 
 * 输入: "9,3,4,#,#,1,#,#,2,#,6,#,#"
 * 输出: true
 * 
 * 示例 2:
 * 
 * 输入: "1,#"
 * 输出: false
 * 
 * 
 * 示例 3:
 * 
 * 输入: "9,#,#,1"
 * 输出: false
 * 
 */

// @lc code=start
public class Solution {
    public bool IsValidSerialization(string preorder) {
        int numCount = 0, endCount = 0; //记录非空结点数与空结点（即#，代表叶子结点）数

        for(int i = 0; i < preorder.Length; i++)
        {
            if(preorder[i] == ',' && preorder[i - 1] != '#')    //逗号前不为#，则结点数+1
                numCount++;
            else if(preorder[i] == '#')
            {
                if(++endCount >= numCount + 1 && i != preorder.Length - 1)  //二叉树的“空结点位置”已经全部占满但序列并未结束，说明该序列不能代表二叉树
                    return false;
            }
        }

        return endCount == numCount + 1;    //一个二叉树空结点（即叶子结点）数应该等于非空结点数 + 1
    }
}


// @lc code=end

