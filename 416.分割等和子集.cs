/*
 * @lc app=leetcode.cn id=416 lang=csharp
 *
 * [416] 分割等和子集
 *
 * https://leetcode-cn.com/problems/partition-equal-subset-sum/description/
 *
 * algorithms
 * Medium (48.69%)
 * Likes:    350
 * Dislikes: 0
 * Total Accepted:    45.7K
 * Total Submissions: 93.8K
 * Testcase Example:  '[1,5,11,5]'
 *
 * 给定一个只包含正整数的非空数组。是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。
 * 
 * 注意:
 * 
 * 
 * 每个数组中的元素不会超过 100
 * 数组的大小不会超过 200
 * 
 * 
 * 示例 1:
 * 
 * 输入: [1, 5, 11, 5]
 * 
 * 输出: true
 * 
 * 解释: 数组可以分割成 [1, 5, 5] 和 [11].
 * 
 * 
 * 
 * 
 * 示例 2:
 * 
 * 输入: [1, 2, 3, 5]
 * 
 * 输出: false
 * 
 * 解释: 数组不能分割成两个元素和相等的子集.
 * 
 * 
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int sum = nums.Sum();
        if (sum % 2 != 0) return false;
        int n = nums.Length;
        int target = sum / 2;
        var dp = new bool[target + 1];
        dp[0] = true;
        if (nums[0] <= target) dp[nums[0]] = true;
        for (int i = 1; i < n; i++)
        {
            for (int j = target; nums[i] <= j; j--)
            {    
                dp[j] |= dp[j - nums[i]];
            }
            if(dp[target]) return true;
        }
        return dp[target];
    }
}
// @lc code=end

