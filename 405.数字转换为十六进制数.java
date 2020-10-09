/*
 * @lc app=leetcode.cn id=405 lang=java
 *
 * [405] 数字转换为十六进制数
 *
 * https://leetcode-cn.com/problems/convert-a-number-to-hexadecimal/description/
 *
 * algorithms
 * Easy (51.18%)
 * Likes:    96
 * Dislikes: 0
 * Total Accepted:    16.2K
 * Total Submissions: 31.4K
 * Testcase Example:  '26'
 *
 * 给定一个整数，编写一个算法将这个数转换为十六进制数。对于负整数，我们通常使用 补码运算 方法。
 * 
 * 注意:
 * 
 * 
 * 十六进制中所有字母(a-f)都必须是小写。
 * 
 * 十六进制字符串中不能包含多余的前导零。如果要转化的数为0，那么以单个字符'0'来表示；对于其他情况，十六进制字符串中的第一个字符将不会是0字符。 
 * 给定的数确保在32位有符号整数范围内。
 * 不能使用任何由库提供的将数字直接转换或格式化为十六进制的方法。
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入:
 * 26
 * 
 * 输出:
 * "1a"
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入:
 * -1
 * 
 * 输出:
 * "ffffffff"
 * 
 * 
 */

// @lc code=start
class Solution {
    public String toHex(int num) {
        if (num == 0) { return "0"; }   // 0特殊处理
        char[] hex = "0123456789abcdef".toCharArray();  // 相当于映射关系
        StringBuilder ans = new StringBuilder();
        while (num != 0) {
            int temp = num & 0xf;   // 取低4位的十进制值
            ans.append(hex[temp]);  // 映射对应字符
            num >>>= 4;             // 逻辑右移4位
        }
        // while的循环条件保证了不会出现前导0
        // 但是从低位开始转换多了一步reverse反转
        return ans.reverse().toString();
    }
}
// @lc code=end

