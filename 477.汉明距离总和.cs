/*
 * @lc app=leetcode.cn id=477 lang=csharp
 *
 * [477] 汉明距离总和
 *
 * https://leetcode-cn.com/problems/total-hamming-distance/description/
 *
 * algorithms
 * Medium (51.56%)
 * Likes:    108
 * Dislikes: 0
 * Total Accepted:    7.8K
 * Total Submissions: 15.1K
 * Testcase Example:  '[4,14,2]'
 *
 * 两个整数的 汉明距离 指的是这两个数字的二进制数对应位不同的数量。
 * 
 * 计算一个数组中，任意两个数之间汉明距离的总和。
 * 
 * 示例:
 * 
 * 
 * 输入: 4, 14, 2
 * 
 * 输出: 6
 * 
 * 解释: 在二进制表示中，4表示为0100，14表示为1110，2表示为0010。（这样表示是为了体现后四位之间关系）
 * 所以答案为：
 * HammingDistance(4, 14) + HammingDistance(4, 2) + HammingDistance(14, 2) = 2
 * + 2 + 2 = 6.
 * 
 * 
 * 注意:
 * 
 * 
 * 数组中元素的范围为从 0到 10^9。
 * 数组的长度不超过 10^4。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public int TotalHammingDistance(int[] nums) {
        int ans = 0;
        int n = nums.Length;
        var count = new int[32];
        foreach(var num in nums) {
            int i = 0;
            int temp = num;
            while(temp > 0) {
                count[i] += (temp & 1);
                i++;
                temp>>=1;
            }
        }
        foreach(var num in count) {
            ans += num * (n - num);
        }
        return ans;
    }
}
// @lc code=end

