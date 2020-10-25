/*
 * @lc app=leetcode.cn id=738 lang=csharp
 *
 * [738] 单调递增的数字
 *
 * https://leetcode-cn.com/problems/monotone-increasing-digits/description/
 *
 * algorithms
 * Medium (43.89%)
 * Likes:    73
 * Dislikes: 0
 * Total Accepted:    6.3K
 * Total Submissions: 14.3K
 * Testcase Example:  '10'
 *
 * 给定一个非负整数 N，找出小于或等于 N 的最大的整数，同时这个整数需要满足其各个位数上的数字是单调递增。
 * 
 * （当且仅当每个相邻位数上的数字 x 和 y 满足 x <= y 时，我们称这个整数是单调递增的。）
 * 
 * 示例 1:
 * 
 * 输入: N = 10
 * 输出: 9
 * 
 * 
 * 示例 2:
 * 
 * 输入: N = 1234
 * 输出: 1234
 * 
 * 
 * 示例 3:
 * 
 * 输入: N = 332
 * 输出: 299
 * 
 * 
 * 说明: N 是在 [0, 10^9] 范围内的一个整数。
 * 
 */

// @lc code=start
public class Solution {
    public int MonotoneIncreasingDigits(int N) {
        if(N < 10) return N;
        string numStr = N.ToString();
        char[] nums = numStr.ToCharArray();
        int len = nums.Length;
        int minVal = nums[len - 1];
        int mark = -1;
        for (int i = len - 2;i>=0;i--) {
            int val = nums[i];
            if (val <= minVal) minVal = val;
            else {
                mark = i;
                minVal = val - 1;
            }
        }
        if(mark != -1) {
            nums[mark]--;
            for (int i = mark + 1;i<len ;i++) {
                nums[i] = '9';
            }
        }
        return int.Parse(new string(nums));
    }
}
// @lc code=end

