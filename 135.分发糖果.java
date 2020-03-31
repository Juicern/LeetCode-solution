/*
 * @lc app=leetcode.cn id=135 lang=java
 *
 * [135] 分发糖果
 */

// @lc code=start
class Solution {
    public int candy(int[] ratings) {
        int n = ratings.length;
        int[] nums = new int[n];
        for(int i=0;i<n;i++) nums[i] = 1;
        for(int i=1;i<n;i++){
            if(ratings[i]>ratings[i-1] && nums[i]<=nums[i-1]) nums[i] = nums[i-1] + 1;
        }
        for(int i=n-1;i>0;i--){
            if(ratings[i-1]>ratings[i] && nums[i-1]<=nums[i]) nums[i-1] = nums[i] + 1;
        }
        int sum = 0;
        for(int i=0;i<n;i++) sum += nums[i];
        return sum;
    }
}
// @lc code=end

