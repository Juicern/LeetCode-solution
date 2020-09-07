using System.Linq;
using System;
/*
 * @lc app=leetcode.cn id=1104 lang=csharp
 *
 * [1104] 二叉树寻路
 *
 * https://leetcode-cn.com/problems/path-in-zigzag-labelled-binary-tree/description/
 *
 * algorithms
 * Medium (69.25%)
 * Likes:    39
 * Dislikes: 0
 * Total Accepted:    5.1K
 * Total Submissions: 7.4K
 * Testcase Example:  '14'
 *
 * 在一棵无限的二叉树上，每个节点都有两个子节点，树中的节点 逐行 依次按 “之” 字形进行标记。
 * 
 * 如下图所示，在奇数行（即，第一行、第三行、第五行……）中，按从左到右的顺序进行标记；
 * 
 * 而偶数行（即，第二行、第四行、第六行……）中，按从右到左的顺序进行标记。
 * 
 * 
 * 
 * 给你树上某一个节点的标号 label，请你返回从根节点到该标号为 label 节点的路径，该路径是由途经的节点标号所组成的。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：label = 14
 * 输出：[1,3,4,14]
 * 
 * 
 * 示例 2：
 * 
 * 输入：label = 26
 * 输出：[1,2,6,10,26]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= label <= 10^6
 * 
 * 
 */

// @lc code=start
public class Solution {
    public IList<int> PathInZigZagTree(int label) {
        var ans = new List<int>();
        int level = (int)Math.Floor(Math.Log(label, 2));
        int num = label;
        if(level % 2 == 1) num = (int)Math.Pow(2, level + 1) - num + (int)Math.Pow(2, level) - 1;
        while(level >=0 ) {
            ans.Insert(0, label);
            num = num / 2;
            level--;
            if(level % 2 == 1) label = (int)Math.Pow(2, level + 1) - num + (int)Math.Pow(2, level) - 1;
            else label = num;
        }
        return ans;
    }
}
// @lc code=end

