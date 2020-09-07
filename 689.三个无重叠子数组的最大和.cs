/*
 * @lc app=leetcode.cn id=689 lang=csharp
 *
 * [689] 三个无重叠子数组的最大和
 *
 * https://leetcode-cn.com/problems/maximum-sum-of-3-non-overlapping-subarrays/description/
 *
 * algorithms
 * Hard (45.32%)
 * Likes:    48
 * Dislikes: 0
 * Total Accepted:    1.3K
 * Total Submissions: 2.9K
 * Testcase Example:  '[1,2,1,2,6,7,5,1]\n2'
 *
 * 给定数组 nums 由正整数组成，找到三个互不重叠的子数组的最大和。
 * 
 * 每个子数组的长度为k，我们要使这3*k个项的和最大化。
 * 
 * 返回每个区间起始索引的列表（索引从 0 开始）。如果有多个结果，返回字典序最小的一个。
 * 
 * 示例:
 * 
 * 
 * 输入: [1,2,1,2,6,7,5,1], 2
 * 输出: [0, 3, 5]
 * 解释: 子数组 [1, 2], [2, 6], [7, 5] 对应的起始索引为 [0, 3, 5]。
 * 我们也可以取 [2, 1], 但是结果 [1, 3, 5] 在字典序上更大。
 * 
 * 
 * 注意:
 * 
 * 
 * nums.length的范围在[1, 20000]之间。
 * nums[i]的范围在[1, 65535]之间。
 * k的范围在[1, floor(nums.length / 3)]之间。
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        int len = nums.Length;
        int[,] dp = new int[len + 1, 4];
        int[,,] index = new int[len + 1, 4, 3];
        int[] sum = new int[len];
        sum[0] = nums[0];
        for (int i = 1; i < len; i++) sum[i] = sum[i - 1] + nums[i];
        for (int i = len - k; i >= 0; i--)
        {
            int l = (len - i) / k;
            int num = sum[i + k - 1] - sum[i] + nums[i];
            if (l >= 1)
            {
                if (num >= dp[i + 1, 1])
                {
                    index[i, 1, 0] = i;
                    dp[i, 1] = num;
                }
                else
                {
                    index[i, 1, 0] = index[i+1, 1, 0];
                    dp[i, 1] = dp[i + 1, 1];
                }
            }
            if (l >= 2)
            {
                if (num + dp[i + k, 1] >= dp[i + 1, 2])
                {
                    index[i, 2, 0] = i;
                    index[i, 2, 1] = index[i + k, 1, 0];
                    dp[i, 2] = num + dp[i + k, 1];
                }
                else
                {
                    index[i, 2, 0] = index[i + 1, 2, 0];
                    index[i, 2, 1] = index[i + 1, 2, 1];
                    dp[i, 2] = dp[i + 1, 2];
                }
            }
            if (l >= 3)
            {
                if (num + dp[i + k, 2] >= dp[i + 1, 3])
                {
                    index[i, 3, 0] = i;
                    index[i, 3, 1] = index[i + k, 2, 0];
                    index[i, 3, 2] = index[i + k, 2, 1];
                    dp[i, 3] = num + dp[i + k, 2];
                }
                else
                {
                    index[i, 3, 0] = index[i + 1, 3, 0];
                    index[i, 3, 1] = index[i + 1, 3, 1];
                    index[i, 3, 2] = index[i + 1, 3, 2];
                    dp[i, 3] = dp[i + 1, 3];
                }
            }
        }
        //index是三维数组
        //return index[0,3];
        int[] ans = new int[3];
        for(int i = 0; i< 3;i++) ans[i] = index[0, 3, i];
        return ans;
    }
}
// @lc code=end

