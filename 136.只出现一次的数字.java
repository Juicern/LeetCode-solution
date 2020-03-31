import java.util.*;

/*
 * @lc app=leetcode.cn id=136 lang=java
 *
 * [136] 只出现一次的数字
 */

// @lc code=start
class Solution {
    public int singleNumber(int[] nums) {
        Map<Integer ,Integer> m = new HashMap<>();
        int n = nums.length;
        for(int i=0;i<n;i++){
            if(m.containsKey(nums[i])){
                m.replace(nums[i], m.get(nums[i])+1);
            }
            else{
                m.put(nums[i], 1);
            }
        }
        int ans = 0;
        for(int i=0;i<n;i++){
            if(m.get(nums[i])==1){
                ans = nums[i];
                break;
            }
        }
        return ans;
    }
}
// @lc code=end

