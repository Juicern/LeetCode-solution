/*
 * @lc app=leetcode.cn id=912 lang=csharp
 *
 * [912] 排序数组
 *
 * https://leetcode-cn.com/problems/sort-an-array/description/
 *
 * algorithms
 * Medium (59.37%)
 * Likes:    131
 * Dislikes: 0
 * Total Accepted:    64.3K
 * Total Submissions: 108.3K
 * Testcase Example:  '[5,2,3,1]'
 *
 * 给你一个整数数组 nums，请你将该数组升序排列。
 * 
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：nums = [5,2,3,1]
 * 输出：[1,2,3,5]
 * 
 * 
 * 示例 2：
 * 
 * 输入：nums = [5,1,1,2,0,0]
 * 输出：[0,0,1,1,2,5]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= nums.length <= 50000
 * -50000 <= nums[i] <= 50000
 * 
 * 
 */

// @lc code=start
public class Solution
{
    private void QuickSort(int[] nums, int start, int end)
    {
        if (start >= end) return;
        int i = start;
        int j = end;
        int key = nums[start];
        while (i < j)
        {
            while (nums[j] >= key && j > i) j--;
            nums[i] = nums[j];
            while (nums[i] <= key && i < j) i++;
            nums[j] = nums[i];
        }
        nums[i] = key;
        QuickSort(nums, start, i - 1);
        QuickSort(nums, i + 1, end);
    }
    public int[] SortArray(int[] nums)
    {
        QuickSort(nums, 0, nums.Length - 1);
        return nums;
    }
}
// @lc code=end

