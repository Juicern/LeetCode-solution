/*
 * @lc app=leetcode.cn id=777 lang=csharp
 *
 * [777] 在LR字符串中交换相邻字符
 *
 * https://leetcode-cn.com/problems/swap-adjacent-in-lr-string/description/
 *
 * algorithms
 * Medium (32.11%)
 * Likes:    46
 * Dislikes: 0
 * Total Accepted:    2.7K
 * Total Submissions: 8.5K
 * Testcase Example:  '"X"\n"L"'
 *
 * 在一个由 'L' , 'R' 和 'X'
 * 三个字符组成的字符串（例如"RXXLRXRXL"）中进行移动操作。一次移动操作指用一个"LX"替换一个"XL"，或者用一个"XR"替换一个"RX"。现给定起始字符串start和结束字符串end，请编写代码，当且仅当存在一系列移动操作使得start可以转换成end时，
 * 返回True。
 * 
 * 
 * 
 * 示例 :
 * 
 * 输入: start = "RXXLRXRXL", end = "XRLXXRRLX"
 * 输出: True
 * 解释:
 * 我们可以通过以下几步将start转换成end:
 * RXXLRXRXL ->
 * XRXLRXRXL ->
 * XRLXRXRXL ->
 * XRLXXRRXL ->
 * XRLXXRRLX
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= len(start) = len(end) <= 10000。
 * start和end中的字符串仅限于'L', 'R'和'X'。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public bool CanTransform(string start, string end)
    {
        var leftIndex = 0;
        var rightIndex = 0;
        while (leftIndex < start.Length || rightIndex < end.Length)
        {
            while (leftIndex < start.Length && start[leftIndex] == 'X') leftIndex++;
            while (rightIndex < end.Length && end[rightIndex] == 'X') rightIndex++;
            if (leftIndex < start.Length && rightIndex < end.Length)
            {
                if (start[leftIndex] == end[rightIndex])
                {
                    if (start[leftIndex] == 'L' && leftIndex < rightIndex) break;
                    if (end[rightIndex] == 'R' && leftIndex > rightIndex) break;
                    leftIndex++;
                    rightIndex++;
                }
                else break;
            }
            else
            {
                if (leftIndex < start.Length && start[leftIndex] != 'X') break;
                if (rightIndex < end.Length && end[rightIndex] != 'X') break;
            }
        }
        return leftIndex == rightIndex && leftIndex == start.Length;
    }
}
// @lc code=end

