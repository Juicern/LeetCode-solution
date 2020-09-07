/*
 * @lc app=leetcode.cn id=264 lang=java
 *
 * [264] 丑数 II
 *
 * https://leetcode-cn.com/problems/ugly-number-ii/description/
 *
 * algorithms
 * Medium (48.82%)
 * Likes:    252
 * Dislikes: 0
 * Total Accepted:    21.8K
 * Total Submissions: 42.8K
 * Testcase Example:  '10'
 *
 * 编写一个程序，找出第 n 个丑数。
 * 
 * 丑数就是只包含质因数 2, 3, 5 的正整数。
 * 
 * 示例:
 * 
 * 输入: n = 10
 * 输出: 12
 * 解释: 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 是前 10 个丑数。
 * 
 * 说明:  
 * 
 * 
 * 1 是丑数。
 * n 不超过1690。
 * 
 * 
 */

// @lc code=start
class Solution {
    public int nthUglyNumber(int n) {
        int[] nums = new int[n];
        int ugly;
        nums[0] = 1;
        int i2=0, i3=0, i5=0;
        for(int i=1;i<n;i++){
            ugly = Math.min(nums[i2]*2, Math.min(nums[i3]*3, nums[i5]*5));
            nums[i] = ugly;
            if(ugly==nums[i2]*2) i2++;
            if(ugly==nums[i3]*3) i3++;
            if(ugly==nums[i5]*5) i5++;
        }
        return nums[n-1];
    }
}
// @lc code=end

