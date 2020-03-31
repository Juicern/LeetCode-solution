/*
 * @lc app=leetcode.cn id=88 lang=java
 *
 * [88] 合并两个有序数组
 *
 * https://leetcode-cn.com/problems/merge-sorted-array/description/
 *
 * algorithms
 * Easy (46.28%)
 * Likes:    444
 * Dislikes: 0
 * Total Accepted:    120.9K
 * Total Submissions: 257.5K
 * Testcase Example:  '[1,2,3,0,0,0]\n3\n[2,5,6]\n3'
 *
 * 给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 num1 成为一个有序数组。
 * 
 * 
 * 
 * 说明:
 * 
 * 
 * 初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。
 * 你可以假设 nums1 有足够的空间（空间大小大于或等于 m + n）来保存 nums2 中的元素。
 * 
 * 
 * 
 * 
 * 示例:
 * 
 * 输入:
 * nums1 = [1,2,3,0,0,0], m = 3
 * nums2 = [2,5,6],       n = 3
 * 
 * 输出: [1,2,2,3,5,6]
 * 
 */

// @lc code=start
class Solution {
    public void merge(int[] nums1, int m, int[] nums2, int n) {
        // two get pointers for nums1 and nums2
        int p1 = m - 1;
        int p2 = n - 1;
        // set pointer for nums1
        int p = m + n - 1;
    
        // while there are still elements to compare
        while ((p1 >= 0) && (p2 >= 0))
            // compare two elements from nums1 and nums2 
            // and add the largest one in nums1 
            nums1[p--] = (nums1[p1] < nums2[p2]) ? nums2[p2--] : nums1[p1--];
    
        // add missing elements from nums2
        System.arraycopy(nums2, 0, nums1, 0, p2 + 1);
    }
}
/*
class Solution {
    public static int[] nums1;
    public static int[] nums2;
    public static int start = 0;
    public void insert(int target, int length){
        int left = start;
        int right = length;
        int mid = (left+right)/2;
        //找到插入的位置(前插)
        while(left < right){
            if(nums1[mid] < target) left = mid+1;
            else if(nums1[mid] > target) right = mid;
            else break;
            mid = (left+right)/2;
        }
        //插入
        for(int i=length-1;i>=mid;i--) nums1[i+1] = nums1[i];
        nums1[mid] = target;
        start = mid+1;
        return;
    }
    public void merge(int[] nums1, int m, int[] nums2, int n) {
        this.nums1 = nums1;
        this.nums2 = nums2;
        for(int i=0;i<n;i++){
            insert(nums2[i],m+i);
        }
        return;
    }
}
*/
// @lc code=end

