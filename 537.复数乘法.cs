/*
 * @lc app=leetcode.cn id=537 lang=csharp
 *
 * [537] 复数乘法
 *
 * https://leetcode-cn.com/problems/complex-number-multiplication/description/
 *
 * algorithms
 * Medium (70.03%)
 * Likes:    47
 * Dislikes: 0
 * Total Accepted:    8.3K
 * Total Submissions: 11.8K
 * Testcase Example:  '"1+1i"\n"1+1i"'
 *
 * 给定两个表示复数的字符串。
 * 
 * 返回表示它们乘积的字符串。注意，根据定义 i^2 = -1 。
 * 
 * 示例 1:
 * 
 * 
 * 输入: "1+1i", "1+1i"
 * 输出: "0+2i"
 * 解释: (1 + i) * (1 + i) = 1 + i^2 + 2 * i = 2i ，你需要将它转换为 0+2i 的形式。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: "1+-1i", "1+-1i"
 * 输出: "0+-2i"
 * 解释: (1 - i) * (1 - i) = 1 + i^2 - 2 * i = -2i ，你需要将它转换为 0+-2i 的形式。 
 * 
 * 
 * 注意:
 * 
 * 
 * 输入字符串不包含额外的空格。
 * 输入字符串将以 a+bi 的形式给出，其中整数 a 和 b 的范围均在 [-100, 100] 之间。输出也应当符合这种形式。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public string ComplexNumberMultiply(string a, string b) {
        var nums_a = a.Split(new char[]{'+', 'i'});
        var nums_b = b.Split(new char[]{'+', 'i'});
        return (int.Parse(nums_a[0]) * int.Parse(nums_b[0]) - int.Parse(nums_a[1]) * int.Parse(nums_b[1])) + "+" + (int.Parse(nums_a[0]) * int.Parse(nums_b[1]) + int.Parse(nums_a[1]) * int.Parse(nums_b[0])) + "i"; 
    }
}
// @lc code=end

