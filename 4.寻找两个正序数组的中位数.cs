using System;
/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 *
 * https://leetcode-cn.com/problems/median-of-two-sorted-arrays/description/
 *
 * algorithms
 * Hard (38.69%)
 * Likes:    3218
 * Dislikes: 0
 * Total Accepted:    262K
 * Total Submissions: 675.7K
 * Testcase Example:  '[1,3]\n[2]'
 *
 * 给定两个大小为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。
 * 
 * 请你找出这两个正序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。
 * 
 * 你可以假设 nums1 和 nums2 不会同时为空。
 * 
 * 
 * 
 * 示例 1:
 * 
 * nums1 = [1, 3]
 * nums2 = [2]
 * 
 * 则中位数是 2.0
 * 
 * 
 * 示例 2:
 * 
 * nums1 = [1, 2]
 * nums2 = [3, 4]
 * 
 * 则中位数是 (2 + 3)/2 = 2.5
 * 
 * 
 */

// @lc code=start
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        if (m > n) return FindMedianSortedArrays(nums2, nums1);
        int iMin = 0;
        int iMax = m;
        while (iMin <= iMax)
        {
            int i = (iMin + iMax) / 2;
            int j = (m + n + 1) / 2 - i;
            if (i != 0 && j != n && nums1[i - 1] > nums2[j])
            {
                iMax = i - 1;
            }
            else if (j != 0 && i != m && nums2[j - 1] > nums1[i])
            {
                iMin = i + 1;
            }
            else
            {
                int left = 0;
                if (i == 0)
                {
                    left = nums2[j - 1];
                }
                else if (j == 0)
                {
                    left = nums1[i - 1];
                }
                else left = Math.Max(nums1[i - 1], nums2[j - 1]);
                if ((m + n) % 2 == 1) return left;
                int right = 0;
                if (i == m)
                {
                    right = nums2[j];
                }
                else if (j == n)
                {
                    right = nums1[i];
                }
                else right = Math.Min(nums1[i], nums2[j]);
                return (left + right) / 2.0;
            }
        }
        return 0;
    }
}
// @lc code=end

