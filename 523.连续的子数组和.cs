using System.Reflection.Emit;
/*
 * @lc app=leetcode.cn id=523 lang=csharp
 *
 * [523] 连续的子数组和
 *
 * https://leetcode-cn.com/problems/continuous-subarray-sum/description/
 *
 * algorithms
 * Medium (22.30%)
 * Likes:    141
 * Dislikes: 0
 * Total Accepted:    19.3K
 * Total Submissions: 86.5K
 * Testcase Example:  '[23,2,4,6,7]\n6'
 *
 * 给定一个包含 非负数 的数组和一个目标 整数 k，编写一个函数来判断该数组是否含有连续的子数组，其大小至少为 2，且总和为 k 的倍数，即总和为
 * n*k，其中 n 也是一个整数。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：[23,2,4,6,7], k = 6
 * 输出：True
 * 解释：[2,4] 是一个大小为 2 的子数组，并且和为 6。
 * 
 * 
 * 示例 2：
 * 
 * 输入：[23,2,6,4,7], k = 6
 * 输出：True
 * 解释：[23,2,6,4,7]是大小为 5 的子数组，并且和为 42。
 * 
 * 
 * 
 * 
 * 说明：
 * 
 * 
 * 数组的长度不会超过 10,000 。
 * 你可以认为所有数字总和在 32 位有符号整数范围内。
 * 
 * 
 */

// @lc code=start
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        int  n = nums.Length;
        var sum = new int[n];
        sum[0] = nums[0];
        for(int i=  1;i<n;i++) {
            sum[i] = sum[i - 1] + nums[i];
            if(k!= 0 && sum[i] % k == 0) return true;
            if(k == 0 && sum[i] == 0) return true;
        }
        for(int i =0;i<n;i++) {
            for(int j = i +2;j<n;j++) {
                if(k!= 0 && (sum[j] - sum[i]) % k == 0) return true;
                if(k== 0 && sum[j] - sum[i] == 0) return true; 
            }
        }
        return false;
    }
}
// @lc code=end

