/*
 * @lc app=leetcode.cn id=171 lang=java
 *
 * [171] Excel表列序号
 *
 * https://leetcode-cn.com/problems/excel-sheet-column-number/description/
 *
 * algorithms
 * Easy (66.30%)
 * Likes:    123
 * Dislikes: 0
 * Total Accepted:    34.5K
 * Total Submissions: 51.7K
 * Testcase Example:  '"A"'
 *
 * 给定一个Excel表格中的列名称，返回其相应的列序号。
 * 
 * 例如，
 * 
 * ⁠   A -> 1
 * ⁠   B -> 2
 * ⁠   C -> 3
 * ⁠   ...
 * ⁠   Z -> 26
 * ⁠   AA -> 27
 * ⁠   AB -> 28 
 * ⁠   ...
 * 
 * 
 * 示例 1:
 * 
 * 输入: "A"
 * 输出: 1
 * 
 * 
 * 示例 2:
 * 
 * 输入: "AB"
 * 输出: 28
 * 
 * 
 * 示例 3:
 * 
 * 输入: "ZY"
 * 输出: 701
 * 
 * 致谢：
 * 特别感谢 @ts 添加此问题并创建所有测试用例。
 * 
 */

// @lc code=start
class Solution {
    public int titleToNumber(String s) {
        int n = s.length();
        int res = 0;
        for(int i=0;i<n;i++){
            int num = s.charAt(i) - 'A' + 1;
            res = res*26 + num;
        }
        return res;
    }
}
// @lc code=end

