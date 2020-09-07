/*
 * @lc app=leetcode.cn id=229 lang=java
 *
 * [229] 求众数 II
 *
 * https://leetcode-cn.com/problems/majority-element-ii/description/
 *
 * algorithms
 * Medium (42.48%)
 * Likes:    168
 * Dislikes: 0
 * Total Accepted:    13.5K
 * Total Submissions: 31.5K
 * Testcase Example:  '[3,2,3]'
 *
 * 给定一个大小为 n 的数组，找出其中所有出现超过 ⌊ n/3 ⌋ 次的元素。
 * 
 * 说明: 要求算法的时间复杂度为 O(n)，空间复杂度为 O(1)。
 * 
 * 示例 1:
 * 
 * 输入: [3,2,3]
 * 输出: [3]
 * 
 * 示例 2:
 * 
 * 输入: [1,1,1,3,3,2,2,2]
 * 输出: [1,2]
 * 
 */

// @lc code=start
class Solution {
    public List<Integer> majorityElement(int[] nums) {
        List<Integer> ans = new ArrayList<>();
        if(nums.length==0) return ans;
        int[] t1 = new int[2];
        int[] t2 = new int[2];
        t1[0] = nums[0];
        t2[0] = nums[0];
        t1[1] = 0;
        t1[1] = 0;
        for(int i=0;i<nums.length;i++){
            if(nums[i]==t1[0]){
                t1[1]++;
            }
            else if(nums[i]==t2[0]){
                t2[1]++;
            }
            else{
                t1[1]--;
                t2[1]--;
                if(t1[1]<0){
                    t1[0] = nums[i];
                    t1[1] = 1;
                    t2[1]++;
                }
                else if(t2[1]<0){
                    t2[0] = nums[i];
                    t2[1] = 1;
                    t1[1]++;
                }
            }
        }
        int count1 = 0;
        int count2 = 0;
        for(int i=0;i<nums.length;i++){
            if(nums[i]==t1[0]) count1++;
            else if(nums[i]==t2[0]) count2++;
        }
        if(count1>nums.length/3) ans.add(t1[0]);
        if(count2>nums.length/3) ans.add(t2[0]);
        return ans;
    }
}
// @lc code=end

