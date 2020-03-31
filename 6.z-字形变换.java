import java.util.ArrayList;

/*
 * @lc app=leetcode.cn id=6 lang=java
 *
 * [6] Z 字形变换
 *
 * https://leetcode-cn.com/problems/zigzag-conversion/description/
 *
 * algorithms
 * Medium (46.36%)
 * Likes:    540
 * Dislikes: 0
 * Total Accepted:    89.8K
 * Total Submissions: 193.6K
 * Testcase Example:  '"PAYPALISHIRING"\n3'
 *
 * 将一个给定字符串根据给定的行数，以从上往下、从左到右进行 Z 字形排列。
 * 
 * 比如输入字符串为 "LEETCODEISHIRING" 行数为 3 时，排列如下：
 * 
 * L   C   I   R
 * E T O E S I I G
 * E   D   H   N
 * 
 * 
 * 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。
 * 
 * 请你实现这个将字符串进行指定行数变换的函数：
 * 
 * string convert(string s, int numRows);
 * 
 * 示例 1:
 * 
 * 输入: s = "LEETCODEISHIRING", numRows = 3
 * 输出: "LCIRETOESIIGEDHN"
 * 
 * 
 * 示例 2:
 * 
 * 输入: s = "LEETCODEISHIRING", numRows = 4
 * 输出: "LDREOEIIECIHNTSG"
 * 解释:
 * 
 * L     D     R
 * E   O E   I I
 * E C   I H   N
 * T     S     G
 * 
 */

// @lc code=start
class Solution {
    public String convert(String s, int numRows) {
        if(numRows==1) return s;    //后面flag翻转时会有bug，因此要直接返回
        ArrayList<StringBuffer> rows = new ArrayList<>();
        for(int i=0;i<Math.min(s.length(),numRows);i++) rows.add(new StringBuffer());
        boolean flag = false;
        int row_num = 0;
        for(char ch : s.toCharArray()){
            rows.get(row_num).append(ch);
            if(row_num==0 || row_num==numRows-1) flag = !flag;
            row_num += flag ? 1 : -1;
        }
        StringBuffer strBuf = new StringBuffer();
        for(StringBuffer row : rows) strBuf.append(row);
        return strBuf.toString();
    }
}
// @lc code=end

